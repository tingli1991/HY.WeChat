using Stack.WeChat.DataContract.Enums;
using Stack.WeChat.DataContract.MessageHandlers;

namespace Stack.WeChat.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class ImageMessageHandler : IMessageHandler
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        public MessageType MessageType => MessageType.Image;

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IMessageContext context)
        {

        }
    }
}