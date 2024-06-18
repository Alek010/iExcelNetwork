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
            this.lb_setOutPutFolder = new System.Windows.Forms.Label();
            this.btn_selectFolder = new System.Windows.Forms.Button();
            this.lb_networkOutputFolderPath = new System.Windows.Forms.Label();
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
            this.lb_networkOutputFolderPath.Size = new System.Drawing.Size(190, 13);
            this.lb_networkOutputFolderPath.TabIndex = 2;
            this.lb_networkOutputFolderPath.Text = "C:\\Users\\Alek\\AppData\\Local\\Temp\\";
            // 
            // NetworkPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lb_networkOutputFolderPath);
            this.Controls.Add(this.btn_selectFolder);
            this.Controls.Add(this.lb_setOutPutFolder);
            this.Name = "NetworkPropertiesForm";
            this.Text = "NetworkProperties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_setOutPutFolder;
        private System.Windows.Forms.Button btn_selectFolder;
        private System.Windows.Forms.Label lb_networkOutputFolderPath;
    }
}