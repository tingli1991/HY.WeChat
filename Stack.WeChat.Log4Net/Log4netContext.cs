using log4net;
using log4net.Repository;
using System;
using System.IO;

namespace Stack.WeChat.Log4Net
{
    /// <summary>
    /// Log4net日志上下文
    /// </summary>
    class Log4netContext
    {
        /// <summary>
        /// 日志库
        /// </summary>
        private static ILoggerRepository repository;

        /// <summary>
        /// 日志记录器
        /// </summary>
        protected internal static ILog Log { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configPath"></param>
        public static void Configure(string configPath)
        {
            FileInfo file = new FileInfo(configPath);
            repository = LogManager.CreateRepository("NETCoreRepository");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(repository, file);

            Log = LogManager.GetLogger(repository.Name, "");
            Log.Debug($"初始化 {configPath} 完成。");
        }

        /// <summary>
        /// 获取对象日志记录器
        /// </summary>
        /// <param name="type">对象</param>
        /// <returns></returns>
        public static ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(repository.Name, type);
        }

        /// <summary>
        /// 获取对象日志记录器
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <returns></returns>
        public static ILog GetLogger<T>() where T : class
        {
            return GetLogger(typeof(T));
        }
    }
}