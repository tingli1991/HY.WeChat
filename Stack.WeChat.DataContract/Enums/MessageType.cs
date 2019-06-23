using System.ComponentModel;

namespace Stack.WeChat.DataContract.Enums
{
    /// <summary>
    /// 错误消息类型定义枚举
    /// </summary>
    public enum MessageType
    {
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
        [Description("服务器异常，请联系客服")]
        Exception = 500
    }
}