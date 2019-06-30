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
            if (string.IsNullOrWhiteSpace(appIdKey))
            {
                result.SetError(MessageType.NoAppId);
                context.Result = new JsonResult(result);
                _log.Debug($"【全局配置过滤器】请求参数：{JsonConvert.SerializeObject(query)}");
                return;
            }

            var baseController = ((Controllers.BaseController)context.Controller);
            baseController.AppId = query[appIdKey];//AppId
            baseController.Account = WeChatSettingsUtil.GetAccountConfig(baseController.AppId);
            if (baseController.Account == null)
            {
                result.SetError(MessageType.ConfigErr);
                context.Result = new JsonResult(result);
                _log.Debug($"【全局配置过滤器】请求参数：{JsonConvert.SerializeObject(query)}");
                return;
            }
        }
    }
}