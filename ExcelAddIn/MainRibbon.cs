using ExcelAddIn.Forms;
using ExcelAddIn.Validations;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        private Action ActivateAddInsTab;

        private void MainRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            ActivateAddInsTab = () => e?.RibbonUI?.ActivateTabMso("TabAddIns");
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

                string filePath = Path.Combine(ConfigManager.GetOutputFolderPath(), ConfigManager.GetNetworkFileName());

                string networkFile = filePath + ".html";
                FileProcessor networkFileProcessor = new FileProcessor(htmlContent, networkFile);
                networkFileProcessor.WriteFile();
                networkFileProcessor.OpenFile();

                string integrityFilePath = filePath + ".txt";
                IntegrityLogContent integrityLogContent = new IntegrityLogContent(networkFile, iExcelNetworkVersion: ConfigManager.GetAddInVersion());
                FileProcessor networkIntegrityFileProcessor = new FileProcessor(integrityLogContent, integrityFilePath);
                networkIntegrityFileProcessor.WriteFile();

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

                DataTableToExcel dataTableToExcel = new DataTableToExcel(Globals.ThisAddIn.Application);

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataTable(normalizeColumnNames: true));

                Globals.Ribbons.MainRibbon.ActivateAddInsTab?.Invoke();
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

                DataTableToExcel dataTableToExcel = new DataTableToExcel(Globals.ThisAddIn.Application);

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithCountTable(normalizeColumnNames: true));

                Globals.Ribbons.MainRibbon.ActivateAddInsTab?.Invoke();
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

                DataTableToExcel dataTableToExcel = new DataTableToExcel(Globals.ThisAddIn.Application);

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataLinkIsConfirmedTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));

                Globals.Ribbons.MainRibbon.ActivateAddInsTab?.Invoke();
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

                DataTableToExcel dataTableToExcel = new DataTableToExcel(Globals.ThisAddIn.Application);

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithCountAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));


                Globals.Ribbons.MainRibbon.ActivateAddInsTab?.Invoke();
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

                DataTableToExcel dataTableToExcel = new DataTableToExcel(Globals.ThisAddIn.Application);

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithNodesIconsTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));

                Globals.Ribbons.MainRibbon.ActivateAddInsTab?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_NetworkDataNodesWithIconsAndLinkIsConfirmed_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                NetworkDataTableTemplates networkDataTemplate = new NetworkDataTableTemplates();

                DataTableToExcel dataTableToExcel = new DataTableToExcel(Globals.ThisAddIn.Application);

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithNodesIconsAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));

                Globals.Ribbons.MainRibbon.ActivateAddInsTab?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_NetwrokDatWithNodesIconsAndCount_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                NetworkDataTableTemplates networkDataTemplate = new NetworkDataTableTemplates();

                DataTableToExcel dataTableToExcel = new DataTableToExcel(Globals.ThisAddIn.Application);

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithNodesIconsAndCountTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));

                Globals.Ribbons.MainRibbon.ActivateAddInsTab?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                NetworkDataTableTemplates networkDataTemplate = new NetworkDataTableTemplates();

                DataTableToExcel dataTableToExcel = new DataTableToExcel(Globals.ThisAddIn.Application);

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithNodesIconsAndLinkIsConfirmedAndCountTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));

                Globals.Ribbons.MainRibbon.ActivateAddInsTab?.Invoke();
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

                DataTableToExcel dataTableToExcel = new DataTableToExcel(Globals.ThisAddIn.Application);

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithNodesIconsInColorTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));

                Globals.Ribbons.MainRibbon.ActivateAddInsTab?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_NetworkDataWithNodesInColorAndLinkIsConfirmed_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                NetworkDataTableTemplates networkDataTemplate = new NetworkDataTableTemplates();

                DataTableToExcel dataTableToExcel = new DataTableToExcel(Globals.ThisAddIn.Application);

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithNodesIconsInColorAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));

                Globals.Ribbons.MainRibbon.ActivateAddInsTab?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_NetworkDataWithNodesInColorAndCount_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                NetworkDataTableTemplates networkDataTemplate = new NetworkDataTableTemplates();

                DataTableToExcel dataTableToExcel = new DataTableToExcel(Globals.ThisAddIn.Application);

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithNodesIconsInColorAndCountTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));

                Globals.Ribbons.MainRibbon.ActivateAddInsTab?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_NetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmed_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                NetworkDataTableTemplates networkDataTemplate = new NetworkDataTableTemplates();

                DataTableToExcel dataTableToExcel = new DataTableToExcel(Globals.ThisAddIn.Application);

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true));

                Globals.Ribbons.MainRibbon.ActivateAddInsTab?.Invoke();
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

                DataTableToExcel dataTableToExcel = new DataTableToExcel(Globals.ThisAddIn.Application);

                dataTableToExcel.PasteAsExcelTable(networkDataTemplate.CreateNetworkDataScalingNodesAndEdges(normalizeColumnNames: true));

                Globals.Ribbons.MainRibbon.ActivateAddInsTab?.Invoke();
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

                DataTableToExcel dataTableToExcel = new DataTableToExcel(excelApp: Globals.ThisAddIn.Application,
                                                                         pasteIntoNewSheet: true);

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                   cellReference: "A1");

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataLinkIsConfirmedTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                   cellReference: "A6");

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithCountTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                   cellReference: "A11");

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithCountAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                   cellReference: "A16");

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithNodesIconsTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                   cellReference: "F1",
                                                   tableStyleName: "TableStyleMedium3");

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithNodesIconsAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                   cellReference: "F6",
                                                   tableStyleName: "TableStyleMedium3");

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithNodesIconsAndCountTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                   cellReference: "F11",
                                                   tableStyleName: "TableStyleMedium3");

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithNodesIconsAndLinkIsConfirmedAndCountTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                   cellReference: "F16",
                                                   tableStyleName: "TableStyleMedium3");

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithNodesIconsInColorTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                   cellReference: "M1",
                                                   tableStyleName: "TableStyleMedium7");

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithNodesIconsInColorAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                   cellReference: "M6",
                                                   tableStyleName: "TableStyleMedium7");

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithNodesIconsInColorAndCountTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                   cellReference: "M11",
                                                   tableStyleName: "TableStyleMedium7");

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmedTable(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                   cellReference: "M16",
                                                   tableStyleName: "TableStyleMedium7");

                dataTableToExcel.PasteAsExcelTable(dataTable: networkDataTemplate.CreateNetworkDataScalingNodesAndEdges(normalizeColumnNames: true),
                                                   columnValidationLists: ExcelDataValidation.GetColumnValidationListsDictionary(normalizeColumnNames: true),
                                                   cellReference: "U1",
                                                   tableStyleName: "TableStyleMedium1");

                Globals.Ribbons.MainRibbon.ActivateAddInsTab?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_SetOutputFolder_Click(object sender, RibbonControlEventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder";
                folderDialog.ShowNewFolderButton = true;
                folderDialog.SelectedPath = ConfigManager.GetOutputFolderPath();

                DialogResult result = folderDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    ConfigManager.SaveOutputFolderPath(folderDialog.SelectedPath);
                }
            }
        }

        private void btn_ChangeNetworkFileName_Click(object sender, RibbonControlEventArgs e)
        {
            var name = ConfigManager.GetNetworkFileName();
            ChangeFileNameForm form =new ChangeFileNameForm(name);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void splitButton_BuildNetwrok_Click(object sender, RibbonControlEventArgs e)
        {
            btn_buildNetwork_Click(sender, e);
        }
    }
}
