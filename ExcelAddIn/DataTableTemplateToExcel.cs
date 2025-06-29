// Ignore Spelling: App

using ExcelAddIn.Validations;
using VisjsNetworkLibrary.Models;
using Excel = Microsoft.Office.Interop.Excel;


namespace ExcelAddIn
{
    public class DataTableTemplateToExcel
    {
        private readonly Excel.Application _excelApp;
        private readonly NetworkDataTableTemplates _networkDataTablesTemplate;
        private readonly DataTableToExcel _dataTableToExcel;

        public DataTableTemplateToExcel(DataTableToExcel dataTableToExcel, NetworkDataTableTemplates networkDataTableTemplates)
        {
            _dataTableToExcel = dataTableToExcel;
            _networkDataTablesTemplate = networkDataTableTemplates;
        }

        public void CreateBasicNetworkDataTable()
        {
            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTablesTemplate.CreateNetworkDataTable(normalizeColumnNames: true));
        }

        public void CreateNetworkDataWithCountTable()
        {
            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTablesTemplate.CreateNetworkDataWithCountTable(normalizeColumnNames: true));
        }

        public void CreateNetworkDataLinkIsConfirmedTable()
        {
            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTablesTemplate.CreateNetworkDataLinkIsConfirmedTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));
        }

        public void CreateNetworkDataWithCountAndLinkIsConfirmedTable()
        {
            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTablesTemplate.CreateNetworkDataWithCountAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));
        }

        public void CreateNetworkDataWithNodesIconsTable()
        {
            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTablesTemplate.CreateNetworkDataWithNodesIconsTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));
        }

        public void CreateNetworkDataWithNodesIconsAndLinkIsConfirmedTable()
        {
            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTablesTemplate.CreateNetworkDataWithNodesIconsAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));
        }

        public void CreateNetworkDataWithNodesIconsAndCountTable()
        {
            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTablesTemplate.CreateNetworkDataWithNodesIconsAndCountTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));
        }

        public void CreateNetworkDataWithNodesIconsAndLinkIsConfirmedAndCountTable()
        {
            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTablesTemplate.CreateNetworkDataWithNodesIconsAndLinkIsConfirmedAndCountTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));
        }

        public void CreateNetworkDataWithNodesIconsInColorTable()
        {
            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTablesTemplate.CreateNetworkDataWithNodesIconsInColorTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));
        }

        public void CreateNetworkDataWithNodesIconsInColorAndLinkIsConfirmedTable()
        {
            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTablesTemplate.CreateNetworkDataWithNodesIconsInColorAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));
        }

        public void CreateNetworkDataWithNodesIconsInColorAndCountTable()
        {
            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTablesTemplate.CreateNetworkDataWithNodesIconsInColorAndCountTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));
        }

        public void CreateNetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmedTable()
        {
            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTablesTemplate.CreateNetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));
        }

        public void CreateNetworkDataScalingNodesAndEdgesTable()
        {
            _dataTableToExcel.PasteAsExcelTable(_networkDataTablesTemplate.CreateNetworkDataScalingNodesAndEdges(normalizeColumnNames: true));
        }
    }
}
