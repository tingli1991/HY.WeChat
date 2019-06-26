using Stack.WeChat.Contracts;
using Stack.WeChat.Contracts.Result;
using Stack.WeChat.DataContract.Config;
using Stack.WeChat.Utils.Config;
using Stack.WeChat.Utils.Extensions;
using Stack.WeChat.Utils.Helper;
using System;
using System.Collections.Generic;

namespace Stack.WeChat.Service
{
    /// <summary>
    /// 微信服务
    /// </summary>
    public class WeChatService : BaseService, IWeChatService
    {
        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="pageUrl">h5页面地址</param>
        /// <returns></returns>
        public ResponseResult<WeChatSignatureResult> GetJsApiTicket(string pageUrl)
        {
            ResponseResult<WeChatSignatureResult> result = new ResponseResult<WeChatSignatureResult>();
            try
            {
                long timestamp = DateTime.Now.ToUnixTime();
                string noncestr = random.GenString(32, true, false, true, false, "");
                WeChatSettingsConfig settings = WeChatSettings.GetConfig(); ;
                var signatureResult = GetJsApiTicket(noncestr, timestamp, pageUrl, settings);
                if (signatureResult.ErrorCode != "0")
                {
                    result.ErrorCode = signatureResult.ErrorCode;
                    result.ErrorMessage = signatureResult.ErrorMessage;
                    return result;
                }

                result.Data = new WeChatSignatureResult()
                {
                    NonceStr = noncestr,
                    AppId = settings.AppId,
                    Timestamp = timestamp,
                    Signature = signatureResult.Data
                };
            }
            catch (Exception)
            {
                //TODO:需要记录错误日志
            }
            return result;
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="noncestr"></param>
        /// <param name="timestamp"></param>
        /// <param name="pageUrl">h5页面地址</param>
        /// <returns></returns>
        public ResponseResult<string> GetJsApiTicket(string noncestr, long timestamp, string pageUrl, WeChatSettingsConfig settings)
        {
            ResponseResult<string> result = new ResponseResult<string>();
            var ticketResult = GetJsApiTicket(settings);
            if (ticketResult.ErrorCode != "0")
            {
                result.ErrorCode = ticketResult.ErrorCode;
                result.ErrorMessage = ticketResult.ErrorMessage;
                return result;
            }

            var dictParam = new SortedDictionary<string, string>
            {
                { "url", pageUrl },
                { "noncestr", noncestr },
                { "timestamp", $"{timestamp}" },
                { "jsapi_ticket", ticketResult.Data }
            };
            var source = "";
            foreach (var pair in dictParam)
            {
                source += pair.Key + "=" + pair.Value + "&";
            }
            source = source.TrimEnd('&');
            result.Data = source.Encode();
            return result;
        }

        /// <summary>
        /// 获取jsapi_ticket
        /// </summary>
        /// <returns></returns>
        private ResponseResult<string> GetJsApiTicket(WeChatSettingsConfig appSettings)
        {
            ResponseResult<string> result = new ResponseResult<string>();
            var tokenResult = GetAccessToken(appSettings);
            if (tokenResult.ErrorCode != "0")
            {
                result.ErrorCode = tokenResult.ErrorCode;
                result.ErrorMessage = tokenResult.ErrorMessage;
                return result;
            }

            var apiUrl = $"{appSettings.JSAPITicketApiUrl}&access_token={tokenResult.Data}";
            JsApiTicketResult response = HttpClientHelper.GetResponse<JsApiTicketResult>(apiUrl);
            if (response.ErrorCode != 0)
            {
                result.ErrorCode = $"{response.ErrorCode}";
                result.ErrorMessage = response.ErrorMessage;
                return result;
            }

            result.Data = response.Ticket;
            return result;
        }

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <param name="apiUrl"></param>
        /// <returns></returns>
        private ResponseResult<string> GetAccessToken(WeChatSettingsConfig appSettings)
        {
            ResponseResult<string> result = new ResponseResult<string>();
            var dictParam = new Dictionary<string, string>
            {
                { "secret", appSettings.SecretKey },
                { "appid", $"{appSettings.AppId}" },
                { "grant_type", "client_credential" }
            };

            AccessTokenResult response = HttpClientHelper.GetResponse<AccessTokenResult>(appSettings.AccessTokenUrl, dictParam);
            if (response.ErrorCode != "0")
            {
                result.ErrorCode = response.ErrorCode;
                result.ErrorMessage = response.ErrorMessage;
                return result;
            }

            result.Data = response.Access_Token;
            return result;
        }
    }
}