using System.Security.Cryptography;
using System.Text;

namespace Stack.WeChat.Tools.Security
{
    /// <summary>
    /// 工具类加密
    /// </summary>
    public class Encrypt
    {
        /// <summary>
        /// 生成SHA1加密字符串
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>经过SHA1加密后的字符串</returns>
        public static string SHA1(string source)
        {
            SHA1 provider = new SHA1CryptoServiceProvider();
            byte[] buffer = Encoding.Default.GetBytes(source);
            byte[] hashData = provider.ComputeHash(buffer);
            StringBuilder sbHash = new StringBuilder();
            foreach (var hash in hashData)
            {
                sbHash.Append(hash.ToString("x2"));
            }
            return sbHash.ToString();
        }
    }
}