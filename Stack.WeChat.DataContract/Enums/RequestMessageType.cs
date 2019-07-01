﻿/**************************************************************************
*   
*   =======================================================================
*   CLR 版本    ：4.0.30319.42000
*   命名空间    ：Stack.WeChat.DataContract.Enums
*   文件名称    ：RequestMessageType.cs
*   =======================================================================
*   创 建 者    ：李廷礼
*   创建日期    ：2019/6/27 14:30:09 
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
    /// 微信请求消息类型
    /// </summary>
    public enum RequestMessageType
    {
        /// <summary>
        /// 
        /// </summary>
        Unknown = -1,
        /// <summary>
        /// 文字
        /// </summary>
        Text = 0,
        /// <summary>
        /// 位置信息
        /// </summary>
        Location = 1,
        /// <summary>
        /// 图片
        /// </summary>
        Image = 2,
        /// <summary>
        /// 语音
        /// </summary>
        Voice = 3,
        /// <summary>
        /// 视频
        /// </summary>
        Video = 4,
        /// <summary>
        /// 连接
        /// </summary>
        Link = 5,
        /// <summary>
        /// 小视频
        /// </summary>
        ShortVideo = 6,
        /// <summary>
        /// 事件
        /// </summary>
        Event = 7,
        /// <summary>
        /// 文件
        /// </summary>
        File = 8,
        /// <summary>
        /// 
        /// </summary>
        NeuChar = 999
    }
}