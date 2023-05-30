using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Weather
{
    public class Program
    {
        string cityName = null;
        // Список городов, для которых реализована возможность получения погоды
        public enum CitiesEnum
        {
            Moscow = 1,
            Berlin,
            London,
            Minsk,
            Paris
        }
        public string ChooseCity()
        {
            Console.WriteLine("Please choose a name of city");
            Console.WriteLine("1. Moscow");
            Console.WriteLine("2. Berlin");
            Console.WriteLine("3. London");
            Console.WriteLine("4. Minsk");
            Console.WriteLine("5. Paris");
            Console.WriteLine("6. Write other name");
            Console.WriteLine("------------------------------");
            int cityNum = 0;

            while (cityNum < 1 || cityNum > 6)
            {
                Console.Write("Your choosen nuber is: ");
                if (!int.TryParse(Console.ReadLine(), out cityNum))
                {
                    Console.WriteLine("\nError: \" You write not exhist number \" ");
                }
            }

            switch (cityNum)
            {
                case (int)CitiesEnum.Moscow:
                    cityName = "Moscow";
                    break;
                case (int)CitiesEnum.Berlin:
                    cityName = "Berlin";
                    break;
                case (int)CitiesEnum.London:
                    cityName = "London";
                    break;
                case (int)CitiesEnum.Minsk:
                    cityName = "Minsk";
                    break;
                case (int)CitiesEnum.Paris:
                    cityName = "Paris";
                    break;
                case 6:
                    Console.Write(" Please write city name: ");
                    cityName = Console.ReadLine();
                    break;
            }

            return cityName;
        }

        // Метод вывода погоды на данный момент
        public async void WeatherShow()
        {

            // Получаем погоду для выбранного города
            var weatherData = await GetWeatherNowAsync();
            // Выводим информацию о погоде сейчас
            Console.WriteLine($"Current weather in {cityName}: {weatherData.Weather[0].Description}, temperature: {weatherData.Main.Temp}°C, humidity: {weatherData.Main.Humidity}%");
            // Получаем прогноз погоды на 5 дней для выбранного города
            var forecastData = await GetWeatherAsync();
            // Выводим информацию о прогнозе погоды
            Console.WriteLine($"Weather forecast for {cityName}:");

            for (var i = 0; i <= 32; i++)
            {
                Console.WriteLine($"                                  {forecastData.List[i].Dt_Txt}:                                    ");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine($"{ forecastData.List[i].Weather[0].Description}, temperature: { forecastData.List[i].Main.Temp}°C," +
                    $" humidity: {forecastData.List[i].Main.Humidity}%\n\n");

                //Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            }
        }

        // Получаем погоду для введенного города на данный момент , если данные не корректны запрашиваем ввод снова
        public async Task<WeatherData> GetWeatherNowAsync()
        {
            string json = null;
            bool isTrue = true;

            using (var webClient = new HttpClient())
            {
                while (isTrue)
                {
                    try
                    {
                        json = await webClient.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?q={cityName}&units=metric&appid=78dceb86a6d5f1f8a93172f682e96402");
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

            return JsonConvert.DeserializeObject<WeatherData>(json);
        }             

        public async Task<ForecastData> GetWeatherAsync()
        {
            string json = null;
            bool isTrue = true;

            using (var webClient = new HttpClient())
            {
                while (isTrue)
                {
                    try
                    {
                        json = await webClient.GetStringAsync($"https://api.openweathermap.org/data/2.5/forecast?q={cityName}&units=metric&appid=78dceb86a6d5f1f8a93172f682e96402");
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

            return JsonConvert.DeserializeObject<ForecastData>(json);
        }


        public static void Main(string[] args)
        {
            var prog = new Program();
            prog.ChooseCity();
            prog.WeatherShow();
            Console.ReadKey();
        }
        public class WeatherData
        {
            public MainData Main { get; set; }
            public Weather[] Weather { get; set; }
        }
        public class MainData
        {
            public float Temp { get; set; }
            public int Humidity { get; set; }
        }
        public class Weather
        {
            public string Description { get; set; }
        }
        public class ForecastData
        {
            public List<ForecastItem> List { get; set; }
        }
        public class ForecastItem
        {
            public MainData Main { get; set; }
            public Weather[] Weather { get; set; }
            public DateTime Dt_Txt { get; set; }
        }
    }
}