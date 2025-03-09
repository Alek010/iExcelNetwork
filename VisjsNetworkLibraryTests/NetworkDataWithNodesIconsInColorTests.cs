// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary.Models;
using VisjsNetworkLibrary.NetworkDataClasses;

namespace VisjsNetworkLibraryTests
{
    public class NetworkDataWithNodesIconsInColorTests
    {
        [Fact]
        public void GetNodes_ExtractsCorrectNodes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromicon", typeof(string));
            dt.Columns.Add("toicon", typeof(string));
            dt.Columns.Add("fromcolor", typeof(string));
            dt.Columns.Add("tocolor", typeof(string));

            dt.Rows.Add("A", "B", "person", "group", "red", "green");

            NetworkDataWithNodesIconsInColor networkData = new NetworkDataWithNodesIconsInColor(dt);

            List<Node> nodes = networkData.GetNodes();

            Assert.Equal(2, nodes.Count);

            Assert.Equivalent(new Node() { Id = 1, Label = "A", Shape = "icon", Icon = new NodeIcon { Face = "FontAwesome", Code = "\uf007", Size = 50, Color = "#e74c3c" } }, nodes[0]);
            Assert.Equivalent(new Node() { Id = 2, Label = "B", Shape = "icon", Icon = new NodeIcon { Face = "FontAwesome", Code = "\uf0c0", Size = 50, Color = "#2ecc71" } }, nodes[1]);
        }

        [Fact]
        public void GetNodes_WhenIconTypeNotSpecified_ExtractsCorrectNodes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromicon", typeof(string));
            dt.Columns.Add("toicon", typeof(string));
            dt.Columns.Add("fromcolor", typeof(string));
            dt.Columns.Add("tocolor", typeof(string));

            dt.Rows.Add("A", "B", "person", "", "red", "");

            NetworkDataWithNodesIconsInColor networkData = new NetworkDataWithNodesIconsInColor(dt);

            List<Node> nodes = networkData.GetNodes();

            Assert.Equal(2, nodes.Count);

            Assert.Equivalent(new Node() { Id = 1, Label = "A", Shape = "icon", Icon = new NodeIcon { Face = "FontAwesome", Code = "\uf007", Size = 50, Color = "#e74c3c" } }, nodes[0]);
            Assert.Equivalent(new Node() { Id = 2, Label = "B", Shape = "icon", Icon = new NodeIcon { Face = "FontAwesome", Code = "\uf111", Size = 50, Color = "#3d85c6" } }, nodes[1]);
        }
    }
}
