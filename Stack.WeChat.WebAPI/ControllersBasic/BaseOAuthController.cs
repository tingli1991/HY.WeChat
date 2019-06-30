using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Stack.WeChat.DataContract.MpResult;
using Stack.WeChat.MP.Attributes;
using Stack.WeChat.MP.Controllers;

namespace Stack.WeChat.WebAPI.Controllers
{
    /// <summary>
    /// 网页授权控制器
    /// </summary>
    [GlobalConfig]
    public class BaseOAuthController : BaseController
    {
        /// <summary>
        /// 缓存键
        /// </summary>
        private const string SESSIONKEY = "Stack.WeChat.WebAPI:OPENID";

        /// <summary>
        /// 用户票据
        /// </summary>
        public OAuthTokenMpResult UserTicket
        {
            get
            {
                string ticketString = HttpContext.Session.GetString(SESSIONKEY);
                if (string.IsNullOrEmpty(ticketString))
                    return null;

                return JsonConvert.DeserializeObject<OAuthTokenMpResult>(ticketString);
            }
            set
            {
                string ticketString = JsonConvert.SerializeObject(value);
                HttpContext.Session.SetString(SESSIONKEY, ticketString);
            }
        }
    }
}