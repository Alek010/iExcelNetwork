// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary;
using VisjsNetworkLibrary.Models;

namespace VisjsNetworkLibraryTests
{
    public class NetworkDataTests
    {
        [Fact]
        public void GetNodes_WithMultipleRowsTable_ExtractsCorrectNodes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));

            dt.Rows.Add("A", "B");
            dt.Rows.Add("B", "C");
            dt.Rows.Add("C", "D");

            NetworkData networkData = new NetworkData(dt);

            List<Node> nodes = networkData.GetNodes();

            Assert.Equal(4, nodes.Count);
            Assert.Contains(nodes, x => x.Label == "A");
            Assert.Equal(1, nodes.First(x => x.Label == "A").Id);
            Assert.Contains(nodes, x => x.Label == "B");
            Assert.Equal(2, nodes.First(x => x.Label == "B").Id);
            Assert.Contains(nodes, x => x.Label == "C");
            Assert.Equal(3, nodes.First(x => x.Label == "C").Id);
            Assert.Contains(nodes, x => x.Label == "D");
            Assert.Equal(4, nodes.First(x => x.Label == "D").Id);
        }
    }
}