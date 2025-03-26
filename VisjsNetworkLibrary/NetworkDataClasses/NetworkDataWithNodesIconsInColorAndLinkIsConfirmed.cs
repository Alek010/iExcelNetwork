// Ignore Spelling: Visjs

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VisjsNetworkLibrary.Exceptions;
using VisjsNetworkLibrary.Helpers;
using VisjsNetworkLibrary.Interfaces;
using VisjsNetworkLibrary.Models;

namespace VisjsNetworkLibrary.NetworkDataClasses
{
    public class NetworkDataWithNodesIconsInColorAndLinkIsConfirmed : NetworkData, INetworkData
    {
        public NetworkDataWithNodesIconsInColorAndLinkIsConfirmed(DataTable dataTable) : base(dataTable)
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

        public override List<Edge> GetEdges()
        {
            if (ValidateLinkIsConfirmedColumnAreBools() == false)
            {
                throw new DataTableStructureException(SelectedDataTableExceptionMessages.NotAllColumnValuesAreBoolean(columnName: "linkisconfirmed"));
            }

            // Validate consistency of linkisconfirmed values for the same edge.
            ValidateLinkIsConfirmedConsistency(_dataTable);

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
                    Count = g.Count().ToString(),
                    // Parse the linkisconfirmed value from the first row in the group.
                    // Invert the value since the JSON field "dashes" is the inverse of link confirmation.
                    IsDashed = !bool.Parse(g.First().Field<string>("linkisconfirmed"))
                })
                .ToList();

            return edgesList;
        }

        private bool ValidateLinkIsConfirmedColumnAreBools()
        {
            return _dataTable.AsEnumerable()
                .All(row =>
                {
                    var value = row["linkisconfirmed"];
                    if (value == DBNull.Value)
                        return false;
                    return bool.TryParse(value.ToString(), out _);
                });
        }

        private static void ValidateLinkIsConfirmedConsistency(DataTable dt)
        {
            var inconsistentEdges = dt.AsEnumerable()
                .GroupBy(row => new
                {
                    From = row.Field<string>("from"),
                    To = row.Field<string>("to")
                })
                .Where(g => g.Select(row => row.Field<string>("linkisconfirmed"))
                             .Distinct(StringComparer.OrdinalIgnoreCase)
                             .Count() > 1)
                .ToList();

            if (inconsistentEdges.Any())
            {
                throw new DataTableStructureException(SelectedDataTableExceptionMessages.ThereAreSameEdgesWithDifferentValuesOfLinkIsConfirmed());
            }
        }
    }
}
