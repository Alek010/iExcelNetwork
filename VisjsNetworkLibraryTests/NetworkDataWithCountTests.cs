// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary.Models;
using VisjsNetworkLibrary;
using VisjsNetworkLibrary.Exceptions;

namespace VisjsNetworkLibraryTests
{
    public class NetworkDataWithCountTests
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

            NetworkDataWithCount networkData = new NetworkDataWithCount(dt);

            List<Edge> edges = networkData.GetEdges();

            Assert.Equal(2, edges.Count);

            Assert.Equivalent(new Edge() { From = 1, To = 2, Count = "1" }, edges[0]);
            Assert.Equivalent(new Edge() { From = 3, To = 2, Count = "2" }, edges[1]);
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


            NetworkDataWithCount networkData = new NetworkDataWithCount(dt);

            List<Edge> edges = networkData.GetEdges();

            Assert.Equal(2, edges.Count);

            Assert.Equivalent(new Edge() { From = 1, To = 2, Count = "10" }, edges[0]);
            Assert.Equivalent(new Edge() { From = 3, To = 2, Count = "1" }, edges[1]);
        }

        [Fact]
        public void GetEdges_WithCountColumnValuesNonInteger_ThrowsDataTableStructureException()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("count", typeof(string));

            dt.Rows.Add("C", "B", "x");

            NetworkDataWithCount networkData = new NetworkDataWithCount(dt);

            var exception = Assert.Throws<DataTableStructureException>(() => networkData.GetEdges());
            Assert.Equal("Not all count column values are integers.", exception.Message);
        }
    }
}
