using Microsoft.AspNetCore.Mvc;
using Stack.WeChat.DataContract.Config;
using Stack.WeChat.WebAPI.Attributes;

namespace Stack.WeChat.WebAPI.Controllers
{
    /// <summary>
    /// 基类控制器
    /// </summary>
    [GlobalConfig]
    public class BaseController : Controller
    {
        /// <summary>
        /// AppId
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 微信公众号账户信息
        /// </summary>
        public WeChatAccount Account { get; set; }
    }
}