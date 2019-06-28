using Microsoft.Extensions.Configuration;
using Stack.WeChat.DataContract.Config;
using System.IO;
using System.Linq;

namespace Stack.WeChat.MP.Config
{
    /// <summary>
    /// 微信配置
    /// </summary>
    public class WeChatSettingsUtil
    {
        /// <summary>
        /// 私有构造函数，禁止使用new关键字创建对象
        /// </summary>
        private WeChatSettingsUtil() { }

        /// <summary>
        /// 配置文件
        /// </summary>
        private static IConfiguration Configuration;

        /// <summary>
        /// 线程对象锁
        /// </summary>
        private static readonly object lock_Obj = new object();

        /// <summary>
        /// 配置文件名称
        /// </summary>
        private static readonly string _fileName = "WeChatSettings.json";

        /// <summary>
        /// 配置信息
        /// </summary>
        public static WeChatSettings Settings { get => GetSettings(); }

        /// <summary>
        /// 获取Json配置
        /// </summary>
        /// <returns></returns>
        public static WeChatSettings GetSettings()
        {
            IConfiguration configuration = GetJsonConfiguration();
            return ConfigurationBinder.Get<WeChatSettings>(configuration);
        }

        /// <summary>
        /// 获取账户配置
        /// </summary>
        /// <param name="appId">AppId</param>
        /// <returns></returns>
        public static WeChatAccount GetAccountConfig(string appId)
        {
            if (string.IsNullOrEmpty(appId) || Settings.AccountList == null | !Settings.AccountList.Any())
                return null;

            return Settings.AccountList.FirstOrDefault(e => e.AppId == appId);
        }

        /// <summary>
        /// 根据文件目录+文件名称获取Json配置
        /// </summary>
        /// <returns></returns>
        private static IConfiguration GetJsonConfiguration()
        {
            string fileDir = $"{Directory.GetCurrentDirectory()}\\Config";
            string fullFileName = Path.Combine(fileDir, _fileName);
            if (Configuration == null)
            {
                lock (lock_Obj)
                {
                    if (Configuration == null)
                    {
                        ConfigurationBuilder builder = new ConfigurationBuilder();
                        IConfigurationBuilder configBuilder = FileConfigurationExtensions.SetBasePath(builder, fileDir);//设置配置文件基础目录
                        IConfigurationRoot configuration = JsonConfigurationExtensions.AddJsonFile(configBuilder, _fileName, true, true).Build();//返回编译结果
                        Configuration = configuration;
                    }
                }
            }
            return Configuration;
        }
    }
}