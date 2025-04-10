// Ignore Spelling: Visjs

using System.Collections.Generic;
using System.Data;
using System.Linq;
using VisjsNetworkLibrary.Interfaces;
using VisjsNetworkLibrary.Models;

namespace VisjsNetworkLibrary.NetworkDataClasses
{
    public class NetworkData : INetworkData
    {
        internal DataTable _dataTable;

        public bool NodesEdgesAreScalable { get; set; } = false;

        public bool EdgesLinksHasTitle { get; set; } = false;

        public NetworkData(DataTable dataTable)
        {
            _dataTable = dataTable;
        }

        public virtual List<Node> GetNodes()
        {
            return _dataTable.AsEnumerable()
                    .SelectMany(row => new[] { row.Field<string>("from"), row.Field<string>("to") })
                    .Distinct()
                    .Select((label, index) => new Node
                    {
                        Id = index + 1,
                        Label = label
                    })
                    .ToList();
        }

        public virtual List<Edge> GetEdges()
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
    }
}
