using System;
using Newtonsoft.Json;

namespace Weather
{
    [Serializable]
    public class ForecastItem : WeatherData
    {
        [JsonProperty("Dt_Txt")]
        public DateTime Data;
    }
}
