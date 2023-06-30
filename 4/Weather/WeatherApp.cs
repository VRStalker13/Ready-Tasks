using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
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
            weatherCache = Storage.Load<ObservableDictionary<string, object>>(filePath);
            if(weatherCache!=null)
            weatherCache.ItemAdded += OnWeatherAdded;
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
