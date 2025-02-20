using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using VisjsNetworkLibrary;


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

        private void btn_buildNetwork_Click(object sender, RibbonControlEventArgs e)
        {
            NetworkHtmlContent htmlContent = new NetworkHtmlContent();
            FileProcessor processor = new FileProcessor(htmlContent);
            processor.WriteFile();
            processor.OpenFile();
        }
    }
}
