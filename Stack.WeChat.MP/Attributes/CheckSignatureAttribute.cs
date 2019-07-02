using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Stack.WeChat.DataContract.Config;
using Stack.WeChat.DataContract.Enums;
using Stack.WeChat.DataContract.Result;
using Stack.WeChat.Log4Net;
using Stack.WeChat.MP.Controllers;
using Stack.WeChat.MP.Security;
using System;

namespace Stack.WeChat.MP.Attributes
{
    /// <summary>
    ///  微信签名校验
    /// </summary>
    public class CheckSignatureAttribute : Attribute, IActionFilter
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        private static readonly ILog _log = Log4netUtil.GetLogger<CheckSignatureAttribute>();

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
            var query = context.HttpContext.Request.Query;
            string nonce = query["nonce"];//随机数
            string timestamp = query["timestamp"];//时间戳
            string signature = query["signature"];//微信加密签名，signature结合了开发者填写的token参数和请求中的timestamp参数、nonce参数
            string openId = query.ContainsKey("openid") ? $"{query["openid"]}" : "";//用户的标识，对当前公众号唯一
            string echostr = query.ContainsKey("echostr") ? $"{query["echostr"]}" : "";//随机字符串
            WeChatAccount account = ((BaseController)context.Controller).Account;//微信账户信息配置
            if (!SignatureVerifyUtil.CheckSignature(signature, timestamp, nonce, account.Token))
            {
                ContractResult result = new ContractResult();
                result.SetError(ErrorCodeType.CheckSignFail);
                context.Result = new JsonResult(result);
                _log.Debug($"【微信签名校验】请求参数=》signature：{signature}，timestamp：{timestamp}，nonce：{nonce}，echostr：{echostr}，appid：{account.AppId}，openid：{openId}");
                return;
            }

            if (context.HttpContext.Request.Method.Equals("GET", StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(echostr))
            {
                ContentResult result = new ContentResult() { Content = echostr };
                context.Result = result;
                return;
            }
        }
    }
}