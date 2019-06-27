/**************************************************************************
*   
*   =======================================================================
*   CLR 版本    ：4.0.30319.42000
*   命名空间    ：Stack.WeChat.MP.MessageHandlers
*   文件名称    ：IMessageHandlerDocument.cs
*   =======================================================================
*   创 建 者    ：李廷礼
*   创建日期    ：2019/6/27 14:13:42 
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


using System.Xml.Linq;

namespace Stack.WeChat.DataContract.MessageHandlers
{
    /// <summary>
    /// 为IMessageHandler单独提供XDocument类型的属性接口（主要是ResponseDocument）
    /// 分离这个接口的目的是为了在MvcExtension中对IMessageHandler解耦，使用IMessageHandlerDocument接口直接操作XML
    /// </summary>
    public interface IMessageHandlerDocument
    {
        /// <summary>
        /// 在构造函数中转换得到原始XML数据
        /// </summary>
        XDocument RequestDocument { get; set; }

        /// <summary>
        /// 获得转换后的ResponseDocument
        /// </summary>
        XDocument ResponseDocument { get; set; }

        /// <summary>
        /// 最后返回的ResponseDocument
        /// </summary>
        XDocument FinalResponseDocument { get; set; }

        /// <summary>
        /// 文字返回信息
        /// </summary>
        string TextResponseMessage { get; set; }
    }
}