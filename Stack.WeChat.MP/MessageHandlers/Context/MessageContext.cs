using Stack.WeChat.DataContract.MessageHandlers;
using System.Xml.Linq;

namespace Stack.WeChat.MP.MessageHandlers
{
    /// <summary>
    /// 请求上下文
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    public class MessageContext : IMessageContext
    {
        /// <summary>
        /// 请求的Xml字符串
        /// </summary>
        public string RequestXmlString { get; set; }

        /// <summary>
        /// 在构造函数中转换得到原始XML数据
        /// </summary>
        public XDocument RequestDocument { get; set; }

        /// <summary>
        /// 基础信息上下文
        /// </summary>
        public IAccountContext Account { get; set; }
    }
}