using Microsoft.AspNetCore.Hosting;
using Stack.WeChat.DataContract.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Stack.WeChat.MP.Extensions
{
    /// <summary>
    /// 消息处理扩展类
    /// </summary>
    public static class MessageHandlerExtensions
    {
        /// <summary>
        /// 线程对象锁
        /// </summary>
        private static readonly object lock_Obj = new object();

        /// <summary>
        /// 实例字典
        /// </summary>
        public static Dictionary<Type, IEnumerable<IHandler>> InstanceDic = new Dictionary<Type, IEnumerable<IHandler>>();

        /// <summary>
        /// 注册消息处理实现类
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IWebHostBuilder RegisterMessageHandler(this IWebHostBuilder builder)
        {
            string assemblyName = Assembly.GetEntryAssembly().GetName().Name;
            return builder.RegisterMessageHandler(assemblyName);
        }

        /// <summary>
        /// 使用Log4net
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="assemblys">程序集</param>
        /// <returns></returns>
        public static IWebHostBuilder RegisterMessageHandler(this IWebHostBuilder builder, params string[] assemblys)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }
            RegisterMessageHandler(assemblys);
            return builder;
        }

        /// <summary>
        /// 注册消息处理实现类
        /// </summary>
        /// <param name="assemblys">实现类程序集</param>
        private static void RegisterMessageHandler(params string[] assemblys)
        {
            if (assemblys == null || !assemblys.Any())
                return;

            Type imessageType = typeof(IHandler);
            string imessageAssemblyName = imessageType.Assembly.ManifestModule.Name;
            Type[] messageAssemblyTypes = Assembly.Load(imessageAssemblyName.Substring(0, imessageAssemblyName.LastIndexOf("."))).GetTypes();
            IEnumerable<Type> imessageTypeList = messageAssemblyTypes.Where(type => type.IsInterface && imessageType.IsAssignableFrom(type)).Distinct(type => type.FullName);
            IEnumerable<Type> subMessageInstanceList = assemblys.SelectMany(assembly => Assembly.Load(assembly).GetTypes()).Where(type => type.IsClass && imessageType.IsAssignableFrom(type)).Distinct(type => type.FullName);
            foreach (var messageTypeInterface in imessageTypeList)
            {
                if (!InstanceDic.ContainsKey(messageTypeInterface))
                {
                    lock (lock_Obj)
                    {
                        if (!InstanceDic.ContainsKey(messageTypeInterface))
                        {
                            IEnumerable<IHandler> messageInstanceList = subMessageInstanceList.Where(type => messageTypeInterface.IsAssignableFrom(type))
                                .Select(type => (IHandler)Activator.CreateInstance(type));

                            if (messageInstanceList != null && messageInstanceList.Any())
                            {
                                InstanceDic.Add(messageTypeInterface, messageInstanceList);
                            }
                        }
                    }
                }
            }
        }
    }
}