using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestSupport.Models
{
    public class AddressModel
    {
        public AddressModel()
        {

        }

        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }

        [JsonProperty(PropertyName = "suite")]
        public string Suite { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "zipcode")]
        public string ZipCode { get; set; }

        [JsonProperty(PropertyName = "geo")]
        public GeoModel Geo {get; set; }

        public override bool Equals(object obj)
        {
            var model = obj as AddressModel;
            return model != null &&
                   Street == model.Street &&
                   Suite == model.Suite &&
                   City == model.City &&
                   ZipCode == model.ZipCode &&
                   EqualityComparer<GeoModel>.Default.Equals(Geo, model.Geo);
        }

        public override int GetHashCode()
        {
            var hashCode = -79167278;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Street);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Suite);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ZipCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<GeoModel>.Default.GetHashCode(Geo);
            return hashCode;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
