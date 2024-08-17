// Ignore Spelling: json

using System.Collections.Generic;
using System.Linq;
using GraphVisualizationLibrary.Interfaces;
using GraphVisualizationLibrary.Models;

namespace GraphVisualizationLibrary
{
    public class DataRange : IDataRange
    {
        private List<Range> _data = new List<Range>();

        public DataRange(ISelectedRange selectedRange)
        {
            _data = selectedRange.GroupRangeByFromToDuplicates();
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
    }
}
