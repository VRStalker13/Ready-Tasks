using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Weather
{
    public class Program
    {
        /// <summary>
        /// Имя города
        /// </summary>
        private string _CityName;
        /// <summary>
        /// 
        /// </summary>
        private const string _Units = "metric";
        /// <summary>
        /// Api ключ доступа
        /// </summary>        
        private const string _Appid = "78dceb86a6d5f1f8a93172f682e96402";
        /// <summary>
        /// Ссылка на сайт
        /// </summary>        
        private const string _Site = "https://api.openweathermap.org/data/2.5";
        /// <summary>
        /// Данные о погоде
        /// </summary>
        private static object _Obj;

        /// <summary>
        /// Функция выполнения программного кода
        /// </summary>        
        private static void Main()
        {
            var weatherApp = new WeatherApp();           

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose:");
                Console.WriteLine("1. Choose a city ");
                Console.WriteLine("2. Close and save ");
                Console.Write("Your choosen number is: ");

                if (!int.TryParse(Console.ReadLine(), out var num))
                    Console.WriteLine("\nError: \" You write not existing number \" ");

                switch(num)
                {
                    case 1:
                        var prog = new Program();
                        prog.ChooseCity();
                        prog.WeatherShow();
                        Console.ReadKey();
                        weatherApp.Add(prog._CityName, _Obj);
                        weatherApp._weatherCache.Dispose();
                        break;
                    case 2:
                        weatherApp.Save(WeatherApp.Way);
                        return;
                    default:
                        Console.WriteLine("Please try again!");
                        break;
                }
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Метод выбора нужного города
        /// </summary>
        private void ChooseCity()
        {
            Menu();
            _CityName = GetCityType();
            Console.Write("Your choosen name is: ");
            Console.WriteLine(_CityName); 
        }

        /// <summary>
        /// Метод который выводит список доступных городов для выбора
        /// </summary>
        private void Menu()
        {
            var cityNames = Enum.GetNames(typeof(CityNamesEnum));
            Console.WriteLine("Please choose a name of city");

            for (var i = 0; i < cityNames.Length; i++)
                Console.WriteLine($"{i + 1}.{cityNames[i]}");

            Console.WriteLine("------------------------------");
        }

        /// <summary>
        /// Метод осуществления проверки корректности введенных данных и получения города выбранного пользователем
        /// </summary>
        /// <returns> название города </returns>
        private string GetCityType()
        {
            var index = 0;
            var cityNames = Enum.GetNames(typeof(CityNamesEnum));

            while (index < 1 || index > cityNames.Length)
            {
                Console.Write("Your choosen nuber is: ");

                if (!int.TryParse(Console.ReadLine(), out index))
                    Console.WriteLine("\nError: \" You write not existing number \" ");
            }

            var type = (CityNamesEnum)index;
            return type == CityNamesEnum.Other ? Console.ReadLine() : $"{type}";
        }

        /// <summary>
        /// Метод вывода на экран данных полученных для выбранного пользователем города
        /// </summary>
        /// <returns> Объект в котором хранятся данные </returns>
        private async void WeatherShow()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("What type of weather do you want");
            Console.WriteLine("1. For 1 Day ");
            Console.WriteLine("2. For 5 Days ");            
            var index = 0;
            _Obj = null;

            while(true)
            {
                Console.Write("Your choosen nuber is: ");
                var result = int.TryParse(Console.ReadLine(), out index);
                
                if (result && index > 0 && index < 3)
                    break;
            }

            switch (index)
            {
                case 1:
                    // Получаем погоду для выбранного города
                    var weatherData = await GetWeather();
                    _Obj = weatherData;
                    // Выводим информацию о погоде сейчас
                    Console.WriteLine($"Current weather in {_CityName}: {weatherData.Weather[0].Description}, " +
                        $"temperature: {weatherData.Main.Temperature}°C, humidity: {weatherData.Main.Humidity}%");
                    break;
                case 2:
                    // Получаем прогноз погоды на 5 дней для выбранного города
                    var forecastData = await GetWeathers();
                    _Obj = forecastData;
                    // Выводим информацию о прогнозе погоды
                    Console.WriteLine($"Weather forecast for {_CityName}:");

                    foreach (var forData in forecastData.List)
                    {
                        Console.WriteLine($"                                  {forData.Data}:                                    ");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        Console.WriteLine($"{ forData.Weather[0].Description}, temperature: { forData.Main.Temperature}°C," +
                                          $" humidity: {forData.Main.Humidity}%\n\n");
                    }
                    break;
            }
        }

        /// <summary>
        /// Получаем погоду для введенного города на данный момент , если данные не корректны запрашиваем ввод снова
        /// </summary>
        private async Task<WeatherData> GetWeather()
        {
            using (var webClient = new HttpClient())
            {
                while (true)
                {
                    try
                    {
                        var data = await webClient.GetStringAsync($"{_Site}/weather?q={_CityName}&units={_Units}&appid={_Appid}");
                        return JsonConvert.DeserializeObject<WeatherData>(data);
                    }
                    catch 
                    {                        
                        Console.Write("Something went wrong");
                        Console.ReadLine();
                    }
                }
            }            
        }

        /// <summary>
        /// Получение погоды на промежутке времени
        /// </summary>
        /// <returns> Данные о погоде </returns>
        private async Task<ForecastsData> GetWeathers()
        {
            using (var webClient = new HttpClient())
            {
                while (true)
                {
                    try
                    {
                        var data = await webClient.GetStringAsync($"{_Site}/forecast?q={_CityName}&units={_Units}&appid={_Appid}");
                        return JsonConvert.DeserializeObject<ForecastsData>(data);
                    }
                    catch
                    {
                        Console.Write("Something went wrong");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}