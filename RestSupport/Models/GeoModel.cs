using Newtonsoft.Json;

namespace RestSupport.Models
{
    public class GeoModel
    {
        public GeoModel() { }

        [JsonProperty(PropertyName = "lat")]
        public float Street { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public float Suite { get; set; }

    }
}
