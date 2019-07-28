/**************************************************************************
*   
*   =======================================================================
*   CLR 版本    ：4.0.30319.42000
*   命名空间    ：Stack.WeChat.DataContract.Enums
*   文件名称    ：ResponseMessageType.cs
*   =======================================================================
*   创 建 者    ：李廷礼
*   创建日期    ：2019/6/27 14:42:52 
*   邮    箱    ：litingxian@live.cn
*   个人主站    ：https://github.com/tingli1991
*   功能描述    ：
*   使用说明    ：
*   ========================================================================
*   修改者      ：
*   修改日期    ：
*   修改内容    ：
*   ========================================================================
*  
***************************************************************************/

namespace Stack.WeChat.DataContract.Enums
{
    /// <summary>
    /// 微信的被动消息类型
    /// </summary>
    public enum PassiveMessageType
    {
        /// <summary>
        /// 其他
        /// </summary>
        Other = -2,
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = -1,
        /// <summary>
        /// 文本
        /// </summary>
        Text = 0,
        /// <summary>
        /// 单图文
        /// </summary>
        News = 1,
        /// <summary>
        /// 音乐
        /// </summary>
        Music = 2,
        /// <summary>
        /// 图片
        /// </summary>
        Image = 3,
        /// <summary>
        /// 语音
        /// </summary>
        Voice = 4,
        /// <summary>
        /// 视频
        /// </summary>
        Video = 5,
        /// <summary>
        /// 多客服
        /// </summary>
        Transfer_Customer_Service = 6,
        /// <summary>
        /// 素材多图文
        /// </summary>
        MpNews = 7,
        /// <summary>
        /// 多图文
        /// </summary>
        MultipleNews = 106,
        /// <summary>
        /// 位置
        /// </summary>
        LocationMessage = 107,
        /// <summary>
        /// 无回复
        /// </summary>
        NoResponse = 110,
        /// <summary>
        /// 无回复
        /// </summary>
        SuccessResponse = 200,
        /// <summary>
        /// 使用API回复
        /// </summary>
        UseApi = 998
    }
}