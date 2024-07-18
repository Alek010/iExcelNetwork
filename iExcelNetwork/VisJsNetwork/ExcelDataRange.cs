// Ignore Spelling: json

using iExcelNetwork.VisJsNetwork.Model;
using System.Collections.Generic;
using System.Linq;

namespace iExcelNetwork.VisJsNetwork
{
    public class ExcelDataRange
    {
        private List<Range> _dataRange = new List<Range>();

        public ExcelDataRange(List<Range> dataRange)
        {
           _dataRange = dataRange;
        }

        public List<string> GetFromColumnValues()
        {
            return _dataRange.Select(range => range.From = string.IsNullOrWhiteSpace(range.From) ? "" : range.From)
                             .ToList();
        }

        public List<string> GetToColumnValues()
        {
            return _dataRange.Select(range => range.To = string.IsNullOrWhiteSpace(range.To) ? "" : range.To)
                           .ToList();
        }

        public List<string> GetLinksCount()
        {
            List<string> LinksCount = _dataRange.Select(range => range.Count = string.IsNullOrWhiteSpace(range.Count) ? "" : range.Count)
                        .ToList();

            if (LinksCountAreEmptyStrings(LinksCount))
            {
                LinksCount = GetFromToOccurrences();
            }

            Validations.SelectedRangeValidator.ValidateIfListOfIntegersAsStringsContainsNonIntegerValue(LinksCount);

            return LinksCount;
        }

        private List<string> GetFromToOccurrences()
        {
            return _dataRange
                    .GroupBy(_fromToRangeList => new { _fromToRangeList.From, _fromToRangeList.To })
                    .Select(group => group.Count().ToString())
                    .ToList();
        }

        private bool LinksCountAreEmptyStrings(List<string> linksCount)
        {
            var uniqueValues = linksCount.Distinct().ToList();

            return(uniqueValues.Count == 1 && string.IsNullOrWhiteSpace(uniqueValues.FirstOrDefault()));
        }
    }
}
