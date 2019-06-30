using Stack.WeChat.MP.Attributes;
using Stack.WeChat.WebAPI.Attributes;

namespace Stack.WeChat.WebAPI.Controllers
{
    /// <summary>
    /// 网页授权控制器
    /// </summary>
    [GlobalConfig, OAuthToken]
    public class BasicsOAuthController : BaseOAuthController
    {

    }
}