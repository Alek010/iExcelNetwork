using iExcelNetwork.Helpers;
using iExcelNetwork.NetworkProperty;
using iExcelNetwork.SheetDataWriter;
using iExcelNetwork.Validations;
using VisJsNetworkLibrary;
using VisJsNetworkLibrary.NetworkProperty;
using VisJsNetworkLibrary.Validations;
using Microsoft.Office.Tools.Ribbon;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using VisJsNetworkLibrary.Models;
using System.Reflection;

namespace iExcelNetwork
{
    public partial class RibbonNetwork
    {
        private string _selectedRangeAsJSON;
        private readonly NetworkProperties networkProperties = new NetworkProperties(new EdgeProperty());

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

                    _selectedRangeAsJSON = ExcelRange.ConvertToJson(selectedRange);
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
                SelectedRangeValidator.ValidateSelectedRangeIsNotNull(_selectedRangeAsJSON);
                SelectedRangeValidator.JsonStringHasData(_selectedRangeAsJSON);

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    ExcelRange.SaveAsJson(_selectedRangeAsJSON, filePath);
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
                VisJsDataValidator.JsonStringIsNotNull(_selectedRangeAsJSON);
                VisJsDataValidator.JsonStringHasData(_selectedRangeAsJSON);
                VisJsDataValidator.JsonFieldNamesAreValid(_selectedRangeAsJSON);

                DataRange dataRange = new DataRange(JsonConvert.DeserializeObject<List<SelectedRange>>(_selectedRangeAsJSON));

                VisJsNetworkData visJsNetworkData = new VisJsNetworkData(dataRange);

                VisJsNetworkBuilder visJsNetworkBuilder = new VisJsNetworkBuilder(networkProperties, visJsNetworkData);
                visJsNetworkBuilder.ShowNetwork();

                NetworkIntegrityLog networkIntegrityLog = new NetworkIntegrityLog(networkProperties);

                networkIntegrityLog.WriteLog(GetAssamblyInformationalVersion());
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

        private string GetAssamblyInformationalVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            var informationalVersionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();

            return informationalVersionAttribute?.InformationalVersion ?? "N/A";
        }
    }
}
