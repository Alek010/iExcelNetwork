﻿// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary.Interfaces;
using VisjsNetworkLibrary;
using VisjsNetworkLibrary.Exceptions;
using VisjsNetworkLibrary.NetworkDataClasses;

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

            dt.Rows.Add("A", "B");

            var factory = new NetworkDataFactory(dt);
            factory.ValidateDataTable();
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

            dt.Rows.Add("A", "B", 1);

            var factory = new NetworkDataFactory(dt);
            factory.ValidateDataTable();
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

        [Fact]
        public void CreateNetworkDataWithNodesIcons_WithValidData_ReturnsNetworkData()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("to");
            dt.Columns.Add("toicon");

            dt.Rows.Add("A", "person", "B", "group");

            var factory = new NetworkDataFactory(dt);
            factory.ValidateDataTable();
            // Act
            INetworkData result = factory.CreateNetworkData();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NetworkDataWithNodesIcons>(result);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIcons_WithMissingColumns_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("to");

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIcons_WithExtraColumns_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("to");
            dt.Columns.Add("toicon");
            dt.Columns.Add("extraColumn");

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataLinkIsConfirmed_WithValidData_ReturnsNetworkData()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("linkisconfirmed");

            dt.Rows.Add("A", "B", "TRUE");

            var factory = new NetworkDataFactory(dt);
            factory.ValidateDataTable();
            // Act
            INetworkData result = factory.CreateNetworkData();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NetworkDataLinkIsConfirmed>(result);
        }

        [Fact]
        public void CreateNetworkDataLinkIsConfirmed_WithExtraColumn_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("linkisconfirmed");
            dt.Columns.Add("extraColumn");

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataLinkIsConfirmed_WithMissingColumn_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("icon");

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIconsInColor_WithValidData_ReturnsNetworkData()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("toicon");
            dt.Columns.Add("fromcolor");
            dt.Columns.Add("tocolor");

            dt.Rows.Add("A", "B", "person", "group", "green", "red");

            var factory = new NetworkDataFactory(dt);
            factory.ValidateDataTable();
            // Act
            INetworkData result = factory.CreateNetworkData();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NetworkDataWithNodesIconsInColor>(result);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIconsInColor_WithExtraColumn_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("toicon");
            dt.Columns.Add("fromcolor");
            dt.Columns.Add("tocolor");
            dt.Columns.Add("extraColumn");

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIconsInColor_WithMissingColumn_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("toicon");
            dt.Columns.Add("fromcolor");
            //dt.Columns.Add("tocolor"); missing column

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataScalingNodesAndEdges_WithValidData_ReturnsNetworkData()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("fromvalue");
            dt.Columns.Add("to");
            dt.Columns.Add("tovalue");

            dt.Rows.Add("A", 1, "B", 1);

            var factory = new NetworkDataFactory(dt);
            factory.ValidateDataTable();
            // Act
            INetworkData result = factory.CreateNetworkData();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NetworkDataScalingNodesAndEdges>(result);
        }

        [Fact]
        public void CreateNetworkDataScalingNodesAndEdges_WithMissingColumn_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("fromvalue");
            //dt.Columns.Add("tovalue"); missing column.

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataScalingNodesAndEdges_WithExtraColumn_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("fromvalue");
            dt.Columns.Add("tovalue");
            dt.Columns.Add("extraColumn");

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataWithCountAndLinkIsConfirmed_WithValidData_ReturnsNetworkData()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("count");
            dt.Columns.Add("linkisconfirmed");

            dt.Rows.Add("A", "B", 1, "FALSE");

            var factory = new NetworkDataFactory(dt);
            factory.ValidateDataTable();
            // Act
            INetworkData result = factory.CreateNetworkData();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NetworkDataWithCountAndLinkIsConfirmed>(result);
        }

        [Fact]
        public void CreateNetworkDataWithCountAndLinkIsConfirmed_WithMissingColumn_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("count");
            dt.Columns.Add("othercolumn");
            //dt.Columns.Add("linkisconfirmed"); missing column

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataWithCountAndLinkIsConfirmed_WithExtraColumn_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("count");
            dt.Columns.Add("linkisconfirmed");
            dt.Columns.Add("extraColumn");

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIconsAndLinkIsConfirmed_WithValidData_ReturnsNetworkData()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("to");
            dt.Columns.Add("toicon");
            dt.Columns.Add("linkisconfirmed");
            dt.Rows.Add("A", "person", "B", "group", "TRUE");

            var factory = new NetworkDataFactory(dt);
            factory.ValidateDataTable();
            // Act
            INetworkData result = factory.CreateNetworkData();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NetworkDataWithNodesIconsAndLinkIsConfirmed>(result);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIconsAndLinkIsConfirmed_WithMissingColumn_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("to");
            dt.Columns.Add("toicon");
            //dt.Columns.Add("linkisconfirmed");
            dt.Columns.Add("OtherColumn");

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIconsAndLinkIsConfirmed_WithExtraColumn_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("to");
            dt.Columns.Add("toicon");
            dt.Columns.Add("linkisconfirmed");
            dt.Columns.Add("extraColumn");

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }


        [Fact]
        public void CreateNetworkDataWithNodesIconsAndLinkIsConfirmedAndCount_WithValidData_ReturnsNetworkData()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("to");
            dt.Columns.Add("toicon");
            dt.Columns.Add("count");
            dt.Columns.Add("linkisconfirmed");

            dt.Rows.Add("A", "person", "B", "group", 1, "TRUE");

            var factory = new NetworkDataFactory(dt);
            factory.ValidateDataTable();
            // Act
            INetworkData result = factory.CreateNetworkData();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount>(result);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIconsAndLinkIsConfirmedAndCount_WithMissingColumn_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("to");
            dt.Columns.Add("toicon");
            dt.Columns.Add("count");
            //dt.Columns.Add("linkisconfirmed");
            dt.Columns.Add("OtherColumn");

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIconsAndLinkIsConfirmedAndCount_WithExtraColumn_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("to");
            dt.Columns.Add("toicon");
            dt.Columns.Add("count");
            dt.Columns.Add("linkisconfirmed");
            dt.Columns.Add("extraColumn");

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIconsInColorAndLinkIsConfirmed_WithValidData_ReturnsNetworkData()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("toicon");
            dt.Columns.Add("fromcolor");
            dt.Columns.Add("tocolor");
            dt.Columns.Add("linkisconfirmed");

            dt.Rows.Add("A", "B", "", "", "", "", "FALSE");

            var factory = new NetworkDataFactory(dt);
            factory.ValidateDataTable();
            // Act
            INetworkData result = factory.CreateNetworkData();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NetworkDataWithNodesIconsInColorAndLinkIsConfirmed>(result);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIconsInColorAndLinkIsConfirmed_WithExtraColumn_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("toicon");
            dt.Columns.Add("fromcolor");
            dt.Columns.Add("tocolor");
            dt.Columns.Add("linkisconfirmed");
            dt.Columns.Add("extraColumn");

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIconsInColorAndLinkIsConfirmed_WithMissingColumn_ThrowsDataTableStructureException()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("fromicon");
            dt.Columns.Add("toicon");
            dt.Columns.Add("fromcolor");
            dt.Columns.Add("tocolor");
            //dt.Columns.Add("linkisconfirmed"); missing column
            dt.Columns.Add("extraColumn");

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIconsInColorAndCount_WithValidData_ReturnsNetworkData()
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

            dt.Rows.Add("A", "B", "", "", "", "", 1);

            var factory = new NetworkDataFactory(dt);
            factory.ValidateDataTable();
            // Act
            INetworkData result = factory.CreateNetworkData();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NetworkDataWithNodesIconsInColorAndCount>(result);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIconsInColorAndCount_WithExtraColumn_ThrowsDataTableStructureException()
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

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIconsInColorAndCount_WithMissingColumn_ThrowsDataTableStructureException()
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

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmed_WithValidData_ReturnsNetworkData()
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
            dt.Columns.Add("linkisconfirmed");

            dt.Rows.Add("A", "B", "", "", "", "", 1, "FALSE");

            var factory = new NetworkDataFactory(dt);
            factory.ValidateDataTable();
            // Act
            INetworkData result = factory.CreateNetworkData();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmed>(result);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmed_WithExtraColumn_ThrowsDataTableStructureException()
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
            dt.Columns.Add("linkisconfirmed");
            dt.Columns.Add("extraColumn");

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

        [Fact]
        public void CreateNetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmed_WithMissingColumn_ThrowsDataTableStructureException()
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
            dt.Columns.Add("linkisconfirmed");
            dt.Columns.Add("extraColumn");

            var factory = new NetworkDataFactory(dt);

            // Act & Assert
            var exception = Assert.Throws<DataTableStructureException>(() => factory.CreateNetworkData());
            Assert.Equal("Selected table column structure not match any pattern.", exception.Message);
        }

    }
}
