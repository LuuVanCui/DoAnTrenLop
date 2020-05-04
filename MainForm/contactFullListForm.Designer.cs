namespace MainForm
{
    partial class contactFullListForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxGroup = new System.Windows.Forms.ListBox();
            this.dataGridViewShowData = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFullAddress = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(33, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(333, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Show All";
            // 
            // listBoxGroup
            // 
            this.listBoxGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxGroup.ForeColor = System.Drawing.Color.Blue;
            this.listBoxGroup.FormattingEnabled = true;
            this.listBoxGroup.ItemHeight = 32;
            this.listBoxGroup.Location = new System.Drawing.Point(39, 87);
            this.listBoxGroup.Name = "listBoxGroup";
            this.listBoxGroup.Size = new System.Drawing.Size(284, 452);
            this.listBoxGroup.TabIndex = 1;
            this.listBoxGroup.Click += new System.EventHandler(this.listBoxGroup_Click);
            // 
            // dataGridViewShowData
            // 
            this.dataGridViewShowData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewShowData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShowData.Location = new System.Drawing.Point(339, 87);
            this.dataGridViewShowData.Name = "dataGridViewShowData";
            this.dataGridViewShowData.RowHeadersWidth = 62;
            this.dataGridViewShowData.RowTemplate.Height = 28;
            this.dataGridViewShowData.Size = new System.Drawing.Size(868, 452);
            this.dataGridViewShowData.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkKhaki;
            this.label3.Location = new System.Drawing.Point(334, 556);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Full Address:";
            // 
            // textBoxFullAddress
            // 
            this.textBoxFullAddress.Location = new System.Drawing.Point(494, 560);
            this.textBoxFullAddress.Multiline = true;
            this.textBoxFullAddress.Name = "textBoxFullAddress";
            this.textBoxFullAddress.Size = new System.Drawing.Size(448, 91);
            this.textBoxFullAddress.TabIndex = 3;
            // 
            // contactFullListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.ClientSize = new System.Drawing.Size(1229, 672);
            this.Controls.Add(this.textBoxFullAddress);
            this.Controls.Add(this.dataGridViewShowData);
            this.Controls.Add(this.listBoxGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "contactFullListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contact Full List";
            this.Load += new System.EventHandler(this.contactFullListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxGroup;
        private System.Windows.Forms.DataGridView dataGridViewShowData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFullAddress;
    }
}