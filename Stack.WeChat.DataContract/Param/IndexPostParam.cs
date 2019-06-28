using Newtonsoft.Json;

namespace Stack.WeChat.DataContract.Param
{
    /// <summary>
    /// 微信出入口请求参数
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class IndexPostParam
    {
        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 微信加密签名，signature结合了开发者填写的token参数和请求中的timestamp参数、nonce参数
        /// </summary>
        [JsonProperty("signature")]
        public string Signature { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; }

        /// <summary>
        /// 随机数
        /// </summary>
        [JsonProperty("nonce")]
        public string Nonce { get; set; }
    }
}