using System;
using Newtonsoft.Json;

namespace Weather
{
    /// <summary>
    /// Данные о погоде в конкретную дату и время
    /// </summary>
    [Serializable]
    public class ForecastItem : WeatherData
    {
        /// <summary>
        /// Дата и время для которых указаны погода
        /// </summary>
        [JsonProperty("Dt_Txt")]
        public DateTime Data;
    }
}
