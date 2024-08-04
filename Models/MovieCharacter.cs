using System.Text.Json.Serialization;

namespace SwipeCardViewDemo.Models
{
    public class MovieCharacter
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("ancestry")]
        public string Ancestry { get; set; }

        [JsonPropertyName("house")]
        public string House { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}
