﻿namespace MainForm
{
    partial class avgScoreByCourseForm
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
            this.dataGridViewAvgScore = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvgScore)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAvgScore
            // 
            this.dataGridViewAvgScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAvgScore.BackgroundColor = System.Drawing.Color.Coral;
            this.dataGridViewAvgScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAvgScore.Location = new System.Drawing.Point(31, 31);
            this.dataGridViewAvgScore.Name = "dataGridViewAvgScore";
            this.dataGridViewAvgScore.RowHeadersWidth = 62;
            this.dataGridViewAvgScore.RowTemplate.Height = 28;
            this.dataGridViewAvgScore.Size = new System.Drawing.Size(585, 597);
            this.dataGridViewAvgScore.TabIndex = 0;
            // 
            // avgScoreByCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(650, 659);
            this.Controls.Add(this.dataGridViewAvgScore);
            this.Name = "avgScoreByCourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AVG Score By Courses";
            this.Load += new System.EventHandler(this.avgScoreByCourseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvgScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAvgScore;
    }
}