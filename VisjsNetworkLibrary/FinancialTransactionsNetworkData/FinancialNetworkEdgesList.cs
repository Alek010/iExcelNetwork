// Ignore Spelling: Visjs
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VisjsNetworkLibrary.Exceptions;
using VisjsNetworkLibrary.Models;

namespace VisjsNetworkLibrary.FinancialTransactionsNetworkData
{
    public static class FinancialNetworkEdgesList
    {

        public static List<Edge> GetList(DataTable dt, List<Node> nodesList)
        {
            if (ValidateCountColumnValuesAreIntegers(dt) == false)
            {
                throw new DataTableStructureException(SelectedDataTableExceptionMessages.NotAllCountColumnValuesAreIntegers());
            }

            DataTable edgesStatsTable = EdgeMetrics.GenerateEdgeStatisticsTable(dt);

            var nodeDict = nodesList.ToDictionary(n => n.Label, n => n.Id);

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

        private static bool ValidateCountColumnValuesAreIntegers(DataTable dt)
        {
            return dt.AsEnumerable()
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
