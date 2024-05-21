using Newtonsoft.Json;

namespace iExcelNetwork.VisJsNetwork.Model
{
    public class Node
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
