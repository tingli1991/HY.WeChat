/**************************************************************************
*   
*   =======================================================================
*   CLR 版本    ：4.0.30319.42000
*   命名空间    ：Stack.WeChat.MP.MessageHandlers
*   文件名称    ：IMessageHandlerBase.cs
*   =======================================================================
*   创 建 者    ：李廷礼
*   创建日期    ：2019/6/27 14:06:26 
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


using System.Threading;
using System.Threading.Tasks;

namespace Stack.WeChat.DataContract.MessageHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMessageHandlerBase
    {
        /// <summary>
		/// 执行微信请求前触发
		/// </summary>
		void OnExecuting();

        /// <summary>
        /// 执行请求
        /// </summary>
        void Execute();

        /// <summary>
        /// 执行请求内部的消息整理逻辑
        /// </summary>
        void BuildResponseMessage();

        /// <summary>
        /// 执行微信请求后触发
        /// </summary>
        void OnExecuted();

        /// <summary>
        /// 【异步方法】执行微信请求前触发
        /// </summary>
        Task OnExecutingAsync(CancellationToken cancellationToken);

        /// <summary>
        /// 【异步方法】执行微信请求
        /// </summary>
        Task ExecuteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// 【异步方法】执行请求内部的消息整理逻辑
        /// </summary>
        Task BuildResponseMessageAsync(CancellationToken cancellationToken);

        /// <summary>
        /// 【异步方法】执行微信请求后触发
        /// </summary>
        Task OnExecutedAsync(CancellationToken cancellationToken);
    }
}