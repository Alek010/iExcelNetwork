using Newtonsoft.Json;

namespace GraphVisualizationLibrary.Models
{
    public class Edge
    {
        [JsonProperty("from")]
        public int From { get; set; }

        [JsonProperty("to")]
        public int To { get; set; }

        [JsonProperty("label")]
        public string Count { get; set; }
    }
}
