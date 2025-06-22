
// Ignore Spelling: Visjs

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VisjsNetworkLibrary.Exceptions;
using VisjsNetworkLibrary.Interfaces;
using VisjsNetworkLibrary.Models;
using VisjsNetworkLibrary.NetworkDataClasses;

namespace VisjsNetworkLibrary.FinancialTransactionsNetworkData
{
    public class FinancialNetworkDataWithCount : NetworkData, INetworkData
    {
        public FinancialNetworkDataWithCount(DataTable dataTable) : base(dataTable)
        {
            base.EdgesLinksHasTitle = true;
        }

        public override List<Edge> GetEdges()
        {
            if (ValidateCountColumnValuesAreIntegers() == false)
            {
                throw new DataTableStructureException(SelectedDataTableExceptionMessages.NotAllCountColumnValuesAreIntegers());
            }

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
                    Title = g.Sum(row => int.Parse(row.Field<string>("count"))).ToString()
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
    }
}
