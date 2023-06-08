using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Weather
{
    public class Program
    {
        public static string cityName;
        public static string Units = "metric";
        public static string Appid = "78dceb86a6d5f1f8a93172f682e96402";
        public static string Site = "https://api.openweathermap.org/data/2.5";

        public static void Main()
        {
            var prog = new Program();
            ChooseCity();
            prog.WeatherShow();
            Console.ReadKey();
        }

        // Список городов, для которых реализована возможность получения погоды
        public enum CityesEnum
        {
            Moscow = 1,
            Berlin,
            London,
            Minsk,
            Paris,
            Other
        }
        public static void ChooseCity()
        {
            var index = Menu();
            var name = (CityesEnum)index;
            Console.Write("Your choosen name is: ");
            Console.WriteLine(cityName = name == CityesEnum.Other ? Console.ReadLine() : $"{name}" ); 

        }

        public static int Menu()
        {
            Console.WriteLine("Please choose a name of city");
            Console.WriteLine("2. Berlin");
            Console.WriteLine("3. London");
            Console.WriteLine("4. Minsk");
            Console.WriteLine("5. Paris");
            Console.WriteLine("6. Other");
            Console.WriteLine("------------------------------");
            var index = 0;
            var cityNames = Enum.GetNames(typeof(CityesEnum));

            while (index < 1 || index > cityNames.Length)
            {
                Console.Write("Your choosen nuber is: ");

                if (!int.TryParse(Console.ReadLine(), out index))
                    Console.WriteLine("\nError: \" You write not exhist number \" ");
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

                if (int.TryParse(Console.ReadLine(), out index))
                    if (index > 0 && index < 3)
                        break;
            }

            switch (index)
            {
                case 1:
                    // Получаем погоду для выбранного города
                    var weatherData = await GetWeather();
                    // Выводим информацию о погоде сейчас
                    Console.WriteLine($"Current weather in {cityName}: {weatherData.Weather[0].Description}, temperature: {weatherData.Main.Temp}°C, humidity: {weatherData.Main.Humidity}%");
                    break;
                case 2:
                    // Получаем прогноз погоды на 5 дней для выбранного города
                    var forecastData = await GetWeathers();
                    // Выводим информацию о прогнозе погоды
                    Console.WriteLine($"Weather forecast for {cityName}:");

                    foreach (var forData in forecastData.List.Take(forecastData.List.Count))
                    {
                        Console.WriteLine($"                                  {forData.Dt_Txt}:                                    ");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        Console.WriteLine($"{ forData.Weather[0].Description}, temperature: { forData.Main.Temp}°C," +
                                          $" humidity: {forData.Main.Humidity}%\n\n");
                    }
                    break;
                default:
                    break;
            }
        }

        // Получаем погоду для введенного города на данный момент , если данные не корректны запрашиваем ввод снова
        public async Task<WeatherData> GetWeather()
        {
            string data = null;
            bool isTrue = true;

            using (var webClient = new HttpClient())
            {
                while (isTrue)
                {
                    try
                    {
                        data = await webClient.GetStringAsync($"{Site}/weather?q={cityName}&units={Units}&appid={Appid}");
                    }
                    catch 
                    {                        
                        Console.Write("Something went wrong, write again name of City:");
                        cityName = Console.ReadLine();
                    }
                }
            }            
            return JsonConvert.DeserializeObject<WeatherData>(data);
        }             

        public async Task<ForecastsData> GetWeathers()
        {
            string data = null;
            bool isTrue = true;

            using (var webClient = new HttpClient())
            {
                while (isTrue)
                {
                    try
                    {
                        data = await webClient.GetStringAsync($"{Site}/forecast?q={cityName}&units={Units}&appid={Appid}");
                    }
                    catch
                    {
                        Console.Write("Something went wrong, write again name of City:");
                        cityName = Console.ReadLine();
                    }
                    finally
                    {
                        isTrue = false;
                    }
                }
            }

            return JsonConvert.DeserializeObject<ForecastsData>(data);
        }
    }
}