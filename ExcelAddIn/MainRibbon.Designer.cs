namespace ExcelAddIn
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
            this.btn_SelectRange = this.Factory.CreateRibbonButton();
            this.group_linkNetwork = this.Factory.CreateRibbonGroup();
            this.btn_buildNetwork = this.Factory.CreateRibbonButton();
            this.splitBtn_NetworkDataTables = this.Factory.CreateRibbonSplitButton();
            this.btn_BasicNetworkData = this.Factory.CreateRibbonButton();
            this.btn_BasicTableWithCount = this.Factory.CreateRibbonButton();
            this.btn_NetworkDataLinkConfirmed = this.Factory.CreateRibbonButton();
            this.btn_NetworkDataWithNodesIcons = this.Factory.CreateRibbonButton();
            this.btn_NetworkDataWithNodesInColor = this.Factory.CreateRibbonButton();
            this.btn_NetworkDataScalinNodesEdges = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group_data.SuspendLayout();
            this.group_linkNetwork.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group_data);
            this.tab1.Groups.Add(this.group_linkNetwork);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group_data
            // 
            this.group_data.Items.Add(this.btn_SelectRange);
            this.group_data.Label = "Data";
            this.group_data.Name = "group_data";
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
            // group_linkNetwork
            // 
            this.group_linkNetwork.Items.Add(this.btn_buildNetwork);
            this.group_linkNetwork.Items.Add(this.splitBtn_NetworkDataTables);
            this.group_linkNetwork.Label = "Link Network";
            this.group_linkNetwork.Name = "group_linkNetwork";
            // 
            // btn_buildNetwork
            // 
            this.btn_buildNetwork.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_buildNetwork.Image = ((System.Drawing.Image)(resources.GetObject("btn_buildNetwork.Image")));
            this.btn_buildNetwork.Label = "Build Network";
            this.btn_buildNetwork.Name = "btn_buildNetwork";
            this.btn_buildNetwork.ShowImage = true;
            this.btn_buildNetwork.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_buildNetwork_Click);
            // 
            // splitBtn_NetworkDataTables
            // 
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_BasicNetworkData);
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_BasicTableWithCount);
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_NetworkDataLinkConfirmed);
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_NetworkDataWithNodesIcons);
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_NetworkDataWithNodesInColor);
            this.splitBtn_NetworkDataTables.Items.Add(this.btn_NetworkDataScalinNodesEdges);
            this.splitBtn_NetworkDataTables.Label = "Network Data Tables";
            this.splitBtn_NetworkDataTables.Name = "splitBtn_NetworkDataTables";
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
            // btn_NetworkDataWithNodesIcons
            // 
            this.btn_NetworkDataWithNodesIcons.Label = "From-To-Icons Table";
            this.btn_NetworkDataWithNodesIcons.Name = "btn_NetworkDataWithNodesIcons";
            this.btn_NetworkDataWithNodesIcons.ShowImage = true;
            this.btn_NetworkDataWithNodesIcons.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_NetworkDataWithNodesIcons_Click);
            // 
            // btn_NetworkDataWithNodesInColor
            // 
            this.btn_NetworkDataWithNodesInColor.Label = "From-To-Icons in Color Table";
            this.btn_NetworkDataWithNodesInColor.Name = "btn_NetworkDataWithNodesInColor";
            this.btn_NetworkDataWithNodesInColor.ShowImage = true;
            this.btn_NetworkDataWithNodesInColor.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_NetworkDataWithNodesInColor_Click);
            // 
            // btn_NetworkDataScalinNodesEdges
            // 
            this.btn_NetworkDataScalinNodesEdges.Label = "From-To Scaling Table";
            this.btn_NetworkDataScalinNodesEdges.Name = "btn_NetworkDataScalinNodesEdges";
            this.btn_NetworkDataScalinNodesEdges.ShowImage = true;
            this.btn_NetworkDataScalinNodesEdges.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_NetworkDataScalinNodesEdges_Click);
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
    }

    partial class ThisRibbonCollection
    {
        internal MainRibbon MainRibbon
        {
            get { return this.GetRibbon<MainRibbon>(); }
        }
    }
}
