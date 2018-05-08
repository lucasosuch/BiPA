using AlgorytmyDoTTP.Struktura;

namespace AlgorytmyDoTTP
{
    partial class Glowna
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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.badanie = new MetroFramework.Controls.MetroTabPage();
            this.historia = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel1.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroTabControl1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(12, 12);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(886, 527);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.badanie);
            this.metroTabControl1.Controls.Add(this.historia);
            this.metroTabControl1.Location = new System.Drawing.Point(0, 0);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(886, 527);
            this.metroTabControl1.TabIndex = 2;
            this.metroTabControl1.UseSelectable = true;
            // 
            // badanie
            // 
            this.badanie.HorizontalScrollbarBarColor = true;
            this.badanie.HorizontalScrollbarHighlightOnWheel = false;
            this.badanie.HorizontalScrollbarSize = 10;
            this.badanie.Location = new System.Drawing.Point(4, 38);
            this.badanie.Name = "badanie";
            this.badanie.Size = new System.Drawing.Size(878, 485);
            this.badanie.TabIndex = 0;
            this.badanie.Text = "Badanie Algorytmu";
            this.badanie.VerticalScrollbarBarColor = true;
            this.badanie.VerticalScrollbarHighlightOnWheel = false;
            this.badanie.VerticalScrollbarSize = 10;
            // 
            // historia
            // 
            this.historia.HorizontalScrollbarBarColor = true;
            this.historia.HorizontalScrollbarHighlightOnWheel = false;
            this.historia.HorizontalScrollbarSize = 10;
            this.historia.Location = new System.Drawing.Point(4, 38);
            this.historia.Name = "historia";
            this.historia.Size = new System.Drawing.Size(878, 485);
            this.historia.TabIndex = 1;
            this.historia.Text = "Historia Badań";
            this.historia.VerticalScrollbarBarColor = true;
            this.historia.VerticalScrollbarHighlightOnWheel = false;
            this.historia.VerticalScrollbarSize = 10;
            // 
            // Glowna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(910, 551);
            this.Controls.Add(this.metroPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Glowna";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Glowna";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage badanie;
        private MetroFramework.Controls.MetroTabPage historia;
    }
}

