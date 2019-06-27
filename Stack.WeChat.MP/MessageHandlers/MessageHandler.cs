/**************************************************************************
*   
*   =======================================================================
*   CLR 版本    ：4.0.30319.42000
*   命名空间    ：Stack.WeChat.MP.MessageHandlers
*   文件名称    ：MessageHandler.cs
*   =======================================================================
*   创 建 者    ：李廷礼
*   创建日期    ：2019/6/27 14:20:03 
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


using Stack.WeChat.DataContract.MessageHandlers;
using System.IO;
using System.Xml.Linq;

namespace Stack.WeChat.MP.MessageHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TC"></typeparam>
    public abstract class MessageHandler<TC> : MessageHandler<TC, IRequestMessageBase, IResponseMessageBase>, IMessageHandler, IMessageHandler<IRequestMessageBase, IResponseMessageBase>, IMessageHandlerDocument, IMessageHandlerBase where TC : class
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="inputStream">微信传入的文件流</param>
        public MessageHandler(Stream inputStream) : base(inputStream)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="requestDocument">微信传入的Xml文档</param>
        public MessageHandler(XDocument requestDocument) : base(requestDocument)
        {

        }
    }
}