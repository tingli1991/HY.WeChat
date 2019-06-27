/**************************************************************************
*   
*   =======================================================================
*   CLR 版本    ：4.0.30319.42000
*   命名空间    ：Stack.WeChat.DataContract.MessageHandelrs
*   文件名称    ：IResponseMessageBase.cs
*   =======================================================================
*   创 建 者    ：李廷礼
*   创建日期    ：2019/6/27 14:41:47 
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
    /// 响应回复消息基类接口
    /// </summary>
    public interface IResponseMessageBase : IMessageBase
    {
        /// <summary>
        /// 响应的消息类型
        /// </summary>
        ResponseMessageType MsgType { get; set; }
    }
}