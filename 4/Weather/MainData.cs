using Newtonsoft.Json;

namespace Weather
{
    public class MainData
    {
        [JsonProperty("Temp")]
        public float Temperature;

        public int Humidity;
    }
}
