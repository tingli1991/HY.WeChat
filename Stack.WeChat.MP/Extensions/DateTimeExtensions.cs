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
        /// 精确到秒（长度10）
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <returns></returns>
        public static long ToUnixTimeForSeconds(this DateTime dateTime)
        {
            TimeSpan timeSpan = dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1));
            return (long)timeSpan.TotalSeconds;
        }

        /// <summary>
        /// 转换为时间错
        /// 精确到毫秒（长度13）
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <returns></returns>
        public static long ToUnixTimeForMilliseconds(this DateTime dateTime)
        {
            TimeSpan timeSpan = dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1));
            return (long)timeSpan.TotalMilliseconds;
        }

        /// <summary>
        /// 时间戳转为C#格式时间10位
        /// </summary>
        /// <param name="timeStamp">Unix时间戳格式</param>
        /// <returns>C#格式时间</returns>
        public static DateTime ToDateTime(this decimal unixTime)
        {
            return ((long)unixTime).ToDateTime();
        }

        /// <summary>
        /// 时间戳转为C#格式时间10位
        /// </summary>
        /// <param name="timeStamp">Unix时间戳格式</param>
        /// <returns>C#格式时间</returns>
        public static DateTime ToDateTime(this double unixTime)
        {
            return ((long)unixTime).ToDateTime();
        }

        /// <summary>
        /// 时间戳转为C#格式时间10位
        /// </summary>
        /// <param name="timeStamp">Unix时间戳格式</param>
        /// <returns>C#格式时间</returns>
        public static DateTime ToDateTime(this long unixTime)
        {
            DateTime? dateTime = null;
            string timeStamp = unixTime.ToString();
            DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddHours(8);
            switch (timeStamp.Length)
            {
                case 10:
                    dateTime = startTime.AddSeconds(unixTime);
                    break;
                case 13:
                    dateTime = startTime.AddMilliseconds(unixTime);
                    break;
                default:
                    throw new ArgumentException("Invalid length");
            }
            return dateTime.Value;
        }
    }
}