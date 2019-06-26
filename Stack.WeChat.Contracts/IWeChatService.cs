using Stack.WeChat.Contracts.Result;
using Stack.WeChat.DataContract.Result;

namespace Stack.WeChat.Contracts
{
    /// <summary>
    /// 微信服务
    /// </summary>
    public interface IWeChatService
    {
        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="pageUrl">h5页面地址</param>
        /// <returns></returns>
        ContractResult<WeChatSignatureResult> GetJsApiTicket(string pageUrl);
    }
}