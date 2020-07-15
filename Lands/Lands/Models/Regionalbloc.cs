using Newtonsoft.Json;

namespace Lands.Models
{
    public class Regionalbloc
    {
        [JsonProperty(PropertyName = "acronym")]
        public string Acronym { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

}
