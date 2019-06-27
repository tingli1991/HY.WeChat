/**************************************************************************
*   
*   =======================================================================
*   CLR 版本    ：4.0.30319.42000
*   命名空间    ：Stack.WeChat.DataContract.MessageHandelrs
*   文件名称    ：IMessageBase.cs
*   =======================================================================
*   创 建 者    ：李廷礼
*   创建日期    ：2019/6/27 14:27:50 
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

using System;

namespace Stack.WeChat.DataContract.MessageHandlers
{
    /// <summary>
    /// 所有Request和Response消息的接口
    /// </summary>
    public interface IMessageBase
    {
        /// <summary>
		/// 接收人（在 Request 中为公众号的微信号，在 Response 中为 OpenId）
		/// </summary>
		string ToUserName { get; set; }

        /// <summary>
        /// 发送人（在 Request 中为OpenId，在 Response 中为公众号的微信号）
        /// </summary>
        string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间
        /// </summary>
        DateTimeOffset CreateTime { get; set; }
    }
}