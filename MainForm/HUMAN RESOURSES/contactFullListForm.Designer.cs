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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonExportExelFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowData)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(29, 29);
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
            this.label2.Location = new System.Drawing.Point(329, 29);
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
            this.listBoxGroup.Location = new System.Drawing.Point(37, 83);
            this.listBoxGroup.Name = "listBoxGroup";
            this.listBoxGroup.Size = new System.Drawing.Size(284, 452);
            this.listBoxGroup.TabIndex = 1;
            this.listBoxGroup.Click += new System.EventHandler(this.listBoxGroup_Click);
            // 
            // dataGridViewShowData
            // 
            this.dataGridViewShowData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewShowData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShowData.Location = new System.Drawing.Point(337, 83);
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
            this.label3.Location = new System.Drawing.Point(330, 556);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Full Address:";
            // 
            // textBoxFullAddress
            // 
            this.textBoxFullAddress.Location = new System.Drawing.Point(490, 560);
            this.textBoxFullAddress.Multiline = true;
            this.textBoxFullAddress.Name = "textBoxFullAddress";
            this.textBoxFullAddress.Size = new System.Drawing.Size(448, 63);
            this.textBoxFullAddress.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonExportExelFile);
            this.panel1.Controls.Add(this.buttonPrint);
            this.panel1.Controls.Add(this.textBoxFullAddress);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dataGridViewShowData);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.listBoxGroup);
            this.panel1.Location = new System.Drawing.Point(-4, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1235, 776);
            this.panel1.TabIndex = 4;
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.Color.Goldenrod;
            this.buttonPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrint.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonPrint.Location = new System.Drawing.Point(675, 668);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(187, 58);
            this.buttonPrint.TabIndex = 4;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonExportExelFile
            // 
            this.buttonExportExelFile.BackColor = System.Drawing.Color.Goldenrod;
            this.buttonExportExelFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportExelFile.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonExportExelFile.Location = new System.Drawing.Point(238, 668);
            this.buttonExportExelFile.Name = "buttonExportExelFile";
            this.buttonExportExelFile.Size = new System.Drawing.Size(246, 58);
            this.buttonExportExelFile.TabIndex = 4;
            this.buttonExportExelFile.Text = "Export Exel File";
            this.buttonExportExelFile.UseVisualStyleBackColor = false;
            this.buttonExportExelFile.Click += new System.EventHandler(this.buttonExportExelFile_Click);
            // 
            // contactFullListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.ClientSize = new System.Drawing.Size(1229, 781);
            this.Controls.Add(this.panel1);
            this.Name = "contactFullListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contact Full List";
            this.Load += new System.EventHandler(this.contactFullListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxGroup;
        private System.Windows.Forms.DataGridView dataGridViewShowData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFullAddress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonExportExelFile;
        private System.Windows.Forms.Button buttonPrint;
    }
}