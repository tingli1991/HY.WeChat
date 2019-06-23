using System;
using System.ComponentModel;
using System.Reflection;

namespace Stack.WeChat.DataContract.Enums
{
    /// <summary>
    /// 错误消息类型定义枚举扩展
    /// </summary>
    public static class MessageTypeExtensions
    {
        /// <summary>
        /// 获取错误消息类型对应的描述信息
        /// </summary>
        /// <param name="messageType">错误消息类型定义枚举</param>
        /// <returns></returns>
        public static string GetDescription(this MessageType messageType)
        {
            FieldInfo field = messageType.GetType().GetField(messageType.ToString());
            if (field.GetCustomAttributes(typeof(DescriptionAttribute), true)[0] is DescriptionAttribute descriptionAttribute)
                return descriptionAttribute.Description;
            else
                return "";
        }
    }
}