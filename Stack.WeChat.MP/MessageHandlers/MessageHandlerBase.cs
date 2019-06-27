/**************************************************************************
*   
*   =======================================================================
*   CLR 版本    ：4.0.30319.42000
*   命名空间    ：Stack.WeChat.MP.MessageHandlers
*   文件名称    ：MessageAbstractHandler.cs
*   =======================================================================
*   创 建 者    ：李廷礼
*   创建日期    ：2019/6/27 15:00:16 
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
using Stack.WeChat.MP.Utils;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Stack.WeChat.MP.MessageHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class MessageHandler<TC, TRequest, TResponse> : IMessageHandler<TRequest, TResponse>, IMessageHandlerDocument, IMessageHandlerBase where TC : class where TRequest : IRequestMessageBase where TResponse : IResponseMessageBase
    {
        /// <summary>
        /// 请求实体
        /// </summary>
        public TRequest RequestMessage { get; set; }

        /// <summary>
        /// 响应实体
        /// </summary>
        public TResponse ResponseMessage { get; set; }

        /// <summary>
        /// 在构造函数中转换得到原始XML数据
        /// </summary>
        public XDocument RequestDocument { get; set; }

        /// <summary>
        /// 获得转换后的ResponseDocument
        /// </summary>
        public XDocument ResponseDocument { get; set; }

        /// <summary>
        /// 最后返回的ResponseDocument
        /// </summary>
        public XDocument FinalResponseDocument { get; set; }

        /// <summary>
        /// 文字返回信息
        /// </summary>
        public string TextResponseMessage { get; set; }

        /// <summary>
        /// 执行微信请求前触发
        /// </summary>
        public void OnExecuting()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 【异步方法】执行微信请求前触发
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task OnExecutingAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 执行请求
        /// </summary>
        public void Execute()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 【异步方法】执行微信请求
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 执行请求内部的消息整理逻辑
        /// </summary>
        public void BuildResponseMessage()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 【异步方法】执行请求内部的消息整理逻辑
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task BuildResponseMessageAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 执行微信请求后触发
        /// </summary>
        public void OnExecuted()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 【异步方法】执行微信请求后触发
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task OnExecutedAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="inputStream">微信传入的文件流</param>
        public MessageHandler(Stream inputStream)
        {
            XDocument requestDocument = XmlUtility.Convert(inputStream);
            OnInit(requestDocument);//初始化
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="requestDocument">微信传入的Xml文档</param>
        public MessageHandler(XDocument requestDocument)
        {
            //初始化
            OnInit(requestDocument);
        }

        /// <summary>
		/// 初始化，获取RequestDocument。
		/// Init中需要对上下文添加当前消息（如果使用上下文）；以及判断消息的加密情况，对解密信息进行解密
		/// </summary>
		/// <param name="requestDocument"></param>
		public abstract void OnInit(XDocument requestDocument);
    }
}