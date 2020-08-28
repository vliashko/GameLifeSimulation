namespace GameOfLife
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.RunButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.movelabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.bornlabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.deadlabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.alivelabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.PauseButton = new System.Windows.Forms.Button();
            this.RunOneStepButton = new System.Windows.Forms.Button();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.seedpercent = new System.Windows.Forms.Label();
            this.densityCount = new System.Windows.Forms.TrackBar();
            this.ComboBoxForChart = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picture = new System.Windows.Forms.PictureBox();
            this.zoomlabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.percentDeathCount = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.countForMaxLife = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.countForNewLife = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.countForMax = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.countForMin = new System.Windows.Forms.NumericUpDown();
            this.ResetButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.densityCount)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percentDeathCount)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countForMaxLife)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countForNewLife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countForMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countForMin)).BeginInit();
            this.SuspendLayout();
            // 
            // RunButton
            // 
            this.RunButton.Enabled = false;
            this.RunButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RunButton.Location = new System.Drawing.Point(818, 230);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(92, 23);
            this.RunButton.TabIndex = 1;
            this.RunButton.Text = "Начать игру";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.Play_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movelabel,
            this.toolStripStatusLabel3,
            this.bornlabel,
            this.toolStripStatusLabel1,
            this.deadlabel,
            this.toolStripStatusLabel2,
            this.alivelabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1147, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // movelabel
            // 
            this.movelabel.Name = "movelabel";
            this.movelabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabel3.Text = " | ";
            // 
            // bornlabel
            // 
            this.bornlabel.ForeColor = System.Drawing.Color.Blue;
            this.bornlabel.Name = "bornlabel";
            this.bornlabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabel1.Text = " | ";
            // 
            // deadlabel
            // 
            this.deadlabel.ForeColor = System.Drawing.Color.Red;
            this.deadlabel.Name = "deadlabel";
            this.deadlabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabel2.Text = " | ";
            // 
            // alivelabel
            // 
            this.alivelabel.ForeColor = System.Drawing.Color.Green;
            this.alivelabel.Name = "alivelabel";
            this.alivelabel.Size = new System.Drawing.Size(0, 17);
            // 
            // PauseButton
            // 
            this.PauseButton.Enabled = false;
            this.PauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PauseButton.Location = new System.Drawing.Point(991, 230);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(69, 23);
            this.PauseButton.TabIndex = 4;
            this.PauseButton.Text = "Пауза";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.Pause_Click);
            // 
            // RunOneStepButton
            // 
            this.RunOneStepButton.Enabled = false;
            this.RunOneStepButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RunOneStepButton.Location = new System.Drawing.Point(916, 230);
            this.RunOneStepButton.Name = "RunOneStepButton";
            this.RunOneStepButton.Size = new System.Drawing.Size(69, 23);
            this.RunOneStepButton.TabIndex = 7;
            this.RunOneStepButton.Text = "+1 ход";
            this.RunOneStepButton.UseVisualStyleBackColor = true;
            this.RunOneStepButton.Click += new System.EventHandler(this.ButtonMove_Click);
            // 
            // chart
            // 
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.WallWidth = 1;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Location = new System.Drawing.Point(0, 25);
            this.chart.Name = "chart";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.LimeGreen;
            series1.Name = "Alive";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Blue;
            series2.Name = "Born";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.Red;
            series3.Name = "Dead";
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Series.Add(series3);
            this.chart.Size = new System.Drawing.Size(1147, 148);
            this.chart.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.seedpercent);
            this.groupBox1.Controls.Add(this.densityCount);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(0, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 70);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Заселенность %";
            // 
            // seedpercent
            // 
            this.seedpercent.AutoSize = true;
            this.seedpercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.seedpercent.Location = new System.Drawing.Point(181, 30);
            this.seedpercent.Name = "seedpercent";
            this.seedpercent.Size = new System.Drawing.Size(14, 13);
            this.seedpercent.TabIndex = 10;
            this.seedpercent.Text = "0";
            // 
            // densityCount
            // 
            this.densityCount.Location = new System.Drawing.Point(12, 19);
            this.densityCount.Maximum = 100;
            this.densityCount.Name = "densityCount";
            this.densityCount.Size = new System.Drawing.Size(163, 45);
            this.densityCount.TabIndex = 7;
            this.densityCount.ValueChanged += new System.EventHandler(this.MaxLifeTrackBar_ValueChanged);
            // 
            // ComboBoxForChart
            // 
            this.ComboBoxForChart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxForChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ComboBoxForChart.FormattingEnabled = true;
            this.ComboBoxForChart.Items.AddRange(new object[] {
            "100",
            "200",
            "300",
            "500",
            "1000"});
            this.ComboBoxForChart.Location = new System.Drawing.Point(870, 201);
            this.ComboBoxForChart.Name = "ComboBoxForChart";
            this.ComboBoxForChart.Size = new System.Drawing.Size(115, 21);
            this.ComboBoxForChart.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(848, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Количество точек график";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1047, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Приближение";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.picture);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 259);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 565);
            this.panel1.TabIndex = 16;
            // 
            // picture
            // 
            this.picture.Location = new System.Drawing.Point(0, 0);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(1147, 565);
            this.picture.TabIndex = 1;
            this.picture.TabStop = false;
            this.picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseDown);
            this.picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseMove);
            this.picture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseUp);
            // 
            // zoomlabel
            // 
            this.zoomlabel.AutoSize = true;
            this.zoomlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zoomlabel.Location = new System.Drawing.Point(1073, 201);
            this.zoomlabel.Name = "zoomlabel";
            this.zoomlabel.Size = new System.Drawing.Size(0, 13);
            this.zoomlabel.TabIndex = 17;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.percentDeathCount);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(211, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(119, 64);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Внезапная смерть %";
            // 
            // percentDeathCount
            // 
            this.percentDeathCount.Location = new System.Drawing.Point(6, 28);
            this.percentDeathCount.Name = "percentDeathCount";
            this.percentDeathCount.ReadOnly = true;
            this.percentDeathCount.Size = new System.Drawing.Size(95, 20);
            this.percentDeathCount.TabIndex = 0;
            this.percentDeathCount.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.percentDeathCount.ValueChanged += new System.EventHandler(this.DeathPercent_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.countForMaxLife);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(336, 188);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(111, 64);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Макс жизнь";
            // 
            // countForMaxLife
            // 
            this.countForMaxLife.Location = new System.Drawing.Point(6, 28);
            this.countForMaxLife.Name = "countForMaxLife";
            this.countForMaxLife.ReadOnly = true;
            this.countForMaxLife.Size = new System.Drawing.Size(64, 20);
            this.countForMaxLife.TabIndex = 0;
            this.countForMaxLife.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.countForMaxLife.ValueChanged += new System.EventHandler(this.MaxLife_ValueChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.countForNewLife);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.countForMax);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.countForMin);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(453, 188);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(359, 64);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Количество соседей";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Для новой жизни";
            // 
            // countForNewLife
            // 
            this.countForNewLife.Location = new System.Drawing.Point(311, 28);
            this.countForNewLife.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.countForNewLife.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countForNewLife.Name = "countForNewLife";
            this.countForNewLife.ReadOnly = true;
            this.countForNewLife.Size = new System.Drawing.Size(42, 20);
            this.countForNewLife.TabIndex = 4;
            this.countForNewLife.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.countForNewLife.ValueChanged += new System.EventHandler(this.NeighboursForNewLife_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Макс";
            // 
            // countForMax
            // 
            this.countForMax.Location = new System.Drawing.Point(146, 28);
            this.countForMax.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.countForMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countForMax.Name = "countForMax";
            this.countForMax.ReadOnly = true;
            this.countForMax.Size = new System.Drawing.Size(42, 20);
            this.countForMax.TabIndex = 2;
            this.countForMax.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.countForMax.ValueChanged += new System.EventHandler(this.MaxNeighbours_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Мин";
            // 
            // countForMin
            // 
            this.countForMin.Location = new System.Drawing.Point(54, 28);
            this.countForMin.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.countForMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countForMin.Name = "countForMin";
            this.countForMin.ReadOnly = true;
            this.countForMin.Size = new System.Drawing.Size(42, 20);
            this.countForMin.TabIndex = 0;
            this.countForMin.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.countForMin.ValueChanged += new System.EventHandler(this.MinNeighbours_ValueChanged);
            // 
            // ResetButton
            // 
            this.ResetButton.Enabled = false;
            this.ResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResetButton.Location = new System.Drawing.Point(1066, 229);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(69, 23);
            this.ResetButton.TabIndex = 21;
            this.ResetButton.Text = "Сброс";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1147, 824);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.zoomlabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboBoxForChart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.RunOneStepButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.RunButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Симуляция жизни";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.densityCount)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.percentDeathCount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.countForMaxLife)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countForNewLife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countForMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countForMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel bornlabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel deadlabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel alivelabel;
        private System.Windows.Forms.ToolStripStatusLabel movelabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button RunOneStepButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label seedpercent;
        private System.Windows.Forms.TrackBar densityCount;
        private System.Windows.Forms.ComboBox ComboBoxForChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Label zoomlabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown percentDeathCount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown countForMaxLife;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown countForMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown countForNewLife;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown countForMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ResetButton;
    }
}

