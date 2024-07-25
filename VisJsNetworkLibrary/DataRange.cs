// Ignore Spelling: json

using System.Collections.Generic;
using System.Linq;
using VisJsNetworkLibrary.Models;
using VisJsNetworkLibrary.Validations;

namespace VisJsNetworkLibrary
{
    public class DataRange
    {
        public List<SelectedRange> _data = new List<SelectedRange>();

        public DataRange(List<SelectedRange> data)
        {
            if (CountFieldValuesAreEmptyStrings(CountFieldValues(data)))
            {
                _data = GroupAndCountFromTo(data);
            }
            else
            {
                VisJsDataValidator.ValidateIfCountFieldValuesContainsNonIntegerValue(CountFieldValues(data));
                _data = GroupAndSumFromTo(data);
            }
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

            return LinksCount;
        }

        private List<SelectedRange> GroupAndCountFromTo(List<SelectedRange> data)
        {
           return data
                .GroupBy(group => new { group.From, group.To })
                .Select(range => new SelectedRange
                {
                    From = range.Key.From,
                    To = range.Key.To,
                    Count = range.Count().ToString()
                })
                .ToList();
        }

        public List<SelectedRange> GroupAndSumFromTo(List<SelectedRange> data)
        {
            return data
                .GroupBy(group => new { group.From, group.To })
                .Select(range => new SelectedRange
                {
                    From = range.Key.From,
                    To = range.Key.To,
                    Count = range.Sum(group => int.Parse(group.Count)).ToString()
                })
                .ToList();
        }

        private List<string> CountFieldValues(List<SelectedRange> data)
        {
            return data
            .Select(range => range.Count = string.IsNullOrWhiteSpace(range.Count) ? "" : range.Count)
            .Distinct()
            .ToList();
        }

        private bool CountFieldValuesAreEmptyStrings(List<string> countFieldValues)
        {
            var uniqueValues = countFieldValues.Distinct().ToList();

            return uniqueValues.Count == 1 && string.IsNullOrWhiteSpace(uniqueValues.FirstOrDefault());
        }
    }
}
