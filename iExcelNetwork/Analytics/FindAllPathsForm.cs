using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using VisJsNetworkLibrary.Models;
using VisJsNetworkLibrary;
using GraphAlgorithmsLibrary;
using VisJsNetworkLibrary.NetworkProperty;

namespace iExcelNetwork.Analytics
{
    public partial class FindAllPathsForm : Form
    {
        private readonly NetworkProperties _networkProperties;
        private readonly string _selectedRangeAsJSON;

        public FindAllPathsForm(NetworkProperties networkProperties, string selectedRangeAsJSON)
        {
            _networkProperties = networkProperties;
            _selectedRangeAsJSON = selectedRangeAsJSON;
            InitializeComponent();
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            try
            {
                FindAllPathsResultForm form = new FindAllPathsResultForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
