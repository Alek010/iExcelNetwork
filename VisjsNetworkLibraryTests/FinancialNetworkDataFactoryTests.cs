

// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary;
using VisjsNetworkLibrary.Exceptions;
using VisjsNetworkLibrary.FinancialNetworkData;
using VisjsNetworkLibrary.Interfaces;

namespace VisjsNetworkLibraryTests
{
    public class FinancialNetworkDataFactoryTests
    {
        #region FinancialNetworkDataWthCount
        [Fact]
        public void CreateFinancialNetworkDataWithCount_WithValidDataTableStructure_ReturnsNetworkData()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("count");

            var factory = new FinancialNetworkDataFactory(dt);

            // Act
            INetworkData result = factory.CreateNetworkData();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<FinancialNetworkDataWithCount>(result);
        }

        [Fact]
        public void CreateFinancialNetworkDataWithCount_WithInvalidDataTableStructure_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("subject"); // Another column name than "to" column
            dt.Columns.Add("count");

            var factory = new FinancialNetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateFinancialNetworkDataWithCount_WithExtraColumns_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("count");
            dt.Columns.Add("extra"); // This extra column makes the column count != 2

            var factory = new FinancialNetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }
        #endregion

        #region FinancialnetworkDataWithNodesIconsAndCount

        [Fact]
        public void CreateFinancialNetworkDataWithNodesIconsAndCount_WithValidDataTableStructure_ReturnsNetworkData()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("toicon");
            dt.Columns.Add("count");

            var factory = new FinancialNetworkDataFactory(dt);

            // Act
            INetworkData result = factory.CreateNetworkData();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<FinancialNetworkDataWithNodesIconsAndCount>(result);
        }

        [Fact]
        public void CreateFinancialNetworkDataWithNodesIconsAndCount_WithExtraColumn_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("toicon");
            dt.Columns.Add("fromcolor");
            dt.Columns.Add("tocolor");
            dt.Columns.Add("count");
            dt.Columns.Add("extraColumn");

            var factory = new FinancialNetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateFinancialNetworkDataWithNodesIconsAndCount_WithMissingColumn_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("toicon");
            dt.Columns.Add("fromcolor");
            dt.Columns.Add("tocolor");
            //dt.Columns.Add("count"); missing column
            dt.Columns.Add("extraColumn");

            var factory = new FinancialNetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        #endregion

        #region FinancialNetworkDataWithNodesiconsInColorAndCount
        [Fact]
        public void CreateFinancialNetworkDataWithNodesIconsInColorAndCount_WithValidDataTableStructure_ReturnsNetworkData()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("toicon");
            dt.Columns.Add("fromcolor");
            dt.Columns.Add("tocolor");
            dt.Columns.Add("count");

            var factory = new FinancialNetworkDataFactory(dt);

            // Act
            INetworkData result = factory.CreateNetworkData();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<FinancialNetworkDataWithNodesIconsInColorAndCount>(result);
        }

        [Fact]
        public void CreateFinancialNetworkDataWithNodesIconsInColorAndCount_WithExtraColumn_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("toicon");
            dt.Columns.Add("fromcolor");
            dt.Columns.Add("tocolor");
            dt.Columns.Add("count");
            dt.Columns.Add("extraColumn");

            var factory = new FinancialNetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateFinancialNetworkDataWithNodesIconsInColorAndCount_WithMissingColumn_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("toicon");
            dt.Columns.Add("fromcolor");
            dt.Columns.Add("tocolor");
            //dt.Columns.Add("count"); missing column
            dt.Columns.Add("extraColumn");

            var factory = new FinancialNetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }
        #endregion
    }
}
