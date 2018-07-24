namespace AlgorytmyDoTTP.Widoki
{
    partial class Porownanie
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel2 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.wykresPorownanCzas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.wykresPorownanWynik = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wykresPorownanCzas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wykresPorownanWynik)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.wykresPorownanWynik, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.wykresPorownanCzas, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1036, 778);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // wykresPorownanCzas
            // 
            customLabel2.FromPosition = 0.7D;
            customLabel2.Text = "Czas";
            customLabel2.ToPosition = 1.3D;
            chartArea2.AxisX.CustomLabels.Add(customLabel2);
            chartArea2.Name = "ChartArea1";
            this.wykresPorownanCzas.ChartAreas.Add(chartArea2);
            this.wykresPorownanCzas.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            legend2.Title = "Algorytmy";
            this.wykresPorownanCzas.Legends.Add(legend2);
            this.wykresPorownanCzas.Location = new System.Drawing.Point(3, 429);
            this.wykresPorownanCzas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wykresPorownanCzas.Name = "wykresPorownanCzas";
            this.wykresPorownanCzas.Size = new System.Drawing.Size(1030, 347);
            this.wykresPorownanCzas.TabIndex = 2;
            this.wykresPorownanCzas.Text = "Porównanie Algorytmów";
            // 
            // wykresPorownanWynik
            // 
            customLabel1.FromPosition = 0.7D;
            customLabel1.Text = "Wynik";
            customLabel1.ToPosition = 1.3D;
            chartArea1.AxisX.CustomLabels.Add(customLabel1);
            chartArea1.Name = "ChartArea1";
            this.wykresPorownanWynik.ChartAreas.Add(chartArea1);
            this.wykresPorownanWynik.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            legend1.Title = "Algorytmy";
            this.wykresPorownanWynik.Legends.Add(legend1);
            this.wykresPorownanWynik.Location = new System.Drawing.Point(3, 79);
            this.wykresPorownanWynik.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wykresPorownanWynik.Name = "wykresPorownanWynik";
            this.wykresPorownanWynik.Size = new System.Drawing.Size(1030, 346);
            this.wykresPorownanWynik.TabIndex = 4;
            this.wykresPorownanWynik.Text = "Porównanie Algorytmów";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 38);
            this.label1.TabIndex = 3;
            this.label1.Text = "Wyniki Porównania";
            // 
            // Porownanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 778);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Porownanie";
            this.Text = "Porównanie";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wykresPorownanCzas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wykresPorownanWynik)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart wykresPorownanWynik;
        private System.Windows.Forms.DataVisualization.Charting.Chart wykresPorownanCzas;
        private System.Windows.Forms.Label label1;
    }
}