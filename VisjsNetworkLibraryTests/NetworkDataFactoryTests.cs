// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary.Interfaces;
using VisjsNetworkLibrary;
using VisjsNetworkLibrary.Exceptions;

namespace VisjsNetworkLibraryTests
{
    public class NetworkDataFactoryTests
    {
        [Fact]
        public void CreateNetworkData_WithValidData_ReturnsNetworkData()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");

            var factory = new NetworkDataFactory(dt);

            // Act
            INetworkData result = factory.CreateNetworkData();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NetworkData>(result);
        }

        [Fact]
        public void CreateNetworkData_WithInvalidData_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("subject"); // Missing "to" column

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkData_WithExtraColumns_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("extra"); // This extra column makes the column count != 2

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataWithCount_WithValidData_ReturnsNetworkData()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("count");

            var factory = new NetworkDataFactory(dt);

            // Act
            INetworkData result = factory.CreateNetworkData();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NetworkDataWithCount>(result);
        }

        [Fact]
        public void CreateNetworkDataWithCount_WithInvalidData_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("subject"); // Missing "to" column
            dt.Columns.Add("count");

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataWithCount_WithExtraColumns_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("count");
            dt.Columns.Add("extra"); // This extra column makes the column count != 2

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }
    }
}
