// Ignore Spelling: Visjs

using System.Collections.Generic;
using System.Data;
using System.Linq;
using VisjsNetworkLibrary.Helpers;
using VisjsNetworkLibrary.Interfaces;
using VisjsNetworkLibrary.Models;

namespace VisjsNetworkLibrary.NetworkDataClasses
{
    public class NetworkDataScalingNodesAndEdges : NetworkData, INetworkData
    {
        public NetworkDataScalingNodesAndEdges(DataTable dataTable) : base(dataTable)
        {
        }

        public override List<Node> GetNodes()
        {
            var nodesLookup = _dataTable.AsEnumerable()
                .SelectMany(row => new[]
                {
                    new { Label = row.Field<string>("from"), Value = row.Field<string>("fromvalue") },
                    new { Label = row.Field<string>("to"), Value = row.Field<string>("tovalue") }
                })
                .GroupBy(x => x.Label)
                .Select(g => new
                {
                    Label = g.Key,
                    Value = g.FirstOrDefault(x => !string.IsNullOrEmpty(x.Value))?.Value ?? "1"
                })
                .ToList();

            return nodesLookup.Select((x, index) => new Node
            {
                Id = index + 1,
                Label = x.Label,
                Value = int.Parse(x.Value)
            }).ToList();
        }

        public override List<Edge> GetEdges()
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
                    Value = g.Count(),
                    Title = g.Count().ToString()
                })
                .ToList();

            return edgesList;
        }
    }
}
