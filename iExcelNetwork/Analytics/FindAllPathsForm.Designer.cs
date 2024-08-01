namespace iExcelNetwork.Analytics
{
    partial class FindAllPathsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindAllPathsForm));
            this.btn_Find = new System.Windows.Forms.Button();
            this.txtBox_Node1 = new System.Windows.Forms.TextBox();
            this.txtBox_Node2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_source = new System.Windows.Forms.Label();
            this.lbl_destination = new System.Windows.Forms.Label();
            this.btn_exchangeSourceDestination = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Find
            // 
            this.btn_Find.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Find.Location = new System.Drawing.Point(245, 108);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(103, 33);
            this.btn_Find.TabIndex = 0;
            this.btn_Find.Text = "Find";
            this.btn_Find.UseVisualStyleBackColor = true;
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            // 
            // txtBox_Node1
            // 
            this.txtBox_Node1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_Node1.Location = new System.Drawing.Point(34, 53);
            this.txtBox_Node1.Name = "txtBox_Node1";
            this.txtBox_Node1.Size = new System.Drawing.Size(224, 31);
            this.txtBox_Node1.TabIndex = 1;
            // 
            // txtBox_Node2
            // 
            this.txtBox_Node2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_Node2.Location = new System.Drawing.Point(330, 53);
            this.txtBox_Node2.Name = "txtBox_Node2";
            this.txtBox_Node2.Size = new System.Drawing.Size(224, 31);
            this.txtBox_Node2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(521, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Find all paths between to nodes  with directed edges.";
            // 
            // lbl_source
            // 
            this.lbl_source.AutoSize = true;
            this.lbl_source.Location = new System.Drawing.Point(117, 87);
            this.lbl_source.Name = "lbl_source";
            this.lbl_source.Size = new System.Drawing.Size(41, 13);
            this.lbl_source.TabIndex = 4;
            this.lbl_source.Text = "Source";
            // 
            // lbl_destination
            // 
            this.lbl_destination.AutoSize = true;
            this.lbl_destination.Location = new System.Drawing.Point(424, 87);
            this.lbl_destination.Name = "lbl_destination";
            this.lbl_destination.Size = new System.Drawing.Size(60, 13);
            this.lbl_destination.TabIndex = 5;
            this.lbl_destination.Text = "Destination";
            // 
            // btn_exchangeSourceDestination
            // 
            this.btn_exchangeSourceDestination.Image = global::iExcelNetwork.Properties.Resources.exchange;
            this.btn_exchangeSourceDestination.Location = new System.Drawing.Point(272, 48);
            this.btn_exchangeSourceDestination.Name = "btn_exchangeSourceDestination";
            this.btn_exchangeSourceDestination.Size = new System.Drawing.Size(46, 47);
            this.btn_exchangeSourceDestination.TabIndex = 6;
            this.btn_exchangeSourceDestination.UseVisualStyleBackColor = true;
            this.btn_exchangeSourceDestination.Click += new System.EventHandler(this.btn_exchangeSourceDestination_Click);
            // 
            // FindAllPathsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 153);
            this.Controls.Add(this.btn_exchangeSourceDestination);
            this.Controls.Add(this.lbl_destination);
            this.Controls.Add(this.lbl_source);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox_Node2);
            this.Controls.Add(this.txtBox_Node1);
            this.Controls.Add(this.btn_Find);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FindAllPathsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Find;
        private System.Windows.Forms.TextBox txtBox_Node1;
        private System.Windows.Forms.TextBox txtBox_Node2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_source;
        private System.Windows.Forms.Label lbl_destination;
        private System.Windows.Forms.Button btn_exchangeSourceDestination;
    }
}