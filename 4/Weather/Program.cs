using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Weather
{
    public class Program
    {
        private string _cityName;
        private const string Units = "metric";
        private const string Appid = "78dceb86a6d5f1f8a93172f682e96402";
        private const string Site = "https://api.openweathermap.org/data/2.5";
        private const string way = "weather.bin";

        /// <summary>
        /// функция выполнения программного кода
        /// </summary>
        private static void Main()
        {
            var wthApp = new WeatherApp();
            wthApp.LoadWeatherData(way);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose:");
                Console.WriteLine("1. Choose a city ");
                Console.WriteLine("2. Close and save ");
                Console.Write("Your choosen number is: ");

                if (!int.TryParse(Console.ReadLine(), out int num))
                    Console.WriteLine("\nError: \" You write not existing number \" ");

                switch(num)
                {
                    case 1:
                        var prog = new Program();
                        prog.ChooseCity();
                        var obj = prog.WeatherShow();
                        Console.ReadKey();
                        wthApp.AddCity(prog._cityName, obj);
                        break;
                    case 2:
                        wthApp.SaveWeatherData(way);
                        return;
                    default:
                        Console.WriteLine("Please try again!");
                        break;
                }

                Console.ReadKey();
            }
        }

        /// <summary>
        /// метод выбора нужного города
        /// </summary>
        private void ChooseCity()
        {
            Menu();
            _cityName = GetCityType();
            Console.Write("Your choosen name is: ");
            Console.WriteLine(_cityName); 
        }

        /// <summary>
        /// метод который выводит список доступных городов для выбора
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
        /// метод осуществления проверки корректности введенных данных и получения города выбранного пользователем
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
        /// метод вывода на экран данных полученных для выбранного пользователем города
        /// </summary>
        /// <returns> объект в котором хранятся данные </returns>
        private async Task<object> WeatherShow()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("What type of weather do you want");
            Console.WriteLine("1. For 1 Day ");
            Console.WriteLine("2. For 5 Days ");            
            var index = 0;
            object obj = null;

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
                    obj = (Object)weatherData;
                    // Выводим информацию о погоде сейчас
                    Console.WriteLine($"Current weather in {_cityName}: {weatherData.Weather[0].Description}, " +
                        $"temperature: {weatherData.Main.Temperature}°C, humidity: {weatherData.Main.Humidity}%");
                    break;
                case 2:
                    // Получаем прогноз погоды на 5 дней для выбранного города
                    var forecastData = await GetWeathers();
                    obj = (Object)forecastData;
                    // Выводим информацию о прогнозе погоды
                    Console.WriteLine($"Weather forecast for {_cityName}:");

                    foreach (var forData in forecastData.List)
                    {
                        Console.WriteLine($"                                  {forData.Data}:                                    ");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        Console.WriteLine($"{ forData.Weather[0].Description}, temperature: { forData.Main.Temperature}°C," +
                                          $" humidity: {forData.Main.Humidity}%\n\n");
                    }
                    break;
            }

            return obj;
        }

        // Получаем погоду для введенного города на данный момент , если данные не корректны запрашиваем ввод снова
        private async Task<WeatherData> GetWeather()
        {
            using (var webClient = new HttpClient())
            {
                while (true)
                {
                    try
                    {
                        var data = await webClient.GetStringAsync($"{Site}/weather?q={_cityName}&units={Units}&appid={Appid}");
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


        private async Task<ForecastsData> GetWeathers()
        {
            using (var webClient = new HttpClient())
            {
                while (true)
                {
                    try
                    {
                        var data = await webClient.GetStringAsync($"{Site}/forecast?q={_cityName}&units={Units}&appid={Appid}");
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