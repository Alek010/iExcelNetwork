// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary.Exceptions;
using VisjsNetworkLibrary.Models;
using VisjsNetworkLibrary.NetworkDataClasses;

namespace VisjsNetworkLibraryTests
{
    public class NetworkDataScalingNodesAndEdgesTests
    {
        [Fact]
        public void GetNodes_ExtractsCorrectNodes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromvalue", typeof(string));
            dt.Columns.Add("tovalue", typeof(string));

            dt.Rows.Add("A", "B", "5", "10");

            NetworkDataScalingNodesAndEdges networkData = new NetworkDataScalingNodesAndEdges(dt);

            List<Node> nodes = networkData.GetNodes();

            Assert.Equal(2, nodes.Count);

            Assert.Equivalent(new Node() { Id = 1, Label = "A", Value = 5  }, nodes[0]);
            Assert.Equivalent(new Node() { Id = 2, Label = "B", Value = 10 }, nodes[1]);
        }

        [Fact]
        public void GetNodes_WhenFromValueColumnHasNonIntegers_ThrowsDataTableStructureException()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromvalue", typeof(string));
            dt.Columns.Add("tovalue", typeof(string));

            dt.Rows.Add("A", "B", "5X", "10");

            NetworkDataScalingNodesAndEdges networkData = new NetworkDataScalingNodesAndEdges(dt);

            var exception = Assert.Throws<DataTableStructureException>(() => networkData.GetNodes());
            Assert.Equal("Not all 'fromvalue' column values are integers.", exception.Message);

        }

        [Fact]
        public void GetNodes_WhenToValueColumnHasNonIntegers_ThrowsDataTableStructureException()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromvalue", typeof(string));
            dt.Columns.Add("tovalue", typeof(string));

            dt.Rows.Add("A", "B", "5", "10XX");

            NetworkDataScalingNodesAndEdges networkData = new NetworkDataScalingNodesAndEdges(dt);

            var exception = Assert.Throws<DataTableStructureException>(() => networkData.GetNodes());
            Assert.Equal("Not all 'tovalue' column values are integers.", exception.Message);

        }

        [Fact]
        public void GetNodes_WhenFromValueAndToValueColumnAreEmpty_ExtractsCorrectNodesWithSizeValueOne()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromvalue", typeof(string));
            dt.Columns.Add("tovalue", typeof(string));

            dt.Rows.Add("A", "B", "", "");

            NetworkDataScalingNodesAndEdges networkData = new NetworkDataScalingNodesAndEdges(dt);

            List<Node> nodes = networkData.GetNodes();

            Assert.Equal(2, nodes.Count);

            Assert.Equivalent(new Node() { Id = 1, Label = "A", Value = 1 }, nodes[0]);
            Assert.Equivalent(new Node() { Id = 2, Label = "B", Value = 1 }, nodes[1]);

        }

        [Fact]
        public void GetEdges_WithMultipleUniqueRowsTable_ExtractsCorrectEdges()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromvalue", typeof(string));
            dt.Columns.Add("tovalue", typeof(string));

            dt.Rows.Add("A", "B", "5", "10");
            dt.Rows.Add("A", "B", "5", "10");

            NetworkDataScalingNodesAndEdges networkData = new NetworkDataScalingNodesAndEdges(dt);

            List<Edge> edges = networkData.GetEdges();

            Assert.Single(edges);

            Assert.Equivalent(new Edge() { From = 1, To = 2, Value = 2, Title = "2" }, edges[0]);
        }

        [Fact]
        public void GetEdges_WithMultipleRowsTable_ExtractsCorrectEdges()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromvalue", typeof(string));
            dt.Columns.Add("tovalue", typeof(string));

            dt.Rows.Add("A", "B", "5", "10");
            dt.Rows.Add("A", "B", "5", "10");
            dt.Rows.Add("C", "D", "1", "2");

            NetworkDataScalingNodesAndEdges networkData = new NetworkDataScalingNodesAndEdges(dt);

            List<Edge> edges = networkData.GetEdges();

            Assert.Equal(2, edges.Count);

            Assert.Equivalent(new Edge() { From = 1, To = 2, Value = 2, Title = "2" }, edges[0]);
            Assert.Equivalent(new Edge() { From = 3, To = 4, Value = 1, Title = "1" }, edges[1]);
        }
    }
}
