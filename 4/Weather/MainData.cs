using Newtonsoft.Json;
using System;

namespace Weather
{
    [Serializable]
    public class MainData
    {
        [JsonProperty("Temp")]
        public float Temperature;

        public int Humidity;
    }
}
