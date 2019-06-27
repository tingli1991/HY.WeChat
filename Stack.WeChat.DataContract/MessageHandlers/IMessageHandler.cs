/**************************************************************************
*   
*   =======================================================================
*   CLR 版本    ：4.0.30319.42000
*   命名空间    ：Stack.WeChat.MP.MessageHandlers
*   文件名称    ：IMessageHandler.cs
*   =======================================================================
*   创 建 者    ：李廷礼
*   创建日期    ：2019/6/27 14:22:43 
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


namespace Stack.WeChat.DataContract.MessageHandlers
{
    /// <summary>
    /// IMessageHandler 接口
    /// </summary>
    public interface IMessageHandler : IMessageHandler<IRequestMessageBase, IResponseMessageBase>, IMessageHandlerDocument, IMessageHandlerBase
    {

    }

    /// <summary>
    /// IMessageHandler 接口
    /// </summary>
    /// <typeparam name="TRequest">请求参数实体</typeparam>
    /// <typeparam name="TResponse">返回参数实体</typeparam>
    public interface IMessageHandler<TRequest, TResponse> : IMessageHandlerDocument, IMessageHandlerBase where TRequest : IRequestMessageBase where TResponse : IResponseMessageBase
    {
        /// <summary>
		/// 请求实体
		/// </summary>
		TRequest RequestMessage { get; set; }

        /// <summary>
        /// 响应实体
        /// 只有当执行Execute()方法后才可能有值
        /// </summary>
        TResponse ResponseMessage { get; set; }
    }
}