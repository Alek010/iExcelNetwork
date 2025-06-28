// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary.Exceptions;
using VisjsNetworkLibrary.FinancialNetworkData;
using VisjsNetworkLibrary.Models;

namespace VisjsNetworkLibraryTests
{
    public class FinancialNetworkDataWithNodesIconsInColorAndCountTests
    {
        public class FinancialNetworkDataWithNodesIconsAndCountTests
        {
            [Fact]
            public void GetNodes_ExtractsCorrectNodes()
            {
                DataTable dt = CreateFinancialNetwrokDataWithNodesIconsAndCountTable();

                dt.Rows.Add("A", "B", "person", "group", "red", "green", "2");

                FinancialNetworkDataWithNodesIconsInColorAndCount networkData = new FinancialNetworkDataWithNodesIconsInColorAndCount(dt);

                List<Node> nodes = networkData.GetNodes();

                Assert.Equal(2, nodes.Count);

                Assert.Equivalent(new Node() { Id = 1, Label = "A", Shape = "icon", Icon = new NodeIcon { Face = "FontAwesome", Code = "\uf007", Size = 50, Color = "#e74c3c" } }, nodes[0]);
                Assert.Equivalent(new Node() { Id = 2, Label = "B", Shape = "icon", Icon = new NodeIcon { Face = "FontAwesome", Code = "\uf0c0", Size = 50, Color = "#2ecc71" } }, nodes[1]);
            }

            [Fact]
            public void GetNodes_WhenIconTypeAndColorNotSpecified_ExtractsCorrectNodesWithDefaultValues()
            {
                DataTable dt = CreateFinancialNetwrokDataWithNodesIconsAndCountTable();

                dt.Rows.Add("A", "B", "person", "", "red", "", "1");

                FinancialNetworkDataWithNodesIconsInColorAndCount networkData = new FinancialNetworkDataWithNodesIconsInColorAndCount(dt);

                List<Node> nodes = networkData.GetNodes();

                Assert.Equal(2, nodes.Count);

                Assert.Equivalent(new Node() { Id = 1, Label = "A", Shape = "icon", Icon = new NodeIcon { Face = "FontAwesome", Code = "\uf007", Size = 50, Color = "#e74c3c" } }, nodes[0]);
                Assert.Equivalent(new Node() { Id = 2, Label = "B", Shape = "icon", Icon = new NodeIcon { Face = "FontAwesome", Code = "\uf111", Size = 50, Color = "#3d85c6" } }, nodes[1]);
            }

            [Fact]
            public void GetEdges_WithMultipleUniqueRowsTable_ExtractsCorrectEdges()
            {
                DataTable dt = CreateFinancialNetwrokDataWithNodesIconsAndCountTable();

                dt.Rows.Add("A", "B", "person", "group", "red", "green", "1");
                dt.Rows.Add("C", "B", "home", "group", "yellow", "green", "2");

                FinancialNetworkDataWithNodesIconsInColorAndCount networkData = new FinancialNetworkDataWithNodesIconsInColorAndCount(dt);

                List<Edge> edges = networkData.GetEdges();

                Assert.Equal(2, edges.Count);

                Assert.Equivalent(
                    new Edge()
                    {
                        From = 1,
                        To = 2,
                        Count = "1",
                        Value = 0.30 * 5,
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
                DataTable dt = CreateFinancialNetwrokDataWithNodesIconsAndCountTable();

                dt.Rows.Add("C", "B", "person", "group", "red", "green", "5");
                dt.Rows.Add("A", "B", "car", "group", "blue", "green", "1");
                dt.Rows.Add("C", "B", "person", "group", "red", "green", "5");


                FinancialNetworkDataWithNodesIconsInColorAndCount networkData = new FinancialNetworkDataWithNodesIconsInColorAndCount(dt);

                List<Edge> edges = networkData.GetEdges();

                Assert.Equal(2, edges.Count);

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
                DataTable dt = CreateFinancialNetwrokDataWithNodesIconsAndCountTable();

                dt.Rows.Add("C", "B", "person", "group", "red", "green", "x");

                FinancialNetworkDataWithNodesIconsInColorAndCount networkData = new FinancialNetworkDataWithNodesIconsInColorAndCount(dt);

                var exception = Assert.Throws<DataTableStructureException>(() => networkData.GetEdges());
                Assert.Equal("Not all count column values are integers.", exception.Message);
            }

            private string BuildEdgeTitle(double[] titleValues)
            {
                return $"Count: {titleValues[0]}\nSum: {titleValues[1]:F2}\nAverage: {titleValues[2]:F2}\nMin: {titleValues[3]:F2}\n" +
                       $"Max: {titleValues[4]:F2}\nStd.Dev: {titleValues[5]:F2}\n---------\nEdgeWeight: {titleValues[6]:F2}";
            }

            private DataTable CreateFinancialNetwrokDataWithNodesIconsAndCountTable()
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("from", typeof(string));
                dt.Columns.Add("to", typeof(string));
                dt.Columns.Add("fromicon", typeof(string));
                dt.Columns.Add("toicon", typeof(string));
                dt.Columns.Add("fromcolor", typeof(string));
                dt.Columns.Add("tocolor", typeof(string));
                dt.Columns.Add("count", typeof(string));

                return dt;
            }
        }
    }
}
