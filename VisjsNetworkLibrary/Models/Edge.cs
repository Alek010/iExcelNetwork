// Ignore Spelling: Visjs

using Newtonsoft.Json;

namespace VisjsNetworkLibrary.Models
{
    public class Edge
    {
        [JsonProperty("from")]
        public int From { get; set; }

        [JsonProperty("to")]
        public int To { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("label")]
        public string Count { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("dashes")]
        public bool IsDashed { get; set; }
    }
}
