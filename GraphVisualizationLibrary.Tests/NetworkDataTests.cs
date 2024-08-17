using GraphVisualizationLibrary.Interfaces;
using GraphVisualizationLibrary.Models;
using Moq;

namespace GraphVisualizationLibrary.Tests
{
    public class NetworkDataTests
    {
        private Mock<IDataRange> MockedDataRange
        {
            get
            {
                Mock<IDataRange> mockDataRange = new Mock<IDataRange>();

                mockDataRange.Setup(from => from.GetFromColumnValues()).Returns(new List<string> { "A", "B", "C" });
                mockDataRange.Setup(to => to.GetToColumnValues()).Returns(new List<string> { "B", "C", "D" });
                mockDataRange.Setup(count => count.GetLinksCount()).Returns(new List<string> { "1", "2", "1" });

                return mockDataRange;
            }
        }

        [Fact]
        public void GetNodes_ShouldReturnCorrectNodesList()
        {
            // Arrange
            var mockDataRange = MockedDataRange;

            NetworkData networkData = new NetworkData(mockDataRange.Object);

            // Act
            List<Node> nodes = networkData.GetNodes();

            // Assert
            Assert.Equal(4, nodes.Count);

            Assert.Equal(1, nodes[0].Id);
            Assert.Equal("A", nodes[0].Label);

            Assert.Equal(2, nodes[1].Id);
            Assert.Equal("B", nodes[1].Label);

            Assert.Equal(3, nodes[2].Id);
            Assert.Equal("C", nodes[2].Label);

            Assert.Equal(4, nodes[3].Id);
            Assert.Equal("D", nodes[3].Label);

            // Verify that were called once
            mockDataRange.Verify(dr => dr.GetFromColumnValues(), Times.Once);
            mockDataRange.Verify(dr => dr.GetToColumnValues(), Times.Once);
            mockDataRange.Verify(dr => dr.GetLinksCount(), Times.Once);
        }

        [Fact]
        public void GetEdges_ShouldReturnCorrectNodesList()
        {
            // Arrange
            var mockDataRange = MockedDataRange;

            NetworkData networkData = new NetworkData(mockDataRange.Object);

            // Act
            List<Edge> edges = networkData.GetEdges();

            // Assert
            Assert.Equal(3, edges.Count);

            Assert.Equal(1, edges[0].From);
            Assert.Equal(2, edges[0].To);
            Assert.Equal("1", edges[0].Count);

            Assert.Equal(2, edges[1].From);
            Assert.Equal(3, edges[1].To);
            Assert.Equal("2", edges[1].Count);

            Assert.Equal(3, edges[2].From);
            Assert.Equal(4, edges[2].To);
            Assert.Equal("1", edges[2].Count);

            // Verify that were called once
            mockDataRange.Verify(dr => dr.GetFromColumnValues(), Times.Once);
            mockDataRange.Verify(dr => dr.GetToColumnValues(), Times.Once);
            mockDataRange.Verify(dr => dr.GetLinksCount(), Times.Once);
        }
    }
}
