using Microsoft.AspNetCore.Mvc;
using Stack.WeChat.Contracts;
using Stack.WeChat.DataContract.Result;
using Stack.WeChat.MP.Controllers;

namespace Stack.WeChat.WebAPI.Controllers
{
    /// <summary>
    /// 微信接口
    /// </summary>
    [Route("api/wechat")]
    public class WeChatController : BaseController
    {
        /// <summary>
        /// 微信服务
        /// </summary>
        public IWeChatService Service { get; set; }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="pageUrl">h5页面Url</param>
        /// <returns></returns>
        [HttpGet("GetJsApiTicket")]
        public ContractResult<WeChatSignatureResult> GetJsApiTicket(string pageUrl)
        {
            return Service.GetJsApiTicket(Account.AppId, Account.SecretKey, pageUrl);
        }
    }
}