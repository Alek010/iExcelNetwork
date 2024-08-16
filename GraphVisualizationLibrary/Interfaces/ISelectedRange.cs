// Ignore Spelling: Json

using GraphVisualizationLibrary.Models;
using System.Collections.Generic;

namespace GraphVisualizationLibrary.Interfaces
{
    public interface ISelectedRange
    {
        List<Range> GroupRangeByFromToDuplicates();
    }
}