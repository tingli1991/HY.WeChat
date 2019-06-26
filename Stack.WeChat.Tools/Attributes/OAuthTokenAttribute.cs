/**************************************************************************
*   
*   =======================================================================
*   CLR 版本    ：4.0.30319.42000
*   命名空间    ：Stack.WeChat.Tools.Attributes
*   文件名称    ：OAuth2Attribute.cs
*   =======================================================================
*   创 建 者    ：李廷礼
*   创建日期    ：2019/6/26 18:07:16 
*   邮    箱    ：litingxian@live.cn
*   个人主站    ：https://github.com/tingli1991
*   功能描述    ：
*   使用说明    ：
*   ========================================================================
*   修改者      ：
*   修改日期    ：
*   修改内容    ：
*   ========================================================================
*  
***************************************************************************/


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Stack.WeChat.DataContract.Enums;
using Stack.WeChat.DataContract.Result;
using Stack.WeChat.Tools.Config;
using Stack.WeChat.Tools.Controllers;
using Stack.WeChat.Tools.Helper;
using Stack.WeChat.Tools.Result;
using System;
using System.Web;

namespace Stack.WeChat.Tools.Attributes
{
    /// <summary>
    /// 用户网页认证授权
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
            ContractResult result = new ContractResult();
            WeChatSettingsConfig appSettings = WeChatSettings.GetConfig();
            if (appSettings == null)
            {
                result.SetError(MessageType.Fail);
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