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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel2 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.wykresPorownan = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wykresPorownan)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.label1);
            this.metroPanel1.Controls.Add(this.wykresPorownan);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, -2);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(778, 378);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(9, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Wyniki Porównania";
            // 
            // wykresPorownan
            // 
            customLabel1.FromPosition = 0.7D;
            customLabel1.Text = "Czas";
            customLabel1.ToPosition = 1.3D;
            customLabel2.FromPosition = 1.7D;
            customLabel2.Text = "Wynik";
            customLabel2.ToPosition = 2.3D;
            chartArea1.AxisX.CustomLabels.Add(customLabel1);
            chartArea1.AxisX.CustomLabels.Add(customLabel2);
            chartArea1.Name = "ChartArea1";
            this.wykresPorownan.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.Title = "Algorytmy";
            this.wykresPorownan.Legends.Add(legend1);
            this.wykresPorownan.Location = new System.Drawing.Point(14, 104);
            this.wykresPorownan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.wykresPorownan.Name = "wykresPorownan";
            this.wykresPorownan.Size = new System.Drawing.Size(750, 264);
            this.wykresPorownan.TabIndex = 2;
            this.wykresPorownan.Text = "Porównanie Algorytmów";
            // 
            // Porownanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 383);
            this.Controls.Add(this.metroPanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(795, 422);
            this.MinimumSize = new System.Drawing.Size(795, 422);
            this.Name = "Porownanie";
            this.Text = "Porównanie";
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wykresPorownan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart wykresPorownan;
        private System.Windows.Forms.Label label1;
    }
}