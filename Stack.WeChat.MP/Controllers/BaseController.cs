using Microsoft.AspNetCore.Mvc;
using Stack.WeChat.DataContract.Config;
using Stack.WeChat.MP.Attributes;

namespace Stack.WeChat.MP.Controllers
{
    /// <summary>
    /// 基类控制器
    /// </summary>
    [GlobalConfig]
    public class BaseController : Controller
    {
        /// <summary>
        /// 公众号Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 微信公众号账户信息
        /// </summary>
        public WeChatAccount Account { get; set; }
    }
}