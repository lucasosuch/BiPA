namespace AlgorytmyDoTTP.Widoki
{
    partial class StronaWynikow
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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.srednia = new MetroFramework.Controls.MetroTabPage();
            this.wykresSrednia = new System.Windows.Forms.PictureBox();
            this.max = new MetroFramework.Controls.MetroTabPage();
            this.wykresMin = new System.Windows.Forms.PictureBox();
            this.min = new MetroFramework.Controls.MetroTabPage();
            this.wykresMax = new System.Windows.Forms.PictureBox();
            this.podsumowanie = new MetroFramework.Controls.MetroTabPage();
            this.wynikiBadnia = new System.Windows.Forms.TextBox();
            this.metroTabControl1.SuspendLayout();
            this.srednia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wykresSrednia)).BeginInit();
            this.max.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wykresMin)).BeginInit();
            this.min.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wykresMax)).BeginInit();
            this.podsumowanie.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.srednia);
            this.metroTabControl1.Controls.Add(this.max);
            this.metroTabControl1.Controls.Add(this.min);
            this.metroTabControl1.Controls.Add(this.podsumowanie);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(0, 0);
            this.metroTabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(1107, 635);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // srednia
            // 
            this.srednia.Controls.Add(this.wykresSrednia);
            this.srednia.HorizontalScrollbarBarColor = true;
            this.srednia.HorizontalScrollbarHighlightOnWheel = false;
            this.srednia.HorizontalScrollbarSize = 12;
            this.srednia.Location = new System.Drawing.Point(4, 38);
            this.srednia.Margin = new System.Windows.Forms.Padding(4);
            this.srednia.Name = "srednia";
            this.srednia.Size = new System.Drawing.Size(1099, 593);
            this.srednia.TabIndex = 0;
            this.srednia.Text = "Średnie wartości z badania";
            this.srednia.VerticalScrollbarBarColor = true;
            this.srednia.VerticalScrollbarHighlightOnWheel = false;
            this.srednia.VerticalScrollbarSize = 13;
            // 
            // wykresSrednia
            // 
            this.wykresSrednia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wykresSrednia.Location = new System.Drawing.Point(0, 0);
            this.wykresSrednia.Margin = new System.Windows.Forms.Padding(4);
            this.wykresSrednia.Name = "wykresSrednia";
            this.wykresSrednia.Size = new System.Drawing.Size(1099, 593);
            this.wykresSrednia.TabIndex = 2;
            this.wykresSrednia.TabStop = false;
            // 
            // max
            // 
            this.max.Controls.Add(this.wykresMin);
            this.max.HorizontalScrollbarBarColor = true;
            this.max.HorizontalScrollbarHighlightOnWheel = false;
            this.max.HorizontalScrollbarSize = 12;
            this.max.Location = new System.Drawing.Point(4, 38);
            this.max.Margin = new System.Windows.Forms.Padding(4);
            this.max.Name = "max";
            this.max.Size = new System.Drawing.Size(1099, 593);
            this.max.TabIndex = 1;
            this.max.Text = "Maksymalne wartości z badania";
            this.max.VerticalScrollbarBarColor = true;
            this.max.VerticalScrollbarHighlightOnWheel = false;
            this.max.VerticalScrollbarSize = 13;
            // 
            // wykresMin
            // 
            this.wykresMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wykresMin.Location = new System.Drawing.Point(0, 0);
            this.wykresMin.Margin = new System.Windows.Forms.Padding(4);
            this.wykresMin.Name = "wykresMin";
            this.wykresMin.Size = new System.Drawing.Size(1099, 593);
            this.wykresMin.TabIndex = 3;
            this.wykresMin.TabStop = false;
            // 
            // min
            // 
            this.min.Controls.Add(this.wykresMax);
            this.min.HorizontalScrollbarBarColor = true;
            this.min.HorizontalScrollbarHighlightOnWheel = false;
            this.min.HorizontalScrollbarSize = 12;
            this.min.Location = new System.Drawing.Point(4, 38);
            this.min.Margin = new System.Windows.Forms.Padding(4);
            this.min.Name = "min";
            this.min.Size = new System.Drawing.Size(1099, 593);
            this.min.TabIndex = 2;
            this.min.Text = "Minimalne wartości z badania";
            this.min.VerticalScrollbarBarColor = true;
            this.min.VerticalScrollbarHighlightOnWheel = false;
            this.min.VerticalScrollbarSize = 13;
            // 
            // wykresMax
            // 
            this.wykresMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wykresMax.Location = new System.Drawing.Point(0, 0);
            this.wykresMax.Margin = new System.Windows.Forms.Padding(4);
            this.wykresMax.Name = "wykresMax";
            this.wykresMax.Size = new System.Drawing.Size(1099, 593);
            this.wykresMax.TabIndex = 3;
            this.wykresMax.TabStop = false;
            // 
            // podsumowanie
            // 
            this.podsumowanie.Controls.Add(this.wynikiBadnia);
            this.podsumowanie.HorizontalScrollbarBarColor = true;
            this.podsumowanie.HorizontalScrollbarHighlightOnWheel = false;
            this.podsumowanie.HorizontalScrollbarSize = 12;
            this.podsumowanie.Location = new System.Drawing.Point(4, 38);
            this.podsumowanie.Margin = new System.Windows.Forms.Padding(4);
            this.podsumowanie.Name = "podsumowanie";
            this.podsumowanie.Size = new System.Drawing.Size(1099, 593);
            this.podsumowanie.TabIndex = 3;
            this.podsumowanie.Text = "Podsumowanie badania";
            this.podsumowanie.VerticalScrollbarBarColor = true;
            this.podsumowanie.VerticalScrollbarHighlightOnWheel = false;
            this.podsumowanie.VerticalScrollbarSize = 13;
            // 
            // wynikiBadnia
            // 
            this.wynikiBadnia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wynikiBadnia.Location = new System.Drawing.Point(0, 0);
            this.wynikiBadnia.Margin = new System.Windows.Forms.Padding(4);
            this.wynikiBadnia.Multiline = true;
            this.wynikiBadnia.Name = "wynikiBadnia";
            this.wynikiBadnia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.wynikiBadnia.Size = new System.Drawing.Size(1099, 593);
            this.wynikiBadnia.TabIndex = 2;
            // 
            // RezultatBadania
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 635);
            this.Controls.Add(this.metroTabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RezultatBadania";
            this.Text = "RezultatBadania";
            this.metroTabControl1.ResumeLayout(false);
            this.srednia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wykresSrednia)).EndInit();
            this.max.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wykresMin)).EndInit();
            this.min.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wykresMax)).EndInit();
            this.podsumowanie.ResumeLayout(false);
            this.podsumowanie.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage srednia;
        private System.Windows.Forms.PictureBox wykresSrednia;
        private MetroFramework.Controls.MetroTabPage max;
        private System.Windows.Forms.PictureBox wykresMin;
        private MetroFramework.Controls.MetroTabPage min;
        private System.Windows.Forms.PictureBox wykresMax;
        private MetroFramework.Controls.MetroTabPage podsumowanie;
        private System.Windows.Forms.TextBox wynikiBadnia;
    }
}