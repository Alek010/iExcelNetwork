﻿namespace ExcelAddIn
{
    partial class MainRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public MainRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainRibbon));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group_data = this.Factory.CreateRibbonGroup();
            this.group_linkNetwork = this.Factory.CreateRibbonGroup();
            this.group_Settings = this.Factory.CreateRibbonGroup();
            this.btn_SelectRange = this.Factory.CreateRibbonButton();
            this.splitButton_BuildNetwrok = this.Factory.CreateRibbonSplitButton();
            this.btn_buildNetwork = this.Factory.CreateRibbonButton();
            this.btn_BuildFinTrxNetwork = this.Factory.CreateRibbonButton();
            this.splitBtn_NetworkDataTables = this.Factory.CreateRibbonSplitButton();
            this.btn_BasicNetworkData = this.Factory.CreateRibbonButton();
            this.btn_BasicTableWithCount = this.Factory.CreateRibbonButton();
            this.btn_NetworkDataLinkConfirmed = this.Factory.CreateRibbonButton();
            this.btn_NetworkDataWithCountAndLinkIsConfirmed = this.Factory.CreateRibbonButton();
            this.btn_NetworkDataWithNodesIcons = this.Factory.CreateRibbonButton();
            this.btn_NetworkDataNodesWithIconsAndLinkIsConfirmed = this.Factory.CreateRibbonButton();
            this.btn_NetwrokDatWithNodesIconsAndCount = this.Factory.CreateRibbonButton();
            this.btn_NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount = this.Factory.CreateRibbonButton();
            this.btn_NetworkDataWithNodesInColor = this.Factory.CreateRibbonButton();
            this.btn_NetworkDataWithNodesInColorAndCount = this.Factory.CreateRibbonButton();
            this.btn_NetworkDataWithNodesInColorAndLinkIsConfirmed = this.Factory.CreateRibbonButton();
            this.btn_NetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmed = this.Factory.CreateRibbonButton();
            this.btn_NetworkDataScalinNodesEdges = this.Factory.CreateRibbonButton();
            this.splitBtn_SampleData = this.Factory.CreateRibbonSplitButton();
            this.btn_AllTablesWithSampleData = this.Factory.CreateRibbonButton();
            this.btn_FinancialTransactionsSampleDataTables = this.Factory.CreateRibbonButton();
            this.btn_SetOutputFolder = this.Factory.CreateRibbonButton();
            this.splitBtn_NetworkSettings = this.Factory.CreateRibbonSplitButton();
            this.btn_ChangeNetworkFileName = this.Factory.CreateRibbonButton();
            this.toggleBtn_RemoveNetworkEdgesData = this.Factory.CreateRibbonToggleButton();
            this.tab1.SuspendLayout();
            this.group_data.SuspendLayout();
            this.group_linkNetwork.SuspendLayout();
            this.group_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group_data);
            this.tab1.Groups.Add(this.group_linkNetwork);
            this.tab1.Groups.Add(this.group_Settings);
            this.tab1.Label = "iExcelNetwork";
            this.tab1.Name = "tab1";
            // 
            // group_data
            // 
            this.group_data.Items.Add(this.btn_SelectRange);
            this.group_data.Label = "Data";
            this.group_data.Name = "group_data";
            // 
            // group_linkNetwork
            // 
            this.group_linkNetwork.Items.Add(this.splitButton_BuildNetwrok);
            this.group_linkNetwork.Items.Add(this.splitBtn_NetworkDataTables);
            this.group_linkNetwork.Items.Add(this.splitBtn_SampleData);
            this.group_linkNetwork.Label = "Link Network";
            this.group_linkNetwork.Name = "group_linkNetwork";
            // 
            // group_Settings
            // 
            this.group_Settings.Items.Add(this.btn_SetOutputFolder);
            this.group_Settings.Items.Add(this.splitBtn_NetworkSettings);
            this.group_Settings.Label = "Settings";
            this.group_Settings.Name = "group_Settings";
            // 
            // btn_SelectRange
            // 
            this.btn_SelectRange.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_SelectRange.Image = ((System.Drawing.Image)(resources.GetObject("btn_SelectRange.Image")));
            this.btn_SelectRange.Label = "Select Range";
            this.btn_SelectRange.Name = "btn_SelectRange";
            this.btn_SelectRange.ShowImage = true;
            this.btn_SelectRange.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_SelectRange_Click);
            // 
            // splitButton_BuildNetwrok
            // 
            this.splitButton_BuildNetwrok.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.splitButton_BuildNetwrok.Image = ((System.Drawing.Image)(resources.GetObject("splitButton_BuildNetwrok.Image")));
            this.splitButton_BuildNetwrok.Items.Add(this.btn_buildNetwork);
            this.splitButton_BuildNetwrok.Items.Add(this.btn_BuildFinTrxNetwork);
            this.splitButton_BuildNetwrok.Label = "Build Netwrok";
            this.splitButton_BuildNetwrok.Name = "splitButton_BuildNetwrok";
            this.splitButton_BuildNetwrok.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.splitButton_BuildNetwrok_Click);
            // 
            // btn_buildNetwork
            // 
            this.btn_buildNetwork.Label = "Build Network";
            this.btn_buildNetwork.Name = "btn_buildNetwork";
            this.btn_buildNetwork.ShowImage = true;
            this.btn_buildNetwork.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_buildNetwork_Click);
            // 
            // btn_BuildFinTrxNetwork
            // 
            this.btn_BuildFinTrxNetwork.Label = "Build Financial Transactions Network";
            this.btn_BuildFinTrxNetwork.Name = "btn_BuildFinTrxNetwork";
            this.btn_BuildFinTrxNetwork.ShowImage = true;
            this.btn_BuildFinTrxNetwork.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_BuildFinTrxNetwork_Click);
            // 
            // splitBtn_NetworkDataTables
            // 
            this.splitBtn_NetworkDataTables.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.splitBtn_NetworkDataTables.Image = ((System.Drawing.Image)(resources.GetObject("splitBtn_NetworkDataTables.Image")));
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_BasicNetworkData);
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_BasicTableWithCount);
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_NetworkDataLinkConfirmed);
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_NetworkDataWithCountAndLinkIsConfirmed);
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_NetworkDataWithNodesIcons);
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_NetworkDataNodesWithIconsAndLinkIsConfirmed);
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_NetwrokDatWithNodesIconsAndCount);
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount);
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_NetworkDataWithNodesInColor);
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_NetworkDataWithNodesInColorAndCount);
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_NetworkDataWithNodesInColorAndLinkIsConfirmed);
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_NetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmed);
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_NetworkDataScalinNodesEdges);
            this.splitBtn_NetworkDataTables.Label = "Data Tables";
            this.splitBtn_NetworkDataTables.Name = "splitBtn_NetworkDataTables";
            this.splitBtn_NetworkDataTables.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.splitBtn_NetworkDataTables_Click);
            // 
            // btn_BasicNetworkData
            // 
            this.btn_BasicNetworkData.Label = "From-To Table";
            this.btn_BasicNetworkData.Name = "btn_BasicNetworkData";
            this.btn_BasicNetworkData.ShowImage = true;
            this.btn_BasicNetworkData.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_BasicNetworkData_Click);
            // 
            // btn_BasicTableWithCount
            // 
            this.btn_BasicTableWithCount.Label = "From-To-Count Table";
            this.btn_BasicTableWithCount.Name = "btn_BasicTableWithCount";
            this.btn_BasicTableWithCount.ShowImage = true;
            this.btn_BasicTableWithCount.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_BasicTableWithCount_Click);
            // 
            // btn_NetworkDataLinkConfirmed
            // 
            this.btn_NetworkDataLinkConfirmed.Label = "From-To-LinkConfirmed Table";
            this.btn_NetworkDataLinkConfirmed.Name = "btn_NetworkDataLinkConfirmed";
            this.btn_NetworkDataLinkConfirmed.ShowImage = true;
            this.btn_NetworkDataLinkConfirmed.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_NetworkDataLinkConfirmed_Click);
            // 
            // btn_NetworkDataWithCountAndLinkIsConfirmed
            // 
            this.btn_NetworkDataWithCountAndLinkIsConfirmed.Label = "From-To-Count-LinkConfirmed Table";
            this.btn_NetworkDataWithCountAndLinkIsConfirmed.Name = "btn_NetworkDataWithCountAndLinkIsConfirmed";
            this.btn_NetworkDataWithCountAndLinkIsConfirmed.ShowImage = true;
            this.btn_NetworkDataWithCountAndLinkIsConfirmed.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_NetworkDataWithCountAndLinkIsConfirmed_Click);
            // 
            // btn_NetworkDataWithNodesIcons
            // 
            this.btn_NetworkDataWithNodesIcons.Label = "From-To-Icons Table";
            this.btn_NetworkDataWithNodesIcons.Name = "btn_NetworkDataWithNodesIcons";
            this.btn_NetworkDataWithNodesIcons.ShowImage = true;
            this.btn_NetworkDataWithNodesIcons.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_NetworkDataWithNodesIcons_Click);
            // 
            // btn_NetworkDataNodesWithIconsAndLinkIsConfirmed
            // 
            this.btn_NetworkDataNodesWithIconsAndLinkIsConfirmed.Label = "From-To-Icons-LinkConfirmed Table";
            this.btn_NetworkDataNodesWithIconsAndLinkIsConfirmed.Name = "btn_NetworkDataNodesWithIconsAndLinkIsConfirmed";
            this.btn_NetworkDataNodesWithIconsAndLinkIsConfirmed.ShowImage = true;
            this.btn_NetworkDataNodesWithIconsAndLinkIsConfirmed.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_NetworkDataNodesWithIconsAndLinkIsConfirmed_Click);
            // 
            // btn_NetwrokDatWithNodesIconsAndCount
            // 
            this.btn_NetwrokDatWithNodesIconsAndCount.Label = "From-To-Icons-Count Table";
            this.btn_NetwrokDatWithNodesIconsAndCount.Name = "btn_NetwrokDatWithNodesIconsAndCount";
            this.btn_NetwrokDatWithNodesIconsAndCount.ShowImage = true;
            this.btn_NetwrokDatWithNodesIconsAndCount.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_NetwrokDatWithNodesIconsAndCount_Click);
            // 
            // btn_NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount
            // 
            this.btn_NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount.Label = "From-To-Icons-Count-LinkConfirmed Table";
            this.btn_NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount.Name = "btn_NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount";
            this.btn_NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount.ShowImage = true;
            this.btn_NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount_Click);
            // 
            // btn_NetworkDataWithNodesInColor
            // 
            this.btn_NetworkDataWithNodesInColor.Label = "From-To-Icons in Color Table";
            this.btn_NetworkDataWithNodesInColor.Name = "btn_NetworkDataWithNodesInColor";
            this.btn_NetworkDataWithNodesInColor.ShowImage = true;
            this.btn_NetworkDataWithNodesInColor.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_NetworkDataWithNodesIconsInColor_Click);
            // 
            // btn_NetworkDataWithNodesInColorAndCount
            // 
            this.btn_NetworkDataWithNodesInColorAndCount.Label = "From-To-Icons-Count in Color Table";
            this.btn_NetworkDataWithNodesInColorAndCount.Name = "btn_NetworkDataWithNodesInColorAndCount";
            this.btn_NetworkDataWithNodesInColorAndCount.ShowImage = true;
            this.btn_NetworkDataWithNodesInColorAndCount.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_NetworkDataWithNodesIconsInColorAndCount_Click);
            // 
            // btn_NetworkDataWithNodesInColorAndLinkIsConfirmed
            // 
            this.btn_NetworkDataWithNodesInColorAndLinkIsConfirmed.Label = "From-To-Icons-LinConfirmed in Color Table";
            this.btn_NetworkDataWithNodesInColorAndLinkIsConfirmed.Name = "btn_NetworkDataWithNodesInColorAndLinkIsConfirmed";
            this.btn_NetworkDataWithNodesInColorAndLinkIsConfirmed.ShowImage = true;
            this.btn_NetworkDataWithNodesInColorAndLinkIsConfirmed.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_NetworkDataWithNodesIconsInColorAndLinkIsConfirmed_Click);
            // 
            // btn_NetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmed
            // 
            this.btn_NetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmed.Label = "From-To-Icons-Count-LinkCofirmed in Color Table";
            this.btn_NetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmed.Name = "btn_NetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmed";
            this.btn_NetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmed.ShowImage = true;
            this.btn_NetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmed.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_NetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmed_Click);
            // 
            // btn_NetworkDataScalinNodesEdges
            // 
            this.btn_NetworkDataScalinNodesEdges.Label = "From-To Scaling Table";
            this.btn_NetworkDataScalinNodesEdges.Name = "btn_NetworkDataScalinNodesEdges";
            this.btn_NetworkDataScalinNodesEdges.ShowImage = true;
            this.btn_NetworkDataScalinNodesEdges.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_NetworkDataScalinNodesEdges_Click);
            // 
            // splitBtn_SampleData
            // 
            this.splitBtn_SampleData.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.splitBtn_SampleData.Image = ((System.Drawing.Image)(resources.GetObject("splitBtn_SampleData.Image")));
            this.splitBtn_SampleData.Items.Add(this.btn_AllTablesWithSampleData);
            this.splitBtn_SampleData.Items.Add(this.btn_FinancialTransactionsSampleDataTables);
            this.splitBtn_SampleData.Label = "Sample Data";
            this.splitBtn_SampleData.Name = "splitBtn_SampleData";
            this.splitBtn_SampleData.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.splitBtn_SampleData_Click);
            // 
            // btn_AllTablesWithSampleData
            // 
            this.btn_AllTablesWithSampleData.Label = "All Tables With Sample Data";
            this.btn_AllTablesWithSampleData.Name = "btn_AllTablesWithSampleData";
            this.btn_AllTablesWithSampleData.ShowImage = true;
            this.btn_AllTablesWithSampleData.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_AllTablesWithSampleData_Click);
            // 
            // btn_FinancialTransactionsSampleDataTables
            // 
            this.btn_FinancialTransactionsSampleDataTables.Label = "Financial Transactions Tables";
            this.btn_FinancialTransactionsSampleDataTables.Name = "btn_FinancialTransactionsSampleDataTables";
            this.btn_FinancialTransactionsSampleDataTables.ShowImage = true;
            this.btn_FinancialTransactionsSampleDataTables.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_FinancialTransactionsSampleDataTables_Click);
            // 
            // btn_SetOutputFolder
            // 
            this.btn_SetOutputFolder.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_SetOutputFolder.Image = ((System.Drawing.Image)(resources.GetObject("btn_SetOutputFolder.Image")));
            this.btn_SetOutputFolder.Label = "Output Folder";
            this.btn_SetOutputFolder.Name = "btn_SetOutputFolder";
            this.btn_SetOutputFolder.ShowImage = true;
            this.btn_SetOutputFolder.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_SetOutputFolder_Click);
            // 
            // splitBtn_NetworkSettings
            // 
            this.splitBtn_NetworkSettings.Items.Add(this.btn_ChangeNetworkFileName);
            this.splitBtn_NetworkSettings.Items.Add(this.toggleBtn_RemoveNetworkEdgesData);
            this.splitBtn_NetworkSettings.Label = "Network Settings";
            this.splitBtn_NetworkSettings.Name = "splitBtn_NetworkSettings";
            // 
            // btn_ChangeNetworkFileName
            // 
            this.btn_ChangeNetworkFileName.Label = "Network File Name";
            this.btn_ChangeNetworkFileName.Name = "btn_ChangeNetworkFileName";
            this.btn_ChangeNetworkFileName.ShowImage = true;
            this.btn_ChangeNetworkFileName.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_ChangeNetworkFileName_Click);
            // 
            // toggleBtn_RemoveNetworkEdgesData
            // 
            this.toggleBtn_RemoveNetworkEdgesData.Label = "Remove Network Link Data";
            this.toggleBtn_RemoveNetworkEdgesData.Name = "toggleBtn_RemoveNetworkEdgesData";
            this.toggleBtn_RemoveNetworkEdgesData.ShowImage = true;
            // 
            // MainRibbon
            // 
            this.Name = "MainRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.MainRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group_data.ResumeLayout(false);
            this.group_data.PerformLayout();
            this.group_linkNetwork.ResumeLayout(false);
            this.group_linkNetwork.PerformLayout();
            this.group_Settings.ResumeLayout(false);
            this.group_Settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group_data;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_SelectRange;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_buildNetwork;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group_linkNetwork;
        internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton splitBtn_NetworkDataTables;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_BasicTableWithCount;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_NetworkDataLinkConfirmed;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_NetworkDataWithNodesIcons;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_NetworkDataWithNodesInColor;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_NetworkDataScalinNodesEdges;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_BasicNetworkData;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_NetworkDataWithCountAndLinkIsConfirmed;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_NetworkDataNodesWithIconsAndLinkIsConfirmed;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_NetwrokDatWithNodesIconsAndCount;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_NetworkDataWithNodesInColorAndLinkIsConfirmed;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_NetworkDataWithNodesInColorAndCount;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_NetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmed;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group_Settings;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_SetOutputFolder;
        internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton splitBtn_NetworkSettings;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_ChangeNetworkFileName;
        internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton splitButton_BuildNetwrok;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_BuildFinTrxNetwork;
        internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton splitBtn_SampleData;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_AllTablesWithSampleData;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_FinancialTransactionsSampleDataTables;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleBtn_RemoveNetworkEdgesData;
    }

    partial class ThisRibbonCollection
    {
        internal MainRibbon MainRibbon
        {
            get { return this.GetRibbon<MainRibbon>(); }
        }
    }
}
