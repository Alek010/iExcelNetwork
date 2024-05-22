using iExcelNetwork.Helpers;
using iExcelNetwork.Validations;
using iExcelNetwork.VisJsNetwork;
using Microsoft.Office.Tools.Ribbon;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace iExcelNetwork
{
    public partial class RibbonNetwork
    {
        private string _selectedRangeJSON;

        private void RibbonNetwork_Load(object sender, RibbonUIEventArgs e)
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

                    SelectedRangeValidator.ValidateRangeIsNotEmptyCell(selectedRange);
                    SelectedRangeValidator.ValidateRangeIsNotCell(selectedRange);
                    SelectedRangeValidator.ValidateSelectedRangeIsNotNull(selectedRange);

                    _selectedRangeJSON = ExcelRange.ConvertToJson(selectedRange);
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

        private void btn_saveJson_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                VisJsDataValidator.JsonIsNotNull(_selectedRangeJSON);
                VisJsDataValidator.JsonHasData(_selectedRangeJSON);

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    ExcelRange.SaveAsJson(_selectedRangeJSON, filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_buildNetwork_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                VisJsDataValidator.JsonIsNotNull(_selectedRangeJSON);
                VisJsDataValidator.JsonFieldNamesAreValid(_selectedRangeJSON);
                VisJsDataValidator.JsonHasData(_selectedRangeJSON);

                FromToRangeData fromToRangeData = new FromToRangeData(_selectedRangeJSON);
                fromToRangeData.ProcessData();

                VisJsNetworkData visJsNetwork = new VisJsNetworkData(fromToRangeData.FromNodesLabels, fromToRangeData.ToNodesLabels);

                string nodesJson = JsonConvert.SerializeObject(visJsNetwork.GetNodes(), Formatting.Indented);
                string edgesJson = JsonConvert.SerializeObject(visJsNetwork.GetEdges(), Formatting.Indented);

                VisJsNetworkBuilder visJsNetworkBuilder = new VisJsNetworkBuilder(nodesJson, edgesJson);
                visJsNetworkBuilder.ShowNetwork();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_howItWorks_Click(object sender, RibbonControlEventArgs e)
        {
            CreateNewSheet();
        }

        private void CreateNewSheet()
        {
            try
            {
                // Get the current Excel application
                Excel.Application excelApp = Globals.ThisAddIn.Application;

                // Get the active workbook
                Excel.Workbook activeWorkbook = excelApp.ActiveWorkbook;

                // Add a new worksheet
                Excel.Worksheet newWorksheet = activeWorkbook.Worksheets.Add();

                // Set the name of the new worksheet
                newWorksheet.Name = "How It Works";

                // Set the tab color of the new worksheet
                newWorksheet.Tab.Color = ColorTranslator.ToOle(Color.Red);

                // Optionally, activate the new worksheet
                newWorksheet.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
