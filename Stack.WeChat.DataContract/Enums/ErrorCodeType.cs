using System.ComponentModel;

namespace Stack.WeChat.DataContract.Enums
{
    /// <summary>
    /// 错误消息类型定义枚举
    /// </summary>
    public enum ErrorCodeType
    {
        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        [Description("未知OpenId！")]
        NoOpenId = -5,

        /// <summary>
        /// 无效的Url地址
        /// </summary>
        [Description("无效的Url地址！")]
        InvalidUrl = -4,

        /// <summary>
        /// 配置错误
        /// </summary>
        [Description("配置错误！")]
        ConfigErr = -3,

        /// <summary>
        /// 公众号Id
        /// </summary>
        [Description("未知AppId！")]
        NoAppId = -2,

        /// <summary>
        /// 微信服务器验证签名失败
        /// </summary>
        [Description("签名校验失败！")]
        CheckSignFail = -1,

        /// <summary>
        /// 业务处理失败
        /// </summary>
        [Description("处理失败！")]
        Fail = 0,

        /// <summary>
        /// 业务处理成功
        /// </summary>
        [Description("处理成功！")]
        Success = 100,

        /// <summary>
        /// 服务器异常
        /// </summary>
        [Description("服务器异常，请联系客服！")]
        Exception = 500
    }
}