using log4net;
using Microsoft.AspNetCore.Mvc;
using Stack.WeChat.DataContract.Param;
using Stack.WeChat.Log4Net;
using Stack.WeChat.MP.Attributes;
using Stack.WeChat.MP.Controllers;
using Stack.WeChat.MP.Utils;
using System.Linq;
using System.Xml.Linq;

namespace Stack.WeChat.WebAPI.Controllers
{
    /// <summary>
    /// 微信交互出入口控制器
    /// </summary>
    [Route("api/index")]
    public class IndexController : BaseController
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        private static readonly ILog _log = Log4netUtil.GetLogger<IndexController>();

        /// <summary>
        /// 微信消息接口接入入口
        /// </summary>
        /// <param name="param">请求参数</param>
        /// <returns></returns>
        [CheckSignature]
        public ActionResult Action(IndexPostParam param)
        {
            XDocument bodyXml = XmlUtility.Convert(Request.Body);
            XElement msgType = bodyXml.Descendants().FirstOrDefault(e => e.Name == "MsgType");
            _log.Debug($"【微信消息接口接入入口】MsgType：{msgType.Value}，Url入参字符串：{Request.QueryString}，Xml入参字符串：{bodyXml.ToString()}");
            return Content("");
        }
    }
}