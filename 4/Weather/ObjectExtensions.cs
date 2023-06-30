using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Weather
{
    public static class ObjectExtensions
    {
        public static byte[] GetBytes(this object data)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, data);
                return memoryStream.ToArray();
            }
        }
        public static T GetObject<T>(this byte[] bytes)
        {
            using (var memoryStream = new MemoryStream(bytes))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}
