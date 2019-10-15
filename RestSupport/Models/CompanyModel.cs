using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestSupport.Models
{
    public class CompanyModel
    {
        public CompanyModel() { }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonProperty(PropertyName = "bs")]
        public string BS { get; set; }

        public override bool Equals(object obj)
        {
            var model = obj as CompanyModel;
            return model != null &&
                   Name == model.Name &&
                   CatchPhrase == model.CatchPhrase &&
                   BS == model.BS;
        }

        public override int GetHashCode()
        {
            var hashCode = -542953119;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CatchPhrase);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BS);
            return hashCode;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}