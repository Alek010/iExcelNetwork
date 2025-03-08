

// Ignore Spelling: Visjs

using System.Collections.Generic;
using System.Data;
using System.Linq;
using VisjsNetworkLibrary.Helpers;
using VisjsNetworkLibrary.Interfaces;
using VisjsNetworkLibrary.Models;

namespace VisjsNetworkLibrary.NetworkDataClasses
{
    public class NetworkDataWithNodesIconsInColor : NetworkData, INetworkData
    {
        public NetworkDataWithNodesIconsInColor(DataTable dataTable) : base(dataTable)
        {
        }

        public override List<Node> GetNodes()
        {
            var nodesLookup = _dataTable.AsEnumerable()
                .SelectMany(row => new[]
                {
                    new { Label = row.Field<string>("from"), Icon = row.Field<string>("fromicon"), Color = row.Field<string>("fromcolor") },
                    new { Label = row.Field<string>("to"), Icon = row.Field<string>("toicon"), Color = row.Field<string>("tocolor") }
                })
                .GroupBy(x => x.Label)
                .Select(g => new
                {
                    Label = g.Key,
                    IconType = g.FirstOrDefault(x => !string.IsNullOrEmpty(x.Icon))?.Icon,
                    ColorType = g.FirstOrDefault(x => !string.IsNullOrEmpty(x.Color))?.Color
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
                    Color = ColorMapper.GetColor(x.ColorType)
                }
            }).ToList();
        }
    }
}
