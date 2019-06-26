/**************************************************************************
*   
*   =======================================================================
*   CLR 版本    ：4.0.30319.42000
*   命名空间    ：Stack.WeChat.Repository.Models
*   文件名称    ：User.cs
*   =======================================================================
*   创 建 者    ：李廷礼
*   创建日期    ：2019/6/26 16:05:48 
*   邮    箱    ：litingxian@live.cn
*   个人主站    ：https://github.com/tingli1991
*   功能描述    ：用户信息表
*   使用说明    ：
*   ========================================================================
*   修改者      ：
*   修改日期    ：
*   修改内容    ：
*   ========================================================================
*  
***************************************************************************/


using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stack.WeChat.Repository.Models
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户Id，主键
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        /// <summary>
        /// 只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段
        /// </summary>
        public string UnionId { get; set; }

        /// <summary>
        /// 公众号Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 用户所在的分组ID（暂时兼容用户分组旧接口）
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// 用户的昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        public byte Sex { get; set; }

        /// <summary>
        /// 用户所在城市
        /// 格式：广州
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 用户所在省份
        /// 格式：广东省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 用户所在国家
        /// 格式：中国
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 用户的语言，简体中文为zh_CN
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// 用户头像，
        /// 最后一个数值代表正方形头像大小
        /// （有0、46、64、96、132数值可选，0代表640*640正方形头像），
        /// 用户没有头像时该项为空。若用户更换头像，原有头像URL将失效。
        /// </summary>
        public string HeadimgUrl { get; set; }

        /// <summary>
        /// 用户是否订阅该公众号标识，值为0时，代表此用户没有关注该公众号，拉取不到其余信息
        /// </summary>
        public bool Subscribe { get; set; }

        /// <summary>
        /// 用户关注时间，为时间戳。如果用户曾多次关注，则取最后关注时间
        /// </summary>
        public long Subscribe_Time { get; set; }

        /// <summary>
        /// 返回用户关注的渠道来源
        /// ADD_SCENE_SEARCH 公众号搜索
        /// ADD_SCENE_ACCOUNT_MIGRATION 公众号迁移
        /// ADD_SCENE_PROFILE_CARD 名片分享
        /// ADD_SCENE_QR_CODE 扫描二维码
        /// ADD_SCENEPROFILE LINK 图文页内名称点击
        /// ADD_SCENE_PROFILE_ITEM 图文页右上角菜单
        /// ADD_SCENE_PAID 支付后关注
        /// ADD_SCENE_OTHERS 其他
        /// </summary>
        public string Subscribe_Scene { get; set; }

        /// <summary>
        /// 用户被打上的标签ID列表
        /// 格式：[128,2]
        /// </summary>
        public string Tagid_List { get; set; }

        /// <summary>
        /// 二维码扫码场景（开发者自定义）
        /// </summary>
        public string Qr_Scene { get; set; }

        /// <summary>
        /// 二维码扫码场景描述（开发者自定义）
        /// </summary>
        public string Qr_Scene_Str { get; set; }

        /// <summary>
        /// 最后一次更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 公众号运营者对粉丝的备注，公众号运营者可在微信公众平台用户管理界面对粉丝添加备注
        /// </summary>
        public string Remark { get; set; }
    }
}