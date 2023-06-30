using System.Collections.Generic;
using System;

namespace Weather
{
    [Serializable]
    public class WeatherData
    {
        public MainData Main;
        public List<Weather> Weather;
    }
}
