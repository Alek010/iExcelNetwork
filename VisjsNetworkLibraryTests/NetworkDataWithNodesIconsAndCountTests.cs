

// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary.Exceptions;
using VisjsNetworkLibrary.Models;
using VisjsNetworkLibrary.NetworkDataClasses;

namespace VisjsNetworkLibraryTests
{
    public class NetworkDataWithNodesIconsAndCountTests
    {
        [Fact]
        public void GetNodes_ExtractsCorrectNodes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromicon", typeof(string));
            dt.Columns.Add("toicon", typeof(string));
            dt.Columns.Add("count", typeof(string));

            dt.Rows.Add("A", "B", "person", "group", "2");

            NetworkDataWithNodesIconsAndCount networkData = new NetworkDataWithNodesIconsAndCount(dt);

            List<Node> nodes = networkData.GetNodes();

            Assert.Equal(2, nodes.Count);

            Assert.Equivalent(new Node() { Id = 1, Label = "A", Shape = "icon", Icon = new NodeIcon { Face = "FontAwesome", Code = "\uf007", Size = 50, Color = "#3d85c6" } }, nodes[0]);
            Assert.Equivalent(new Node() { Id = 2, Label = "B", Shape = "icon", Icon = new NodeIcon { Face = "FontAwesome", Code = "\uf0c0", Size = 50, Color = "#3d85c6" } }, nodes[1]);
        }

        [Fact]
        public void GetNodes_WhenIconTypeNotSpecified_ExtractsCorrectNodes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromicon", typeof(string));
            dt.Columns.Add("toicon", typeof(string));
            dt.Columns.Add("count", typeof(string));

            dt.Rows.Add("A", "B", "person", "", "2");

            NetworkDataWithNodesIconsAndCount networkData = new NetworkDataWithNodesIconsAndCount(dt);

            List<Node> nodes = networkData.GetNodes();

            Assert.Equal(2, nodes.Count);

            Assert.Equivalent(new Node() { Id = 1, Label = "A", Shape = "icon", Icon = new NodeIcon { Face = "FontAwesome", Code = "\uf007", Size = 50, Color = "#3d85c6" } }, nodes[0]);
            Assert.Equivalent(new Node() { Id = 2, Label = "B", Shape = "icon", Icon = new NodeIcon { Face = "FontAwesome", Code = "\uf111", Size = 50, Color = "#3d85c6" } }, nodes[1]);
        }

        [Fact]
        public void GetEdges_WithMultipleUniqueRowsTable_ExtractsCorrectEdges()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromicon", typeof(string));
            dt.Columns.Add("toicon", typeof(string));
            dt.Columns.Add("count", typeof(string));

            dt.Rows.Add("A", "B", "person", "group", "1");
            dt.Rows.Add("C", "B", "home", "group", "2");

            NetworkDataWithNodesIconsAndCount networkData = new NetworkDataWithNodesIconsAndCount(dt);

            List<Edge> edges = networkData.GetEdges();

            Assert.Equal(2, edges.Count);

            Assert.Equivalent(new Edge() { From = 1, To = 2, Count = "1" }, edges[0]);
            Assert.Equivalent(new Edge() { From = 3, To = 2, Count = "2" }, edges[1]);
        }

        [Fact]
        public void GetEdges_WithDuplicateRows_ExtractsCorrectEdges()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromicon", typeof(string));
            dt.Columns.Add("toicon", typeof(string));
            dt.Columns.Add("count", typeof(string));

            dt.Rows.Add("C", "B", "person", "group", "1");
            dt.Rows.Add("A", "B", "male", "group", "1" );
            dt.Rows.Add("E", "F", "ID-card", "person", "2");
            dt.Rows.Add("E", "F", "ID-card", "person", "2");

            NetworkDataWithNodesIconsAndCount networkData = new NetworkDataWithNodesIconsAndCount(dt);

            List<Edge> edges = networkData.GetEdges();

            Assert.Equal(3, edges.Count);

            Assert.Equivalent(new Edge() { From = 1, To = 2, Count = "1" }, edges[0]);
            Assert.Equivalent(new Edge() { From = 3, To = 2, Count = "1" }, edges[1]);
            Assert.Equivalent(new Edge() { From = 4, To = 5, Count = "4" }, edges[2]);
        }

        [Fact]
        public void GetEdges_WithCountColumnValuesNonInteger_ThrowsDataTableStructureException()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromicon", typeof(string));
            dt.Columns.Add("toicon", typeof(string));
            dt.Columns.Add("count", typeof(string));

            dt.Rows.Add("A", "B", "person", "", "xxx");

            NetworkDataWithNodesIconsAndCount networkData = new NetworkDataWithNodesIconsAndCount(dt);

            var exception = Assert.Throws<DataTableStructureException>(() => networkData.GetEdges());
            Assert.Equal("Not all count column values are integers.", exception.Message);
        }
    }
}
