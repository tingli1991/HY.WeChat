using log4net;
using System;

namespace Stack.WeChat.Utils.Log4net
{
    /// <summary>
    /// Log4net日志工具类
    /// </summary>
    public class Log4netUtil
    {
        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            Log4netContext.Log.Debug(message);
        }

        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Debug(string message, Exception ex)
        {
            Log4netContext.Log.Debug(message, ex);
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            Log4netContext.Log.Info(message);
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Info(string message, Exception ex)
        {
            Log4netContext.Log.Info(message, ex);
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(string message)
        {
            Log4netContext.Log.Warn(message);
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Warn(string message, Exception ex)
        {
            Log4netContext.Log.Warn(message, ex);
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            Log4netContext.Log.Error(message);
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Error(string message, Exception ex)
        {
            Log4netContext.Log.Error(message, ex);
        }

        /// <summary>
        /// 获取对象日志记录器
        /// </summary>
        /// <param name="type">对象</param>
        /// <returns></returns>
        public static ILog GetLogger(Type type)
        {
            return Log4netContext.GetLogger(type);
        }

        /// <summary>
        /// 获取对象日志记录器
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <returns></returns>
        public static ILog GetLogger<T>() where T : class
        {
            return Log4netContext.GetLogger<T>();
        }
    }
}