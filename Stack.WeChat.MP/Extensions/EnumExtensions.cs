using Stack.WeChat.DataContract.Enums;
using System;
using System.Linq;

namespace Stack.WeChat.MP.Extensions
{
    /// <summary>
    /// 消息类型转换
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// 将字符串的消息类型转换成ResponseMessageType枚举
        /// </summary>
        /// <param name="messageType">消息类型字符串</param>
        /// <returns></returns>
        public static PassiveMessageType ToResponseMessageType(this byte messageType)
        {
            return messageType.ToEnum<PassiveMessageType>();
        }

        /// <summary>
        /// 将字符串的消息类型转换成ResponseMessageType枚举
        /// </summary>
        /// <param name="messageType">消息类型字符串</param>
        /// <returns></returns>
        public static PassiveMessageType ToResponseMessageType(this int messageType)
        {
            return messageType.ToEnum<PassiveMessageType>();
        }

        /// <summary>
        /// 将字符串的消息类型转换成ResponseMessageType枚举
        /// </summary>
        /// <param name="messageType">消息类型字符串</param>
        /// <returns></returns>
        public static PassiveMessageType ToResponseMessageType(this long messageType)
        {
            return messageType.ToEnum<PassiveMessageType>();
        }

        /// <summary>
        /// 将字符串的消息类型转换成ResponseMessageType枚举
        /// </summary>
        /// <param name="messageType">消息类型字符串</param>
        /// <returns></returns>
        public static PassiveMessageType ToResponseMessageType(this string messageType)
        {
            return messageType.ToEnum<PassiveMessageType>();
        }

        /// <summary>
        /// 将字符串的消息类型转换成RequestMessageType枚举
        /// </summary>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public static MessageType ToRequestMessageType(this byte messageType)
        {
            return messageType.ToEnum<MessageType>();
        }

        /// <summary>
        /// 将字符串的消息类型转换成RequestMessageType枚举
        /// </summary>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public static MessageType ToRequestMessageType(this int messageType)
        {
            return messageType.ToEnum<MessageType>();
        }

        /// <summary>
        /// 将字符串的消息类型转换成RequestMessageType枚举
        /// </summary>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public static MessageType ToRequestMessageType(this long messageType)
        {
            return messageType.ToEnum<MessageType>();
        }

        /// <summary>
        /// 将字符串的消息类型转换成RequestMessageType枚举
        /// </summary>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public static MessageType ToRequestMessageType(this string messageType)
        {
            return messageType.ToEnum<MessageType>();
        }

        /// <summary>
        /// 枚举转换
        /// </summary>
        /// <typeparam name="T">目标枚举</typeparam>
        /// <param name="enumValue">枚举值</param>
        /// <returns></returns>
        public static T ToEnum<T>(this byte enumValue) where T : Enum
        {
            return ToEnum<T>($"{enumValue}");
        }

        /// <summary>
        /// 枚举转换
        /// </summary>
        /// <typeparam name="T">目标枚举</typeparam>
        /// <param name="enumValue">枚举值</param>
        /// <returns></returns>
        public static T ToEnum<T>(this int enumValue) where T : Enum
        {
            return ToEnum<T>($"{enumValue}");
        }

        /// <summary>
        /// 枚举转换
        /// </summary>
        /// <typeparam name="T">目标枚举</typeparam>
        /// <param name="enumValue">枚举值</param>
        /// <returns></returns>
        public static T ToEnum<T>(this long enumValue) where T : Enum
        {
            return ToEnum<T>($"{enumValue}");
        }

        /// <summary>
        /// 枚举转换
        /// </summary>
        /// <typeparam name="T">目标枚举</typeparam>
        /// <param name="enumNameOrValue">枚举名称或者枚举值</param>
        /// <returns></returns>
        public static T ToEnum<T>(this string enumNameOrValue) where T : Enum
        {
            //判断是否可以转换为整型
            if (!int.TryParse(enumNameOrValue, out int number))
            {
                Type type = typeof(T);
                string[] enumNames = type.GetEnumNames();
                string nameKey = enumNames.FirstOrDefault(name => name.Equals(enumNameOrValue, StringComparison.InvariantCultureIgnoreCase));
                if (!string.IsNullOrEmpty(nameKey))
                    enumNameOrValue = nameKey;
            }
            return (T)Enum.Parse(typeof(T), enumNameOrValue);
        }
    }
}