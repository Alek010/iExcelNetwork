using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;

namespace ExcelAddIn
{
    public partial class MainRibbon
    {
        private void MainRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btn_SelectRange_Click(object sender, RibbonControlEventArgs e)
        {
            MessageBox.Show("Click on button!");
        }
    }
}
