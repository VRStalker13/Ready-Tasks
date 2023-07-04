using System;
using System.Collections.Generic;

namespace Weather
{
    /// <summary>
    /// Класс который хранит данные о погоде в городе в данный момент
    /// </summary>
    [Serializable]
    public class WeatherData
    {
        public MainData Main;
        public List<Weather> Weather;
    }
}
