﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iExcelNetwork.NetworkProperty
{
    public partial class NetworkPropertiesForm : Form
    {
        public NetworkPropertiesForm()
        {
            InitializeComponent();
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
                }
            }
        }
    }
}
