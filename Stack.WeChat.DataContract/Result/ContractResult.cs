using Stack.WeChat.DataContract.Enums;
using System;

namespace Stack.WeChat.DataContract.Result
{
    /// <summary>
    /// 通用契约返回值
    /// </summary>
    public class ContractResult
    {
        /// <summary>
        /// 错误编码（详细对应枚举：MessageType）
        /// 0：失败
        /// 100：成功
        /// 500：服务器异常
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        public object ExtendParam { get; set; }

        /// <summary>
        /// 服务器时间
        /// </summary>
        public DateTime ServiceTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ContractResult()
        {
            //默认创建对象时设置为失败
            SetError(MessageType.Fail);
        }

        /// <summary>
        /// 设置为成功
        /// </summary>
        public void SetSuccess()
        {
            MessageType messageType = MessageType.Success;
            ErrorCode = $"{(int)messageType}";
            ErrorMessage = messageType.GetDescription();
        }

        /// <summary>
        /// 判断是否成功
        /// </summary>
        /// <returns></returns>
        public bool IsSuccess()
        {
            MessageType messageType = MessageType.Success;
            return ErrorCode == $"{(int)messageType}";
        }

        /// <summary>
        /// 设置错误信息
        /// </summary>
        /// <param name="message">错误信息</param>
        public void SetError(MessageType messageType)
        {
            ErrorCode = $"{(int)MessageType.Fail}";
            ErrorMessage = messageType.GetDescription();
        }

        /// <summary>
        /// 设置错误信息
        /// </summary>
        /// <param name="code">错误码</param>
        /// <param name="message">错误消息</param>
        public void SetError(string code, string message)
        {
            ErrorCode = code;
            ErrorMessage = message;
        }
    }

    /// <summary>
    /// 通用契约返回值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ContractResult<T> : ContractResult
    {
        /// <summary>
        /// 返回数据对象
        /// </summary>
        public T Data { get; set; }
    }
}