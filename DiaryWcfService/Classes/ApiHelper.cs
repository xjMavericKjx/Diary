using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace DiaryWcfService.Classes
{
    public static class ApiHelper
    {
        public enum SerializeType
        {
            JSON = 1,
            XML = 2
        }

        public static string Salt = "$2a$11$pJbur0SqSGg0tCcjMeMZ0e";

        /// <summary>
        /// Получает версию файла проекта из AssemblyInfo
        /// </summary>
        /// <returns>Версия api сервиса</returns>
        public static string GetApiVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion;
        }

        public static string GetMD5Hash(string inputString)
        {
            var data = Encoding.Unicode.GetBytes(inputString);
            var md5 = MD5.Create();
            var result = md5.ComputeHash(data);
            var resultString = BitConverter.ToString(result).Replace("-", string.Empty);
            md5.Dispose();

            return resultString;
        }

        public static string XmlSerializeToString(this object objectInstance)
        {
            var serializer = new XmlSerializer(objectInstance.GetType());

            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8);

            serializer.Serialize(streamWriter, objectInstance);
            memoryStream.Position = 0;
            var sr = new StreamReader(memoryStream, Encoding.UTF8);
            var utf8EncodedXml = sr.ReadToEnd();
            sr.Dispose();            
            streamWriter.Dispose();
            memoryStream.Dispose();

            return utf8EncodedXml;
        }

        public static T XmlDeserializeFromString<T>(string objectData)
        {
            return (T)XmlDeserializeFromString(objectData, typeof(T));
        }

        public static object XmlDeserializeFromString(string objectData, Type type)
        {
            var serializer = new XmlSerializer(type);
            object result;

            using (TextReader reader = new StringReader(objectData))
            {
                result = serializer.Deserialize(reader);
            }

            return result;
        }
    }
}