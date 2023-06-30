using System;
using Newtonsoft.Json;

namespace Weather
{
    public class ForecastItem : WeatherData
    {
        [JsonProperty("Dt_Txt")]
        public DateTime Data;
    }
}
