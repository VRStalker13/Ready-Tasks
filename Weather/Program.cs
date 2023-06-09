using System;
using System.Linq;
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

        public static void Main()
        {
            var prog = new Program();
            prog.ChooseCity();
            prog.WeatherShow();
            Console.ReadKey();
        }

        public void ChooseCity()
        {
            Menu();
            var index = GetCityType();
            var name = (CityesEnum)index;
            Console.Write("Your choosen name is: ");
            Console.WriteLine(_cityName = name == CityesEnum.Other ? Console.ReadLine() : $"{name}" ); 

        }

        public void Menu()
        {
            var cityNames = Enum.GetNames(typeof(CityesEnum));
            Console.WriteLine("Please choose a name of city");

            for (var i = 0; i < cityNames.Length; i++)
                Console.WriteLine($"{i + 1}.{cityNames[i]}");

            Console.WriteLine("------------------------------");
        }
        public int GetCityType()
        {
            var index = 0;
            var cityNames = Enum.GetNames(typeof(CityesEnum));

            while (index < 1 || index > cityNames.Length)
            {
                Console.Write("Your choosen nuber is: ");

                if (!int.TryParse(Console.ReadLine(), out index))
                    Console.WriteLine("\nError: \" You write not existing number \" ");
            }

            return index;
        }

        // Метод вывода погоды на данный момент
        public async void WeatherShow()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("What type of weather do you want");
            Console.WriteLine("1. For 1 Day ");
            Console.WriteLine("2. For 5 Days ");            
            var index = 0;

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
                    // Выводим информацию о погоде сейчас
                    Console.WriteLine($"Current weather in {_cityName}: {weatherData.Weather[0].Description}, temperature: {weatherData.Main.Temperature}°C, humidity: {weatherData.Main.Humidity}%");
                    break;
                case 2:
                    // Получаем прогноз погоды на 5 дней для выбранного города
                    var forecastData = await GetWeathers();
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
        }

        // Получаем погоду для введенного города на данный момент , если данные не корректны запрашиваем ввод снова
        public async Task<WeatherData> GetWeather()
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
        

        public async Task<ForecastsData> GetWeathers()
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