using Newtonsoft.Json;
using System;

namespace Stack.WeChat.Contracts.Result
{
    /// <summary>
    /// 网页授权返回用户信息
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class OAuthTokenResult
    {
        /// <summary>
        /// 网页授权Token
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 到期秒数
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpireSeconds { get; set; }

        /// <summary>
        /// 用来获取新的access_token的刷新密钥
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// 微信用户唯一标识（未关注公众号用户，也会产生一个用户和公众号唯一的OpenID ）
        /// </summary>
        [JsonProperty("openid")]
        public string OpenID { get; set; }

        /// <summary>
        /// 用户授权的作用域，使用逗号（,）分隔 
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        [JsonProperty("errcode")]
        public int ErrorCode { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        [JsonProperty("errmsg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonProperty("mtime")]
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}