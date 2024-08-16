// Ignore Spelling: json

using System.Collections.Generic;

namespace GraphVisualizationLibrary.Interfaces
{
    public interface IDataRange
    {
        List<string> GetFromColumnValues();
        List<string> GetLinksCount();
        List<string> GetToColumnValues();
    }
}