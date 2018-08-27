using System;

namespace Stack.WeChat.Contracts.Result
{
    /// <summary>
    /// 统一输出结果
    /// </summary>
    public class ResponseResult
    {
        /// <summary>
        /// 业务处理是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 业务扩展参数
        /// </summary>
        public object ExtendParam { get; set; }

        /// <summary>
        /// 当前的服务器时间
        /// </summary>
        public DateTime ServiceTime => DateTime.Now;

        /// <summary>
        /// 错误编码
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误消息文案
        /// </summary>
        public string ErrorMessage { get; set; }
    }

    /// <summary>
    /// 统一输出结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseResult<T> : ResponseResult
    {
        /// <summary>
        /// 返回的业务数据
        /// </summary>
        public T Data { get; set; }
    }
}