using System;
using System.Collections.Generic;

namespace Weather
{   
    /// <summary>
    /// Класс обработчик данных о погоде
    /// </summary>
    public class WeatherApp
    {
        /// <summary>
        /// Словарь в котором зранятся данные предыдущих запросов о погоде
        /// </summary>
        public ObservableDictionary<string, object> _weatherCache;
        /// <summary>
        /// Путь к файлу в котором хранятся данные полученных значений о погоде с предыдущей сессий
        /// </summary>
        public const string Way = "weather.bin";
        public WeatherApp()
        {
            _weatherCache = new ObservableDictionary<string, object>();
            _weatherCache.ItemAdded += OnWeatherAdded;
            _weatherCache.ItemRemoved += OnWeatherRemoved;
            LoadWeatherData(Way);

            if (_weatherCache == null)
                _weatherCache = new ObservableDictionary<string, object>();
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
                _weatherCache = Storage.Load<ObservableDictionary<string, object>>(filePath);
                _weatherCache.ItemAdded += OnWeatherAdded;
            }
                
        }

        /// <summary>
        /// Метод добавления данных в кэш
        /// </summary>
        /// <param name="city"> Название города </param>
        /// <param name="weatherData"> Данные о погоде </param>
        public void Add(string city, object weatherData)
        {
            _weatherCache.Add(city, weatherData);
        }

        /// <summary>
        /// Метод сохранения кэша по указанному пути
        /// </summary>
        /// <param name="filePath"> Путь к файлу в торобый производится сохранение</param>
        public void Save(string filePath)
        {
            Storage.Save(_weatherCache, filePath);
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
