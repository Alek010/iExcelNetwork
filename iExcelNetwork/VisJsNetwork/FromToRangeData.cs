// Ignore Spelling: json

using iExcelNetwork.Exceptions;
using iExcelNetwork.VisJsNetwork.Model;
using Newtonsoft.Json;
using System;
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
        public List<string> LinksCount;

        public FromToRangeData(string jsonFromToRange)
        {
            _jsonFromToRange = jsonFromToRange;
        }

        public void ProcessData()
        {
            DeserializeJson();
            GetFromValues();
            GetToValues();
            GetLinksCount();
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

        private void GetLinksCount()
        {
            LinksCount = _fromToRangeList.Select(range => range.Count = string.IsNullOrWhiteSpace(range.Count) ? "" : range.Count)
                        .ToList();

            if (LinksCountAreEmptyStrings())
            {
                LinksCount = GetFromToOccurrences();
            }

            Validations.SelectedRangeValidator.ValidateIfListOfIntegersAsStringsContainsNonIntegerValue(LinksCount);
        }

        private List<string> GetFromToOccurrences()
        {
            return _fromToRangeList
                    .GroupBy(_fromToRangeList => new { _fromToRangeList.From, _fromToRangeList.To })
                    .Select(group => group.Count().ToString())
                    .ToList();
        }

        private bool LinksCountAreEmptyStrings()
        {
            var uniqueValues = LinksCount.Distinct().ToList();

            return(uniqueValues.Count == 1 && string.IsNullOrWhiteSpace(uniqueValues.FirstOrDefault()));
        }
    }
}
