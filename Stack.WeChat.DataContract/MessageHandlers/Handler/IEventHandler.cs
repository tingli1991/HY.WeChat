using Stack.WeChat.DataContract.Enums;

namespace Stack.WeChat.DataContract.MessageHandlers.Handler
{
    /// <summary>
    /// 事件消息处理接口
    /// </summary>
    public interface IEventMessageHandler : IHandler
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        EventType EventType { get; }
    }
}