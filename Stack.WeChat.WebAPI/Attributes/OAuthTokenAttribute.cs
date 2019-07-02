using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Stack.WeChat.DataContract.Enums;
using Stack.WeChat.DataContract.MpResult;
using Stack.WeChat.DataContract.Result;
using Stack.WeChat.MP.Config;
using Stack.WeChat.MP.Security;
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
            var baseController = ((BaseOAuthController)context.Controller);
            if (baseController.UserTicket != null)
            {
                baseController.UserTicket = AccessTokenUtil.RefreshToken(baseController.Account.AppId, baseController.UserTicket);
                return;
            }

            string codeKey = context.HttpContext.Request.Query.Keys.FirstOrDefault(key => key.ToLower() == "code");
            if (!string.IsNullOrEmpty(codeKey))
            {
                string secretKey = baseController.Account.SecretKey;
                string code = context.HttpContext.Request.Query[codeKey];
                baseController.UserTicket = AccessTokenUtil.GetOAuthToken(baseController.Account.AppId, code, baseController.Account.SecretKey);
            }
            else
            {
                string authorizeUrl = WeChatSettingsUtil.Settings.AuthorizeUrl;
                string urlKey = context.HttpContext.Request.Query.Keys.FirstOrDefault(key => key.ToLower() == "url");
                if (string.IsNullOrEmpty(urlKey))
                {
                    result.SetError(ErrorCodeType.InvalidUrl);
                    context.Result = new JsonResult(result);
                    return;
                }

                string redirect_uri = context.HttpContext.Request.Query[urlKey];
                string location = $"{authorizeUrl}?appid={baseController.Account.AppId}&redirect_uri={redirect_uri}&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect";
                context.Result = new RedirectResult(location);//302重定向跳转
            }
        }
    }
}