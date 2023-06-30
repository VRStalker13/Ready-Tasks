using Newtonsoft.Json;
using System;
using System.IO;

namespace Weather
{
    /// <summary>
    /// Хранилище данных.
    /// </summary>
    public static class Storage
    {
        /// <summary>
        /// Метод сохраняет данные типа T по указанному пути filePath
        /// </summary>
        /// <typeparam name="T"> Тип данных </typeparam>
        /// <param name="data"> Сохраняемый объект </param>
        /// <param name="filePath"> Путь к файлу в  котором будет произведено сохранение </param>
        public static void Save<T>(T data, string filePath)
        {
            var bytes = data.GetBytes();

            try
            {
                File.WriteAllBytes(filePath, bytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        /// <summary>
        /// Метод загрузки данных из файла
        /// </summary>
        /// <typeparam name="T"> Тип данных </typeparam>
        /// <param name="filePath"> Путь к файлу в  котором будет произведено сохранение </param>
        /// <returns> Данные загруженные из файла </returns>
        public static T Load<T>(string filePath)
        {
            try
            {
                var bytes = File.ReadAllBytes(filePath);
                return bytes.GetObject<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
                return default(T);
            }
        }
    }
}