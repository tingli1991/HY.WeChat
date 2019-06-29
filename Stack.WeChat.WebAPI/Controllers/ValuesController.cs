using Microsoft.AspNetCore.Mvc;

namespace Stack.WeChat.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/values")]
    public class ValuesController : OAuthController
    {
        /// <summary>
        ///  GET api/values
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "This is Check OAuth2.0 API";
        }
    }
}