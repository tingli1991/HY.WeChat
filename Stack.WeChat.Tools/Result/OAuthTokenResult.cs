/**************************************************************************
*   
*   =======================================================================
*   CLR 版本    ：4.0.30319.42000
*   命名空间    ：Stack.WeChat.Tools.Result
*   文件名称    ：OAuthTokenResult.cs
*   =======================================================================
*   创 建 者    ：李廷礼
*   创建日期    ：2019/6/26 18:16:05 
*   邮    箱    ：litingxian@live.cn
*   个人主站    ：https://github.com/tingli1991
*   功能描述    ：
*   使用说明    ：
*   ========================================================================
*   修改者      ：
*   修改日期    ：
*   修改内容    ：
*   ========================================================================
*  
***************************************************************************/

using Newtonsoft.Json;
using System;

namespace Stack.WeChat.Tools.Result
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