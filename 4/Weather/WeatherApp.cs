using System;
using System.Collections.Generic;

namespace Weather
{
    [Serializable]
    public class WeatherApp
    {
        private ObservableDictionary<string, object> weatherCache = new ObservableDictionary<string, object>();
        public WeatherApp()
        {
            weatherCache.ItemAdded += OnWeatherAdded;
            weatherCache.ItemRemoved += OnWeatherRemoved;
        }
        public void AddCity(string city, object weatherData)
        {           
            weatherCache.Add(city, weatherData);
        }
        public void SaveWeatherData(string filePath)
        {
            Storage.Save(weatherCache, filePath);
        }
        public void LoadWeatherData(string filePath)
        {
            var dict = Storage.Load<Dictionary<string, object>>(filePath);
            if(dict != null)
            {
                weatherCache = Storage.Load<ObservableDictionary<string, object>>(filePath);
                weatherCache.ItemAdded += OnWeatherAdded;
            }
                
        }
        private void OnWeatherAdded(string city, object data)
        {
            Console.WriteLine($"Weather added for {city}");
        }

        private void OnWeatherRemoved(string city)
        {
            Console.WriteLine($"Weather removed for {city}");
        }

    }
}
