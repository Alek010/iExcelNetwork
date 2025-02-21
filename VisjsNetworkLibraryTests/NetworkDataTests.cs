// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary;
using VisjsNetworkLibrary.Models;

namespace VisjsNetworkLibraryTests
{
    public class NetworkDataTests
    {
        [Fact]
        public void GetNodes_WithOneRowsTable_ExtractsCorrectNodes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));

            dt.Rows.Add("A", "B");

            NetworkData networkData = new NetworkData(dt);

            List<Node> nodes = networkData.GetNodes();

            Assert.Equal(2, nodes.Count);
            Assert.Contains(nodes, x => x.Label == "A");
            Assert.Equal(1, nodes.First(x => x.Label == "A").Id);
            Assert.Contains(nodes, x => x.Label == "B");
            Assert.Equal(2, nodes.First(x => x.Label == "B").Id);
        }

        [Fact]
        public void GetNodes_WithTwoDuplicateRowsTable_ExtractsCorrectNodes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));

            dt.Rows.Add("A", "B");
            dt.Rows.Add("A", "B");

            NetworkData networkData = new NetworkData(dt);

            List<Node> nodes = networkData.GetNodes();

            Assert.Equal(2, nodes.Count);
            Assert.Contains(nodes, x => x.Label == "A");
            Assert.Equal(1, nodes.First(x => x.Label == "A").Id);
            Assert.Contains(nodes, x => x.Label == "B");
            Assert.Equal(2, nodes.First(x => x.Label == "B").Id);
        }

        [Fact]
        public void GetNodes_WithTwoUniqueRowsTable_ExtractsCorrectNodes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));

            dt.Rows.Add("A", "B");
            dt.Rows.Add("F", "D");

            NetworkData networkData = new NetworkData(dt);

            List<Node> nodes = networkData.GetNodes();

            Assert.Equal(4, nodes.Count);
            Assert.Contains(nodes, x => x.Label == "A");
            Assert.Equal(1, nodes.First(x => x.Label == "A").Id);
            Assert.Contains(nodes, x => x.Label == "B");
            Assert.Equal(2, nodes.First(x => x.Label == "B").Id);
            Assert.Contains(nodes, x => x.Label == "D");
            Assert.Equal(4, nodes.First(x => x.Label == "D").Id);
            Assert.Contains(nodes, x => x.Label == "F");
            Assert.Equal(3, nodes.First(x => x.Label == "F").Id);
        }

        [Fact]
        public void GetNodes_WithThreeRowsAndDuplicateRowsTable_ExtractsCorrectNodes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));

            dt.Rows.Add("A", "B");
            dt.Rows.Add("F", "D");
            dt.Rows.Add("A", "B");

            NetworkData networkData = new NetworkData(dt);

            List<Node> nodes = networkData.GetNodes();

            Assert.Equal(4, nodes.Count);
            Assert.Contains(nodes, x => x.Label == "A");
            Assert.Equal(1, nodes.First(x => x.Label == "A").Id);
            Assert.Contains(nodes, x => x.Label == "B");
            Assert.Equal(2, nodes.First(x => x.Label == "B").Id);
            Assert.Contains(nodes, x => x.Label == "D");
            Assert.Equal(4, nodes.First(x => x.Label == "D").Id);
            Assert.Contains(nodes, x => x.Label == "F");
            Assert.Equal(3, nodes.First(x => x.Label == "F").Id);
        }

        [Fact]
        public void GetEdges_WithMultipleUniqueRowsTable_ExtractsCorrectEdges()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));

            dt.Rows.Add("A", "B");
            dt.Rows.Add("C", "B");

            NetworkData networkData = new NetworkData(dt);

            List<Edge> edges = networkData.GetEdges();

            Assert.Equal(2, edges.Count);

            Assert.Equivalent(new Edge() { From = 1, To = 2, Count = "1" }, edges[0]);
            Assert.Equivalent(new Edge() { From = 3, To = 2, Count = "1" }, edges[1]);
        }

        [Fact]
        public void GetEdges_WithDuplicateRowsTable_ExtractsCorrectEdges()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));

            dt.Rows.Add("C", "B");
            dt.Rows.Add("A", "B");
            dt.Rows.Add("C", "B");


            NetworkData networkData = new NetworkData(dt);

            List<Edge> edges = networkData.GetEdges();

            Assert.Equal(2, edges.Count);

            Assert.Equivalent(new Edge() { From = 1, To = 2, Count = "2" }, edges[0]);
            Assert.Equivalent(new Edge() { From = 3, To = 2, Count = "1" }, edges[1]);
        }
    }
}