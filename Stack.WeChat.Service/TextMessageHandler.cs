using Stack.WeChat.DataContract.Enums;
using Stack.WeChat.DataContract.MessageHandlers;
using Stack.WeChat.DataContract.MessageHandlers.Handler;

namespace Stack.WeChat.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class TextRequestMessageHandler : IMessageHandler
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        public MessageType MessageType => MessageType.Text;

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IMessageContext context)
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TextRequestMessageHandler1 : IMessageHandler
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        public MessageType MessageType => MessageType.Text;

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IMessageContext context)
        {

        }
    }
}