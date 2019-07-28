namespace Stack.WeChat.DataContract.MessageHandlers
{
    /// <summary>
    /// 所有Request和Response消息的接口
    /// </summary>
    public class MessageModel : IMessageModel
    {
        /// <summary>
        /// 响应的消息类型
        /// </summary>
        public string MsgType { get; set; }
        /// <summary>
        /// 接收人（在 Request 中为公众号的微信号，在 Response 中为 OpenId）
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 发送人（在 Request 中为OpenId，在 Response 中为公众号的微信号）
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间
        /// </summary>
        public long CreateTime { get; set; }
    }
}