using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestSupport.Models
{
    public class UserModel
    {
        public UserModel() { }

        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "address")]
        public AddressModel Address { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "website")]
        public string Website { get; set; }

        [JsonProperty(PropertyName = "company")]
        public CompanyModel Company { get; set; }

        public override bool Equals(object obj)
        {
            var model = obj as UserModel;
            return model != null &&
                   ID == model.ID &&
                   Name == model.Name &&
                   Username == model.Username &&
                   Email == model.Email &&
                   EqualityComparer<AddressModel>.Default.Equals(Address, model.Address) &&
                   Phone == model.Phone &&
                   Website == model.Website &&
                   EqualityComparer<CompanyModel>.Default.Equals(Company, model.Company);
        }

        public override int GetHashCode()
        {
            var hashCode = 435790814;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Username);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<AddressModel>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Phone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Website);
            hashCode = hashCode * -1521134295 + EqualityComparer<CompanyModel>.Default.GetHashCode(Company);
            return hashCode;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
