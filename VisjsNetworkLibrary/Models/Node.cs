﻿using Newtonsoft.Json;

namespace VisjsNetworkLibrary.Models
{
    public class Node
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("shape")]
        public string Shape { get; set; }

        [JsonProperty("icon")]
        public NodeIcon Icon { get; set; }
    }
}
