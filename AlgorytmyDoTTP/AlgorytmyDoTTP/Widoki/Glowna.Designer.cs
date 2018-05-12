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
            this.ewolucyjny = new MetroFramework.Controls.MetroPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.pwoKrzyzowania = new MetroFramework.Controls.MetroTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pwoMutacji = new MetroFramework.Controls.MetroTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rozmiarPopulacji = new MetroFramework.Controls.MetroTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.iloscPokolen = new MetroFramework.Controls.MetroTextBox();
            this.start = new MetroFramework.Controls.MetroTile();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.wyborAlgorytmu = new MetroFramework.Controls.MetroComboBox();
            this.historia = new MetroFramework.Controls.MetroTabPage();
            this.domyslny = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.wybierzProblem = new MetroFramework.Controls.MetroComboBox();
            this.metroPanel1.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.badanie.SuspendLayout();
            this.ewolucyjny.SuspendLayout();
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
            this.badanie.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.badanie.Controls.Add(this.label7);
            this.badanie.Controls.Add(this.wybierzProblem);
            this.badanie.Controls.Add(this.ewolucyjny);
            this.badanie.Controls.Add(this.start);
            this.badanie.Controls.Add(this.label6);
            this.badanie.Controls.Add(this.label1);
            this.badanie.Controls.Add(this.wyborAlgorytmu);
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
            // ewolucyjny
            // 
            this.ewolucyjny.Controls.Add(this.domyslny);
            this.ewolucyjny.Controls.Add(this.label4);
            this.ewolucyjny.Controls.Add(this.pwoKrzyzowania);
            this.ewolucyjny.Controls.Add(this.label5);
            this.ewolucyjny.Controls.Add(this.pwoMutacji);
            this.ewolucyjny.Controls.Add(this.label3);
            this.ewolucyjny.Controls.Add(this.rozmiarPopulacji);
            this.ewolucyjny.Controls.Add(this.label2);
            this.ewolucyjny.Controls.Add(this.iloscPokolen);
            this.ewolucyjny.HorizontalScrollbarBarColor = true;
            this.ewolucyjny.HorizontalScrollbarHighlightOnWheel = false;
            this.ewolucyjny.HorizontalScrollbarSize = 10;
            this.ewolucyjny.Location = new System.Drawing.Point(46, 138);
            this.ewolucyjny.Name = "ewolucyjny";
            this.ewolucyjny.Size = new System.Drawing.Size(829, 280);
            this.ewolucyjny.TabIndex = 13;
            this.ewolucyjny.VerticalScrollbarBarColor = true;
            this.ewolucyjny.VerticalScrollbarHighlightOnWheel = false;
            this.ewolucyjny.VerticalScrollbarSize = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(479, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Prawdopodobieństwo krzyżowania";
            // 
            // pwoKrzyzowania
            // 
            // 
            // 
            // 
            this.pwoKrzyzowania.CustomButton.Image = null;
            this.pwoKrzyzowania.CustomButton.Location = new System.Drawing.Point(232, 2);
            this.pwoKrzyzowania.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.pwoKrzyzowania.CustomButton.Name = "";
            this.pwoKrzyzowania.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.pwoKrzyzowania.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.pwoKrzyzowania.CustomButton.TabIndex = 1;
            this.pwoKrzyzowania.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.pwoKrzyzowania.CustomButton.UseSelectable = true;
            this.pwoKrzyzowania.CustomButton.Visible = false;
            this.pwoKrzyzowania.Lines = new string[] {
        "0,7"};
            this.pwoKrzyzowania.Location = new System.Drawing.Point(481, 79);
            this.pwoKrzyzowania.Margin = new System.Windows.Forms.Padding(2);
            this.pwoKrzyzowania.MaxLength = 32767;
            this.pwoKrzyzowania.Name = "pwoKrzyzowania";
            this.pwoKrzyzowania.PasswordChar = '\0';
            this.pwoKrzyzowania.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.pwoKrzyzowania.SelectedText = "";
            this.pwoKrzyzowania.SelectionLength = 0;
            this.pwoKrzyzowania.SelectionStart = 0;
            this.pwoKrzyzowania.ShortcutsEnabled = true;
            this.pwoKrzyzowania.Size = new System.Drawing.Size(250, 20);
            this.pwoKrzyzowania.TabIndex = 22;
            this.pwoKrzyzowania.Text = "0,7";
            this.pwoKrzyzowania.UseSelectable = true;
            this.pwoKrzyzowania.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.pwoKrzyzowania.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(479, 125);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Prawdopodobieństwo mutacji";
            // 
            // pwoMutacji
            // 
            // 
            // 
            // 
            this.pwoMutacji.CustomButton.Image = null;
            this.pwoMutacji.CustomButton.Location = new System.Drawing.Point(232, 2);
            this.pwoMutacji.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.pwoMutacji.CustomButton.Name = "";
            this.pwoMutacji.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.pwoMutacji.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.pwoMutacji.CustomButton.TabIndex = 1;
            this.pwoMutacji.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.pwoMutacji.CustomButton.UseSelectable = true;
            this.pwoMutacji.CustomButton.Visible = false;
            this.pwoMutacji.Lines = new string[] {
        "0,1"};
            this.pwoMutacji.Location = new System.Drawing.Point(481, 141);
            this.pwoMutacji.Margin = new System.Windows.Forms.Padding(2);
            this.pwoMutacji.MaxLength = 32767;
            this.pwoMutacji.Name = "pwoMutacji";
            this.pwoMutacji.PasswordChar = '\0';
            this.pwoMutacji.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.pwoMutacji.SelectedText = "";
            this.pwoMutacji.SelectionLength = 0;
            this.pwoMutacji.SelectionStart = 0;
            this.pwoMutacji.ShortcutsEnabled = true;
            this.pwoMutacji.Size = new System.Drawing.Size(250, 20);
            this.pwoMutacji.TabIndex = 23;
            this.pwoMutacji.Text = "0,1";
            this.pwoMutacji.UseSelectable = true;
            this.pwoMutacji.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.pwoMutacji.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Rozmiar populacji";
            // 
            // rozmiarPopulacji
            // 
            // 
            // 
            // 
            this.rozmiarPopulacji.CustomButton.Image = null;
            this.rozmiarPopulacji.CustomButton.Location = new System.Drawing.Point(232, 2);
            this.rozmiarPopulacji.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.rozmiarPopulacji.CustomButton.Name = "";
            this.rozmiarPopulacji.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.rozmiarPopulacji.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.rozmiarPopulacji.CustomButton.TabIndex = 1;
            this.rozmiarPopulacji.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.rozmiarPopulacji.CustomButton.UseSelectable = true;
            this.rozmiarPopulacji.CustomButton.Visible = false;
            this.rozmiarPopulacji.Lines = new string[] {
        "100"};
            this.rozmiarPopulacji.Location = new System.Drawing.Point(2, 79);
            this.rozmiarPopulacji.Margin = new System.Windows.Forms.Padding(2);
            this.rozmiarPopulacji.MaxLength = 32767;
            this.rozmiarPopulacji.Name = "rozmiarPopulacji";
            this.rozmiarPopulacji.PasswordChar = '\0';
            this.rozmiarPopulacji.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.rozmiarPopulacji.SelectedText = "";
            this.rozmiarPopulacji.SelectionLength = 0;
            this.rozmiarPopulacji.SelectionStart = 0;
            this.rozmiarPopulacji.ShortcutsEnabled = true;
            this.rozmiarPopulacji.Size = new System.Drawing.Size(250, 20);
            this.rozmiarPopulacji.TabIndex = 20;
            this.rozmiarPopulacji.Text = "100";
            this.rozmiarPopulacji.UseSelectable = true;
            this.rozmiarPopulacji.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.rozmiarPopulacji.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 125);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Ilość pokoleń";
            // 
            // iloscPokolen
            // 
            // 
            // 
            // 
            this.iloscPokolen.CustomButton.Image = null;
            this.iloscPokolen.CustomButton.Location = new System.Drawing.Point(232, 2);
            this.iloscPokolen.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.iloscPokolen.CustomButton.Name = "";
            this.iloscPokolen.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.iloscPokolen.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.iloscPokolen.CustomButton.TabIndex = 1;
            this.iloscPokolen.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.iloscPokolen.CustomButton.UseSelectable = true;
            this.iloscPokolen.CustomButton.Visible = false;
            this.iloscPokolen.Lines = new string[] {
        "70"};
            this.iloscPokolen.Location = new System.Drawing.Point(2, 141);
            this.iloscPokolen.Margin = new System.Windows.Forms.Padding(2);
            this.iloscPokolen.MaxLength = 32767;
            this.iloscPokolen.Name = "iloscPokolen";
            this.iloscPokolen.PasswordChar = '\0';
            this.iloscPokolen.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.iloscPokolen.SelectedText = "";
            this.iloscPokolen.SelectionLength = 0;
            this.iloscPokolen.SelectionStart = 0;
            this.iloscPokolen.ShortcutsEnabled = true;
            this.iloscPokolen.Size = new System.Drawing.Size(250, 20);
            this.iloscPokolen.TabIndex = 21;
            this.iloscPokolen.Text = "70";
            this.iloscPokolen.UseSelectable = true;
            this.iloscPokolen.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.iloscPokolen.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // start
            // 
            this.start.ActiveControl = null;
            this.start.Location = new System.Drawing.Point(677, 430);
            this.start.Margin = new System.Windows.Forms.Padding(2);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(198, 60);
            this.start.TabIndex = 6;
            this.start.Text = "Uruchom";
            this.start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.start.UseSelectable = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Wybierz Algorytm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(41, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Konfiguracja Algorytmu";
            // 
            // wyborAlgorytmu
            // 
            this.wyborAlgorytmu.FormattingEnabled = true;
            this.wyborAlgorytmu.ItemHeight = 23;
            this.wyborAlgorytmu.Items.AddRange(new object[] {
            "Ewolucyjny"});
            this.wyborAlgorytmu.Location = new System.Drawing.Point(46, 87);
            this.wyborAlgorytmu.Margin = new System.Windows.Forms.Padding(2);
            this.wyborAlgorytmu.Name = "wyborAlgorytmu";
            this.wyborAlgorytmu.Size = new System.Drawing.Size(251, 29);
            this.wyborAlgorytmu.TabIndex = 1;
            this.wyborAlgorytmu.UseSelectable = true;
            this.wyborAlgorytmu.SelectionChangeCommitted += new System.EventHandler(this.wyborAlgorytmu_SelectedIndexChanged);
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
            // domyslny
            // 
            this.domyslny.Location = new System.Drawing.Point(0, 0);
            this.domyslny.Name = "domyslny";
            this.domyslny.Size = new System.Drawing.Size(829, 280);
            this.domyslny.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(623, 68);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Wybierz Problem Optymalizacyjny";
            // 
            // wybierzProblem
            // 
            this.wybierzProblem.FormattingEnabled = true;
            this.wybierzProblem.ItemHeight = 23;
            this.wybierzProblem.Location = new System.Drawing.Point(623, 87);
            this.wybierzProblem.Margin = new System.Windows.Forms.Padding(2);
            this.wybierzProblem.Name = "wybierzProblem";
            this.wybierzProblem.Size = new System.Drawing.Size(251, 29);
            this.wybierzProblem.TabIndex = 14;
            this.wybierzProblem.UseSelectable = true;
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
            this.badanie.ResumeLayout(false);
            this.badanie.PerformLayout();
            this.ewolucyjny.ResumeLayout(false);
            this.ewolucyjny.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage badanie;
        private MetroFramework.Controls.MetroTabPage historia;
        private MetroFramework.Controls.MetroComboBox wyborAlgorytmu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private MetroFramework.Controls.MetroTile start;
        private MetroFramework.Controls.MetroPanel ewolucyjny;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroTextBox pwoKrzyzowania;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroTextBox pwoMutacji;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroTextBox rozmiarPopulacji;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroTextBox iloscPokolen;
        private System.Windows.Forms.Panel domyslny;
        private System.Windows.Forms.Label label7;
        private MetroFramework.Controls.MetroComboBox wybierzProblem;
    }
}

