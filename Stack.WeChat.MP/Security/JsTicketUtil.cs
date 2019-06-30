using Stack.WeChat.DataContract.MpResult;
using Stack.WeChat.DataContract.Result;
using Stack.WeChat.MP.Config;
using Stack.WeChat.MP.Extensions;
using Stack.WeChat.MP.Utils;
using System;
using System.Collections.Generic;

namespace Stack.WeChat.MP.Security
{
    /// <summary>
    /// jsdk票据工具类
    /// </summary>
    public class JsTicketUtil
    {
        /// <summary>
        /// 随机因子
        /// </summary>
        public static Random random = new Random();

        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="secretKey"></param>
        /// <param name="pageUrl">h5页面地址</param>
        /// <returns></returns>
        public static ContractResult<WeChatSignatureResult> GetJsApiTicket(string appId, string secretKey, string pageUrl)
        {
            long timestamp = DateTime.Now.ToUnixTime();
            string noncestr = random.GenString(32, true, false, true, false, "");
            ContractResult<WeChatSignatureResult> result = new ContractResult<WeChatSignatureResult>();
            var signatureResult = GetJsApiTicket(appId, secretKey, noncestr, timestamp, pageUrl);
            if (signatureResult.ErrorCode != "0")
            {
                result.SetError(signatureResult.ErrorCode, signatureResult.ErrorMessage);
                return result;
            }

            result.Data = new WeChatSignatureResult()
            {
                NonceStr = noncestr,
                Timestamp = timestamp,
                AppId = appId,
                Signature = signatureResult.Data
            };
            return result;
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="secretKey"></param>
        /// <param name="noncestr"></param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="pageUrl">h5页面地址</param>
        /// <param name="account">微信账户配置</param>
        /// <returns></returns>
        private static ContractResult<string> GetJsApiTicket(string appId, string secretKey, string noncestr, long timestamp, string pageUrl)
        {
            ContractResult<string> result = new ContractResult<string>();
            var ticketResult = GetJsApiTicket(appId, secretKey);
            if (ticketResult.ErrorCode != "0")
            {
                result.SetError(ticketResult.ErrorCode, ticketResult.ErrorMessage);
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
        /// <param name="account">微信账户配置</param>
        /// <returns></returns>
        private static ContractResult<string> GetJsApiTicket(string appId, string secretKey)
        {
            ContractResult<string> result = new ContractResult<string>();
            var tokenResult = AccessTokenUtil.GetAccessToken(appId, secretKey);
            if (tokenResult.ErrorCode != "0")
            {
                result.SetError(tokenResult.ErrorCode, tokenResult.ErrorMessage);
                return result;
            }

            var apiUrl = $"{WeChatSettingsUtil.Settings.JSAPITicketApiUrl}&access_token={tokenResult.Data}";
            JsApiTicketMpResult response = HttpClientUtil.GetResponse<JsApiTicketMpResult>(apiUrl);
            if (response.ErrorCode != 0)
            {
                result.SetError($"{response.ErrorCode}", response.ErrorMessage);
                return result;
            }

            result.Data = response.Ticket;
            return result;
        }
    }
}