namespace Stack.WeChat.DataContract.Enums
{
    /// <summary>
    /// 微信事件类型
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// 关注/订阅/扫描带参数二维码事件(用户未关注时，进行关注后的事件推送)
        /// </summary>
        Subscribe = 1,

        /// <summary>
        /// 取消关注/取消订阅
        /// </summary>
        UnSubscribe = 2,

        /// <summary>
        /// 扫描带参数二维码事件
        /// 用户已关注时的事件推送
        /// </summary>
        Scan = 3,

        /// <summary>
        /// 上报地理位置事件
        /// 用户同意上报地理位置后，每次进入公众号会话时，都会在进入时上报地理位置，
        /// 或在进入会话后每5秒上报一次地理位置，公众号可以在公众平台网站中修改以上设置。
        /// 上报地理位置时，微信会将上报地理位置事件推送到开发者填写的URL
        /// </summary>
        Location = 4,

        /// <summary>
        /// 自定义菜单事件
        /// 点击菜单拉取消息时的事件推送
        /// </summary>
        Click = 5,

        /// <summary>
        /// 自定义菜单事件
        /// 点击菜单拉取消息时的事件推送
        /// 用户点击自定义菜单后，微信会把点击事件推送给开发者，请注意，点击菜单弹出子菜单，不会产生上报。
        /// </summary>
        View = 6
    }
}