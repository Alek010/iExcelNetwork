using System.Collections.Generic;

namespace GraphVisualizationLibrary.NetworkProperty
{
    public class EdgeProperty
    {
        public string SelectedDirection { get; set; } = "to";

        private readonly Dictionary<string, string> Direction = new Dictionary<string, string>()
        {
            {"From", "from" },
            {"To", "to" },
            {"Both", "from,to" },
            {"None", "" }
        };

        public Dictionary<string, string> EdgeDirectionOptions()
        {
            return Direction;
        }
    }
}
