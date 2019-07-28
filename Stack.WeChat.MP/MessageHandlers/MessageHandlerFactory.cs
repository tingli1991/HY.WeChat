using System.Collections.Generic;
using System;
using System.Xml.Linq;
using Stack.WeChat.DataContract.MessageHandlers;
using Stack.WeChat.MP.Extensions;
using Stack.WeChat.DataContract.Enums;
using System.Linq;

namespace Stack.WeChat.MP.MessageHandlers
{
    /// <summary>
    /// 消息处理工厂
    /// </summary>
    class MessageHandlerFactory
    {
        /// <summary>
        /// 线程对象锁
        /// </summary>
        private static readonly object lock_Obj = new object();

        /// <summary>
        /// 实例字典
        /// </summary>
        private static Dictionary<MessageType, IEnumerable<IMessageHandler>> messageHandler = new Dictionary<MessageType, IEnumerable<IMessageHandler>>();

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <param name="RequestMessageType">请求消息类型</param>
        /// <returns></returns>
        private static IEnumerable<IMessageHandler> GetMessageHandllers(MessageType requestMessageType)
        {
            if (!messageHandler.ContainsKey(requestMessageType))
            {
                lock (lock_Obj)
                {
                    if (!messageHandler.ContainsKey(requestMessageType))
                    {
                        Type type = null;
                        switch (requestMessageType)
                        {
                            case MessageType.Text:
                            case MessageType.Image:
                            case MessageType.Voice:
                            case MessageType.Video:
                            case MessageType.ShortVideo:
                            case MessageType.Location:
                            case MessageType.Link:
                                type = typeof(IMessageHandler);
                                break;
                            case MessageType.Event:
                                break;
                            default:
                                throw new ArgumentException("无效的消息类型");
                        }

                        if (!MessageHandlerExtensions.InstanceDic.ContainsKey(type))
                        {
                            throw new ArgumentException("无效的消息类型");
                        }

                        IEnumerable<IHandler> handlers = MessageHandlerExtensions.InstanceDic[type];
                        IEnumerable<IMessageHandler> requestHandlers = handlers.Select(handler => (IMessageHandler)handler).Where(handler => handler.MessageType == requestMessageType);
                        messageHandler.Add(requestMessageType, requestHandlers);
                    }
                }
            }
            return messageHandler[requestMessageType];
        }

        /// <summary>
        /// 执行微信请处理方法
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requestMessageType">请求的消息枚举类型</param>
        public static void Execute(IMessageContext context, MessageType requestMessageType)
        {
            if (requestMessageType != MessageType.Event)
            {
                IEnumerable<IMessageHandler> messageHandllers = GetMessageHandllers(requestMessageType);
                foreach (IMessageHandler messageHandller in messageHandllers)
                {
                    messageHandller.Execute(context);
                }
            }
            else
            {

            }
        }
    }
}