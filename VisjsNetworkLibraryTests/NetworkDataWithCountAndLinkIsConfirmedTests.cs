// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary.Exceptions;
using VisjsNetworkLibrary.Models;
using VisjsNetworkLibrary.NetworkDataClasses;

namespace VisjsNetworkLibraryTests
{
    public class NetworkDataWithCountAndLinkIsConfirmedTests
    {
        [Fact]
        public void GetEdges_WithMultipleUniqueRowsTable_ExtractsCorrectEdges()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("count", typeof(string));
            dt.Columns.Add("linkisconfirmed", typeof(string));

            dt.Rows.Add("A", "B", "1", "TRUE");
            dt.Rows.Add("C", "B", "2", "FALSE");

            NetworkDataWithCountAndLinkIsConfirmed networkData = new NetworkDataWithCountAndLinkIsConfirmed(dt);

            List<Edge> edges = networkData.GetEdges();

            Assert.Equal(2, edges.Count);

            Assert.Equivalent(new Edge() { From = 1, To = 2, Count = "1", IsDashed = false }, edges[0]);
            Assert.Equivalent(new Edge() { From = 3, To = 2, Count = "2", IsDashed = true }, edges[1]);
        }

        [Fact]
        public void GetEdges_WithDuplicateRowsTable_ExtractsCorrectEdges()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("count", typeof(string));
            dt.Columns.Add("linkisconfirmed", typeof(string));

            dt.Rows.Add("C", "B", "5", "True");
            dt.Rows.Add("A", "B", "1", "FALSE");
            dt.Rows.Add("C", "B", "5", "TRUE");


            NetworkDataWithCountAndLinkIsConfirmed networkData = new NetworkDataWithCountAndLinkIsConfirmed(dt);

            List<Edge> edges = networkData.GetEdges();

            Assert.Equal(2, edges.Count);

            Assert.Equivalent(new Edge() { From = 1, To = 2, Count = "10", IsDashed = false }, edges[0]);
            Assert.Equivalent(new Edge() { From = 3, To = 2, Count = "1", IsDashed = true }, edges[1]);
        }

        [Fact]
        public void GetEdges_WithCountColumnValuesNonInteger_ThrowsDataTableStructureException()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("count", typeof(string));
            dt.Columns.Add("linkisconfirmed", typeof(string));

            dt.Rows.Add("C", "B", "x", "TRUE");

            NetworkDataWithCountAndLinkIsConfirmed networkData = new NetworkDataWithCountAndLinkIsConfirmed(dt);

            var exception = Assert.Throws<DataTableStructureException>(() => networkData.GetEdges());
            Assert.Equal("Not all count column values are integers.", exception.Message);
        }

        [Fact]
        public void GetEdges_WithLinkkIsConfirmedColumnValuesNonBoolean_ThrowsDataTableStructureException()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("count", typeof(string));
            dt.Columns.Add("linkisconfirmed", typeof(string));

            dt.Rows.Add("C", "B", "1", "1");

            NetworkDataWithCountAndLinkIsConfirmed networkData = new NetworkDataWithCountAndLinkIsConfirmed(dt);

            var exception = Assert.Throws<DataTableStructureException>(() => networkData.GetEdges());
            Assert.Equal("Not all IsDashed column values are booleans.", exception.Message);
        }

        [Fact]
        public void GetEdges_WithDuplicateRowsTableWithLinkIsConfirmedValuesAreDifferent_ThrowsDataStructureException()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("count", typeof(string));
            dt.Columns.Add("linkisconfirmed", typeof(string));

            dt.Rows.Add("C", "B", "1", "true");
            dt.Rows.Add("A", "B", "2", "false");
            dt.Rows.Add("E", "F", "1", "false");
            dt.Rows.Add("E", "F", "10", "true");

            NetworkDataLinkIsConfirmed networkData = new NetworkDataLinkIsConfirmed(dt);

            var exception = Assert.Throws<DataTableStructureException>(() => networkData.GetEdges());
            Assert.Equal("There are same link From-To with different values of 'Link Is Confirmed' column.", exception.Message);
        }
    }
}
