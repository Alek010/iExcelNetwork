// Ignore Spelling: Visjs

using System;
using System.Data;
using System.Linq;

namespace VisjsNetworkLibrary.FinancialTransactionsNetworkData
{
    public class EdgeStats
    {
        public static DataTable CalculateEdgeStats(DataTable inputTable)
        {
            // Step 1: Group by edges and calculate raw stats
            var grouped = inputTable.AsEnumerable()
                .GroupBy(row => new
                {
                    From = row.Field<string>("from"),
                    To = row.Field<string>("to")
                })
                .Select(g =>
                {
                    var values = g.Select(r => Convert.ToDouble(r.Field<string>("count"))).ToList();
                    double avg = values.Average();
                    double stdDev = values.Count > 1
                        ? Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)))
                        : 0.0;

                    return new
                    {
                        From = g.Key.From,
                        To = g.Key.To,
                        Count = values.Count,
                        Sum = values.Sum(),
                        Avg = avg,
                        Max = values.Max(),
                        Min = values.Min(),
                        StdDev = stdDev
                    };
                })
                .ToList();

            // Step 2: Compute min-max for normalization
            double Normalize(double value, double min, double max) =>
                (max == min) ? 1.0 : (value - min) / (max - min);

            double minCount = grouped.Min(x => x.Count);
            double maxCount = grouped.Max(x => x.Count);
            double minSum = grouped.Min(x => x.Sum);
            double maxSum = grouped.Max(x => x.Sum);
            double minAvg = grouped.Min(x => x.Avg);
            double maxAvg = grouped.Max(x => x.Avg);
            double minMax = grouped.Min(x => x.Max);
            double maxMax = grouped.Max(x => x.Max);
            double minMin = grouped.Min(x => x.Min);
            double maxMin = grouped.Max(x => x.Min);
            double minStd = grouped.Min(x => x.StdDev);
            double maxStd = grouped.Max(x => x.StdDev);

            // Step 3: Prepare result table
            var result = new DataTable();
            result.Columns.Add("From", typeof(string));
            result.Columns.Add("To", typeof(string));
            result.Columns.Add("Count", typeof(int));
            result.Columns.Add("Sum", typeof(double));
            result.Columns.Add("Avg", typeof(double));
            result.Columns.Add("Min", typeof(double));
            result.Columns.Add("Max", typeof(double));
            result.Columns.Add("StdDev", typeof(double));
            result.Columns.Add("Weight", typeof(double));
            result.Columns.Add("Title", typeof(string));

            // Step 4: Calculate normalized values and final weight
            foreach (var e in grouped)
            {
                double normCount = Normalize(e.Count, minCount, maxCount);
                double normSum = Normalize(e.Sum, minSum, maxSum);
                double normAvg = Normalize(e.Avg, minAvg, maxAvg);
                double normMax = Normalize(e.Max, minMax, maxMax);
                double normMin = Normalize(e.Min, minMin, maxMin);
                double normStd = Normalize(e.StdDev, minStd, maxStd);

                double weight = 0.3 * normCount +
                                0.3 * normSum +
                                0.1 * normAvg +
                                0.1 * normMax +
                                0.1 * normMin +
                                0.1 * (1 - normStd); // More consistency = higher weight

                string title = $"Count: {e.Count}\n" +
                               $"Sum: {e.Sum:F2}\n" +
                               $"Average: {e.Avg:F2}\n" +
                               $"Min: {e.Min:F2}\n" +
                               $"Max: {e.Max:F2}\n" +
                               $"Std.Dev: {e.StdDev:F2}\n" +
                               $"Weight: {weight:F2}";

                result.Rows.Add(e.From, e.To, e.Count, e.Sum, e.Avg, e.Min, e.Max, e.StdDev, weight, title);
            }

            return result;
        }
    }
}
