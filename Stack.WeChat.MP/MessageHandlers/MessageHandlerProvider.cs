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


using Stack.WeChat.DataContract.Config;
using Stack.WeChat.DataContract.Enums;
using Stack.WeChat.DataContract.MessageHandlers;
using Stack.WeChat.MP.Utils;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Stack.WeChat.MP.Extensions;
using System;

namespace Stack.WeChat.MP.MessageHandlers
{
    /// <summary>
    /// 消息处理类
    /// </summary>
    public class MessageHandlerProvider
    {
        /// <summary>
        /// 请求的Xml文档
        /// </summary>
        private XDocument RequestDocument;

        /// <summary>
        /// 消息上下文
        /// </summary>
        private IAccountContext Account;

        /// <summary>
        /// XElement子元素列表
        /// </summary>
        private IEnumerable<XElement> Descendants;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="openId">用户的标识，对当前公众号唯一</param>
        /// <param name="account">公众号账户配置</param>
        /// <param name="inputStream">微信传入的文件流</param>
        public MessageHandlerProvider(string openId, WeChatAccount account, Stream inputStream)
        {
            Account = InitContext(openId, account);
            RequestDocument = XmlUtility.SerializeObject(inputStream);
            Descendants = RequestDocument.Descendants();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="openId">用户的标识，对当前公众号唯一</param>
        /// <param name="account">公众号账户配置</param>
        /// <param name="requestDocument">微信传入的Xml文档</param>
        public MessageHandlerProvider(string openId, WeChatAccount account, XDocument requestDocument)
        {
            RequestDocument = requestDocument;
            Account = InitContext(openId, account);
            Descendants = RequestDocument.Descendants();
        }

        /// <summary>
        /// 初始化基础上下文
        /// </summary>
        /// <param name="openId">用户的标识，对当前公众号唯一</param>
        /// <param name="account">公众号账户配置</param>
        /// <returns></returns>
        private IAccountContext InitContext(string openId, WeChatAccount account)
        {
            var messageContext = new AccountContext();
            if (account == null || string.IsNullOrEmpty(account.AppId)
                  || string.IsNullOrEmpty(account.SecretKey) || string.IsNullOrEmpty(account.Token))
                return messageContext;


            messageContext.OpenId = openId;
            messageContext.Account = account;
            messageContext.AppId = account.AppId;
            return messageContext;
        }

        /// <summary>
        /// 处理方法
        /// </summary>
        public void Handler()
        {
            IMessageContext context = GetMessageContext();
            IEnumerable<XElement> descendants = RequestDocument.Descendants();
            XElement msgTypeElement = descendants.FirstOrDefault(e => $"{e.Name}".Equals("msgtype", StringComparison.InvariantCultureIgnoreCase));
            MessageType requestMessageType = msgTypeElement.Value.ToRequestMessageType();
            MessageHandlerFactory.Execute(context, requestMessageType);
        }

        /// <summary>
        /// 初始化上下文
        /// </summary>
        /// <returns></returns>
        private IMessageContext GetMessageContext()
        {
            return new MessageContext()
            {
                Account = Account,
                RequestDocument = RequestDocument,
                RequestXmlString = RequestDocument.ToString()
            };
        }
    }
}