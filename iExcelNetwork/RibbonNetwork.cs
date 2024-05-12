using Microsoft.Office.Tools.Ribbon;
using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace iExcelNetwork
{
    public partial class RibbonNetwork
    {
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
                    // Do something with the selected range
                    MessageBox.Show("Selected range: " + selectedRange.Address);

                    //_selectedRangeAsJSON = DataFrame.ConvertRangeToJson(selectedRange);
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
    }
}
