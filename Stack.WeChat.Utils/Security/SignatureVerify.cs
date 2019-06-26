using System;

namespace Stack.WeChat.Utils.Security
{
    /// <summary>
    /// 签名验证工具类
    /// </summary>
    public class SignatureVerify
    {
        /// <summary>
        /// 验证消息的确来自微信服务器
        /// 开发者提交信息后，微信服务器将发送GET请求到填写的服务器地址URL上，GET请求携带参数如下表所示
        /// 1. 将token、timestamp、nonce三个参数进行字典序排序
        /// 2. 将三个参数字符串拼接成一个字符串进行sha1加密
        /// 3. 开发者获得加密后的字符串可与signature对比，表示该请求来源于微信
        /// </summary>
        /// <param name="signature">微信加密签名，signature结合了开发者填写的token参数和请求中的timestamp参数、nonce参数</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="nonce">随机数</param>
        /// <param name="echostr">随机字符串</param>
        /// <param name="token">token密钥</param>
        /// <returns></returns>
        public static bool CheckSignature(string signature, string timestamp, string nonce, string echostr, string token)
        {
            if (string.IsNullOrEmpty(signature) || string.IsNullOrEmpty(timestamp)
                || string.IsNullOrEmpty(nonce) || string.IsNullOrEmpty(echostr) || string.IsNullOrEmpty(token))
            {
                return false;
            }

            string[] paramArray = new string[] { token, timestamp, nonce };
            Array.Sort(paramArray);//字典序排序
            string paramStrings = string.Join("", paramArray);//加密前字符串
            string sha1ParamStrings = Encrypt.SHA1(paramStrings);//加密后字符串
            return sha1ParamStrings.ToLower() == signature.ToLower();//验证签名是否相等
        }
    }
}