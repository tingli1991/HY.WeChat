using Microsoft.AspNetCore.Mvc;

namespace Stack.WeChat.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/index")]
    public class IndexController : BaseController
    {
        /// <summary>
        ///  GET api/index
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "";
        }

        /// <summary>
        /// POST api/index
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<string> Post()
        {
            return "";
        }
    }
}