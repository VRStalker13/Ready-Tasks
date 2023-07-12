using System.Text;
using Newtonsoft.Json;

namespace Weather
{
    /// <summary>
    /// Класс расширение для Object
    /// </summary>    
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
            var json = Encoding.UTF8.GetString(bytes);
            return (T)JsonConvert.DeserializeObject(json);            
        }
    }
}
