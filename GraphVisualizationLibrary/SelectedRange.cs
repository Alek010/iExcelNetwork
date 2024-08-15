// Ignore Spelling: Json

using GraphVisualizationLibrary.Models;
using GraphVisualizationLibrary.Validations;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace GraphVisualizationLibrary
{
    public class SelectedRange
    {
        private readonly List<Range> _data;

        public SelectedRange(string selectedRangeAsJson)
        {
            _data = JsonConvert.DeserializeObject<List<Range>>(selectedRangeAsJson);
        }

        public List<Range> GroupRangeByFromToDuplicates()
        {
            if (CountFieldValuesAreEmptyStrings(CountFieldValues(_data)))
            {
                return GroupAndCountFromTo(_data);
            }
            else
            {
                Validator.ValidateIfCountFieldValuesContainsNonIntegerValue(CountFieldValues(_data));
                return GroupAndSumFromTo(_data);
            }
        }

        private List<Range> GroupAndCountFromTo(List<Range> data)
        {
            return data
                 .GroupBy(group => new { group.From, group.To })
                 .Select(range => new Range
                 {
                     From = range.Key.From,
                     To = range.Key.To,
                     Count = range.Count().ToString()
                 })
                 .ToList();
        }

        private List<Range> GroupAndSumFromTo(List<Range> data)
        {
            return data
                .GroupBy(group => new { group.From, group.To })
                .Select(range => new Range
                {
                    From = range.Key.From,
                    To = range.Key.To,
                    Count = range.Sum(group => int.Parse(group.Count)).ToString()
                })
                .ToList();
        }

        private List<string> CountFieldValues(List<Range> data)
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
