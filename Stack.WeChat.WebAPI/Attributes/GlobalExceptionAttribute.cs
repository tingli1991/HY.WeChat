using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Stack.WeChat.DataContract.Enums;
using Stack.WeChat.DataContract.Result;
using Stack.WeChat.Utils.Log4net;
using System;
using System.Net;

namespace Stack.WeChat.WebAPI.Attributes
{
    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    public class GlobalExceptionAttribute : IExceptionFilter
    {
        /// <summary>
        /// 发生异常时调用
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            Exception ex = context.Exception;
            context.ExceptionHandled = true;
            var result = new ContractResult();
            result.SetError(MessageType.Exception);
            context.Result = new JsonResult(result);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            ILog _log = Log4netUtil.GetLogger<GlobalExceptionAttribute>();
            _log.Error($"【全局异常】发生未经处理的全局异常：{ex}");
        }
    }
}