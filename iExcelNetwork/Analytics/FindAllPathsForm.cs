using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using VisJsNetworkLibrary.Models;
using VisJsNetworkLibrary;
using GraphAlgorithmsLibrary;
using VisJsNetworkLibrary.NetworkProperty;
using System.Linq;

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
                DataRange dataRange = new DataRange(JsonConvert.DeserializeObject<List<SelectedRange>>(_selectedRangeAsJSON));

                var networkData = new NetworkData(dataRange);

                NetworkAnalytics networkAnalytics = new NetworkAnalytics(networkData, new GraphDirectionalEdges());
                var paths = networkAnalytics.FindAllPaths(txtBox_Node1.Text, txtBox_Node2.Text).Result;

                NetworkFilteredData networkFilteredData = new NetworkFilteredData(paths, networkData);

                NetworkHtml networkHtml = new NetworkHtml(_networkProperties, networkFilteredData);

                FileProcessor fileProcessor = new FileProcessor(networkHtml);
                fileProcessor.WriteFile();
                fileProcessor.OpenFile();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_exchangeSourceDestination_Click(object sender, EventArgs e)
        {
            string Node1 = txtBox_Node2.Text;
            string Node2 = txtBox_Node1.Text;

            txtBox_Node1.Text = Node1;
            txtBox_Node2.Text = Node2;
        }
    }
}
