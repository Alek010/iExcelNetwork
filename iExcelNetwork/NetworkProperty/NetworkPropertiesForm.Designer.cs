using System.IO;

namespace iExcelNetwork.NetworkProperty
{
    partial class NetworkPropertiesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkPropertiesForm));
            this.btn_selectFolder = new System.Windows.Forms.Button();
            this.lb_networkOutputFolderPath = new System.Windows.Forms.Label();
            this.lb_EdgesDirection = new System.Windows.Forms.Label();
            this.cmBox_setEdgesDirection = new System.Windows.Forms.ComboBox();
            this.lb_OutputProperties = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_Ok = new System.Windows.Forms.Button();
            this.lb_NetworkFileName = new System.Windows.Forms.Label();
            this.txBox_fileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_selectFolder
            // 
            this.btn_selectFolder.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_selectFolder.Location = new System.Drawing.Point(24, 179);
            this.btn_selectFolder.Name = "btn_selectFolder";
            this.btn_selectFolder.Size = new System.Drawing.Size(101, 30);
            this.btn_selectFolder.TabIndex = 1;
            this.btn_selectFolder.Text = "Set Folder";
            this.btn_selectFolder.UseVisualStyleBackColor = true;
            this.btn_selectFolder.Click += new System.EventHandler(this.btn_selectFolder_Click);
            // 
            // lb_networkOutputFolderPath
            // 
            this.lb_networkOutputFolderPath.AutoSize = true;
            this.lb_networkOutputFolderPath.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_networkOutputFolderPath.Location = new System.Drawing.Point(137, 179);
            this.lb_networkOutputFolderPath.MaximumSize = new System.Drawing.Size(150, 50);
            this.lb_networkOutputFolderPath.Name = "lb_networkOutputFolderPath";
            this.lb_networkOutputFolderPath.Size = new System.Drawing.Size(147, 15);
            this.lb_networkOutputFolderPath.TabIndex = 2;
            this.lb_networkOutputFolderPath.Text = "C:\\path\\to\\output\\folder\\";
            // 
            // lb_EdgesDirection
            // 
            this.lb_EdgesDirection.AutoSize = true;
            this.lb_EdgesDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_EdgesDirection.Location = new System.Drawing.Point(20, 57);
            this.lb_EdgesDirection.Name = "lb_EdgesDirection";
            this.lb_EdgesDirection.Size = new System.Drawing.Size(114, 20);
            this.lb_EdgesDirection.TabIndex = 3;
            this.lb_EdgesDirection.Text = "Arrow direction";
            // 
            // cmBox_setEdgesDirection
            // 
            this.cmBox_setEdgesDirection.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmBox_setEdgesDirection.FormattingEnabled = true;
            this.cmBox_setEdgesDirection.Location = new System.Drawing.Point(140, 56);
            this.cmBox_setEdgesDirection.Name = "cmBox_setEdgesDirection";
            this.cmBox_setEdgesDirection.Size = new System.Drawing.Size(67, 27);
            this.cmBox_setEdgesDirection.TabIndex = 4;
            this.cmBox_setEdgesDirection.SelectedValueChanged += new System.EventHandler(this.cmBox_setEdgesDirection_SelectedValueChanged);
            // 
            // lb_OutputProperties
            // 
            this.lb_OutputProperties.AutoSize = true;
            this.lb_OutputProperties.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_OutputProperties.Location = new System.Drawing.Point(12, 107);
            this.lb_OutputProperties.Name = "lb_OutputProperties";
            this.lb_OutputProperties.Size = new System.Drawing.Size(154, 23);
            this.lb_OutputProperties.TabIndex = 5;
            this.lb_OutputProperties.Text = "Output Properties";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Edges Properties";
            // 
            // bt_Ok
            // 
            this.bt_Ok.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Ok.Location = new System.Drawing.Point(131, 227);
            this.bt_Ok.Name = "bt_Ok";
            this.bt_Ok.Size = new System.Drawing.Size(97, 31);
            this.bt_Ok.TabIndex = 7;
            this.bt_Ok.Text = "OK";
            this.bt_Ok.UseVisualStyleBackColor = true;
            this.bt_Ok.Click += new System.EventHandler(this.bt_Ok_Click);
            // 
            // lb_NetworkFileName
            // 
            this.lb_NetworkFileName.AutoSize = true;
            this.lb_NetworkFileName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NetworkFileName.Location = new System.Drawing.Point(33, 149);
            this.lb_NetworkFileName.Name = "lb_NetworkFileName";
            this.lb_NetworkFileName.Size = new System.Drawing.Size(74, 19);
            this.lb_NetworkFileName.TabIndex = 8;
            this.lb_NetworkFileName.Text = "File Name";
            // 
            // txBox_fileName
            // 
            this.txBox_fileName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txBox_fileName.Location = new System.Drawing.Point(140, 141);
            this.txBox_fileName.Name = "txBox_fileName";
            this.txBox_fileName.Size = new System.Drawing.Size(144, 27);
            this.txBox_fileName.TabIndex = 9;
            // 
            // NetworkPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 270);
            this.Controls.Add(this.txBox_fileName);
            this.Controls.Add(this.lb_NetworkFileName);
            this.Controls.Add(this.bt_Ok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_OutputProperties);
            this.Controls.Add(this.cmBox_setEdgesDirection);
            this.Controls.Add(this.lb_EdgesDirection);
            this.Controls.Add(this.lb_networkOutputFolderPath);
            this.Controls.Add(this.btn_selectFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NetworkPropertiesForm";
            this.Text = "Network Properties";
            this.Load += new System.EventHandler(this.NetworkPropertiesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_selectFolder;
        private System.Windows.Forms.Label lb_networkOutputFolderPath;
        private System.Windows.Forms.Label lb_EdgesDirection;
        private System.Windows.Forms.ComboBox cmBox_setEdgesDirection;
        private System.Windows.Forms.Label lb_OutputProperties;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_Ok;
        private System.Windows.Forms.Label lb_NetworkFileName;
        private System.Windows.Forms.TextBox txBox_fileName;
    }
}