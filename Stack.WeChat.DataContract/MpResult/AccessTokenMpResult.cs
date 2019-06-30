using Newtonsoft.Json;

namespace Stack.WeChat.DataContract.MpResult
{
    /// <summary>
    /// 微信认证token返回
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AccessTokenMpResult : IMpResult
    {
        /// <summary>
        /// 错误码0表示成功
        /// </summary>
        [JsonProperty("errcode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        [JsonProperty("errmsg")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        [JsonProperty("expires_in")]
        public int Expires_In { get; set; }

        /// <summary>
        /// 登陆的票据
        /// </summary>
        [JsonProperty("access_token")]
        public string Access_Token { get; set; }
    }
}