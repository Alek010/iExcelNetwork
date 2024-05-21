// Ignore Spelling: json

using iExcelNetwork.VisJsNetwork.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace iExcelNetwork.VisJsNetwork
{
    public class FromToRangeData
    {
        private string _jsonFromToRange;
        private List<FromToRange> _fromToRangeList = new List<FromToRange>();

        public List<string> FromNodesLabels;
        public List<string> ToNodesLabels;

        public FromToRangeData(string jsonFromToRange)
        {
            _jsonFromToRange = jsonFromToRange;
        }

        public void ProcessData()
        {
            DeserializeJson();
            GetFromValues();
            GetToValues();
        }

        private void DeserializeJson()
        {
            _fromToRangeList = JsonConvert.DeserializeObject<List<FromToRange>>(_jsonFromToRange);
        }

        private void GetFromValues()
        {
            FromNodesLabels = _fromToRangeList.Select(range => range.From = string.IsNullOrWhiteSpace(range.From) ? "" : range.From)
                             .ToList();
        }

        private void GetToValues()
        {
            ToNodesLabels = _fromToRangeList.Select(range => range.To = string.IsNullOrWhiteSpace(range.To) ? "" : range.To)
                           .ToList();
        }
    }
}
