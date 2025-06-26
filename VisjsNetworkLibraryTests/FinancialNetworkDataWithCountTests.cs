// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary.Exceptions;
using VisjsNetworkLibrary.FinancialNetworkData;
using VisjsNetworkLibrary.Models;

namespace VisjsNetworkLibraryTests
{
    public class FinancialNetworkDataWithCountTests
    {
        [Fact]
        public void GetEdges_WithMultipleUniqueRowsTable_ExtractsCorrectEdges()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("count", typeof(string));

            dt.Rows.Add("A", "B", "1");
            dt.Rows.Add("C", "B", "2");

            FinancialNetworkDataWithCount networkData = new FinancialNetworkDataWithCount(dt);

            List<Edge> edges = networkData.GetEdges();

            Assert.Equal(2, edges.Count);

            Assert.Equivalent(
                new Edge() 
                { 
                    From = 1, 
                    To = 2, 
                    Count = "1", 
                    Value = 0.30*5,
                    Title = BuildEdgeTitle([1, 1.00, 1.00, 1.00, 1.00, 0.00, 0.30])
                }, 
                edges[0]
                );

            Assert.Equivalent(
                new Edge() 
                { 
                    From = 3, 
                    To = 2, 
                    Count = "2",
                    Value = 0.90 * 5,
                    Title = BuildEdgeTitle([1, 2.00, 2.00, 2.00, 2.00, 0.00, 0.90])
                }, 
                edges[1]);
        }

        [Fact]
        public void GetEdges_WithDuplicateRowsTable_ExtractsCorrectEdges()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("count", typeof(string));

            dt.Rows.Add("C", "B", "5");
            dt.Rows.Add("A", "B", "1");
            dt.Rows.Add("C", "B", "5");


            FinancialNetworkDataWithCount networkData = new FinancialNetworkDataWithCount(dt);

            List<Edge> edges = networkData.GetEdges();

            Assert.Equal(2, edges.Count);

            var a = BuildEdgeTitle([1, 10.00, 5.00, 5.00, 5.00, 0.00, 0.90]);

            Assert.Equivalent(
                new Edge()
                {
                    From = 1,
                    To = 2,
                    Count = "10",
                    Value = 0.90 * 5,
                    Title = BuildEdgeTitle([2, 10.00, 5.00, 5.00, 5.00, 0.00, 0.90])
                },
                edges[0]
                );

            Assert.Equivalent(
                new Edge()
                {
                    From = 3,
                    To = 2,
                    Count = "1",
                    Value = 0.00 * 5,
                    Title = BuildEdgeTitle([1, 1.00, 1.00, 1.00, 1.00, 0.00, 0.00])
                },
                edges[1]);
        }

        [Fact]
        public void GetEdges_WithCountColumnValuesNonInteger_ThrowsDataTableStructureException()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("count", typeof(string));

            dt.Rows.Add("C", "B", "x");

            FinancialNetworkDataWithCount networkData = new FinancialNetworkDataWithCount(dt);

            var exception = Assert.Throws<DataTableStructureException>(() => networkData.GetEdges());
            Assert.Equal("Not all count column values are integers.", exception.Message);
        }

        private string BuildEdgeTitle(double[] titleValues)
        {
            return $"Count: {titleValues[0]}\nSum: {titleValues[1]:F2}\nAverage: {titleValues[2]:F2}\nMin: {titleValues[3]:F2}\n" +
                   $"Max: {titleValues[4]:F2}\nStd.Dev: {titleValues[5]:F2}\n---------\nEdgeWeight: {titleValues[6]:F2}";
        }
    }
}
