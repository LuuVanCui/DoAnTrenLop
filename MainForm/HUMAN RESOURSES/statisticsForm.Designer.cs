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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClumnChart = new System.Windows.Forms.Button();
            this.buttonPieChart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // chartGroup
            // 
            this.chartGroup.BackColor = System.Drawing.Color.DarkSlateGray;
            this.chartGroup.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            chartArea1.Name = "ChartArea1";
            this.chartGroup.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartGroup.Legends.Add(legend1);
            this.chartGroup.Location = new System.Drawing.Point(44, 104);
            this.chartGroup.Name = "chartGroup";
            this.chartGroup.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "Group";
            this.chartGroup.Series.Add(series1);
            this.chartGroup.Size = new System.Drawing.Size(435, 296);
            this.chartGroup.TabIndex = 0;
            this.chartGroup.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(99, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Statistics By Group";
            // 
            // buttonClumnChart
            // 
            this.buttonClumnChart.BackColor = System.Drawing.Color.DimGray;
            this.buttonClumnChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClumnChart.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClumnChart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonClumnChart.Location = new System.Drawing.Point(540, 169);
            this.buttonClumnChart.Name = "buttonClumnChart";
            this.buttonClumnChart.Size = new System.Drawing.Size(172, 52);
            this.buttonClumnChart.TabIndex = 2;
            this.buttonClumnChart.Text = "Column Chart";
            this.buttonClumnChart.UseVisualStyleBackColor = false;
            this.buttonClumnChart.Click += new System.EventHandler(this.buttonClumnChart_Click);
            // 
            // buttonPieChart
            // 
            this.buttonPieChart.BackColor = System.Drawing.Color.DimGray;
            this.buttonPieChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPieChart.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPieChart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonPieChart.Location = new System.Drawing.Point(540, 296);
            this.buttonPieChart.Name = "buttonPieChart";
            this.buttonPieChart.Size = new System.Drawing.Size(172, 52);
            this.buttonPieChart.TabIndex = 2;
            this.buttonPieChart.Text = "Pie Chart";
            this.buttonPieChart.UseVisualStyleBackColor = false;
            this.buttonPieChart.Click += new System.EventHandler(this.buttonPieChart_Click);
            // 
            // statisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(764, 426);
            this.Controls.Add(this.buttonPieChart);
            this.Controls.Add(this.buttonClumnChart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartGroup);
            this.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.Name = "statisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.statisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClumnChart;
        private System.Windows.Forms.Button buttonPieChart;
    }
}