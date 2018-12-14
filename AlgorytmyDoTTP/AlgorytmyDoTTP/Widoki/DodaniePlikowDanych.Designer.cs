namespace AlgorytmyDoTTP.Widoki
{
    partial class DodaniePlikowDanych
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
            this.wygenerujPlikDanych = new MetroFramework.Controls.MetroButton();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabela = new MetroFramework.Controls.MetroTabControl();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.przedmioty = new MetroFramework.Controls.MetroTabPage();
            this.miasta = new MetroFramework.Controls.MetroTabPage();
            this.dodajPrzedmiot = new MetroFramework.Controls.MetroButton();
            this.listaPrzedmiotow = new MetroFramework.Controls.MetroListView();
            this.przedmiotyID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.przedmiotyWartosc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.waga = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.wartosc = new MetroFramework.Controls.MetroTextBox();
            this.stworzPlikDanych = new MetroFramework.Controls.MetroButton();
            this.usunPredmiot = new MetroFramework.Controls.MetroButton();
            this.usunMiasto = new MetroFramework.Controls.MetroButton();
            this.dodajMiasto = new MetroFramework.Controls.MetroButton();
            this.listaMiast = new MetroFramework.Controls.MetroListView();
            this.miastaID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wspX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wsp_y = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.wsp_x = new MetroFramework.Controls.MetroTextBox();
            this.dostepnePrzedmioty = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.przedmiotyWaga = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wspY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.miastaDostepnePrzedmioty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroPanel1.SuspendLayout();
            this.tabela.SuspendLayout();
            this.przedmioty.SuspendLayout();
            this.miasta.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.tabela);
            this.metroPanel1.Controls.Add(this.wygenerujPlikDanych);
            this.metroPanel1.Controls.Add(this.metroLabel6);
            this.metroPanel1.Controls.Add(this.label1);
            this.metroPanel1.Controls.Add(this.metroComboBox1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1040, 712);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // wygenerujPlikDanych
            // 
            this.wygenerujPlikDanych.Location = new System.Drawing.Point(396, 52);
            this.wygenerujPlikDanych.Name = "wygenerujPlikDanych";
            this.wygenerujPlikDanych.Size = new System.Drawing.Size(235, 30);
            this.wygenerujPlikDanych.TabIndex = 15;
            this.wygenerujPlikDanych.Text = "Wygeneruj losowy plik danych";
            this.wygenerujPlikDanych.UseSelectable = true;
            this.wygenerujPlikDanych.Click += new System.EventHandler(this.wygenerujPlikDanych_Click);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(12, 55);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(136, 20);
            this.metroLabel6.TabIndex = 13;
            this.metroLabel6.Text = "Nazwa pliku danych:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 38);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tworzenie plików danych";
            // 
            // tabela
            // 
            this.tabela.Controls.Add(this.przedmioty);
            this.tabela.Controls.Add(this.miasta);
            this.tabela.Location = new System.Drawing.Point(10, 108);
            this.tabela.Name = "tabela";
            this.tabela.SelectedIndex = 1;
            this.tabela.Size = new System.Drawing.Size(1018, 592);
            this.tabela.TabIndex = 116;
            this.tabela.UseSelectable = true;
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 24;
            this.metroComboBox1.Location = new System.Drawing.Point(187, 52);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(203, 30);
            this.metroComboBox1.TabIndex = 117;
            this.metroComboBox1.UseSelectable = true;
            // 
            // przedmioty
            // 
            this.przedmioty.Controls.Add(this.usunPredmiot);
            this.przedmioty.Controls.Add(this.dodajPrzedmiot);
            this.przedmioty.Controls.Add(this.listaPrzedmiotow);
            this.przedmioty.Controls.Add(this.waga);
            this.przedmioty.Controls.Add(this.metroLabel3);
            this.przedmioty.Controls.Add(this.metroLabel2);
            this.przedmioty.Controls.Add(this.wartosc);
            this.przedmioty.HorizontalScrollbarBarColor = true;
            this.przedmioty.HorizontalScrollbarHighlightOnWheel = false;
            this.przedmioty.HorizontalScrollbarSize = 10;
            this.przedmioty.Location = new System.Drawing.Point(4, 38);
            this.przedmioty.Name = "przedmioty";
            this.przedmioty.Size = new System.Drawing.Size(1010, 550);
            this.przedmioty.TabIndex = 0;
            this.przedmioty.Text = "Przedmioty";
            this.przedmioty.VerticalScrollbarBarColor = true;
            this.przedmioty.VerticalScrollbarHighlightOnWheel = false;
            this.przedmioty.VerticalScrollbarSize = 10;
            // 
            // miasta
            // 
            this.miasta.Controls.Add(this.metroLabel5);
            this.miasta.Controls.Add(this.dostepnePrzedmioty);
            this.miasta.Controls.Add(this.usunMiasto);
            this.miasta.Controls.Add(this.stworzPlikDanych);
            this.miasta.Controls.Add(this.dodajMiasto);
            this.miasta.Controls.Add(this.listaMiast);
            this.miasta.Controls.Add(this.wsp_y);
            this.miasta.Controls.Add(this.metroLabel1);
            this.miasta.Controls.Add(this.metroLabel4);
            this.miasta.Controls.Add(this.wsp_x);
            this.miasta.HorizontalScrollbarBarColor = true;
            this.miasta.HorizontalScrollbarHighlightOnWheel = false;
            this.miasta.HorizontalScrollbarSize = 10;
            this.miasta.Location = new System.Drawing.Point(4, 38);
            this.miasta.Name = "miasta";
            this.miasta.Size = new System.Drawing.Size(1010, 550);
            this.miasta.TabIndex = 1;
            this.miasta.Text = "Miasta";
            this.miasta.VerticalScrollbarBarColor = true;
            this.miasta.VerticalScrollbarHighlightOnWheel = false;
            this.miasta.VerticalScrollbarSize = 10;
            // 
            // dodajPrzedmiot
            // 
            this.dodajPrzedmiot.Location = new System.Drawing.Point(831, 28);
            this.dodajPrzedmiot.Name = "dodajPrzedmiot";
            this.dodajPrzedmiot.Size = new System.Drawing.Size(176, 23);
            this.dodajPrzedmiot.TabIndex = 124;
            this.dodajPrzedmiot.Text = "Dodaj przedmiot";
            this.dodajPrzedmiot.UseSelectable = true;
            this.dodajPrzedmiot.Click += new System.EventHandler(this.dodajPrzedmiot_Click);
            // 
            // listaPrzedmiotow
            // 
            this.listaPrzedmiotow.AllowSorting = true;
            this.listaPrzedmiotow.CheckBoxes = true;
            this.listaPrzedmiotow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.przedmiotyID,
            this.przedmiotyWartosc,
            this.przedmiotyWaga});
            this.listaPrzedmiotow.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.listaPrzedmiotow.FullRowSelect = true;
            this.listaPrzedmiotow.Location = new System.Drawing.Point(0, 62);
            this.listaPrzedmiotow.Margin = new System.Windows.Forms.Padding(4);
            this.listaPrzedmiotow.Name = "listaPrzedmiotow";
            this.listaPrzedmiotow.OwnerDraw = true;
            this.listaPrzedmiotow.Size = new System.Drawing.Size(1010, 400);
            this.listaPrzedmiotow.TabIndex = 123;
            this.listaPrzedmiotow.UseCompatibleStateImageBehavior = false;
            this.listaPrzedmiotow.UseSelectable = true;
            this.listaPrzedmiotow.View = System.Windows.Forms.View.Details;
            // 
            // przedmiotyID
            // 
            this.przedmiotyID.Text = "Indeks";
            this.przedmiotyID.Width = 150;
            // 
            // przedmiotyWartosc
            // 
            this.przedmiotyWartosc.Text = "Wartość";
            this.przedmiotyWartosc.Width = 300;
            // 
            // waga
            // 
            // 
            // 
            // 
            this.waga.CustomButton.Image = null;
            this.waga.CustomButton.Location = new System.Drawing.Point(109, 1);
            this.waga.CustomButton.Name = "";
            this.waga.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.waga.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.waga.CustomButton.TabIndex = 1;
            this.waga.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.waga.CustomButton.UseSelectable = true;
            this.waga.CustomButton.Visible = false;
            this.waga.Lines = new string[0];
            this.waga.Location = new System.Drawing.Point(695, 28);
            this.waga.MaxLength = 32767;
            this.waga.Multiline = true;
            this.waga.Name = "waga";
            this.waga.PasswordChar = '\0';
            this.waga.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.waga.SelectedText = "";
            this.waga.SelectionLength = 0;
            this.waga.SelectionStart = 0;
            this.waga.ShortcutsEnabled = true;
            this.waga.Size = new System.Drawing.Size(131, 23);
            this.waga.TabIndex = 119;
            this.waga.UseSelectable = true;
            this.waga.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.waga.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(695, 5);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(43, 20);
            this.metroLabel3.TabIndex = 118;
            this.metroLabel3.Text = "Waga";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(558, 5);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(59, 20);
            this.metroLabel2.TabIndex = 117;
            this.metroLabel2.Text = "Wartość";
            // 
            // wartosc
            // 
            // 
            // 
            // 
            this.wartosc.CustomButton.Image = null;
            this.wartosc.CustomButton.Location = new System.Drawing.Point(110, 1);
            this.wartosc.CustomButton.Name = "";
            this.wartosc.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.wartosc.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.wartosc.CustomButton.TabIndex = 1;
            this.wartosc.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.wartosc.CustomButton.UseSelectable = true;
            this.wartosc.CustomButton.Visible = false;
            this.wartosc.Lines = new string[0];
            this.wartosc.Location = new System.Drawing.Point(558, 28);
            this.wartosc.MaxLength = 32767;
            this.wartosc.Multiline = true;
            this.wartosc.Name = "wartosc";
            this.wartosc.PasswordChar = '\0';
            this.wartosc.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.wartosc.SelectedText = "";
            this.wartosc.SelectionLength = 0;
            this.wartosc.SelectionStart = 0;
            this.wartosc.ShortcutsEnabled = true;
            this.wartosc.Size = new System.Drawing.Size(132, 23);
            this.wartosc.TabIndex = 116;
            this.wartosc.UseSelectable = true;
            this.wartosc.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.wartosc.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // stworzPlikDanych
            // 
            this.stworzPlikDanych.Location = new System.Drawing.Point(831, 469);
            this.stworzPlikDanych.Name = "stworzPlikDanych";
            this.stworzPlikDanych.Size = new System.Drawing.Size(176, 32);
            this.stworzPlikDanych.TabIndex = 123;
            this.stworzPlikDanych.Text = "Stwórz plik danch";
            this.stworzPlikDanych.UseSelectable = true;
            // 
            // usunPredmiot
            // 
            this.usunPredmiot.Location = new System.Drawing.Point(1, 28);
            this.usunPredmiot.Name = "usunPredmiot";
            this.usunPredmiot.Size = new System.Drawing.Size(165, 23);
            this.usunPredmiot.TabIndex = 125;
            this.usunPredmiot.Text = "Usuń przedmiot";
            this.usunPredmiot.UseSelectable = true;
            // 
            // usunMiasto
            // 
            this.usunMiasto.Location = new System.Drawing.Point(1, 28);
            this.usunMiasto.Name = "usunMiasto";
            this.usunMiasto.Size = new System.Drawing.Size(165, 23);
            this.usunMiasto.TabIndex = 132;
            this.usunMiasto.Text = "Usuń miasto";
            this.usunMiasto.UseSelectable = true;
            // 
            // dodajMiasto
            // 
            this.dodajMiasto.Location = new System.Drawing.Point(831, 28);
            this.dodajMiasto.Name = "dodajMiasto";
            this.dodajMiasto.Size = new System.Drawing.Size(176, 23);
            this.dodajMiasto.TabIndex = 131;
            this.dodajMiasto.Text = "Dodaj miasto";
            this.dodajMiasto.UseSelectable = true;
            this.dodajMiasto.Click += new System.EventHandler(this.dodajMiasto_Click);
            // 
            // listaMiast
            // 
            this.listaMiast.AllowSorting = true;
            this.listaMiast.CheckBoxes = true;
            this.listaMiast.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.miastaID,
            this.wspX,
            this.wspY,
            this.miastaDostepnePrzedmioty});
            this.listaMiast.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.listaMiast.FullRowSelect = true;
            this.listaMiast.Location = new System.Drawing.Point(0, 62);
            this.listaMiast.Margin = new System.Windows.Forms.Padding(4);
            this.listaMiast.Name = "listaMiast";
            this.listaMiast.OwnerDraw = true;
            this.listaMiast.Size = new System.Drawing.Size(1010, 400);
            this.listaMiast.TabIndex = 130;
            this.listaMiast.UseCompatibleStateImageBehavior = false;
            this.listaMiast.UseSelectable = true;
            this.listaMiast.View = System.Windows.Forms.View.Details;
            // 
            // miastaID
            // 
            this.miastaID.Text = "Indeks";
            this.miastaID.Width = 150;
            // 
            // wspX
            // 
            this.wspX.Text = "Współrzędna X";
            this.wspX.Width = 100;
            // 
            // wsp_y
            // 
            // 
            // 
            // 
            this.wsp_y.CustomButton.Image = null;
            this.wsp_y.CustomButton.Location = new System.Drawing.Point(109, 1);
            this.wsp_y.CustomButton.Name = "";
            this.wsp_y.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.wsp_y.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.wsp_y.CustomButton.TabIndex = 1;
            this.wsp_y.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.wsp_y.CustomButton.UseSelectable = true;
            this.wsp_y.CustomButton.Visible = false;
            this.wsp_y.Lines = new string[0];
            this.wsp_y.Location = new System.Drawing.Point(448, 28);
            this.wsp_y.MaxLength = 32767;
            this.wsp_y.Multiline = true;
            this.wsp_y.Name = "wsp_y";
            this.wsp_y.PasswordChar = '\0';
            this.wsp_y.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.wsp_y.SelectedText = "";
            this.wsp_y.SelectionLength = 0;
            this.wsp_y.SelectionStart = 0;
            this.wsp_y.ShortcutsEnabled = true;
            this.wsp_y.Size = new System.Drawing.Size(131, 23);
            this.wsp_y.TabIndex = 129;
            this.wsp_y.UseSelectable = true;
            this.wsp_y.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.wsp_y.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(448, 5);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(51, 20);
            this.metroLabel1.TabIndex = 128;
            this.metroLabel1.Text = "Wsp. Y";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(311, 5);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(51, 20);
            this.metroLabel4.TabIndex = 127;
            this.metroLabel4.Text = "Wsp. X";
            // 
            // wsp_x
            // 
            // 
            // 
            // 
            this.wsp_x.CustomButton.Image = null;
            this.wsp_x.CustomButton.Location = new System.Drawing.Point(109, 1);
            this.wsp_x.CustomButton.Name = "";
            this.wsp_x.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.wsp_x.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.wsp_x.CustomButton.TabIndex = 1;
            this.wsp_x.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.wsp_x.CustomButton.UseSelectable = true;
            this.wsp_x.CustomButton.Visible = false;
            this.wsp_x.Lines = new string[0];
            this.wsp_x.Location = new System.Drawing.Point(311, 28);
            this.wsp_x.MaxLength = 32767;
            this.wsp_x.Multiline = true;
            this.wsp_x.Name = "wsp_x";
            this.wsp_x.PasswordChar = '\0';
            this.wsp_x.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.wsp_x.SelectedText = "";
            this.wsp_x.SelectionLength = 0;
            this.wsp_x.SelectionStart = 0;
            this.wsp_x.ShortcutsEnabled = true;
            this.wsp_x.Size = new System.Drawing.Size(131, 23);
            this.wsp_x.TabIndex = 126;
            this.wsp_x.UseSelectable = true;
            this.wsp_x.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.wsp_x.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dostepnePrzedmioty
            // 
            // 
            // 
            // 
            this.dostepnePrzedmioty.CustomButton.Image = null;
            this.dostepnePrzedmioty.CustomButton.Location = new System.Drawing.Point(219, 1);
            this.dostepnePrzedmioty.CustomButton.Name = "";
            this.dostepnePrzedmioty.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.dostepnePrzedmioty.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.dostepnePrzedmioty.CustomButton.TabIndex = 1;
            this.dostepnePrzedmioty.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dostepnePrzedmioty.CustomButton.UseSelectable = true;
            this.dostepnePrzedmioty.CustomButton.Visible = false;
            this.dostepnePrzedmioty.Lines = new string[0];
            this.dostepnePrzedmioty.Location = new System.Drawing.Point(585, 28);
            this.dostepnePrzedmioty.MaxLength = 32767;
            this.dostepnePrzedmioty.Multiline = true;
            this.dostepnePrzedmioty.Name = "dostepnePrzedmioty";
            this.dostepnePrzedmioty.PasswordChar = '\0';
            this.dostepnePrzedmioty.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dostepnePrzedmioty.SelectedText = "";
            this.dostepnePrzedmioty.SelectionLength = 0;
            this.dostepnePrzedmioty.SelectionStart = 0;
            this.dostepnePrzedmioty.ShortcutsEnabled = true;
            this.dostepnePrzedmioty.Size = new System.Drawing.Size(241, 23);
            this.dostepnePrzedmioty.TabIndex = 133;
            this.dostepnePrzedmioty.UseSelectable = true;
            this.dostepnePrzedmioty.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.dostepnePrzedmioty.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(585, 5);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(143, 20);
            this.metroLabel5.TabIndex = 134;
            this.metroLabel5.Text = "Dostępne przedmioty";
            // 
            // przedmiotyWaga
            // 
            this.przedmiotyWaga.Text = "Waga";
            this.przedmiotyWaga.Width = 300;
            // 
            // wspY
            // 
            this.wspY.Text = "Współrzędna Y";
            this.wspY.Width = 100;
            // 
            // miastaDostepnePrzedmioty
            // 
            this.miastaDostepnePrzedmioty.Text = "Dostępne przedmioty";
            this.miastaDostepnePrzedmioty.Width = 400;
            // 
            // DodaniePlikowDanych
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 712);
            this.Controls.Add(this.metroPanel1);
            this.MaximumSize = new System.Drawing.Size(1058, 759);
            this.MinimumSize = new System.Drawing.Size(1058, 759);
            this.Name = "DodaniePlikowDanych";
            this.Text = "DodaniePlikowDanych";
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.tabela.ResumeLayout(false);
            this.przedmioty.ResumeLayout(false);
            this.przedmioty.PerformLayout();
            this.miasta.ResumeLayout(false);
            this.miasta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton wygenerujPlikDanych;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTabControl tabela;
        private MetroFramework.Controls.MetroButton dodajPrzedmiot;
        protected MetroFramework.Controls.MetroListView listaPrzedmiotow;
        private System.Windows.Forms.ColumnHeader przedmiotyID;
        private System.Windows.Forms.ColumnHeader przedmiotyWartosc;
        private MetroFramework.Controls.MetroTextBox waga;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox wartosc;
        private MetroFramework.Controls.MetroTabPage miasta;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroButton stworzPlikDanych;
        private MetroFramework.Controls.MetroTabPage przedmioty;
        private MetroFramework.Controls.MetroButton usunPredmiot;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox dostepnePrzedmioty;
        private MetroFramework.Controls.MetroButton usunMiasto;
        private MetroFramework.Controls.MetroButton dodajMiasto;
        protected MetroFramework.Controls.MetroListView listaMiast;
        private System.Windows.Forms.ColumnHeader miastaID;
        private System.Windows.Forms.ColumnHeader wspX;
        private MetroFramework.Controls.MetroTextBox wsp_y;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox wsp_x;
        private System.Windows.Forms.ColumnHeader przedmiotyWaga;
        private System.Windows.Forms.ColumnHeader wspY;
        private System.Windows.Forms.ColumnHeader miastaDostepnePrzedmioty;
    }
}