using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Stack.WeChat.Contracts.Result;
using Stack.WeChat.DataContract.Config;
using Stack.WeChat.DataContract.Enums;
using Stack.WeChat.DataContract.Result;
using Stack.WeChat.MP.Config;
using Stack.WeChat.Utils.Helper;
using Stack.WeChat.WebAPI.Controllers;
using System;
using System.Linq;

namespace Stack.WeChat.WebAPI.Attributes
{
    /// <summary>
    ///  用户网页认证授权
    /// </summary>
    public class OAuthTokenAttribute : Attribute, IActionFilter
    {
        /// <summary>
        /// action调用结束后不做任何处理
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        /// <summary>
        /// 在Action执行之前调用
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            ContractResult result = new ContractResult();
            var baseController = ((OAuthController)context.Controller);
            if (baseController.UserTicket != null)
            {
                baseController.UserTicket = RefreshToken(baseController.UserTicket, baseController.Account);
                return;
            }

            string codeKey = context.HttpContext.Request.Query.Keys.FirstOrDefault(key => key.ToLower() == "code");
            if (!string.IsNullOrEmpty(codeKey))
            {
                string code = context.HttpContext.Request.Query[codeKey];
                string oAuthTokenUrl = WeChatSettingsUtil.Settings.OAuthTokenUrl;
                string apiUrl = $"{oAuthTokenUrl}?appid={baseController.Account.AppId}&secret={baseController.Account.SecretKey}&code={code}&grant_type=authorization_code";
                baseController.UserTicket = HttpClientUtil.GetResponse<OAuthTokenResult>(apiUrl);
            }
            else
            {
                string authorizeUrl = WeChatSettingsUtil.Settings.AuthorizeUrl;
                string urlKey = context.HttpContext.Request.Query.Keys.FirstOrDefault(key => key.ToLower() == "url");
                if (string.IsNullOrEmpty(urlKey))
                {
                    result.SetError(MessageType.InvalidUrl);
                    context.Result = new JsonResult(result);
                    return;
                }

                string redirect_uri = context.HttpContext.Request.Query[urlKey];
                string location = $"{authorizeUrl}?appid={baseController.Account.AppId}&redirect_uri={redirect_uri}&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect";
                context.Result = new RedirectResult(location);//302重定向跳转
            }
        }

        /// <summary>
        /// 刷新token
        /// </summary>
        /// <param name="userTicket">用户票据</param>
        /// <param name="account"></param>
        /// <returns></returns>
        private OAuthTokenResult RefreshToken(OAuthTokenResult userTicket, WeChatAccount account)
        {
            if (userTicket.UpdateTime.AddSeconds(userTicket.ExpireSeconds) > DateTime.Now)
                return userTicket;//还没过期直接返回

            string oAuthRefreshTokenUrl = WeChatSettingsUtil.Settings.OAuthRefreshTokenUrl;
            string apiUrl = $"{oAuthRefreshTokenUrl}?appid={account.AppId}&grant_type=refresh_token&refresh_token={userTicket.RefreshToken}";
            return HttpClientUtil.GetResponse<OAuthTokenResult>(apiUrl);
        }
    }
}