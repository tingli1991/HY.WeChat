using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stack.WeChat.Tools.Result;

namespace Stack.WeChat.Tools.Controllers
{
    /// <summary>
    /// 基类控制器
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 
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