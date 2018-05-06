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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.kartaAlgorytmu = new System.Windows.Forms.TabPage();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.kartaProblemu = new System.Windows.Forms.TabPage();
            this.metroComboBox2 = new MetroFramework.Controls.MetroComboBox();
            this.kartaStopu = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.kartaAlgorytmu.SuspendLayout();
            this.kartaProblemu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.kartaAlgorytmu);
            this.tabControl1.Controls.Add(this.kartaProblemu);
            this.tabControl1.Controls.Add(this.kartaStopu);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(885, 445);
            this.tabControl1.TabIndex = 0;
            // 
            // kartaAlgorytmu
            // 
            this.kartaAlgorytmu.Controls.Add(this.metroComboBox1);
            this.kartaAlgorytmu.Location = new System.Drawing.Point(4, 22);
            this.kartaAlgorytmu.Name = "kartaAlgorytmu";
            this.kartaAlgorytmu.Padding = new System.Windows.Forms.Padding(3);
            this.kartaAlgorytmu.Size = new System.Drawing.Size(877, 419);
            this.kartaAlgorytmu.TabIndex = 0;
            this.kartaAlgorytmu.Text = "Konfiguracja Algorytmu";
            this.kartaAlgorytmu.UseVisualStyleBackColor = true;
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Location = new System.Drawing.Point(6, 6);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(200, 29);
            this.metroComboBox1.TabIndex = 0;
            this.metroComboBox1.UseSelectable = true;
            // 
            // kartaProblemu
            // 
            this.kartaProblemu.Controls.Add(this.metroComboBox2);
            this.kartaProblemu.Location = new System.Drawing.Point(4, 22);
            this.kartaProblemu.Name = "kartaProblemu";
            this.kartaProblemu.Padding = new System.Windows.Forms.Padding(3);
            this.kartaProblemu.Size = new System.Drawing.Size(877, 419);
            this.kartaProblemu.TabIndex = 1;
            this.kartaProblemu.Text = "Konfiguracja Problemu Optymalizacyjnego";
            this.kartaProblemu.UseVisualStyleBackColor = true;
            // 
            // metroComboBox2
            // 
            this.metroComboBox2.FormattingEnabled = true;
            this.metroComboBox2.ItemHeight = 23;
            this.metroComboBox2.Location = new System.Drawing.Point(6, 6);
            this.metroComboBox2.Name = "metroComboBox2";
            this.metroComboBox2.Size = new System.Drawing.Size(200, 29);
            this.metroComboBox2.TabIndex = 0;
            this.metroComboBox2.UseSelectable = true;
            // 
            // kartaStopu
            // 
            this.kartaStopu.Location = new System.Drawing.Point(4, 22);
            this.kartaStopu.Name = "kartaStopu";
            this.kartaStopu.Size = new System.Drawing.Size(877, 419);
            this.kartaStopu.TabIndex = 2;
            this.kartaStopu.Text = "Konfiguracja Warunku STOP-u";
            this.kartaStopu.UseVisualStyleBackColor = true;
            // 
            // Glowna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(910, 551);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Glowna";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Glowna";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.kartaAlgorytmu.ResumeLayout(false);
            this.kartaProblemu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage kartaAlgorytmu;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private System.Windows.Forms.TabPage kartaProblemu;
        private MetroFramework.Controls.MetroComboBox metroComboBox2;
        private System.Windows.Forms.TabPage kartaStopu;
    }
}

