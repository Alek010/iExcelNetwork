namespace iExcelNetwork
{
    partial class RibbonNetwork : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonNetwork()
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
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btn_SelectRange = this.Factory.CreateRibbonButton();
            this.btn_saveJson = this.Factory.CreateRibbonButton();
            this.btn_buildNetwork = this.Factory.CreateRibbonButton();
            this.btn_howItWorks = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "iExcelNetwork";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btn_SelectRange);
            this.group1.Items.Add(this.btn_saveJson);
            this.group1.Items.Add(this.btn_buildNetwork);
            this.group1.Items.Add(this.btn_howItWorks);
            this.group1.Label = "Basic";
            this.group1.Name = "group1";
            // 
            // btn_SelectRange
            // 
            this.btn_SelectRange.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_SelectRange.Image = global::iExcelNetwork.Properties.Resources.select1;
            this.btn_SelectRange.Label = "Select Range";
            this.btn_SelectRange.Name = "btn_SelectRange";
            this.btn_SelectRange.ShowImage = true;
            this.btn_SelectRange.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_SelectRange_Click);
            // 
            // btn_saveJson
            // 
            this.btn_saveJson.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_saveJson.Image = global::iExcelNetwork.Properties.Resources.toJson;
            this.btn_saveJson.Label = "Range To JSON";
            this.btn_saveJson.Name = "btn_saveJson";
            this.btn_saveJson.ShowImage = true;
            this.btn_saveJson.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_saveJson_Click);
            // 
            // btn_buildNetwork
            // 
            this.btn_buildNetwork.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_buildNetwork.Image = global::iExcelNetwork.Properties.Resources.buildNetwork;
            this.btn_buildNetwork.Label = "Build Network";
            this.btn_buildNetwork.Name = "btn_buildNetwork";
            this.btn_buildNetwork.ShowImage = true;
            this.btn_buildNetwork.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_buildNetwork_Click);
            // 
            // btn_howItWorks
            // 
            this.btn_howItWorks.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_howItWorks.Image = global::iExcelNetwork.Properties.Resources.how_it_works_22;
            this.btn_howItWorks.Label = "How It Works";
            this.btn_howItWorks.Name = "btn_howItWorks";
            this.btn_howItWorks.ShowImage = true;
            // 
            // RibbonNetwork
            // 
            this.Name = "RibbonNetwork";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonNetwork_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_SelectRange;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_saveJson;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_buildNetwork;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_howItWorks;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonNetwork RibbonNetwork
        {
            get { return this.GetRibbon<RibbonNetwork>(); }
        }
    }
}
