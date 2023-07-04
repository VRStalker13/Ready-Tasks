using System;
using Newtonsoft.Json;

namespace Weather
{
    /// <summary>
    /// Класс в котором зраняться значение температуры и влажности
    /// </summary>
    [Serializable]
    public class MainData
    {
        /// <summary>
        /// Температура значение
        /// </summary>
        [JsonProperty("Temp")]
        public float Temperature;
        /// <summary>
        /// Влажность значение
        /// </summary>
        public int Humidity;
    }
}
