// Ignore Spelling: Visjs

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VisjsNetworkLibrary.Exceptions;
using VisjsNetworkLibrary.Helpers;
using VisjsNetworkLibrary.Interfaces;
using VisjsNetworkLibrary.Models;
using VisjsNetworkLibrary.NetworkDataClasses;

namespace VisjsNetworkLibrary.FinancialTransactionsNetworkData
{
    public class FinancialNetworkDataWithNodesIconsInColorAndCount : NetworkData, INetworkData
    {
        public FinancialNetworkDataWithNodesIconsInColorAndCount(DataTable dataTable) : base(dataTable)
        {
            base.EdgesLinksHasTitle = true;
            base.NodesEdgesAreScalable = true;
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
            if (ValidateCountColumnValuesAreIntegers() == false)
            {
                throw new DataTableStructureException(SelectedDataTableExceptionMessages.NotAllCountColumnValuesAreIntegers());
            }

            DataTable edgesStatsTable = EdgeMetrics.GenerateEdgeStatisticsTable(_dataTable);

            var nodeDict = GetNodes().ToDictionary(n => n.Label, n => n.Id);

            var edgesList = edgesStatsTable.AsEnumerable().Select(row => new Edge
            {
                From = nodeDict[row.Field<string>("From")],
                To = nodeDict[row.Field<string>("To")],
                Count = row.Field<double>("Sum").ToString(),
                Title = row.Field<string>("Title"),
                Value = row.Field<double>("EdgeWeight") * 5
                // Number 5 is multiplier to EdgeWeight (min 0 and max 1) in order to adjust edge scaling from 0 to 5.
                // Scaling is set in NetworkHtmlContent class.
            }).ToList();

            return edgesList;
        }

        private bool ValidateCountColumnValuesAreIntegers()
        {
            return _dataTable.AsEnumerable()
                .All(row =>
                {
                    var value = row["count"];
                    if (value == DBNull.Value)
                        return false;
                    return int.TryParse(value.ToString(), out _);
                });
        }
    }
}
