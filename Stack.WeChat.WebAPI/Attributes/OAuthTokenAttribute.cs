using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Stack.WeChat.Contracts.Config;
using Stack.WeChat.Contracts.Result;
using Stack.WeChat.Utils.Config;
using Stack.WeChat.Utils.Helper;
using Stack.WeChat.WebAPI.Controllers;
using System;
using System.Web;

namespace Stack.WeChat.WebAPI.Attributes
{
    /// <summary>
    ///  用户网页认证授权
    /// </summary>
    public class OAuthTokenAttribute : Attribute, IActionFilter
    {
        /// <summary>
        /// 在Action执行之前调用
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            ResponseResult result = new ResponseResult();
            WeChatSettingsConfig appSettings = AppSettings.GetValue<WeChatSettingsConfig>("WeChatSettings");
            if (appSettings == null)
            {
                result.ErrorCode = "100000";
                result.ErrorMessage = "微信配置异常";
                context.Result = new ContentResult()
                {
                    StatusCode = 200,
                    Content = JsonConvert.SerializeObject(result)
                };
                return;
            }

            var baseController = ((BaseController)context.Controller);
            if (baseController.UserTicket != null)
            {
                baseController.UserTicket = RefreshToken(baseController.UserTicket, appSettings);
                return;
            }

            if (!context.ActionArguments.ContainsKey("code"))
            {
                string redirect_uri = HttpUtility.UrlEncode($"{context.ActionArguments["html5"]}");
                string location = $"{appSettings.AuthorizeUrl}?appid={appSettings.AppId}&redirect_uri={redirect_uri}&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect";
                context.Result = new RedirectResult(location);//302重定向跳转
                return;
            }

            string code = $"{context.ActionArguments["code"]}";
            string apiUrl = $"{appSettings.OAuthTokenUrl}?appid={appSettings.AppId}&secret={appSettings.SecretKey}&code={code}&grant_type=authorization_code";
            baseController.UserTicket = HttpClientHelper.GetResponse<OAuthTokenResult>(apiUrl);
            string jsonValue = JsonConvert.SerializeObject(baseController.UserTicket);
        }

        /// <summary>
        /// action调用结束后不做任何处理
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        /// <summary>
        /// 刷新token
        /// </summary>
        /// <param name="userTicket">用户票据</param>
        /// <param name="appSettings"></param>
        /// <returns></returns>
        private OAuthTokenResult RefreshToken(OAuthTokenResult userTicket, WeChatSettingsConfig appSettings)
        {
            if (userTicket.UpdateTime.AddSeconds(userTicket.ExpireSeconds) > DateTime.Now)
                return userTicket;//还没过期直接返回

            string apiUrl = $"{appSettings.OAuthRefreshTokenUrl}?appid={appSettings.AppId}&grant_type=refresh_token&refresh_token={userTicket.RefreshToken}";
            return HttpClientHelper.GetResponse<OAuthTokenResult>(apiUrl);
        }
    }
}