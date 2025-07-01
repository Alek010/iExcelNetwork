// Ignore Spelling: App

using ExcelAddIn.Validations;
using VisjsNetworkLibrary.Models;

namespace ExcelAddIn
{
    public class DataTableWithSampleDataToExcel
    {
        private readonly NetworkDataTableTemplatesWithSampleData _networkDataTemplate;
        private readonly DataTableToExcel _dataTableToExcel;

        public DataTableWithSampleDataToExcel(DataTableToExcel dataTableToExcel, NetworkDataTableTemplatesWithSampleData networkDataTableTemplatesWithSampleData)
        {
            _dataTableToExcel = dataTableToExcel;
            _networkDataTemplate = networkDataTableTemplatesWithSampleData;
        }

        public void PasteAllTables()
        {
            _dataTableToExcel.DeleteSampleDataSheetIfExists();

            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "A1");

            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataLinkIsConfirmedTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "A6");

            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithCountTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "A11");

            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithCountAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "A16");

            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithNodesIconsTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "F1",
                                               tableStyleName: "TableStyleMedium3");

            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithNodesIconsAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "F6",
                                               tableStyleName: "TableStyleMedium3");

            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithNodesIconsAndCountTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "F11",
                                               tableStyleName: "TableStyleMedium3");

            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithNodesIconsAndLinkIsConfirmedAndCountTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "F16",
                                               tableStyleName: "TableStyleMedium3");

            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithNodesIconsInColorTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "M1",
                                               tableStyleName: "TableStyleMedium7");

            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithNodesIconsInColorAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "M6",
                                               tableStyleName: "TableStyleMedium7");

            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithNodesIconsInColorAndCountTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "M11",
                                               tableStyleName: "TableStyleMedium7");

            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "M16",
                                               tableStyleName: "TableStyleMedium7");

            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataScalingNodesAndEdges(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "U1",
                                               tableStyleName: "TableStyleMedium1");
        }

        public void PasteFinancialTransactionsTables()
        {
            _dataTableToExcel.DeleteSampleDataSheetIfExists();

            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithCountTable(normalizeColumnNames: true),
                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                   cellReference: "A1");

            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithNodesIconsAndCountTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "E1",
                                               tableStyleName: "TableStyleMedium3");

            _dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithNodesIconsInColorAndCountTable(normalizeColumnNames: true),
                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                   cellReference: "K1",
                                   tableStyleName: "TableStyleMedium7");
        }
    }
}
