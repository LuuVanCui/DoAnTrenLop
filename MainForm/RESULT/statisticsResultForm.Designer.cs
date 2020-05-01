namespace MainForm
{
    partial class statisticsResultForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chartCourses = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartResult = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartResult)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Freestyle Script", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Turquoise;
            this.label1.Location = new System.Drawing.Point(170, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Statistics by Courses";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Freestyle Script", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Turquoise;
            this.label2.Location = new System.Drawing.Point(786, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 47);
            this.label2.TabIndex = 0;
            this.label2.Text = "Statistics by Result";
            // 
            // chartCourses
            // 
            chartArea1.Name = "ChartArea1";
            this.chartCourses.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartCourses.Legends.Add(legend1);
            this.chartCourses.Location = new System.Drawing.Point(23, 119);
            this.chartCourses.Name = "chartCourses";
            this.chartCourses.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Courses";
            this.chartCourses.Series.Add(series1);
            this.chartCourses.Size = new System.Drawing.Size(523, 300);
            this.chartCourses.TabIndex = 1;
            this.chartCourses.Text = "chart1";
            // 
            // chartResult
            // 
            chartArea2.Name = "ChartArea1";
            this.chartResult.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartResult.Legends.Add(legend2);
            this.chartResult.Location = new System.Drawing.Point(668, 119);
            this.chartResult.Name = "chartResult";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Result";
            this.chartResult.Series.Add(series2);
            this.chartResult.Size = new System.Drawing.Size(485, 305);
            this.chartResult.TabIndex = 1;
            this.chartResult.Text = "chart1";
            // 
            // statisticsResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1178, 457);
            this.Controls.Add(this.chartResult);
            this.Controls.Add(this.chartCourses);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "statisticsResultForm";
            this.Text = "statisticsResult";
            this.Load += new System.EventHandler(this.statisticsResultForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCourses;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResult;
    }
}