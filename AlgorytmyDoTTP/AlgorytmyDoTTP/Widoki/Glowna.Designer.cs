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
            this.domyslny = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panelKP = new System.Windows.Forms.Panel();
            this.domyslnyProblem = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.maxWaga = new MetroFramework.Controls.MetroTextBox();
            this.panelTTP = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.wyporzyczeniePlecaka = new MetroFramework.Controls.MetroTextBox();
            this.wybierzDane = new MetroFramework.Controls.MetroComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.wybierzProblem = new MetroFramework.Controls.MetroComboBox();
            this.ewolucyjny = new MetroFramework.Controls.MetroPanel();
            this.wspinaczkowy_losowy = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.iloscRozwiazan = new MetroFramework.Controls.MetroTextBox();
            this.pwoMutacji = new MetroFramework.Controls.MetroTextBox();
            this.iloscPokolen = new MetroFramework.Controls.MetroTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rodzajKrzyzowania = new MetroFramework.Controls.MetroComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.metodaSelekcji = new MetroFramework.Controls.MetroComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pwoKrzyzowania = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rozmiarPopulacji = new MetroFramework.Controls.MetroTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.start = new MetroFramework.Controls.MetroTile();
            this.label6 = new System.Windows.Forms.Label();
            this.wyborAlgorytmu = new MetroFramework.Controls.MetroComboBox();
            this.historia = new MetroFramework.Controls.MetroTabPage();
            this.usuniecieBadania = new MetroFramework.Controls.MetroButton();
            this.podglad = new System.Windows.Forms.TextBox();
            this.porownaj = new MetroFramework.Controls.MetroTile();
            this.daneHistoryczne = new MetroFramework.Controls.MetroListView();
            this.nazwaBadania = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataBadania = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroPanel1.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.badanie.SuspendLayout();
            this.panelKP.SuspendLayout();
            this.panelTTP.SuspendLayout();
            this.ewolucyjny.SuspendLayout();
            this.wspinaczkowy_losowy.SuspendLayout();
            this.historia.SuspendLayout();
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
            this.metroPanel1.Size = new System.Drawing.Size(984, 705);
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
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(984, 705);
            this.metroTabControl1.TabIndex = 2;
            this.metroTabControl1.UseSelectable = true;
            this.metroTabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.zmienKarte);
            // 
            // badanie
            // 
            this.badanie.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.badanie.Controls.Add(this.domyslny);
            this.badanie.Controls.Add(this.label11);
            this.badanie.Controls.Add(this.panelKP);
            this.badanie.Controls.Add(this.wybierzDane);
            this.badanie.Controls.Add(this.label7);
            this.badanie.Controls.Add(this.wybierzProblem);
            this.badanie.Controls.Add(this.ewolucyjny);
            this.badanie.Controls.Add(this.start);
            this.badanie.Controls.Add(this.label6);
            this.badanie.Controls.Add(this.wyborAlgorytmu);
            this.badanie.HorizontalScrollbarBarColor = true;
            this.badanie.HorizontalScrollbarHighlightOnWheel = false;
            this.badanie.HorizontalScrollbarSize = 10;
            this.badanie.Location = new System.Drawing.Point(4, 38);
            this.badanie.Name = "badanie";
            this.badanie.Size = new System.Drawing.Size(976, 663);
            this.badanie.TabIndex = 0;
            this.badanie.Text = "Badanie Algorytmu";
            this.badanie.VerticalScrollbarBarColor = true;
            this.badanie.VerticalScrollbarHighlightOnWheel = false;
            this.badanie.VerticalScrollbarSize = 10;
            // 
            // domyslny
            // 
            this.domyslny.Location = new System.Drawing.Point(494, 194);
            this.domyslny.Name = "domyslny";
            this.domyslny.Size = new System.Drawing.Size(482, 402);
            this.domyslny.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(273, 60);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Wybierz Plik Danych";
            // 
            // panelKP
            // 
            this.panelKP.Controls.Add(this.domyslnyProblem);
            this.panelKP.Controls.Add(this.label15);
            this.panelKP.Controls.Add(this.label10);
            this.panelKP.Controls.Add(this.maxWaga);
            this.panelKP.Controls.Add(this.panelTTP);
            this.panelKP.Location = new System.Drawing.Point(0, 194);
            this.panelKP.Name = "panelKP";
            this.panelKP.Size = new System.Drawing.Size(486, 402);
            this.panelKP.TabIndex = 29;
            // 
            // domyslnyProblem
            // 
            this.domyslnyProblem.Location = new System.Drawing.Point(0, 0);
            this.domyslnyProblem.Name = "domyslnyProblem";
            this.domyslnyProblem.Size = new System.Drawing.Size(486, 402);
            this.domyslnyProblem.TabIndex = 31;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(417, 25);
            this.label15.TabIndex = 33;
            this.label15.Text = "Konfiguracja Problemu Optymalizacyjnego";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 55);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Maksymalna waga plecaka";
            // 
            // maxWaga
            // 
            // 
            // 
            // 
            this.maxWaga.CustomButton.Image = null;
            this.maxWaga.CustomButton.Location = new System.Drawing.Point(78, 2);
            this.maxWaga.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.maxWaga.CustomButton.Name = "";
            this.maxWaga.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.maxWaga.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.maxWaga.CustomButton.TabIndex = 1;
            this.maxWaga.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.maxWaga.CustomButton.UseSelectable = true;
            this.maxWaga.CustomButton.Visible = false;
            this.maxWaga.Lines = new string[] {
        "7"};
            this.maxWaga.Location = new System.Drawing.Point(5, 81);
            this.maxWaga.Margin = new System.Windows.Forms.Padding(2);
            this.maxWaga.MaxLength = 32767;
            this.maxWaga.Name = "maxWaga";
            this.maxWaga.PasswordChar = '\0';
            this.maxWaga.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.maxWaga.SelectedText = "";
            this.maxWaga.SelectionLength = 0;
            this.maxWaga.SelectionStart = 0;
            this.maxWaga.ShortcutsEnabled = true;
            this.maxWaga.Size = new System.Drawing.Size(96, 20);
            this.maxWaga.TabIndex = 4;
            this.maxWaga.Text = "7";
            this.maxWaga.UseSelectable = true;
            this.maxWaga.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.maxWaga.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // panelTTP
            // 
            this.panelTTP.Controls.Add(this.label13);
            this.panelTTP.Controls.Add(this.wyporzyczeniePlecaka);
            this.panelTTP.Location = new System.Drawing.Point(0, 151);
            this.panelTTP.Name = "panelTTP";
            this.panelTTP.Size = new System.Drawing.Size(486, 251);
            this.panelTTP.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(2, 7);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(164, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "$ za wyporzyczenie plecaka na h";
            // 
            // wyporzyczeniePlecaka
            // 
            // 
            // 
            // 
            this.wyporzyczeniePlecaka.CustomButton.Image = null;
            this.wyporzyczeniePlecaka.CustomButton.Location = new System.Drawing.Point(78, 2);
            this.wyporzyczeniePlecaka.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.wyporzyczeniePlecaka.CustomButton.Name = "";
            this.wyporzyczeniePlecaka.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.wyporzyczeniePlecaka.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.wyporzyczeniePlecaka.CustomButton.TabIndex = 1;
            this.wyporzyczeniePlecaka.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.wyporzyczeniePlecaka.CustomButton.UseSelectable = true;
            this.wyporzyczeniePlecaka.CustomButton.Visible = false;
            this.wyporzyczeniePlecaka.Lines = new string[] {
        "1"};
            this.wyporzyczeniePlecaka.Location = new System.Drawing.Point(4, 32);
            this.wyporzyczeniePlecaka.Margin = new System.Windows.Forms.Padding(2);
            this.wyporzyczeniePlecaka.MaxLength = 32767;
            this.wyporzyczeniePlecaka.Name = "wyporzyczeniePlecaka";
            this.wyporzyczeniePlecaka.PasswordChar = '\0';
            this.wyporzyczeniePlecaka.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.wyporzyczeniePlecaka.SelectedText = "";
            this.wyporzyczeniePlecaka.SelectionLength = 0;
            this.wyporzyczeniePlecaka.SelectionStart = 0;
            this.wyporzyczeniePlecaka.ShortcutsEnabled = true;
            this.wyporzyczeniePlecaka.Size = new System.Drawing.Size(96, 20);
            this.wyporzyczeniePlecaka.TabIndex = 5;
            this.wyporzyczeniePlecaka.Text = "1";
            this.wyporzyczeniePlecaka.UseSelectable = true;
            this.wyporzyczeniePlecaka.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.wyporzyczeniePlecaka.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // wybierzDane
            // 
            this.wybierzDane.FormattingEnabled = true;
            this.wybierzDane.ItemHeight = 23;
            this.wybierzDane.Location = new System.Drawing.Point(276, 79);
            this.wybierzDane.Name = "wybierzDane";
            this.wybierzDane.Size = new System.Drawing.Size(128, 29);
            this.wybierzDane.TabIndex = 2;
            this.wybierzDane.UseSelectable = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-3, 60);
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
            this.wybierzProblem.Location = new System.Drawing.Point(0, 79);
            this.wybierzProblem.Margin = new System.Windows.Forms.Padding(2);
            this.wybierzProblem.Name = "wybierzProblem";
            this.wybierzProblem.Size = new System.Drawing.Size(256, 29);
            this.wybierzProblem.TabIndex = 1;
            this.wybierzProblem.UseSelectable = true;
            this.wybierzProblem.SelectionChangeCommitted += new System.EventHandler(this.wybierzProblem_SelectedIndexChanged);
            // 
            // ewolucyjny
            // 
            this.ewolucyjny.Controls.Add(this.wspinaczkowy_losowy);
            this.ewolucyjny.Controls.Add(this.pwoMutacji);
            this.ewolucyjny.Controls.Add(this.iloscPokolen);
            this.ewolucyjny.Controls.Add(this.label9);
            this.ewolucyjny.Controls.Add(this.label5);
            this.ewolucyjny.Controls.Add(this.rodzajKrzyzowania);
            this.ewolucyjny.Controls.Add(this.label8);
            this.ewolucyjny.Controls.Add(this.metodaSelekcji);
            this.ewolucyjny.Controls.Add(this.label4);
            this.ewolucyjny.Controls.Add(this.pwoKrzyzowania);
            this.ewolucyjny.Controls.Add(this.label1);
            this.ewolucyjny.Controls.Add(this.label3);
            this.ewolucyjny.Controls.Add(this.rozmiarPopulacji);
            this.ewolucyjny.Controls.Add(this.label2);
            this.ewolucyjny.HorizontalScrollbarBarColor = true;
            this.ewolucyjny.HorizontalScrollbarHighlightOnWheel = false;
            this.ewolucyjny.HorizontalScrollbarSize = 10;
            this.ewolucyjny.Location = new System.Drawing.Point(494, 194);
            this.ewolucyjny.Name = "ewolucyjny";
            this.ewolucyjny.Size = new System.Drawing.Size(486, 402);
            this.ewolucyjny.TabIndex = 13;
            this.ewolucyjny.VerticalScrollbarBarColor = true;
            this.ewolucyjny.VerticalScrollbarHighlightOnWheel = false;
            this.ewolucyjny.VerticalScrollbarSize = 10;
            // 
            // wspinaczkowy_losowy
            // 
            this.wspinaczkowy_losowy.Controls.Add(this.label12);
            this.wspinaczkowy_losowy.Controls.Add(this.iloscRozwiazan);
            this.wspinaczkowy_losowy.Location = new System.Drawing.Point(0, 28);
            this.wspinaczkowy_losowy.Name = "wspinaczkowy_losowy";
            this.wspinaczkowy_losowy.Size = new System.Drawing.Size(482, 374);
            this.wspinaczkowy_losowy.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 27);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Ilość rozwiązań";
            // 
            // iloscRozwiazan
            // 
            // 
            // 
            // 
            this.iloscRozwiazan.CustomButton.Image = null;
            this.iloscRozwiazan.CustomButton.Location = new System.Drawing.Point(78, 2);
            this.iloscRozwiazan.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.iloscRozwiazan.CustomButton.Name = "";
            this.iloscRozwiazan.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.iloscRozwiazan.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.iloscRozwiazan.CustomButton.TabIndex = 1;
            this.iloscRozwiazan.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.iloscRozwiazan.CustomButton.UseSelectable = true;
            this.iloscRozwiazan.CustomButton.Visible = false;
            this.iloscRozwiazan.Lines = new string[] {
        "20"};
            this.iloscRozwiazan.Location = new System.Drawing.Point(7, 44);
            this.iloscRozwiazan.Margin = new System.Windows.Forms.Padding(2);
            this.iloscRozwiazan.MaxLength = 32767;
            this.iloscRozwiazan.Name = "iloscRozwiazan";
            this.iloscRozwiazan.PasswordChar = '\0';
            this.iloscRozwiazan.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.iloscRozwiazan.SelectedText = "";
            this.iloscRozwiazan.SelectionLength = 0;
            this.iloscRozwiazan.SelectionStart = 0;
            this.iloscRozwiazan.ShortcutsEnabled = true;
            this.iloscRozwiazan.Size = new System.Drawing.Size(96, 20);
            this.iloscRozwiazan.TabIndex = 33;
            this.iloscRozwiazan.Text = "20";
            this.iloscRozwiazan.UseSelectable = true;
            this.iloscRozwiazan.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.iloscRozwiazan.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pwoMutacji
            // 
            // 
            // 
            // 
            this.pwoMutacji.CustomButton.Image = null;
            this.pwoMutacji.CustomButton.Location = new System.Drawing.Point(78, 2);
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
            this.pwoMutacji.Location = new System.Drawing.Point(291, 267);
            this.pwoMutacji.Margin = new System.Windows.Forms.Padding(2);
            this.pwoMutacji.MaxLength = 32767;
            this.pwoMutacji.Name = "pwoMutacji";
            this.pwoMutacji.PasswordChar = '\0';
            this.pwoMutacji.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.pwoMutacji.SelectedText = "";
            this.pwoMutacji.SelectionLength = 0;
            this.pwoMutacji.SelectionStart = 0;
            this.pwoMutacji.ShortcutsEnabled = true;
            this.pwoMutacji.Size = new System.Drawing.Size(96, 20);
            this.pwoMutacji.TabIndex = 12;
            this.pwoMutacji.Text = "0,1";
            this.pwoMutacji.UseSelectable = true;
            this.pwoMutacji.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.pwoMutacji.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // iloscPokolen
            // 
            // 
            // 
            // 
            this.iloscPokolen.CustomButton.Image = null;
            this.iloscPokolen.CustomButton.Location = new System.Drawing.Point(78, 2);
            this.iloscPokolen.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.iloscPokolen.CustomButton.Name = "";
            this.iloscPokolen.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.iloscPokolen.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.iloscPokolen.CustomButton.TabIndex = 1;
            this.iloscPokolen.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.iloscPokolen.CustomButton.UseSelectable = true;
            this.iloscPokolen.CustomButton.Visible = false;
            this.iloscPokolen.Lines = new string[] {
        "15"};
            this.iloscPokolen.Location = new System.Drawing.Point(291, 183);
            this.iloscPokolen.Margin = new System.Windows.Forms.Padding(2);
            this.iloscPokolen.MaxLength = 32767;
            this.iloscPokolen.Name = "iloscPokolen";
            this.iloscPokolen.PasswordChar = '\0';
            this.iloscPokolen.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.iloscPokolen.SelectedText = "";
            this.iloscPokolen.SelectionLength = 0;
            this.iloscPokolen.SelectionStart = 0;
            this.iloscPokolen.ShortcutsEnabled = true;
            this.iloscPokolen.Size = new System.Drawing.Size(96, 20);
            this.iloscPokolen.TabIndex = 10;
            this.iloscPokolen.Text = "15";
            this.iloscPokolen.UseSelectable = true;
            this.iloscPokolen.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.iloscPokolen.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 158);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Rodzaj krzyżowania";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 242);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Prawdopodobieństwo mutacji";
            // 
            // rodzajKrzyzowania
            // 
            this.rodzajKrzyzowania.FormattingEnabled = true;
            this.rodzajKrzyzowania.ItemHeight = 23;
            this.rodzajKrzyzowania.Location = new System.Drawing.Point(7, 183);
            this.rodzajKrzyzowania.Name = "rodzajKrzyzowania";
            this.rodzajKrzyzowania.Size = new System.Drawing.Size(128, 29);
            this.rodzajKrzyzowania.TabIndex = 9;
            this.rodzajKrzyzowania.UseSelectable = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 55);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Metoda selekcji";
            // 
            // metodaSelekcji
            // 
            this.metodaSelekcji.FormattingEnabled = true;
            this.metodaSelekcji.ItemHeight = 23;
            this.metodaSelekcji.Location = new System.Drawing.Point(7, 72);
            this.metodaSelekcji.Name = "metodaSelekcji";
            this.metodaSelekcji.Size = new System.Drawing.Size(128, 29);
            this.metodaSelekcji.TabIndex = 7;
            this.metodaSelekcji.UseSelectable = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 242);
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
            this.pwoKrzyzowania.CustomButton.Location = new System.Drawing.Point(78, 2);
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
            this.pwoKrzyzowania.Location = new System.Drawing.Point(7, 267);
            this.pwoKrzyzowania.Margin = new System.Windows.Forms.Padding(2);
            this.pwoKrzyzowania.MaxLength = 32767;
            this.pwoKrzyzowania.Name = "pwoKrzyzowania";
            this.pwoKrzyzowania.PasswordChar = '\0';
            this.pwoKrzyzowania.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.pwoKrzyzowania.SelectedText = "";
            this.pwoKrzyzowania.SelectionLength = 0;
            this.pwoKrzyzowania.SelectionStart = 0;
            this.pwoKrzyzowania.ShortcutsEnabled = true;
            this.pwoKrzyzowania.Size = new System.Drawing.Size(96, 20);
            this.pwoKrzyzowania.TabIndex = 11;
            this.pwoKrzyzowania.Text = "0,7";
            this.pwoKrzyzowania.UseSelectable = true;
            this.pwoKrzyzowania.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.pwoKrzyzowania.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Konfiguracja Algorytmu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 55);
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
            this.rozmiarPopulacji.CustomButton.Location = new System.Drawing.Point(78, 2);
            this.rozmiarPopulacji.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.rozmiarPopulacji.CustomButton.Name = "";
            this.rozmiarPopulacji.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.rozmiarPopulacji.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.rozmiarPopulacji.CustomButton.TabIndex = 1;
            this.rozmiarPopulacji.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.rozmiarPopulacji.CustomButton.UseSelectable = true;
            this.rozmiarPopulacji.CustomButton.Visible = false;
            this.rozmiarPopulacji.Lines = new string[] {
        "20"};
            this.rozmiarPopulacji.Location = new System.Drawing.Point(291, 72);
            this.rozmiarPopulacji.Margin = new System.Windows.Forms.Padding(2);
            this.rozmiarPopulacji.MaxLength = 32767;
            this.rozmiarPopulacji.Name = "rozmiarPopulacji";
            this.rozmiarPopulacji.PasswordChar = '\0';
            this.rozmiarPopulacji.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.rozmiarPopulacji.SelectedText = "";
            this.rozmiarPopulacji.SelectionLength = 0;
            this.rozmiarPopulacji.SelectionStart = 0;
            this.rozmiarPopulacji.ShortcutsEnabled = true;
            this.rozmiarPopulacji.Size = new System.Drawing.Size(96, 20);
            this.rozmiarPopulacji.TabIndex = 8;
            this.rozmiarPopulacji.Text = "20";
            this.rozmiarPopulacji.UseSelectable = true;
            this.rozmiarPopulacji.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.rozmiarPopulacji.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 158);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Liczba pokoleń";
            // 
            // start
            // 
            this.start.ActiveControl = null;
            this.start.Location = new System.Drawing.Point(778, 601);
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
            this.label6.Location = new System.Drawing.Point(491, 60);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Wybierz Algorytm";
            // 
            // wyborAlgorytmu
            // 
            this.wyborAlgorytmu.FormattingEnabled = true;
            this.wyborAlgorytmu.ItemHeight = 23;
            this.wyborAlgorytmu.Location = new System.Drawing.Point(494, 79);
            this.wyborAlgorytmu.Margin = new System.Windows.Forms.Padding(2);
            this.wyborAlgorytmu.Name = "wyborAlgorytmu";
            this.wyborAlgorytmu.Size = new System.Drawing.Size(256, 29);
            this.wyborAlgorytmu.TabIndex = 3;
            this.wyborAlgorytmu.UseSelectable = true;
            this.wyborAlgorytmu.SelectionChangeCommitted += new System.EventHandler(this.wyborAlgorytmu_SelectedIndexChanged);
            // 
            // historia
            // 
            this.historia.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.historia.Controls.Add(this.usuniecieBadania);
            this.historia.Controls.Add(this.podglad);
            this.historia.Controls.Add(this.porownaj);
            this.historia.Controls.Add(this.daneHistoryczne);
            this.historia.HorizontalScrollbarBarColor = true;
            this.historia.HorizontalScrollbarHighlightOnWheel = false;
            this.historia.HorizontalScrollbarSize = 10;
            this.historia.Location = new System.Drawing.Point(4, 38);
            this.historia.Name = "historia";
            this.historia.Size = new System.Drawing.Size(976, 663);
            this.historia.TabIndex = 1;
            this.historia.Text = "Historia Badań";
            this.historia.VerticalScrollbarBarColor = true;
            this.historia.VerticalScrollbarHighlightOnWheel = false;
            this.historia.VerticalScrollbarSize = 10;
            // 
            // usuniecieBadania
            // 
            this.usuniecieBadania.Location = new System.Drawing.Point(0, 22);
            this.usuniecieBadania.Name = "usuniecieBadania";
            this.usuniecieBadania.Size = new System.Drawing.Size(90, 23);
            this.usuniecieBadania.TabIndex = 9;
            this.usuniecieBadania.Text = "Usuń Badanie";
            this.usuniecieBadania.UseSelectable = true;
            this.usuniecieBadania.Click += new System.EventHandler(this.usuniecieBadania_Click);
            // 
            // podglad
            // 
            this.podglad.BackColor = System.Drawing.SystemColors.Window;
            this.podglad.Enabled = false;
            this.podglad.Location = new System.Drawing.Point(586, 55);
            this.podglad.Multiline = true;
            this.podglad.Name = "podglad";
            this.podglad.ReadOnly = true;
            this.podglad.Size = new System.Drawing.Size(390, 519);
            this.podglad.TabIndex = 8;
            // 
            // porownaj
            // 
            this.porownaj.ActiveControl = null;
            this.porownaj.Location = new System.Drawing.Point(778, 601);
            this.porownaj.Margin = new System.Windows.Forms.Padding(2);
            this.porownaj.Name = "porownaj";
            this.porownaj.Size = new System.Drawing.Size(200, 60);
            this.porownaj.TabIndex = 7;
            this.porownaj.Text = "Porównaj";
            this.porownaj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.porownaj.UseSelectable = true;
            this.porownaj.Click += new System.EventHandler(this.porownaj_Click);
            // 
            // daneHistoryczne
            // 
            this.daneHistoryczne.AllowSorting = true;
            this.daneHistoryczne.CheckBoxes = true;
            this.daneHistoryczne.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nazwaBadania,
            this.dataBadania});
            this.daneHistoryczne.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.daneHistoryczne.FullRowSelect = true;
            this.daneHistoryczne.Location = new System.Drawing.Point(0, 55);
            this.daneHistoryczne.Name = "daneHistoryczne";
            this.daneHistoryczne.OwnerDraw = true;
            this.daneHistoryczne.Size = new System.Drawing.Size(580, 605);
            this.daneHistoryczne.TabIndex = 2;
            this.daneHistoryczne.UseCompatibleStateImageBehavior = false;
            this.daneHistoryczne.UseSelectable = true;
            this.daneHistoryczne.View = System.Windows.Forms.View.Details;
            this.daneHistoryczne.SelectedIndexChanged += new System.EventHandler(this.podgladBadania);
            // 
            // nazwaBadania
            // 
            this.nazwaBadania.Text = "Nazwa Badania";
            this.nazwaBadania.Width = 410;
            // 
            // dataBadania
            // 
            this.dataBadania.Text = "Data Badania";
            this.dataBadania.Width = 163;
            // 
            // Glowna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.metroPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "Glowna";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Glowna";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroTabControl1.ResumeLayout(false);
            this.badanie.ResumeLayout(false);
            this.badanie.PerformLayout();
            this.panelKP.ResumeLayout(false);
            this.panelKP.PerformLayout();
            this.panelTTP.ResumeLayout(false);
            this.panelTTP.PerformLayout();
            this.ewolucyjny.ResumeLayout(false);
            this.ewolucyjny.PerformLayout();
            this.wspinaczkowy_losowy.ResumeLayout(false);
            this.wspinaczkowy_losowy.PerformLayout();
            this.historia.ResumeLayout(false);
            this.historia.PerformLayout();
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
        private MetroFramework.Controls.MetroTextBox iloscPokolen;
        private System.Windows.Forms.Panel domyslny;
        private System.Windows.Forms.Label label7;
        private MetroFramework.Controls.MetroComboBox wybierzProblem;
        private MetroFramework.Controls.MetroComboBox wybierzDane;
        private System.Windows.Forms.Label label9;
        private MetroFramework.Controls.MetroComboBox rodzajKrzyzowania;
        private System.Windows.Forms.Label label8;
        private MetroFramework.Controls.MetroComboBox metodaSelekcji;
        private System.Windows.Forms.Panel panelKP;
        private System.Windows.Forms.Panel panelTTP;
        private System.Windows.Forms.Label label10;
        private MetroFramework.Controls.MetroTextBox maxWaga;
        private System.Windows.Forms.Label label11;
        protected MetroFramework.Controls.MetroListView daneHistoryczne;
        private System.Windows.Forms.ColumnHeader nazwaBadania;
        private System.Windows.Forms.ColumnHeader dataBadania;
        private MetroFramework.Controls.MetroTile porownaj;
        private System.Windows.Forms.Panel wspinaczkowy_losowy;
        private System.Windows.Forms.Label label12;
        private MetroFramework.Controls.MetroTextBox iloscRozwiazan;
        private System.Windows.Forms.Panel domyslnyProblem;
        private System.Windows.Forms.Label label13;
        private MetroFramework.Controls.MetroTextBox wyporzyczeniePlecaka;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox podglad;
        private MetroFramework.Controls.MetroButton usuniecieBadania;
    }
}

