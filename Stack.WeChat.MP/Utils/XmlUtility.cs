﻿/**************************************************************************
*   
*   =======================================================================
*   CLR 版本    ：4.0.30319.42000
*   命名空间    ：Stack.WeChat.MP.Utils
*   文件名称    ：XmlUtility.cs
*   =======================================================================
*   创 建 者    ：李廷礼
*   创建日期    ：2019/6/27 17:33:31 
*   邮    箱    ：litingxian@live.cn
*   个人主站    ：https://github.com/tingli1991
*   功能描述    ：
*   使用说明    ：
*   ========================================================================
*   修改者      ：
*   修改日期    ：
*   修改内容    ：
*   ========================================================================
*  
***************************************************************************/

using Newtonsoft.Json;
using Stack.WeChat.DataContract.MessageHandlers;
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Stack.WeChat.MP.Utils
{
    /// <summary>
    /// XML 工具类
    /// </summary>
    public class XmlUtility
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="xml">XML字符串</param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string xml) where T : IMessageModel
        {
            try
            {
                var root = new XmlRootAttribute("xml");
                var serializer = new XmlSerializer(typeof(T), root);
                using (var reader = new StringReader(xml))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default;
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(Stream stream) where T : IMessageModel
        {
            var root = new XmlRootAttribute("xml");
            var serializer = new XmlSerializer(typeof(T), root);
            return (T)serializer.Deserialize(stream);
        }

        /// <summary>
        /// 序列化
        /// 说明：此方法序列化复杂类，如果没有声明XmlInclude等特性，可能会引发“使用 XmlInclude 或 SoapInclude 特性静态指定非已知的类型。”的错误。
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string SerializeObject<T>(T message) where T : IMessageModel
        {
            var root = new XmlRootAttribute("xml");
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), root);
            try
            {
                xmlSerializer.Serialize(memoryStream, message);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            memoryStream.Position = 0L;
            StreamReader streamReader = new StreamReader(memoryStream);
            string result = streamReader.ReadToEnd();
            streamReader.Dispose();
            memoryStream.Dispose();
            return result;
        }

        /// <summary>
        /// 序列化将流转成XML字符串
        /// </summary>
        /// <param name="stream">文件流</param>
        /// <returns></returns>
        public static XDocument SerializeObject(Stream stream)
        {
            if (stream.CanSeek)
            {
                stream.Seek(0L, SeekOrigin.Begin);
            }
            using (XmlReader reader = XmlReader.Create(stream))
            {
                return XDocument.Load(reader);
            }
        }
    }
}