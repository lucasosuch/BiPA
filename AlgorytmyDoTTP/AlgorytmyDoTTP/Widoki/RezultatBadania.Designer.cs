namespace AlgorytmyDoTTP.Widoki
{
    partial class RezultatBadania
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
            this.min = new System.Windows.Forms.TabPage();
            this.max = new System.Windows.Forms.TabPage();
            this.podsumowanie = new System.Windows.Forms.TabPage();
            this.srednia = new System.Windows.Forms.TabPage();
            this.metroTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.srednia);
            this.metroTabControl1.Controls.Add(this.min);
            this.metroTabControl1.Controls.Add(this.max);
            this.metroTabControl1.Controls.Add(this.podsumowanie);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(0, 0);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(830, 516);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // min
            // 
            this.min.Location = new System.Drawing.Point(4, 38);
            this.min.Name = "min";
            this.min.Size = new System.Drawing.Size(822, 474);
            this.min.TabIndex = 1;
            this.min.Text = "Minimalne wyniki";
            // 
            // max
            // 
            this.max.Location = new System.Drawing.Point(4, 38);
            this.max.Name = "max";
            this.max.Size = new System.Drawing.Size(822, 474);
            this.max.TabIndex = 2;
            this.max.Text = "Maksymalne wyniki";
            // 
            // podsumowanie
            // 
            this.podsumowanie.Location = new System.Drawing.Point(4, 38);
            this.podsumowanie.Name = "podsumowanie";
            this.podsumowanie.Size = new System.Drawing.Size(822, 474);
            this.podsumowanie.TabIndex = 3;
            this.podsumowanie.Text = "Podsumowanie badania";
            // 
            // srednia
            // 
            this.srednia.Location = new System.Drawing.Point(4, 38);
            this.srednia.Name = "srednia";
            this.srednia.Size = new System.Drawing.Size(822, 474);
            this.srednia.TabIndex = 0;
            this.srednia.Text = "Średnie wyniki";
            // 
            // RezultatBadania
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 516);
            this.Controls.Add(this.metroTabControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RezultatBadania";
            this.Text = "RezultatBadania";
            this.metroTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private System.Windows.Forms.TabPage srednia;
        private System.Windows.Forms.TabPage min;
        private System.Windows.Forms.TabPage max;
        private System.Windows.Forms.TabPage podsumowanie;
    }
}