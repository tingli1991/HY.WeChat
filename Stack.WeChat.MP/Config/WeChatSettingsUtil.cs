using Microsoft.Extensions.Configuration;
using Stack.WeChat.DataContract.Config;
using System.IO;

namespace Stack.WeChat.MP.Config
{
    /// <summary>
    /// 微信配置
    /// </summary>
    public class WeChatSettingsUtil
    {
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
        public static readonly WeChatSettingsConfig Settings;

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static WeChatSettingsUtil()
        {
            Settings = GetSettings();
        }

        /// <summary>
        /// 获取Json配置
        /// </summary>
        /// <returns></returns>
        public static WeChatSettingsConfig GetSettings()
        {
            IConfiguration configuration = GetJsonConfiguration();
            return ConfigurationBinder.Get<WeChatSettingsConfig>(configuration);
        }

        /// <summary>
        /// 获取Json配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">配置文件的Key(格式：xxx:yyy，注意中间使用':'分割)</param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            return GetValue<string>(key);
        }

        /// <summary>
        /// 获取Json配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">配置文件的Key(格式：xxx:yyy，注意中间使用':'分割)</param>
        /// <returns></returns>
        public static T GetValue<T>(string key)
        {
            IConfiguration configuration = GetJsonConfiguration();
            return ConfigurationBinder.Get<T>(configuration);
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