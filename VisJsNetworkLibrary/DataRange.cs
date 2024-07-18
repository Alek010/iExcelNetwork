// Ignore Spelling: json

using System.Collections.Generic;
using System.Linq;
using VisJsNetworkLibrary.Models;
using VisJsNetworkLibrary.Validations;

namespace VisJsNetworkLibrary
{
    public class DataRange
    {
        private List<SelectedRange> _data = new List<SelectedRange>();

        public DataRange(List<SelectedRange> data)
        {
            _data = data;
        }

        public List<string> GetFromColumnValues()
        {
            return _data.Select(range => range.From = string.IsNullOrWhiteSpace(range.From) ? "" : range.From)
                             .ToList();
        }

        public List<string> GetToColumnValues()
        {
            return _data.Select(range => range.To = string.IsNullOrWhiteSpace(range.To) ? "" : range.To)
                           .ToList();
        }

        public List<string> GetLinksCount()
        {
            List<string> LinksCount = _data.Select(range => range.Count = string.IsNullOrWhiteSpace(range.Count) ? "" : range.Count)
                        .ToList();

            if (LinksCountAreEmptyStrings(LinksCount))
            {
                LinksCount = GetFromToOccurrences();
            }

            VisJsDataValidator.ValidateIfListOfIntegersAsStringsContainsNonIntegerValue(LinksCount);

            return LinksCount;
        }

        private List<string> GetFromToOccurrences()
        {
            return _data
                    .GroupBy(_fromToRangeList => new { _fromToRangeList.From, _fromToRangeList.To })
                    .Select(group => group.Count().ToString())
                    .ToList();
        }

        private bool LinksCountAreEmptyStrings(List<string> linksCount)
        {
            var uniqueValues = linksCount.Distinct().ToList();

            return uniqueValues.Count == 1 && string.IsNullOrWhiteSpace(uniqueValues.FirstOrDefault());
        }
    }
}
