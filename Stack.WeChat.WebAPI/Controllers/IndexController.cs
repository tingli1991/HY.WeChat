using log4net;
using Microsoft.AspNetCore.Mvc;
using Stack.WeChat.DataContract.Param;
using Stack.WeChat.Log4Net;
using Stack.WeChat.MP.Attributes;
using Stack.WeChat.MP.Controllers;
using System.IO;
using System.Text;

namespace Stack.WeChat.WebAPI.Controllers
{
    /// <summary>
    /// 微信交互出入口控制器
    /// </summary>
    [Route("api/index")]
    public class IndexController : MP.Controllers.BaseController
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        private static readonly ILog _log = Log4netUtil.GetLogger<IndexController>();

        /// <summary>
        /// 验证消息的确来自微信服务器
        /// 开发者提交信息后，微信服务器将发送GET请求到填写的服务器地址URL上，GET请求携带参数如下表所示
        /// </summary>
        /// <param name="echostr">随机字符串</param>
        /// <returns></returns>
        [HttpGet, CheckSignature]
        public ActionResult Get(string echostr)
        {
            return Content(echostr);
        }

        /// <summary>
        /// 微信消息接口接入入口
        /// </summary>
        /// <param name="param">请求参数</param>
        /// <returns></returns>
        [HttpPost, CheckSignature]
        public ActionResult Post(IndexPostParam param)
        {
            StreamReader readStream = new StreamReader(Request.Body, Encoding.UTF8);
            string sourceCode = readStream.ReadToEnd();

            //XDocument bodyXml = XmlUtility.Convert(Request.Body);
            _log.Debug($"【微信消息接口接入入口】文件流参数：{sourceCode}");
            return Content("");
        }
    }
}