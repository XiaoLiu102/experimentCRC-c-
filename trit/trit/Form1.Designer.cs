namespace trit
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Random = new System.Windows.Forms.Button();
            this.tritCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RandomError = new System.Windows.Forms.Button();
            this.trit = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.crctrit = new System.Windows.Forms.TextBox();
            this.crctest = new System.Windows.Forms.Button();
            this.tbtrue = new System.Windows.Forms.TextBox();
            this.tbfalse = new System.Windows.Forms.TextBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.run = new System.Windows.Forms.Button();
            this.trueCount = new System.Windows.Forms.Label();
            this.falseCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // Random
            // 
            this.Random.Location = new System.Drawing.Point(348, 454);
            this.Random.Name = "Random";
            this.Random.Size = new System.Drawing.Size(100, 50);
            this.Random.TabIndex = 0;
            this.Random.Text = "Random";
            this.Random.UseVisualStyleBackColor = true;
            this.Random.Click += new System.EventHandler(this.Random_Click);
            // 
            // tritCount
            // 
            this.tritCount.Location = new System.Drawing.Point(215, 467);
            this.tritCount.Name = "tritCount";
            this.tritCount.Size = new System.Drawing.Size(100, 28);
            this.tritCount.TabIndex = 2;
            this.tritCount.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 470);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "wordCount = ";
            // 
            // RandomError
            // 
            this.RandomError.Location = new System.Drawing.Point(348, 528);
            this.RandomError.Name = "RandomError";
            this.RandomError.Size = new System.Drawing.Size(150, 50);
            this.RandomError.TabIndex = 4;
            this.RandomError.Text = "RandomError";
            this.RandomError.UseVisualStyleBackColor = true;
            this.RandomError.Click += new System.EventHandler(this.RandomError_Click);
            // 
            // trit
            // 
            this.trit.Location = new System.Drawing.Point(604, 476);
            this.trit.Name = "trit";
            this.trit.Size = new System.Drawing.Size(254, 28);
            this.trit.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(68, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 60;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1223, 333);
            this.dataGridView1.TabIndex = 6;
            // 
            // crctrit
            // 
            this.crctrit.Location = new System.Drawing.Point(161, 528);
            this.crctrit.Name = "crctrit";
            this.crctrit.Size = new System.Drawing.Size(166, 28);
            this.crctrit.TabIndex = 7;
            this.crctrit.Text = "x^3-x^2+1";
            // 
            // crctest
            // 
            this.crctest.Location = new System.Drawing.Point(348, 611);
            this.crctest.Name = "crctest";
            this.crctest.Size = new System.Drawing.Size(100, 50);
            this.crctest.TabIndex = 10;
            this.crctest.Text = "crctest";
            this.crctest.UseVisualStyleBackColor = true;
            this.crctest.Click += new System.EventHandler(this.crctest_Click);
            // 
            // tbtrue
            // 
            this.tbtrue.Location = new System.Drawing.Point(717, 566);
            this.tbtrue.Name = "tbtrue";
            this.tbtrue.Size = new System.Drawing.Size(100, 28);
            this.tbtrue.TabIndex = 12;
            // 
            // tbfalse
            // 
            this.tbfalse.Location = new System.Drawing.Point(717, 624);
            this.tbfalse.Name = "tbfalse";
            this.tbfalse.Size = new System.Drawing.Size(100, 28);
            this.tbfalse.TabIndex = 13;
            // 
            // chart
            // 
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(905, 400);
            this.chart.Name = "chart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series2";
            this.chart.Series.Add(series3);
            this.chart.Series.Add(series4);
            this.chart.Size = new System.Drawing.Size(466, 300);
            this.chart.TabIndex = 14;
            this.chart.Text = "chart";
            // 
            // run
            // 
            this.run.Location = new System.Drawing.Point(348, 675);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(100, 50);
            this.run.TabIndex = 15;
            this.run.Text = "run";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // trueCount
            // 
            this.trueCount.AutoSize = true;
            this.trueCount.Location = new System.Drawing.Point(598, 576);
            this.trueCount.Name = "trueCount";
            this.trueCount.Size = new System.Drawing.Size(89, 18);
            this.trueCount.TabIndex = 16;
            this.trueCount.Text = "trueCount";
            // 
            // falseCount
            // 
            this.falseCount.AutoSize = true;
            this.falseCount.Location = new System.Drawing.Point(601, 627);
            this.falseCount.Name = "falseCount";
            this.falseCount.Size = new System.Drawing.Size(98, 18);
            this.falseCount.TabIndex = 17;
            this.falseCount.Text = "falseCount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 531);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "CRC-3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(476, 479);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "Random word";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1481, 768);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.falseCount);
            this.Controls.Add(this.trueCount);
            this.Controls.Add(this.run);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.tbfalse);
            this.Controls.Add(this.tbtrue);
            this.Controls.Add(this.crctest);
            this.Controls.Add(this.crctrit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.trit);
            this.Controls.Add(this.RandomError);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tritCount);
            this.Controls.Add(this.Random);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Random;
        private System.Windows.Forms.TextBox tritCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RandomError;
        private System.Windows.Forms.TextBox trit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox crctrit;
        private System.Windows.Forms.Button crctest;
        private System.Windows.Forms.TextBox tbtrue;
        private System.Windows.Forms.TextBox tbfalse;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Label trueCount;
        private System.Windows.Forms.Label falseCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

