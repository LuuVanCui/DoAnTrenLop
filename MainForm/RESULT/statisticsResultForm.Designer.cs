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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chartCourses = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartResult = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxTypeChart = new System.Windows.Forms.ComboBox();
            this.checkBoxCourses = new System.Windows.Forms.CheckBox();
            this.checkBoxResult = new System.Windows.Forms.CheckBox();
            this.buttonSet = new System.Windows.Forms.Button();
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
            this.label2.Location = new System.Drawing.Point(759, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 47);
            this.label2.TabIndex = 0;
            this.label2.Text = "Statistics by Result";
            // 
            // chartCourses
            // 
            chartArea7.Name = "ChartArea1";
            this.chartCourses.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chartCourses.Legends.Add(legend7);
            this.chartCourses.Location = new System.Drawing.Point(53, 119);
            this.chartCourses.Name = "chartCourses";
            this.chartCourses.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Courses";
            this.chartCourses.Series.Add(series7);
            this.chartCourses.Size = new System.Drawing.Size(523, 300);
            this.chartCourses.TabIndex = 1;
            this.chartCourses.Text = "chart1";
            // 
            // chartResult
            // 
            chartArea8.Name = "ChartArea1";
            this.chartResult.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chartResult.Legends.Add(legend8);
            this.chartResult.Location = new System.Drawing.Point(646, 119);
            this.chartResult.Name = "chartResult";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series8.Legend = "Legend1";
            series8.Name = "Result";
            this.chartResult.Series.Add(series8);
            this.chartResult.Size = new System.Drawing.Size(485, 305);
            this.chartResult.TabIndex = 1;
            this.chartResult.Text = "chart1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(342, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Statistics  by:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label4.Location = new System.Drawing.Point(354, 505);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Type Chart:";
            // 
            // comboBoxTypeChart
            // 
            this.comboBoxTypeChart.FormattingEnabled = true;
            this.comboBoxTypeChart.Items.AddRange(new object[] {
            "Line Chart",
            "Clumn Chart",
            "Pie Chart"});
            this.comboBoxTypeChart.Location = new System.Drawing.Point(485, 506);
            this.comboBoxTypeChart.Name = "comboBoxTypeChart";
            this.comboBoxTypeChart.Size = new System.Drawing.Size(195, 28);
            this.comboBoxTypeChart.TabIndex = 4;
            // 
            // checkBoxCourses
            // 
            this.checkBoxCourses.AutoSize = true;
            this.checkBoxCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCourses.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.checkBoxCourses.Location = new System.Drawing.Point(485, 461);
            this.checkBoxCourses.Name = "checkBoxCourses";
            this.checkBoxCourses.Size = new System.Drawing.Size(112, 29);
            this.checkBoxCourses.TabIndex = 5;
            this.checkBoxCourses.Text = "Courses";
            this.checkBoxCourses.UseVisualStyleBackColor = true;
            // 
            // checkBoxResult
            // 
            this.checkBoxResult.AutoSize = true;
            this.checkBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxResult.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.checkBoxResult.Location = new System.Drawing.Point(599, 461);
            this.checkBoxResult.Name = "checkBoxResult";
            this.checkBoxResult.Size = new System.Drawing.Size(92, 29);
            this.checkBoxResult.TabIndex = 5;
            this.checkBoxResult.Text = "Result";
            this.checkBoxResult.UseVisualStyleBackColor = true;
            // 
            // buttonSet
            // 
            this.buttonSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSet.ForeColor = System.Drawing.Color.Crimson;
            this.buttonSet.Location = new System.Drawing.Point(724, 487);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(154, 43);
            this.buttonSet.TabIndex = 6;
            this.buttonSet.Text = "Set";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // statisticsResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1178, 569);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.checkBoxResult);
            this.Controls.Add(this.checkBoxCourses);
            this.Controls.Add(this.comboBoxTypeChart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chartResult);
            this.Controls.Add(this.chartCourses);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Name = "statisticsResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics";
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTypeChart;
        private System.Windows.Forms.CheckBox checkBoxCourses;
        private System.Windows.Forms.CheckBox checkBoxResult;
        private System.Windows.Forms.Button buttonSet;
    }
}