using Newtonsoft.Json;

namespace VisJsNetworkLibrary.Models
{
    public class Node
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
