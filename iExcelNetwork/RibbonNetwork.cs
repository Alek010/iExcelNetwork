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
                selectedRange = excelApp.InputBox("Select a range of cells:", Type: 8);
                if (selectedRange != null)
                {
                    MessageBox.Show("Selected range: " + selectedRange.Address);

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

        private void btn_buildNetwork_Click(object sender, RibbonControlEventArgs e)
        {
            OpenVisJsNetwork();
        }

        private void OpenVisJsNetwork()
        {
            VisJsNetworkData visJsNetwork = new VisJsNetworkData(_selectedRangeAsJSON);

            visJsNetwork.ProcessJson();

            var nodes = visJsNetwork.GetNodes();
            var edges = visJsNetwork.GetEdges();

            string nodesJson = JsonConvert.SerializeObject(nodes, Formatting.Indented);
            string edgesJson = JsonConvert.SerializeObject(edges, Formatting.Indented);

            VisJsNetworkBuilder visJsNetworkBuilder = new VisJsNetworkBuilder(nodesJson, edgesJson);
            visJsNetworkBuilder.ShowNetwork();

        }
    }
}
