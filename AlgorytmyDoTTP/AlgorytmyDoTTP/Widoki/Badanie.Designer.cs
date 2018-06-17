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
            this.zapiszBadanie = new MetroFramework.Controls.MetroButton();
            this.pobierzCSV = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.wynikiBadania = new System.Windows.Forms.TextBox();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.zapiszBadanie);
            this.metroPanel1.Controls.Add(this.pobierzCSV);
            this.metroPanel1.Controls.Add(this.label1);
            this.metroPanel1.Controls.Add(this.wynikiBadania);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(1, 0);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1041, 476);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 11;
            // 
            // zapiszBadanie
            // 
            this.zapiszBadanie.Location = new System.Drawing.Point(707, 75);
            this.zapiszBadanie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zapiszBadanie.Name = "zapiszBadanie";
            this.zapiszBadanie.Size = new System.Drawing.Size(147, 28);
            this.zapiszBadanie.TabIndex = 5;
            this.zapiszBadanie.Text = "Zapisz Badanie";
            this.zapiszBadanie.UseSelectable = true;
            this.zapiszBadanie.Click += new System.EventHandler(this.zapiszBadanie_Click);
            // 
            // pobierzCSV
            // 
            this.pobierzCSV.Location = new System.Drawing.Point(876, 75);
            this.pobierzCSV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pobierzCSV.Name = "pobierzCSV";
            this.pobierzCSV.Size = new System.Drawing.Size(147, 28);
            this.pobierzCSV.TabIndex = 4;
            this.pobierzCSV.Text = "Pobierz plik CSV";
            this.pobierzCSV.UseSelectable = true;
            this.pobierzCSV.Click += new System.EventHandler(this.pobierzCSV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(11, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 38);
            this.label1.TabIndex = 3;
            this.label1.Text = "Wyniki";
            // 
            // wynikiBadania
            // 
            this.wynikiBadania.Location = new System.Drawing.Point(11, 108);
            this.wynikiBadania.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wynikiBadania.Multiline = true;
            this.wynikiBadania.Name = "wynikiBadania";
            this.wynikiBadania.ReadOnly = true;
            this.wynikiBadania.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.wynikiBadania.Size = new System.Drawing.Size(1016, 354);
            this.wynikiBadania.TabIndex = 2;
            // 
            // Badanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 463);
            this.Controls.Add(this.metroPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1055, 510);
            this.MinimumSize = new System.Drawing.Size(1055, 510);
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
        private MetroFramework.Controls.MetroButton zapiszBadanie;
    }
}