using iExcelNetwork.Helpers;
using iExcelNetwork.NetworkProperty;
using iExcelNetwork.SheetDataWriter;
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
        private NetworkProperties networkProperties = new NetworkProperties(new EdgeProperty());

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

                VisJsNetworkData visJsNetwork = new VisJsNetworkData(fromToRangeData.FromNodesLabels, fromToRangeData.ToNodesLabels, fromToRangeData.LinksCount);

                string nodesJson = JsonConvert.SerializeObject(visJsNetwork.GetNodes(), Formatting.Indented);
                string edgesJson = JsonConvert.SerializeObject(visJsNetwork.GetEdges(), Formatting.Indented);

                VisJsNetworkBuilder visJsNetworkBuilder = new VisJsNetworkBuilder(networkProperties, nodesJson, edgesJson);
                visJsNetworkBuilder.ShowNetwork();

                NetworkIntegrityLog networkIntegrityLog = new NetworkIntegrityLog(networkProperties);

                networkIntegrityLog.WriteLog();
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
                Excel.Application excelApp = Globals.ThisAddIn.Application;

                Excel.Workbook activeWorkbook = excelApp.ActiveWorkbook;

                string sheetName = "How It Works";

                if (!ExcelWorkbook.SheetNameExists(activeWorkbook, sheetName))
                {
                    Excel.Worksheet newWorksheet = activeWorkbook.Worksheets.Add();

                    newWorksheet.Name = "How It Works";

                    newWorksheet.Tab.Color = ColorTranslator.ToOle(Color.Red);

                    newWorksheet.Activate();

                    DataWriter dataWriter = new DataWriter();

                    dataWriter.PopulateData(HowItWorksData.FromToTable, newWorksheet.Cells[1, 1]);
                    dataWriter.PopulateData(HowItWorksData.InstructionsToBuildNetwork, newWorksheet.Cells[1, 5]);
                    dataWriter.PopulateData(HowItWorksData.FromToCountTable, newWorksheet.Cells[16, 1]);
                    dataWriter.PopulateData(HowItWorksData.InstructionsToBuildNetworkWithCountColumn, newWorksheet.Cells[16, 5]);
                    dataWriter.PopulateData(HowItWorksData.InstructionsToSaveJson, newWorksheet.Cells[34, 1]);
                    dataWriter.PopulateData(HowItWorksData.FromToGeneratedNumbersDescription, newWorksheet.Cells[1, 14]);
                    dataWriter.PopulateData(HowItWorksData.FromToRandomNumbersAsLatvianPhoneNumbers, newWorksheet.Cells[5, 14]);
                    dataWriter.PopulateData(HowItWorksData.FromToRandomNumberBetweenOneAndHundred, newWorksheet.Cells[4, 18]);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_networkProperties_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                NetworkPropertiesForm form = new NetworkPropertiesForm(networkProperties);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
