using Newtonsoft.Json;

namespace iExcelNetwork
{
    public class Edge
    {
        [JsonProperty("from")]
        public int From { get; set; }

        [JsonProperty("to")]
        public int To { get; set; }
    }
}
