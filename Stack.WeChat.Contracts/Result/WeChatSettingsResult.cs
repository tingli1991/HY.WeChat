namespace Stack.WeChat.Contracts.Result
{
    /// <summary>
    /// 微信配置信息
    /// </summary>
    public class WeChatSettingsResult
    {
        /// <summary>
        /// AppId
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 密钥
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// 授权地址
        /// </summary>
        public string AuthorizeUrl { get; set; }

        /// <summary>
        /// 刷新网页授权token
        /// </summary>
        public string Refresh_TokenUrl { get; set; }

        /// <summary>
        /// 获取网页授权的token
        /// </summary>
        public string Access_TokenUrl { get; set; }
    }
}