
using GraphVisualizationLibrary.Interfaces;
using Moq;

namespace GraphVisualizationLibrary.Tests
{
    public class DataRangeTests
    {
        private Mock<ISelectedRange> MockedSelectedRange
        {
            get
            {
                var mockSelectedRange = new Mock<ISelectedRange>();

                // Set up the mock to return a specific list of Range objects
                mockSelectedRange.Setup(x => x.GroupRangeByFromToDuplicates())
                                 .Returns(new List<Models.Range>
                                 {
                                 new Models.Range { From = "A", To = "B", Count = "5" },
                                 new Models.Range { From = "C", To = "D", Count = "3" }
                                 });

                return mockSelectedRange;
            }
        }

        [Fact]
        public void GetFromColumnValues()
        {
            // Arrange
            var mockSelectedRange = MockedSelectedRange;

            // Act
            var dataRange = new DataRange(mockSelectedRange.Object);
            var fromValues = dataRange.GetFromColumnValues();

            // Assert
            Assert.Equal(2, fromValues.Count);
            Assert.Equal("A", fromValues[0]);
            Assert.Equal("C", fromValues[1]);

            // Verify that GroupRangeByFromToDuplicates was called exactly once
            mockSelectedRange.Verify(x => x.GroupRangeByFromToDuplicates(), Times.Once);
        }

        [Fact]
        public void GetToColumnValues()
        {
            // Arrange
            var mockSelectedRange = MockedSelectedRange;

            // Act
            var dataRange = new DataRange(mockSelectedRange.Object);
            var fromValues = dataRange.GetToColumnValues();

            // Assert
            Assert.Equal(2, fromValues.Count);
            Assert.Equal("B", fromValues[0]);
            Assert.Equal("D", fromValues[1]);

            // Verify that GroupRangeByFromToDuplicates was called exactly once
            mockSelectedRange.Verify(x => x.GroupRangeByFromToDuplicates(), Times.Once);
        }

        [Fact]
        public void GetLinksCount()
        {
            // Arrange
            var mockSelectedRange = MockedSelectedRange;

            // Act
            var dataRange = new DataRange(mockSelectedRange.Object);
            var fromValues = dataRange.GetLinksCount();

            // Assert
            Assert.Equal(2, fromValues.Count);
            Assert.Equal("5", fromValues[0]);
            Assert.Equal("3", fromValues[1]);

            // Verify that GroupRangeByFromToDuplicates was called exactly once
            mockSelectedRange.Verify(x => x.GroupRangeByFromToDuplicates(), Times.Once);
        }
    }
}
