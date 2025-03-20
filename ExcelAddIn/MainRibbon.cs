using ExcelAddIn.Validations;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using VisjsNetworkLibrary;
using VisjsNetworkLibrary.Interfaces;
using VisjsNetworkLibrary.Models;
using VisjsNetworkLibrary.NetworkDataClasses;
using VisjsNetworkLibrary.Validations;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelAddIn
{
    public partial class MainRibbon
    {
        private DataTable SelectedRangeAsDataTable { get; set; }

        private void MainRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btn_SelectRange_Click(object sender, RibbonControlEventArgs e)
        {
            Excel.Application excelApp = Globals.ThisAddIn.Application;
            Excel.Range selectedRange = null;

            try
            {
                object result = excelApp.InputBox(Prompt: "Select a range:",
                                                  Default: excelApp.Selection.Address,
                                                  Type: 8);

                if (result is bool && (bool)result == false)
                {
                    //MessageBox.Show("You canceled the range selection.");
                }
                else
                {
                    selectedRange = (Excel.Range)result;

                    SelectedRangeValidator validator = new SelectedRangeValidator(selectedRange);
                    validator.ValidateRangeIsNotEmptyCell();
                    validator.ValidateRangeIsNotCell();
                    validator.ValidateSelectedRangeIsNotNull();

                    SelectedRangeAsDataTable = ExcelRangeHelper.GetDataTableFromRange(selectedRange);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (selectedRange != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(selectedRange);
            }
        }

        private void btn_buildNetwork_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                SelectedDataTableValidator validator = new SelectedDataTableValidator(SelectedRangeAsDataTable);
                validator.ValidateDataTableIsNotNull();
                validator.ValidateDataTableHasRecords();
                validator.ValidateDataTableHasTwoOrMoreColumns();

                NetworkDataFactory networkDataFactory = new NetworkDataFactory(SelectedRangeAsDataTable);

                INetworkData networkData = networkDataFactory.CreateNetworkData();

                NetworkHtmlContent htmlContent = new NetworkHtmlContent(networkData);

                FileProcessor processor = new FileProcessor(htmlContent);
                processor.WriteFile();
                processor.OpenFile();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_BasicNetworkData_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                NetworkDataTableTemplates networkDataTemplate = new NetworkDataTableTemplates();

                DataTableToExcelHelper.PasteDataTableToExcel(networkDataTemplate.CreateNetworkDataTable(normalizeColumnNames: true));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_BasicTableWithCount_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                NetworkDataTableTemplates networkDataTemplate = new NetworkDataTableTemplates();

                DataTableToExcelHelper.PasteDataTableToExcel(networkDataTemplate.CreateNetworkDataWithCountTable(normalizeColumnNames: true));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_NetworkDataLinkConfirmed_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                NetworkDataTableTemplates networkDataTemplate = new NetworkDataTableTemplates();

                DataTableToExcelHelper.PasteDataTableToExcel(dt: networkDataTemplate.CreateNetworkDataLinkIsConfirmedTable(normalizeColumnNames: true),
                                                             columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_NetworkDataWithCountAndLinkIsConfirmed_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                NetworkDataTableTemplates networkDataTemplate = new NetworkDataTableTemplates();

                DataTableToExcelHelper.PasteDataTableToExcel(dt: networkDataTemplate.CreateNetworkDataWithCountAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                                             columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_NetworkDataWithNodesIcons_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                NetworkDataTableTemplates networkDataTemplate = new NetworkDataTableTemplates();

                DataTableToExcelHelper.PasteDataTableToExcel(dt: networkDataTemplate.CreateNetworkDataWithNodesIconsTable(normalizeColumnNames: true),
                                                             columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_NetworkDataWithNodesInColor_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                NetworkDataTableTemplates networkDataTemplate = new NetworkDataTableTemplates();

                DataTableToExcelHelper.PasteDataTableToExcel(dt: networkDataTemplate.CreateNetworkDataWithNodesIconsInColorTable(normalizeColumnNames: true),
                                                             columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_NetworkDataScalinNodesEdges_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                NetworkDataTableTemplates networkDataTemplate = new NetworkDataTableTemplates();

                DataTableToExcelHelper.PasteDataTableToExcel(networkDataTemplate.CreateNetworkDataScalingNodesAndEdges(normalizeColumnNames: true));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_AllTablesWithSampleData_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                NetworkDataTableTemplatesWithSampleData networkDataTemplate = new NetworkDataTableTemplatesWithSampleData(new NetworkDataTableTemplates());

                DataTableToExcelHelper.PasteDataTableToExcel(dt: networkDataTemplate.CreateNetworkDataTable(normalizeColumnNames: true),
                                                             columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                             pasteIntoNewSheet: true,
                                                             cellReference: "A1");

                DataTableToExcelHelper.PasteDataTableToExcel(dt: networkDataTemplate.CreateNetworkDataLinkIsConfirmedTable(normalizeColumnNames: true),
                                                             columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                             pasteIntoNewSheet: true, 
                                                             cellReference: "A6");

                DataTableToExcelHelper.PasteDataTableToExcel(dt: networkDataTemplate.CreateNetworkDataWithCountTable(normalizeColumnNames: true),
                                                             columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                             pasteIntoNewSheet: true,
                                                             cellReference: "A11");

                DataTableToExcelHelper.PasteDataTableToExcel(dt: networkDataTemplate.CreateNetworkDataWithCountAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                             columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                             pasteIntoNewSheet: true,
                                             cellReference: "A16");

                DataTableToExcelHelper.PasteDataTableToExcel(dt: networkDataTemplate.CreateNetworkDataWithNodesIconsTable(normalizeColumnNames: true),
                                                             columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                             pasteIntoNewSheet: true,
                                                             cellReference: "F1");

                DataTableToExcelHelper.PasteDataTableToExcel(dt: networkDataTemplate.CreateNetworkDataWithNodesIconsInColorTable(normalizeColumnNames: true),
                                                             columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                             pasteIntoNewSheet: true,
                                                             cellReference: "F6");

                DataTableToExcelHelper.PasteDataTableToExcel(dt: networkDataTemplate.CreateNetworkDataScalingNodesAndEdges(normalizeColumnNames: true),
                                                             columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                             pasteIntoNewSheet: true,
                                                             cellReference: "F11");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
