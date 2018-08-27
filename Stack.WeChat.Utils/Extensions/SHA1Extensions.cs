using System.Security.Cryptography;
using System.Text;

namespace Stack.WeChat.Utils.Extensions
{
    /// <summary>
    /// SHA1加解密扩展
    /// </summary>
    public static class SHA1Extensions
    {
        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Encode(this string source)
        {
            string newStr = string.Empty;
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(source));
            StringBuilder sbHash = new StringBuilder();
            foreach (var hash in hashData)
            {
                sbHash.Append(hash.ToString("x2"));
            }
            newStr = sbHash.ToString();
            return newStr;
        }
    }
}