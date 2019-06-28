using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Stack.WeChat.Contracts.Result;
using Stack.WeChat.WebAPI.Attributes;

namespace Stack.WeChat.WebAPI.Controllers
{
    /// <summary>
    /// 网页授权控制器
    /// </summary>
    [GlobalConfig, OAuthToken]
    public class OAuthController : BaseController
    {
        /// <summary>
        /// 缓存键
        /// </summary>
        private const string SESSIONKEY = "Stack.WeChat.WebAPI:OPENID";

        /// <summary>
        /// 用户票据
        /// </summary>
        public OAuthTokenResult UserTicket
        {
            get
            {
                string ticketString = HttpContext.Session.GetString(SESSIONKEY);
                if (string.IsNullOrEmpty(ticketString))
                    return null;

                return JsonConvert.DeserializeObject<OAuthTokenResult>(ticketString);
            }
            set
            {
                string ticketString = JsonConvert.SerializeObject(value);
                HttpContext.Session.SetString(SESSIONKEY, ticketString);
            }
        }
    }
}