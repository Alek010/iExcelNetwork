using ExcelAddIn.Forms;
using ExcelAddIn.Validations;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.Data;
using System.Windows.Forms;
using VisjsNetworkLibrary;
using VisjsNetworkLibrary.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelAddIn
{
    public partial class MainRibbon
    {
        private DataTable SelectedRangeAsDataTable { get; set; }

        private Action ActivateAddInsTab;

        private DataTableTemplateToExcel DataTableTemplate { get; set; }
        private DataTableWithSampleDataToExcel DataTableSampleData { get; set; }

        private void MainRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            ActivateAddInsTab = () => e?.RibbonUI?.ActivateTabMso("TabAddIns");

            DataTableTemplate = new DataTableTemplateToExcel(
                new DataTableToExcel(excelApp: Globals.ThisAddIn.Application),
                new NetworkDataTableTemplates());

            DataTableSampleData = new DataTableWithSampleDataToExcel(
                new DataTableToExcel(excelApp: Globals.ThisAddIn.Application, pasteIntoNewSheet: true),
                new NetworkDataTableTemplatesWithSampleData(new NetworkDataTableTemplates()));
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

        private void splitButton_BuildNetwrok_Click(object sender, RibbonControlEventArgs e)
        {
            btn_buildNetwork_Click(sender, e);
        }

        private void btn_buildNetwork_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                VisjsNetwork visjsNetwork = new VisjsNetwork(new NetworkDataFactory(SelectedRangeAsDataTable));
                visjsNetwork.BuildNetwork();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_BuildFinTrxNetwork_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                VisjsNetwork visjsNetwork = new VisjsNetwork(new FinancialNetworkDataFactory(SelectedRangeAsDataTable));
                visjsNetwork.BuildNetwork();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_BasicNetworkData_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                DataTableTemplate.CreateBasicNetworkDataTable();

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
                DataTableTemplate.CreateNetworkDataWithCountTable();

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
                DataTableTemplate.CreateNetworkDataLinkIsConfirmedTable();

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
                DataTableTemplate.CreateNetworkDataWithCountAndLinkIsConfirmedTable();

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
                DataTableTemplate.CreateNetworkDataWithNodesIconsTable();

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
                DataTableTemplate.CreateNetworkDataWithNodesIconsAndLinkIsConfirmedTable();

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
                DataTableTemplate.CreateNetworkDataWithNodesIconsAndCountTable();

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
                DataTableTemplate.CreateNetworkDataWithNodesIconsAndLinkIsConfirmedAndCountTable();

                Globals.Ribbons.MainRibbon.ActivateAddInsTab?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_NetworkDataWithNodesIconsInColor_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                DataTableTemplate.CreateNetworkDataWithNodesIconsInColorTable();

                Globals.Ribbons.MainRibbon.ActivateAddInsTab?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_NetworkDataWithNodesIconsInColorAndLinkIsConfirmed_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                DataTableTemplate.CreateNetworkDataWithNodesIconsInColorAndLinkIsConfirmedTable();

                Globals.Ribbons.MainRibbon.ActivateAddInsTab?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_NetworkDataWithNodesIconsInColorAndCount_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                DataTableTemplate.CreateNetworkDataWithNodesIconsInColorAndCountTable();

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
                DataTableTemplate.CreateNetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmedTable();

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
                DataTableTemplate.CreateNetworkDataScalingNodesAndEdgesTable();

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
                DataTableSampleData.PasteAllTables();

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

        private void splitBtn_SampleData_Click(object sender, RibbonControlEventArgs e)
        {
            btn_AllTablesWithSampleData_Click(sender, e);
        }

        private void splitBtn_NetworkDataTables_Click(object sender, RibbonControlEventArgs e)
        {
            btn_BasicNetworkData_Click(sender, e);
        }
    }
}
