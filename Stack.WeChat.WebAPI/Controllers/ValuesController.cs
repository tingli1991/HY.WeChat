using Microsoft.AspNetCore.Mvc;
using Stack.WeChat.WebAPI.Attributes;

namespace Stack.WeChat.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/values")]
    public class ValuesController : BasicsOAuthController
    {
        /// <summary>
        ///  GET 网页授权测试接口
        /// </summary>
        /// <returns></returns>
        [HttpGet, OAuthToken]
        public ActionResult<string> Get()
        {
            return "This is Check OAuth2.0 API";
        }
    }
}