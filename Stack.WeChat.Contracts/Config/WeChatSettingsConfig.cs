namespace Stack.WeChat.Contracts.Config
{
    /// <summary>
    /// 微信配置信息
    /// </summary>
    public class WeChatSettingsConfig
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
        /// 获取网页授权的token
        /// </summary>
        public string OAuthTokenUrl { get; set; }

        /// <summary>
        /// 刷新网页授权token
        /// </summary>
        public string OAuthRefreshTokenUrl { get; set; }

        /// <summary>
        /// 普通授权接口地址
        /// </summary>
        public string AccessTokenUrl { get; set; }

        /// <summary>
        /// JSAPITicket接口地址
        /// </summary>
        public string JSAPITicketApiUrl { get; set; }
    }
}