// Ignore Spelling: Visjs

using System.Collections.Generic;
using System.Data;
using System.Linq;
using VisjsNetworkLibrary.Models;

namespace VisjsNetworkLibrary
{
    public class NetworkData
    {
        private DataTable _dataTable;

        public NetworkData(DataTable dataTable)
        {
            _dataTable = dataTable;
        }

        public List<Node> GetNodes()
        {
            return GetNodesLabels()
                    .Select((label, index) => new Node
                    {
                        Id = index + 1,
                        Label = label
                    })
                    .ToList();
        }

        public List<Edge> GetEdges()
        {
            var nodeDict = GetNodes().ToDictionary(n => n.Label, n => n.Id);

            var edgesList = _dataTable.AsEnumerable()
                .GroupBy(row => new
                {
                    From = row.Field<string>("from"),
                    To = row.Field<string>("to")
                })
                .Select(g => new Edge
                {
                    From = nodeDict[g.Key.From],
                    To = nodeDict[g.Key.To],
                    Count = g.Count().ToString()
                })
                .ToList();

            return edgesList;
        }

        private List<string> GetNodesLabels()
        {
            var nodesLabels = _dataTable.AsEnumerable()
                .SelectMany(row => new[] { row.Field<string>("from"), row.Field<string>("to") })
                .Distinct()
                .ToList();

            return nodesLabels;
        }
    }
}
