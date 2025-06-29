// Ignore Spelling: App

using ExcelAddIn.Validations;
using VisjsNetworkLibrary.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelAddIn
{
    public class DataTableWithSampleData
    {
        private readonly Excel.Application _excelApp;
        private readonly NetworkDataTableTemplatesWithSampleData _networkDataTemplate = new NetworkDataTableTemplatesWithSampleData(new NetworkDataTableTemplates());

        public DataTableWithSampleData(Excel.Application excelApp)
        {
            _excelApp = excelApp;
        }

        public void PasteAllTables()
        {
            DataTableToExcel dataTableToExcel = new DataTableToExcel(excelApp: Globals.ThisAddIn.Application,
                                                                         pasteIntoNewSheet: true);

            dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "A1");

            dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataLinkIsConfirmedTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "A6");

            dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithCountTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "A11");

            dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithCountAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "A16");

            dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithNodesIconsTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "F1",
                                               tableStyleName: "TableStyleMedium3");

            dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithNodesIconsAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "F6",
                                               tableStyleName: "TableStyleMedium3");

            dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithNodesIconsAndCountTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "F11",
                                               tableStyleName: "TableStyleMedium3");

            dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithNodesIconsAndLinkIsConfirmedAndCountTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "F16",
                                               tableStyleName: "TableStyleMedium3");

            dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithNodesIconsInColorTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "M1",
                                               tableStyleName: "TableStyleMedium7");

            dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithNodesIconsInColorAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "M6",
                                               tableStyleName: "TableStyleMedium7");

            dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithNodesIconsInColorAndCountTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "M11",
                                               tableStyleName: "TableStyleMedium7");

            dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "M16",
                                               tableStyleName: "TableStyleMedium7");

            dataTableToExcel.PasteAsExcelTable(dataTable: _networkDataTemplate.CreateNetworkDataScalingNodesAndEdges(normalizeColumnNames: true),
                                               columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                               cellReference: "U1",
                                               tableStyleName: "TableStyleMedium1");
        }


    }
}
