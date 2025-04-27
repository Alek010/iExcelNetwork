using System;
using System.Windows.Forms;

namespace ExcelAddIn.Forms
{
    public partial class ChangeFileNameForm : Form
    {
        public ChangeFileNameForm(string fileName)
        {
            InitializeComponent();
            textBox_FileName.Text = fileName;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            ConfigManager.SaveNetworkFileName(textBox_FileName.Text);
            this.Close();
        }
    }
}
