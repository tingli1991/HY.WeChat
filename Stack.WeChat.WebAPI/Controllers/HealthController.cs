using Microsoft.AspNetCore.Mvc;

namespace Stack.WeChat.WebAPI.Controllers
{
    /// <summary>
    /// 健康检查控制器
    /// </summary>
    [Route("api/health")]
    [Produces("application/json")]
    public class HealthController : Controller
    {
        /// <summary>
        /// 健康检查接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get() => Ok("ok");
    }
}