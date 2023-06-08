using System.Collections.Generic;

namespace Weather
{
    public class WeatherData
    {
        public MainData Main { get; set; }
        public List<Weather> Weather { get; set; }
    }
}
