using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestSupport.Models
{
    public class PostModel
    {
        public PostModel() { }

        [JsonProperty(PropertyName = "userId")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        public override bool Equals(object obj)
        {
            var model = obj as PostModel;
            return model != null &&
                   UserId == model.UserId &&
                   Id == model.Id &&
                   Title == model.Title &&
                   Body == model.Body;
        }

        public override int GetHashCode()
        {
            var hashCode = -1966040659;
            hashCode = hashCode * -1521134295 + UserId.GetHashCode();
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Body);
            return hashCode;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
