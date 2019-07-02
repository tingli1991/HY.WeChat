using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Stack.WeChat.DataContract.Enums;
using Stack.WeChat.DataContract.Result;
using Stack.WeChat.Log4Net;
using Stack.WeChat.MP.Config;
using Stack.WeChat.MP.Controllers;
using System;
using System.Linq;

namespace Stack.WeChat.MP.Attributes
{
    /// <summary>
    ///  全局配置过滤器
    /// </summary>
    public class GlobalConfigAttribute : Attribute, IActionFilter
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        private static readonly ILog _log = Log4netUtil.GetLogger<GlobalConfigAttribute>();

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
            IQueryCollection query = context.HttpContext.Request.Query;
            string appIdKey = query.Keys.FirstOrDefault(key => key.ToLower() == "appid");
            string openIdKey = query.Keys.FirstOrDefault(key => key.ToLower() == "openid");
            if (string.IsNullOrWhiteSpace(appIdKey))
            {
                result.SetError(ErrorCodeType.NoAppId);
                context.Result = new JsonResult(result);
                _log.Debug($"【全局配置过滤器】请求参数：{JsonConvert.SerializeObject(query)}");
                return;
            }

            if (string.IsNullOrWhiteSpace(openIdKey))
            {
                result.SetError(ErrorCodeType.NoOpenId);
                context.Result = new JsonResult(result);
                _log.Debug($"【全局配置过滤器】请求参数：{JsonConvert.SerializeObject(query)}");
                return;
            }

            var baseController = ((BaseController)context.Controller);
            baseController.AppId = query[appIdKey];//公众号Id
            baseController.OpenId = query[openIdKey];//用户的标识，对当前公众号唯一
            baseController.Account = WeChatSettingsUtil.GetAccountConfig(baseController.AppId);
            if (baseController.Account == null)
            {
                result.SetError(ErrorCodeType.ConfigErr);
                context.Result = new JsonResult(result);
                _log.Debug($"【全局配置过滤器】请求参数：{JsonConvert.SerializeObject(query)}");
                return;
            }
        }
    }
}