using Newtonsoft.Json;

namespace Stack.WeChat.Contracts.Result
{
    /// <summary>
    /// jsdk票据结果
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class JsApiTicketResult
    {
        /// <summary>
        /// 返回码（0：请求成功）
        /// </summary>
        [JsonProperty("errcode")]
        public int ErrorCode { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonProperty("errmsg")]
        public string ErrorMessage { get; set; }
        /// <summary>
        /// jsapi_ticket
        /// </summary>
        [JsonProperty("ticket")]
        public string Ticket { get; set; }
        /// <summary>
        /// 到期秒数
        /// </summary>
        [JsonProperty("expires_in")]
        public int Expires_In { get; set; }
    }
}