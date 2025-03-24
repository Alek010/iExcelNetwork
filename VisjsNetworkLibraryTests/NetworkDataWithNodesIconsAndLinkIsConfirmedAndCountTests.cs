
// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary.Exceptions;
using VisjsNetworkLibrary.Models;
using VisjsNetworkLibrary.NetworkDataClasses;

namespace VisjsNetworkLibraryTests
{
    public class NetworkDataWithNodesIconsAndLinkIsConfirmedAndCountTests
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
            dt.Columns.Add("linkisconfirmed", typeof(string));

            dt.Rows.Add("A", "B", "person", "group", "1", "True");

            NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount networkData = new NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount(dt);

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
            dt.Columns.Add("linkisconfirmed", typeof(string));

            dt.Rows.Add("A", "B", "person", "", "True");

            NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount networkData = new NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount(dt);

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
            dt.Columns.Add("linkisconfirmed", typeof(string));

            dt.Rows.Add("A", "B", "Person", "Group", "1", "true");
            dt.Rows.Add("C", "B", "Cellphone", "Group", "2", "false");


            NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount networkData = new NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount(dt);

            List<Edge> edges = networkData.GetEdges();

            Assert.Equal(2, edges.Count);

            Assert.Equivalent(new Edge() { From = 1, To = 2, Count = "1", IsDashed = false }, edges[0]);
            Assert.Equivalent(new Edge() { From = 3, To = 2, Count = "2", IsDashed = true }, edges[1]);
        }

        [Fact]
        public void GetEdges_WithDuplicateRowsTableWithLinkIsConfirmedValuesAreSame_ExtractsCorrectEdges()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromicon", typeof(string));
            dt.Columns.Add("toicon", typeof(string));
            dt.Columns.Add("count", typeof(string));
            dt.Columns.Add("linkisconfirmed", typeof(string));

            dt.Rows.Add("C", "B", "Person", "Group", "5", "true");
            dt.Rows.Add("A", "B", "ID-card", "Group", "5", "false");
            dt.Rows.Add("E", "F", "car", "Person", "1", "false");
            dt.Rows.Add("E", "F", "car", "person", "1", "false");

            NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount networkData = new NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount(dt);

            List<Edge> edges = networkData.GetEdges();

            Assert.Equal(3, edges.Count);

            Assert.Equivalent(new Edge() { From = 1, To = 2, Count = "5", IsDashed = false }, edges[0]);
            Assert.Equivalent(new Edge() { From = 3, To = 2, Count = "5", IsDashed = true }, edges[1]);
            Assert.Equivalent(new Edge() { From = 4, To = 5, Count = "2", IsDashed = true }, edges[2]);
        }

        [Fact]
        public void GetEdges_WithDuplicateRowsTableWithLinkIsConfirmedValuesAreDifferent_ThrowsDataStructureException()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromicon", typeof(string));
            dt.Columns.Add("toicon", typeof(string));
            dt.Columns.Add("count", typeof(string));
            dt.Columns.Add("linkisconfirmed", typeof(string));

            dt.Rows.Add("C", "B", "Person", "Group", "5", "true");
            dt.Rows.Add("A", "B", "ID-card", "Group", "5", "false");
            dt.Rows.Add("E", "F", "car", "Person", "1", "true");
            dt.Rows.Add("E", "F", "car", "person", "1", "false");

            NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount networkData = new NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount(dt);

            var exception = Assert.Throws<DataTableStructureException>(() => networkData.GetEdges());
            Assert.Equal("There are same link From-To with different values of 'Link Is Confirmed' column.", exception.Message);
        }

        [Fact]
        public void GetEdges_WitLinkIsConfirmedColumnValuesNonBoolean_ThrowsDataTableStructureException()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromicon", typeof(string));
            dt.Columns.Add("toicon", typeof(string));
            dt.Columns.Add("count", typeof(string));
            dt.Columns.Add("linkisconfirmed", typeof(string));

            dt.Rows.Add("C", "B", "Person", "Group", "5", "x");

            NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount networkData = new NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount(dt);

            var exception = Assert.Throws<DataTableStructureException>(() => networkData.GetEdges());
            Assert.Equal("Not all 'linkisconfirmed' column values are booleans.", exception.Message);
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
            dt.Columns.Add("linkisconfirmed", typeof(string));

            dt.Rows.Add("C", "B", "Person", "Group", "xxx", "True");

            NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount networkData = new NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount(dt);

            var exception = Assert.Throws<DataTableStructureException>(() => networkData.GetEdges());
            Assert.Equal("Not all count column values are integers.", exception.Message);
        }
    }
}
