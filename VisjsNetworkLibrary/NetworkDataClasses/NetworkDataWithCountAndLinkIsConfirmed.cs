// Ignore Spelling: Visjs

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VisjsNetworkLibrary.Exceptions;
using VisjsNetworkLibrary.Interfaces;
using VisjsNetworkLibrary.Models;

namespace VisjsNetworkLibrary.NetworkDataClasses
{
    public class NetworkDataWithCountAndLinkIsConfirmed : NetworkData, INetworkData
    {
        public NetworkDataWithCountAndLinkIsConfirmed(DataTable dataTable) : base(dataTable)
        {
        }

        public override List<Edge> GetEdges()
        {
            if (ValidateCountColumnValuesAreIntegers() == false)
            {
                throw new DataTableStructureException(SelectedDataTableExceptionMessages.NotAllCountColumnValuesAreIntegers());
            }

            if (ValidateLinkIsConfirmedColumnAreBools() == false)
            {
                throw new DataTableStructureException(SelectedDataTableExceptionMessages.NotAllLinkIsConfirmedColumnValuesAreBoolean());
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
                    Count = g.Sum(row => int.Parse(row.Field<string>("count"))).ToString(),
                    IsDashed = !bool.Parse(g.First().Field<string>("linkisconfirmed"))
                })
                .ToList();

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
