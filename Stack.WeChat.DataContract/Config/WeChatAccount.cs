namespace Stack.WeChat.DataContract.Config
{
    /// <summary>
    /// 微信账户信息
    /// </summary>
    public class WeChatAccount
    {
        /// <summary>
        /// AppId
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 开发者密码
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// 消息加解密密钥
        /// </summary>
        public string EncodingAESKey { get; set; }
    }
}