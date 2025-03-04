// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary.Exceptions;
using VisjsNetworkLibrary.Models;
using VisjsNetworkLibrary;
using VisjsNetworkLibrary.NetworkDataClasses;

namespace VisjsNetworkLibraryTests
{
    public class NetworkDataLinkIsConfirmedTests
    {
        [Fact]
        public void GetEdges_WithMultipleUniqueRowsTable_ExtractsCorrectEdges()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("linkisconfirmed", typeof(string));

            dt.Rows.Add("A", "B", "true");
            dt.Rows.Add("C", "B", "false");

            NetworkDataLinkIsConfirmed networkData = new NetworkDataLinkIsConfirmed(dt);

            List<Edge> edges = networkData.GetEdges();

            Assert.Equal(2, edges.Count);

            Assert.Equivalent(new Edge() { From = 1, To = 2, LinkIsConfirmed = false }, edges[0]);
            Assert.Equivalent(new Edge() { From = 3, To = 2, LinkIsConfirmed = true }, edges[1]);
        }

        [Fact]
        public void GetEdges_WithDuplicateRowsTable_ExtractsCorrectEdges()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("linkisconfirmed", typeof(string));

            dt.Rows.Add("C", "B", "true");
            dt.Rows.Add("A", "B", "false");
            dt.Rows.Add("C", "B", "false");

            NetworkDataLinkIsConfirmed networkData = new NetworkDataLinkIsConfirmed(dt);

            List<Edge> edges = networkData.GetEdges();

            Assert.Equal(3, edges.Count);

            Assert.Equivalent(new Edge() { From = 1, To = 2, LinkIsConfirmed = false }, edges[0]);
            Assert.Equivalent(new Edge() { From = 3, To = 2, LinkIsConfirmed = true }, edges[1]);
            Assert.Equivalent(new Edge() { From = 1, To = 2, LinkIsConfirmed = true }, edges[2]);
        }

        [Fact]
        public void GetEdges_WithCountColumnValuesNonInteger_ThrowsDataTableStructureException()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("linkisconfirmed", typeof(string));

            dt.Rows.Add("C", "B", "x");

            NetworkDataLinkIsConfirmed networkData = new NetworkDataLinkIsConfirmed(dt);

            var exception = Assert.Throws<DataTableStructureException>(() => networkData.GetEdges());
            Assert.Equal("Not all LinkIsConfirmed column values are booleans.", exception.Message);
        }
    }
}
