namespace Lab1SingleChannel
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.History = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CountMess = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.NewChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.History)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountMess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewChart)).BeginInit();
            this.SuspendLayout();
            // 
            // History
            // 
            chartArea1.Name = "ChartArea1";
            this.History.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.History.Legends.Add(legend1);
            this.History.Location = new System.Drawing.Point(12, 12);
            this.History.Name = "History";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.History.Series.Add(series1);
            this.History.Size = new System.Drawing.Size(317, 317);
            this.History.TabIndex = 0;
            this.History.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Средняя задержка ";
            this.History.Titles.Add(title1);
            // 
            // CountMess
            // 
            chartArea2.Name = "ChartArea1";
            this.CountMess.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.CountMess.Legends.Add(legend2);
            this.CountMess.Location = new System.Drawing.Point(471, 12);
            this.CountMess.Name = "CountMess";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.CountMess.Series.Add(series2);
            this.CountMess.Size = new System.Drawing.Size(317, 317);
            this.CountMess.TabIndex = 1;
            this.CountMess.Text = "chart2";
            title2.Name = "Title1";
            title2.Text = "CountMess";
            this.CountMess.Titles.Add(title2);
            // 
            // NewChart
            // 
            chartArea3.Name = "ChartArea1";
            this.NewChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.NewChart.Legends.Add(legend3);
            this.NewChart.Location = new System.Drawing.Point(96, 335);
            this.NewChart.Name = "NewChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.NewChart.Series.Add(series3);
            this.NewChart.Size = new System.Drawing.Size(620, 263);
            this.NewChart.TabIndex = 2;
            this.NewChart.Text = "chart1";
            title3.Name = "Title1";
            title3.Text = "Отношение интенсивности входного к выходному";
            this.NewChart.Titles.Add(title3);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 610);
            this.Controls.Add(this.NewChart);
            this.Controls.Add(this.CountMess);
            this.Controls.Add(this.History);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.History)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountMess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart History;
        private System.Windows.Forms.DataVisualization.Charting.Chart CountMess;
        private System.Windows.Forms.DataVisualization.Charting.Chart NewChart;
    }
}

