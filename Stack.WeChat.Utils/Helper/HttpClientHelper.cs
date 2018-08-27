using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Stack.WeChat.Utils.Helper
{
    /// <summary>
    /// Http客户端请求帮助类
    /// </summary>
    public class HttpClientHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly HttpClient _httpClient;

        /// <summary>
        /// 
        /// </summary>
        static HttpClientHelper()
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
            _httpClient = new HttpClient(handler);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="args"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static string GetResponse(string url, Dictionary<string, string> args = null, Dictionary<string, string> headers = null)
        {
            HttpResponseMessage httpResponseMessage = GetHttpResponseMessage(url, args, headers);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return httpResponseMessage.Content.ReadAsStringAsync().Result;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="args"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static T GetResponse<T>(string url, Dictionary<string, string> args = null, Dictionary<string, string> headers = null) where T : class, new()
        {
            HttpResponseMessage httpResponseMessage = GetHttpResponseMessage(url, args, headers);
            T result = null;
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return result;
            }
            return JsonConvert.DeserializeObject<T>(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="args"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        private static HttpResponseMessage GetHttpResponseMessage(string url, Dictionary<string, string> args = null, Dictionary<string, string> headers = null)
        {
            string text = "";
            Dictionary<string, string>.Enumerator enumerator;
            if (args != null)
            {
                enumerator = args.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        KeyValuePair<string, string> current = enumerator.Current;
                        text = text + current.Key + "=" + current.Value + "&";
                    }
                }
                finally
                {
                    ((IDisposable)enumerator).Dispose();
                }
                text = "?" + text.TrimEnd(new char[1] { '&' });
            }
            if (headers != null)
            {
                enumerator = headers.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        KeyValuePair<string, string> current2 = enumerator.Current;
                        _httpClient.DefaultRequestHeaders.Add(current2.Key, current2.Value);
                    }
                }
                finally
                {
                    ((IDisposable)enumerator).Dispose();
                }
            }
            url += text;
            return _httpClient.GetAsync(url).Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static string PostResponse(string url, string postData, Dictionary<string, string> headers = null)
        {
            HttpContent httpContent = new StringContent(postData, Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            HttpResponseMessage result = _httpClient.PostAsync(url, httpContent).Result;
            if (result.IsSuccessStatusCode)
            {
                return result.Content.ReadAsStringAsync().Result;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static string PostResponse<T>(string url, T postData, Dictionary<string, string> headers = null) where T : class, new()
        {
            string result = "";
            IsoDateTimeConverter val = new IsoDateTimeConverter();
            string jsonValue = JsonConvert.SerializeObject(postData, Formatting.Indented, val);
            StringContent content = new StringContent(jsonValue, Encoding.UTF8, "application/json");
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            HttpResponseMessage result2 = _httpClient.PostAsync(url, content).Result;
            if (result2.IsSuccessStatusCode)
            {
                result = result2.Content.ReadAsStringAsync().Result;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static T PostResponse<T>(string url, string postData, Dictionary<string, string> headers = null) where T : class, new()
        {
            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            T result = null;
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            HttpResponseMessage result2 = _httpClient.PostAsync(url, httpContent).Result;
            if (!result2.IsSuccessStatusCode)
            {
                return result;
            }
            return JsonConvert.DeserializeObject<T>(result2.Content.ReadAsStringAsync().Result);
        }
    }
}