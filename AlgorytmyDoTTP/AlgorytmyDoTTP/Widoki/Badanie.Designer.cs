namespace AlgorytmyDoTTP.Widoki
{
    partial class Badanie
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.wynikiBadania = new System.Windows.Forms.TextBox();
            this.pobierzCSV = new MetroFramework.Controls.MetroButton();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.pobierzCSV);
            this.metroPanel1.Controls.Add(this.label1);
            this.metroPanel1.Controls.Add(this.wynikiBadania);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 8;
            this.metroPanel1.Location = new System.Drawing.Point(1, 0);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(781, 387);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Wyniki";
            // 
            // wynikiBadania
            // 
            this.wynikiBadania.Location = new System.Drawing.Point(8, 88);
            this.wynikiBadania.Margin = new System.Windows.Forms.Padding(2);
            this.wynikiBadania.Multiline = true;
            this.wynikiBadania.Name = "wynikiBadania";
            this.wynikiBadania.ReadOnly = true;
            this.wynikiBadania.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.wynikiBadania.Size = new System.Drawing.Size(763, 288);
            this.wynikiBadania.TabIndex = 2;
            // 
            // pobierzCSV
            // 
            this.pobierzCSV.Location = new System.Drawing.Point(657, 61);
            this.pobierzCSV.Name = "pobierzCSV";
            this.pobierzCSV.Size = new System.Drawing.Size(110, 23);
            this.pobierzCSV.TabIndex = 4;
            this.pobierzCSV.Text = "Pobierz plik CSV";
            this.pobierzCSV.UseSelectable = true;
            this.pobierzCSV.Click += new System.EventHandler(this.pobierzCSV_Click);
            // 
            // Badanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 385);
            this.Controls.Add(this.metroPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(796, 424);
            this.MinimumSize = new System.Drawing.Size(796, 424);
            this.Name = "Badanie";
            this.Text = "Badanie";
            this.Load += new System.EventHandler(this.Badanie_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox wynikiBadania;
        private MetroFramework.Controls.MetroButton pobierzCSV;
    }
}