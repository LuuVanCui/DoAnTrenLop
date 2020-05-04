namespace MainForm
{
    partial class statisticsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartGroup = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // chartGroup
            // 
            chartArea1.Name = "ChartArea1";
            this.chartGroup.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartGroup.Legends.Add(legend1);
            this.chartGroup.Location = new System.Drawing.Point(223, 95);
            this.chartGroup.Name = "chartGroup";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Group";
            this.chartGroup.Series.Add(series1);
            this.chartGroup.Size = new System.Drawing.Size(419, 290);
            this.chartGroup.TabIndex = 0;
            this.chartGroup.Text = "chart1";
            // 
            // statisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartGroup);
            this.Name = "statisticsForm";
            this.Text = "statisticsForm";
            this.Load += new System.EventHandler(this.statisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartGroup;
    }
}