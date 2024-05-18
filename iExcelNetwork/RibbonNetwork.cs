using iExcelNetwork.Exceptions;
using iExcelNetwork.Validations;
using Microsoft.Office.Tools.Ribbon;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace iExcelNetwork
{
    public partial class RibbonNetwork
    {
        private string _selectedRangeAsJSON;

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
                if (_selectedRangeAsJSON == null)
                    throw new SelectedRangeIsNullException(ExceptionMessage.RangeIsNotSelected());

                if (!VisJsDataValidator.HasRecords(_selectedRangeAsJSON))
                    throw new SelectedRangeJsonHasNoRecordsException(ExceptionMessage.RangeHasNoRecords());

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
            OpenVisJsNetwork();
        }

        private void OpenVisJsNetwork()
        {
            VisJsNetworkData visJsNetwork = new VisJsNetworkData(_selectedRangeAsJSON);

            try
            {
                visJsNetwork.ProcessJson();

                var nodes = visJsNetwork.GetNodes();
                var edges = visJsNetwork.GetEdges();

                string nodesJson = JsonConvert.SerializeObject(nodes, Formatting.Indented);
                string edgesJson = JsonConvert.SerializeObject(edges, Formatting.Indented);

                VisJsNetworkBuilder visJsNetworkBuilder = new VisJsNetworkBuilder(nodesJson, edgesJson);
                visJsNetworkBuilder.ShowNetwork();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
