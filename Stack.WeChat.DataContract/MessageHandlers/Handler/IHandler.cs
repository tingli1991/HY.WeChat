using Stack.WeChat.DataContract.Enums;

namespace Stack.WeChat.DataContract.MessageHandlers
{
    /// <summary>
    /// 消息处理类
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// 请求的消息类型
        /// </summary>
        MessageType MessageType { get; }

        /// <summary>
        /// 执行微信请处理方法
        /// </summary>
        /// <param name="context"></param>
        void Execute(IMessageContext context);
    }
}