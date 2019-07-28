using System.Xml.Linq;

namespace Stack.WeChat.DataContract.MessageHandlers
{
    /// <summary>
    /// 消息内容上下文
    /// </summary>
    public interface IMessageContext
    {
        /// <summary>
        /// 请求的Xml字符串
        /// </summary>
        string RequestXmlString { get; set; }

        /// <summary>
        /// 在构造函数中转换得到原始XML数据
        /// </summary>
        XDocument RequestDocument { get; set; }

        /// <summary>
        /// 请求上下文
        /// </summary>
        IAccountContext Account { get; set; }
    }
}