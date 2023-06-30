using System;
using System.Collections.Generic;

namespace Weather
{
    [Serializable]
    public class WeatherApp
    {
        private ObservableDictionary<string, object> weatherCache;
        public const string way = "weather.bin";
        public WeatherApp()
        {
            weatherCache = new ObservableDictionary<string, object>();
            weatherCache.ItemAdded += OnWeatherAdded;
            weatherCache.ItemRemoved += OnWeatherRemoved;
            LoadWeatherData(way);

            if (weatherCache == null)
                weatherCache = new ObservableDictionary<string, object>();

            weatherCache.Dispose();
        }

        /// <summary>
        /// Метод добавления данных в кэш
        /// </summary>
        /// <param name="city"> Название города </param>
        /// <param name="weatherData"> Данные о погоде </param>
        public void Add(string city, object weatherData)
        {           
            weatherCache.Add(city, weatherData);
        }

        /// <summary>
        /// Метод сохранения кэша по указанному пути
        /// </summary>
        /// <param name="filePath"> Путь к файлу в торобый производится сохранение</param>
        public void Save(string filePath)
        {
            Storage.Save(weatherCache, filePath);
        }

        /// <summary>
        /// Загруска массива байтов с данными с предыдущей сессии работы программы
        /// </summary>
        /// <param name="filePath"> Путь к файлу в торобый производится сохранение</param>
        public void LoadWeatherData(string filePath)
        {
            var dict = Storage.Load<Dictionary<string, object>>(filePath);
            if(dict != null)
            {
                weatherCache = Storage.Load<ObservableDictionary<string, object>>(filePath);
                weatherCache.ItemAdded += OnWeatherAdded;
            }
                
        }

        /// <summary>
        /// Вызываемое событие при добавлении данных в кэш
        /// </summary>
        /// <param name="city">Имя города</param>
        /// <param name="data">Данные о погоде</param>
        private void OnWeatherAdded(string city, object data)
        {
            Console.WriteLine($"Weather added for {city}");
        }

        /// <summary>
        ///  Вызываемое событие при удалении данных из кэша
        /// </summary>
        /// <param name="city">Имя города</param>
        private void OnWeatherRemoved(string city)
        {
            Console.WriteLine($"Weather removed for {city}");
        }

    }
}
