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
            this.btn_Find = new System.Windows.Forms.Button();
            this.txtBox_Node1 = new System.Windows.Forms.TextBox();
            this.txtBox_Node2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Find
            // 
            this.btn_Find.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Find.Location = new System.Drawing.Point(241, 104);
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
            // FindAllPathsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 153);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox_Node2);
            this.Controls.Add(this.txtBox_Node1);
            this.Controls.Add(this.btn_Find);
            this.Name = "FindAllPathsForm";
            this.Text = "FindAllPaths";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Find;
        private System.Windows.Forms.TextBox txtBox_Node1;
        private System.Windows.Forms.TextBox txtBox_Node2;
        private System.Windows.Forms.Label label1;
    }
}