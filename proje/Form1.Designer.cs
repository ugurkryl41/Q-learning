
namespace proje
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grid1 = new FlexCell.Grid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_iterasyon = new System.Windows.Forms.Label();
            this.tbx_iterasyon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.tbx_ajanhedefkonum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_ajankonum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.CheckedImage = null;
            this.grid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.grid1.Location = new System.Drawing.Point(12, 12);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(840, 643);
            this.grid1.TabIndex = 0;
            this.grid1.UncheckedImage = null;
            this.grid1.Visible = false;
            this.grid1.Click += new FlexCell.Grid.ClickEventHandler(this.grid1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_iterasyon);
            this.groupBox1.Controls.Add(this.tbx_iterasyon);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_exit);
            this.groupBox1.Controls.Add(this.btn_reset);
            this.groupBox1.Controls.Add(this.btn_start);
            this.groupBox1.Controls.Add(this.tbx_ajanhedefkonum);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbx_ajankonum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(977, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 111);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ajan Bilgisi";
            // 
            // lbl_iterasyon
            // 
            this.lbl_iterasyon.AutoSize = true;
            this.lbl_iterasyon.Location = new System.Drawing.Point(445, 27);
            this.lbl_iterasyon.Name = "lbl_iterasyon";
            this.lbl_iterasyon.Size = new System.Drawing.Size(31, 13);
            this.lbl_iterasyon.TabIndex = 3;
            this.lbl_iterasyon.Text = "1000";
            // 
            // tbx_iterasyon
            // 
            this.tbx_iterasyon.Location = new System.Drawing.Point(326, 24);
            this.tbx_iterasyon.Name = "tbx_iterasyon";
            this.tbx_iterasyon.Size = new System.Drawing.Size(100, 20);
            this.tbx_iterasyon.TabIndex = 8;
            this.tbx_iterasyon.Text = "1000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "İterasyon Sayısı:";
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(431, 64);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 6;
            this.btn_exit.Text = "Çıkış";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(337, 64);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_reset.TabIndex = 5;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(240, 64);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 4;
            this.btn_start.Text = "Başla";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // tbx_ajanhedefkonum
            // 
            this.tbx_ajanhedefkonum.Enabled = false;
            this.tbx_ajanhedefkonum.Location = new System.Drawing.Point(115, 67);
            this.tbx_ajanhedefkonum.Name = "tbx_ajanhedefkonum";
            this.tbx_ajanhedefkonum.Size = new System.Drawing.Size(68, 20);
            this.tbx_ajanhedefkonum.TabIndex = 3;
            this.tbx_ajanhedefkonum.Text = "0,0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ajan Hedef Konum :";
            // 
            // tbx_ajankonum
            // 
            this.tbx_ajankonum.Enabled = false;
            this.tbx_ajankonum.Location = new System.Drawing.Point(115, 28);
            this.tbx_ajankonum.Name = "tbx_ajankonum";
            this.tbx_ajankonum.Size = new System.Drawing.Size(68, 20);
            this.tbx_ajankonum.TabIndex = 1;
            this.tbx_ajankonum.Text = "0,0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ajan Konum :";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(1014, 145);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "episode via steps";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(469, 243);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(1014, 428);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "episode via cost";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(469, 227);
            this.chart2.TabIndex = 3;
            this.chart2.Text = "chart2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1602, 856);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FlexCell.Grid grid1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox tbx_ajanhedefkonum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_ajankonum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.TextBox tbx_iterasyon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lbl_iterasyon;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}

