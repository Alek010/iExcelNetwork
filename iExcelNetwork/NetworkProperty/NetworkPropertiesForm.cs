using GraphVisualizationLibrary.NetworkProperty;
using System;
using System.Windows.Forms;

namespace iExcelNetwork.NetworkProperty
{
    public partial class NetworkPropertiesForm : Form
    {
        private bool isFormLoaded = false;
        private NetworkProperties _networkProperties;

        public NetworkPropertiesForm(NetworkProperties networkProperties)
        {
            InitializeComponent();

            _networkProperties = networkProperties;
        }

        private void NetworkPropertiesForm_Load(object sender, EventArgs e)
        {
            lb_networkOutputFolderPath.Text = _networkProperties.OutputFolder;

            cmBox_setEdgesDirection.DataSource = new BindingSource(_networkProperties.EdgeProperty.EdgeDirectionOptions(), null);
            cmBox_setEdgesDirection.DisplayMember = "Key";
            cmBox_setEdgesDirection.ValueMember = "Value";

            cmBox_setEdgesDirection.SelectedValue = _networkProperties.EdgeProperty.SelectedDirection;

            txBox_fileName.Text = _networkProperties.OutputFileName;

            isFormLoaded = true;
        }

        private void btn_selectFolder_Click(object sender, EventArgs e)
        {
             
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                // Show the FolderBrowserDialog
                DialogResult result = folderBrowserDialog.ShowDialog();

                // If the user selects a folder and clicks OK
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    // Display the selected folder path in the label
                    lb_networkOutputFolderPath.Text = folderBrowserDialog.SelectedPath;
                    _networkProperties.OutputFolder = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void cmBox_setEdgesDirection_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!isFormLoaded)
                return;

            _networkProperties.EdgeProperty.SelectedDirection = cmBox_setEdgesDirection.SelectedValue.ToString();
        }

        private void bt_Ok_Click(object sender, EventArgs e)
        {
            _networkProperties.OutputFileName = txBox_fileName.Text;

            this.Close();
        }
    }
}
