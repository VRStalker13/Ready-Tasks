using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

namespace Weather
{
    [Serializable]
    public static class ObjectExtensions
    {
        public static byte[] GetBytes(this object data)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, data);
                return memoryStream.ToArray();
            }
        }
        public static T GetObject<T>(this byte[] bytes)
        {
            using (var memoryStream = new MemoryStream(bytes))
            {
                var binaryFormatter = new BinaryFormatter();
                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}
