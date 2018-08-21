using Microsoft.AspNetCore.Mvc;

namespace Stack.WeChat.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/Values")]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        ///  GET api/values
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "";
        }

        /// <summary>
        /// GET api/values/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "";
        }
    }
}