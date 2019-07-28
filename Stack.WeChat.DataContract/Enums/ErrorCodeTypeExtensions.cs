using System.ComponentModel;
using System.Reflection;

namespace Stack.WeChat.DataContract.Enums
{
    /// <summary>
    /// 错误消息类型定义枚举扩展
    /// </summary>
    public static class ErrorCodeTypeExtensions
    {
        /// <summary>
        /// 获取错误消息类型对应的描述信息
        /// </summary>
        /// <param name="messageType">错误消息类型定义枚举</param>
        /// <returns></returns>
        public static string GetDescription(this ErrorCodeType messageType)
        {
            FieldInfo field = messageType.GetType().GetField(messageType.ToString());
            return (field.GetCustomAttributes(typeof(DescriptionAttribute), true)[0] is DescriptionAttribute descriptionAttribute) ? descriptionAttribute.Description : "";
        }
    }
}