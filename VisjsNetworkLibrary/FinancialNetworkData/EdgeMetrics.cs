// Ignore Spelling: Visjs

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VisjsNetworkLibrary.Models;

namespace VisjsNetworkLibrary.FinancialNetworkData
{
    public class EdgeMetrics
    {
        public static DataTable GenerateEdgeStatisticsTable(DataTable inputTable)
        {
            var grouped = GroupEdgesAndCalculateStats(inputTable);

            var minMax = CalculateMinMax(grouped);

            var result = CreateEdgeStatsTable();

            foreach (var e in grouped)
            {
                double weight = CalculateWeight(e, minMax);
                string title = BuildTitle(e, weight);

                result.Rows.Add(e.From, e.To, e.Count, e.Sum, e.Avg, e.Min, e.Max, e.StdDev, weight, title);
            }

            return result;
        }

        // --- Grouping and aggregation ---

        private static List<EdgeStatistics> GroupEdgesAndCalculateStats(DataTable inputTable)
        {
            return inputTable.AsEnumerable()
                .GroupBy(row => new
                {
                    From = row.Field<string>("from"),
                    To = row.Field<string>("to")
                })
                .Select(g => AggregateEdge(g))
                .ToList();
        }

        private static EdgeStatistics AggregateEdge(IGrouping<object, DataRow> group)
        {
            var values = group.Select(r => Convert.ToDouble(r.Field<string>("count"))).ToList();
            double avg = values.Average();
            double stdDev = values.Count > 1
                ? Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)))
                : 0.0;

            return new EdgeStatistics
            {
                From = group.Key.GetType().GetProperty("From")?.GetValue(group.Key)?.ToString(),
                To = group.Key.GetType().GetProperty("To")?.GetValue(group.Key)?.ToString(),
                Count = values.Count,
                Sum = values.Sum(),
                Avg = avg,
                Max = values.Max(),
                Min = values.Min(),
                StdDev = stdDev
            };
        }

        // --- Weight and title generation ---

        private static double CalculateWeight(EdgeStatistics e, (double min, double max)[] minMax)
        {
            double normCount = Normalize(e.Count, minMax[0].min, minMax[0].max);
            double normSum = Normalize(e.Sum, minMax[1].min, minMax[1].max);
            double normAvg = Normalize(e.Avg, minMax[2].min, minMax[2].max);
            double normMax = Normalize(e.Max, minMax[3].min, minMax[3].max);
            double normMin = Normalize(e.Min, minMax[4].min, minMax[4].max);
            double normStd = Normalize(e.StdDev, minMax[5].min, minMax[5].max);

            return 0.3 * normCount +
                   0.3 * normSum +
                   0.1 * normAvg +
                   0.1 * normMax +
                   0.1 * normMin +
                   0.1 * (1 - normStd);
        }

        private static string BuildTitle(EdgeStatistics e, double weight)
        {
            return $"Count: {e.Count}\n" +
                   $"Sum: {e.Sum:F2}\n" +
                   $"Average: {e.Avg:F2}\n" +
                   $"Min: {e.Min:F2}\n" +
                   $"Max: {e.Max:F2}\n" +
                   $"Std.Dev: {e.StdDev:F2}\n" +
                   "---------\n" +
                   $"EdgeWeight: {weight:F2}";
        }

        // --- Helpers ---

        private static double Normalize(double value, double min, double max)
        {
            return (max == min) ? 1.0 : (value - min) / (max - min);
        }

        private static (double min, double max)[] CalculateMinMax(List<EdgeStatistics> grouped)
        {
            return new[]
            {
            (grouped.Min(x => (double)x.Count), grouped.Max(x => (double)x.Count)),
            (grouped.Min(x => x.Sum), grouped.Max(x => x.Sum)),
            (grouped.Min(x => x.Avg), grouped.Max(x => x.Avg)),
            (grouped.Min(x => x.Max), grouped.Max(x => x.Max)),
            (grouped.Min(x => x.Min), grouped.Max(x => x.Min)),
            (grouped.Min(x => x.StdDev), grouped.Max(x => x.StdDev))
        };
        }

        private static DataTable CreateEdgeStatsTable()
        {
            var table = new DataTable();
            table.Columns.Add("From", typeof(string));
            table.Columns.Add("To", typeof(string));
            table.Columns.Add("Count", typeof(int));
            table.Columns.Add("Sum", typeof(double));
            table.Columns.Add("Avg", typeof(double));
            table.Columns.Add("Min", typeof(double));
            table.Columns.Add("Max", typeof(double));
            table.Columns.Add("StdDev", typeof(double));
            table.Columns.Add("EdgeWeight", typeof(double));
            table.Columns.Add("Title", typeof(string));
            return table;
        }
    }


}
