using Microsoft.AspNetCore.Mvc;
using Stack.WeChat.DataContract.Config;
using Stack.WeChat.DataContract.Enums;
using Stack.WeChat.Utils.Config;
using Stack.WeChat.Utils.Security;

namespace Stack.WeChat.WebAPI.Controllers
{
    /// <summary>
    /// 微信交互出入口控制器
    /// </summary>
    [Route("api/index")]
    public class IndexController : BaseController
    {
        /// <summary>
        /// 验证消息的确来自微信服务器
        /// 开发者提交信息后，微信服务器将发送GET请求到填写的服务器地址URL上，GET请求携带参数如下表所示
        /// </summary>
        /// <param name="signature">微信加密签名，signature结合了开发者填写的token参数和请求中的timestamp参数、nonce参数</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="nonce">随机数</param>
        /// <param name="echostr">随机字符串</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get(string signature, string timestamp, string nonce, string echostr)
        {
            string result = MessageType.Fail.GetDescription();
            WeChatSettingsConfig settings = WeChatSettings.GetConfig();
            if (SignatureVerifyUtil.CheckSignature(signature, timestamp, nonce, echostr, settings.Token))
            {
                result = echostr;
            }
            return Content(result);
        }

        /// <summary>
        /// POST api/index
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post()
        {
            return Content("");
        }
    }
}