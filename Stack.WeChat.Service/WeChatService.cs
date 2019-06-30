using Stack.WeChat.Contracts;
using Stack.WeChat.DataContract.Result;
using Stack.WeChat.MP.Security;

namespace Stack.WeChat.Service
{
    /// <summary>
    /// 微信服务
    /// </summary>
    public class WeChatService : BaseService, IWeChatService
    {
        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="secretKey"></param>
        /// <param name="pageUrl">h5页面地址</param>
        /// <returns></returns>
        public ContractResult<WeChatSignatureResult> GetJsApiTicket(string appId, string secretKey, string pageUrl)
        {
            return JsTicketUtil.GetJsApiTicket(appId, secretKey, pageUrl);
        }
    }
}