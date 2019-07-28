using Stack.WeChat.DataContract.Config;
using System.Collections.Generic;

namespace Stack.WeChat.DataContract.MessageHandlers
{
    /// <summary>
    /// 消息内容上下文
    /// </summary>
    public interface IAccountContext
    {
        /// <summary>
        /// 公众号Id
        /// </summary>
        string AppId { get; set; }

        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        string OpenId { get; set; }

        /// <summary>
        /// 微信账户配置信息
        /// </summary>
        WeChatAccount Account { get; set; }
    }
}