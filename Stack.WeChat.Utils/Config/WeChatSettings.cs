using Stack.WeChat.DataContract.Config;
using System.IO;

namespace Stack.WeChat.Utils.Config
{
    /// <summary>
    /// 微信配置
    /// </summary>
    public class WeChatSettings
    {
        /// <summary>
        /// 配置文件名称
        /// </summary>
        private static readonly string _fileName = "WeChatSettings.json";

        /// <summary>
        /// 获取Json配置
        /// </summary>
        /// <returns></returns>
        public static WeChatSettingsConfig GetConfig()
        {
            string fileDir = $"{Directory.GetCurrentDirectory()}\\Config";
            return AppSettings.GetValue<WeChatSettingsConfig>(fileDir, _fileName);
        }
    }
}