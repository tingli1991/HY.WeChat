/**************************************************************************
*   
*   =======================================================================
*   CLR 版本    ：4.0.30319.42000
*   命名空间    ：Stack.WeChat.DataContract.MessageHandelrs
*   文件名称    ：IRequestMessageBasecs.cs
*   =======================================================================
*   创 建 者    ：李廷礼
*   创建日期    ：2019/6/27 14:29:13 
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


using Stack.WeChat.DataContract.Enums;

namespace Stack.WeChat.DataContract.MessageHandlers
{

    /// <summary>
    /// 请求消息基础接口
    /// </summary>
    public interface IRequestMessageBase : IMessageBase
    {
        /// <summary>
        /// 消息Id
        /// </summary>
        long MsgId { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        RequestMessageType MsgType { get; set; }
    }
}