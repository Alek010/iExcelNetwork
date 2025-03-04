
// Ignore Spelling: Visjs

using Newtonsoft.Json;

namespace VisjsNetworkLibrary.Models
{
    public class NodeIcon
    {
        [JsonProperty("face")]
        public string Face { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }
}
