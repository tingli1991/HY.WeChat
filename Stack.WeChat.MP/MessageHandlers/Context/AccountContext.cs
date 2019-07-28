using Stack.WeChat.DataContract.Config;
using Stack.WeChat.DataContract.MessageHandlers;
using System.Collections.Generic;

namespace Stack.WeChat.MP.MessageHandlers
{
    /// <summary>
    /// 消息上下文
    /// </summary>
    public class AccountContext : IAccountContext
    {
        /// <summary>
        /// 公众号Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 微信账户配置信息
        /// </summary>
        public WeChatAccount Account { get; set; }
    }
}