// Ignore Spelling: Visjs

using System.Collections.Generic;
using System.Data;
using System.Linq;
using VisjsNetworkLibrary.Helpers;
using VisjsNetworkLibrary.Interfaces;
using VisjsNetworkLibrary.Models;
using VisjsNetworkLibrary.NetworkDataClasses;

namespace VisjsNetworkLibrary.FinancialTransactionsNetworkData
{
    public class FinancialNetworkDataWithNodesIconsAndCount : NetworkData, INetworkData
    {
        public FinancialNetworkDataWithNodesIconsAndCount(DataTable dataTable) : base(dataTable)
        {
            base.EdgesLinksHasTitle = true;
            base.NodesEdgesAreScalable = true;
        }

        public override List<Node> GetNodes()
        {
            var nodesLookup = _dataTable.AsEnumerable()
                .SelectMany(row => new[]
                {
                    new { Label = row.Field<string>("from"), Icon = row.Field<string>("fromicon") },
                    new { Label = row.Field<string>("to"), Icon = row.Field<string>("toicon") }
                })
                .GroupBy(x => x.Label)
                .Select(g => new
                {
                    Label = g.Key,
                    IconType = g.FirstOrDefault(x => !string.IsNullOrEmpty(x.Icon))?.Icon
                })
                .ToList();

            return nodesLookup.Select((x, index) => new Node
            {
                Id = index + 1,
                Label = x.Label,
                Shape = "icon", // Set the node shape as an icon
                Icon = new NodeIcon
                {
                    Face = "FontAwesome",
                    // Look up the Unicode code from the mapping.
                    // If the meaningful value isn't found, use the raw value from the DataTable.
                    Code = IconMapper.GetIconCode(x.IconType),
                    Size = 50,
                    Color = "#3d85c6"
                }
            }).ToList();
        }

        public override List<Edge> GetEdges()
        {
            return FinancialNetworkEdgesList.GetList(_dataTable, GetNodes());
        }
    }
}
