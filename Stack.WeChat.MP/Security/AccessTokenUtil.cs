using Stack.WeChat.DataContract.MpResult;
using Stack.WeChat.DataContract.Result;
using Stack.WeChat.MP.Config;
using Stack.WeChat.MP.Utils;
using System;
using System.Collections.Generic;

namespace Stack.WeChat.MP.Security
{
    /// <summary>
    /// 微信授权工具类
    /// </summary>
    public class AccessTokenUtil
    {
        /// <summary>
        /// 获取获取网页授权的Token
        /// </summary>
        /// <param name="appId">AppId</param>
        /// <param name="code">授权码</param>
        /// <param name="seccretKey">开发者密码</param>
        /// <returns></returns>
        public static OAuthTokenMpResult GetOAuthToken(string appId, string code, string seccretKey)
        {
            string oAuthTokenUrl = WeChatSettingsUtil.Settings.OAuthTokenUrl;
            string apiUrl = $"{oAuthTokenUrl}?appid={appId}&secret={seccretKey}&code={code}&grant_type=authorization_code";
            return HttpClientUtil.GetResponse<OAuthTokenMpResult>(apiUrl);
        }

        /// <summary>
        /// 刷新网页授权的Token
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="userTicket">用户票据</param>
        /// <returns></returns>
        public static OAuthTokenMpResult RefreshToken(string appId, OAuthTokenMpResult userTicket)
        {
            if (userTicket.UpdateTime.AddSeconds(userTicket.ExpireSeconds) > DateTime.Now)
                return userTicket;//还没过期直接返回

            string oAuthRefreshTokenUrl = WeChatSettingsUtil.Settings.OAuthRefreshTokenUrl;
            string apiUrl = $"{oAuthRefreshTokenUrl}?appid={appId}&grant_type=refresh_token&refresh_token={userTicket.RefreshToken}";
            return HttpClientUtil.GetResponse<OAuthTokenMpResult>(apiUrl);
        }

        /// <summary>
        /// 获取普通授权Token信息
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret">开发者密码</param>
        /// <returns></returns>
        public static ContractResult<string> GetAccessToken(string appId, string secretKey)
        {
            ContractResult<string> result = new ContractResult<string>();
            var dictParam = new Dictionary<string, string>
            {
                { "secret", secretKey },
                { "appid", $"{appId}" },
                { "grant_type", "client_credential" }
            };

            string accessTokenUrl = WeChatSettingsUtil.Settings.AccessTokenUrl;
            AccessTokenMpResult response = HttpClientUtil.GetResponse<AccessTokenMpResult>(accessTokenUrl, dictParam);
            if (response.ErrorCode != "0")
            {
                result.SetError(response.ErrorCode, response.ErrorMessage);
                return result;
            }

            result.Data = response.Access_Token;
            return result;
        }
    }
}