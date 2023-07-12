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
        /// <summary>
        /// Данные о температуре и влажности
        /// </summary>
        public MainData Main;

        /// <summary>
        /// Описание погоды
        /// </summary>
        public List<Weather> Weather;
    }
}
