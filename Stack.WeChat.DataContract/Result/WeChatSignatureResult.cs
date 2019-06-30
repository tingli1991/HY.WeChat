namespace Stack.WeChat.DataContract.Result
{
    /// <summary>
    /// 微信JsSDK签名配置
    /// </summary>
    public class WeChatSignatureResult
    {
        /// <summary>
        /// AppId
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 必填，生成签名的时间戳
        /// 备注：以秒为单位的时间戳
        /// </summary>
        public long Timestamp { get; set; }

        /// <summary>
        /// 必填，生成签名的随机串
        /// </summary>
        public string NonceStr { get; set; }

        /// <summary>
        /// 签名字符串
        /// </summary>
        public string Signature { get; set; }
    }
}