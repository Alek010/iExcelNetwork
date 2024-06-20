﻿using System.IO;

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
            this.lb_setOutPutFolder = new System.Windows.Forms.Label();
            this.btn_selectFolder = new System.Windows.Forms.Button();
            this.lb_networkOutputFolderPath = new System.Windows.Forms.Label();
            this.lb_EdgesDirection = new System.Windows.Forms.Label();
            this.cmBox_setEdgesDirection = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lb_setOutPutFolder
            // 
            this.lb_setOutPutFolder.AutoSize = true;
            this.lb_setOutPutFolder.Location = new System.Drawing.Point(32, 25);
            this.lb_setOutPutFolder.Name = "lb_setOutPutFolder";
            this.lb_setOutPutFolder.Size = new System.Drawing.Size(82, 13);
            this.lb_setOutPutFolder.TabIndex = 0;
            this.lb_setOutPutFolder.Text = "Network Output";
            // 
            // btn_selectFolder
            // 
            this.btn_selectFolder.Location = new System.Drawing.Point(120, 19);
            this.btn_selectFolder.Name = "btn_selectFolder";
            this.btn_selectFolder.Size = new System.Drawing.Size(91, 25);
            this.btn_selectFolder.TabIndex = 1;
            this.btn_selectFolder.Text = "Change Folder";
            this.btn_selectFolder.UseVisualStyleBackColor = true;
            this.btn_selectFolder.Click += new System.EventHandler(this.btn_selectFolder_Click);
            // 
            // lb_networkOutputFolderPath
            // 
            this.lb_networkOutputFolderPath.AutoSize = true;
            this.lb_networkOutputFolderPath.Location = new System.Drawing.Point(217, 25);
            this.lb_networkOutputFolderPath.Name = "lb_networkOutputFolderPath";
            this.lb_networkOutputFolderPath.Size = new System.Drawing.Size(128, 13);
            this.lb_networkOutputFolderPath.TabIndex = 2;
            this.lb_networkOutputFolderPath.Text = "C:\\path\\to\\output\\folder\\";
            // 
            // lb_EdgesDirection
            // 
            this.lb_EdgesDirection.AutoSize = true;
            this.lb_EdgesDirection.Location = new System.Drawing.Point(107, 141);
            this.lb_EdgesDirection.Name = "lb_EdgesDirection";
            this.lb_EdgesDirection.Size = new System.Drawing.Size(104, 13);
            this.lb_EdgesDirection.TabIndex = 3;
            this.lb_EdgesDirection.Text = "Set Edges Dirrection";
            // 
            // cmBox_setEdgesDirection
            // 
            this.cmBox_setEdgesDirection.FormattingEnabled = true;
            this.cmBox_setEdgesDirection.Location = new System.Drawing.Point(120, 166);
            this.cmBox_setEdgesDirection.Name = "cmBox_setEdgesDirection";
            this.cmBox_setEdgesDirection.Size = new System.Drawing.Size(67, 21);
            this.cmBox_setEdgesDirection.TabIndex = 4;
            this.cmBox_setEdgesDirection.SelectedValueChanged += new System.EventHandler(this.cmBox_setEdgesDirection_SelectedValueChanged);
            // 
            // NetworkPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmBox_setEdgesDirection);
            this.Controls.Add(this.lb_EdgesDirection);
            this.Controls.Add(this.lb_networkOutputFolderPath);
            this.Controls.Add(this.btn_selectFolder);
            this.Controls.Add(this.lb_setOutPutFolder);
            this.Name = "NetworkPropertiesForm";
            this.Text = "NetworkProperties";
            this.Load += new System.EventHandler(this.NetworkPropertiesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_setOutPutFolder;
        private System.Windows.Forms.Button btn_selectFolder;
        private System.Windows.Forms.Label lb_networkOutputFolderPath;
        private System.Windows.Forms.Label lb_EdgesDirection;
        private System.Windows.Forms.ComboBox cmBox_setEdgesDirection;
    }
}