using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace Weather
{
    /// <summary>
    /// Класс расширение для Object
    /// </summary>
    [Serializable]
    public static class ObjectExtensions
    {
        /// <summary>
        /// Метод конвертации данных в байтовый тип
        /// </summary>
        /// <param name="data"> Конвертируемые данные </param>
        /// <returns> Массив байтов </returns>
        public static byte[] GetBytes(this object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return Encoding.UTF8.GetBytes(json);
            
        }

        /// <summary>
        /// Метод получения данных из массива байтов
        /// </summary>
        /// <typeparam name="T"> Класс обьекта в который передаем разконвертированные данные </typeparam>
        /// <param name="bytes"> Массив байтов </param>
        /// <returns> Разконвертированные данные  </returns>
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
