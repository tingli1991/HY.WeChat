using System;

namespace Stack.WeChat.MP.Extensions
{
    /// <summary>
    /// 时间扩展
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 转换为时间错
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long ToUnixTime(this DateTime dateTime)
        {
            return (dateTime.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }
    }
}