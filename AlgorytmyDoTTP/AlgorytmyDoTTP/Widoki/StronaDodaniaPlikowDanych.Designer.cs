namespace BiPA.Widoki
{
    partial class StronaDodaniaPlikowDanych
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StronaDodaniaPlikowDanych));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.usunPlik = new MetroFramework.Controls.MetroButton();
            this.tabela = new MetroFramework.Controls.MetroTabControl();
            this.przedmioty = new MetroFramework.Controls.MetroTabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.kp_sumaWag = new MetroFramework.Controls.MetroTextBox();
            this.kp_sumaWartosci = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.usunPredmiot = new MetroFramework.Controls.MetroButton();
            this.dodajPrzedmiot = new MetroFramework.Controls.MetroButton();
            this.listaPrzedmiotow = new MetroFramework.Controls.MetroListView();
            this.przedmiotyID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.przedmiotyWartosc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.przedmiotyWaga = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.waga = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.wartosc = new MetroFramework.Controls.MetroTextBox();
            this.miasta = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.ttp_sumaWag = new MetroFramework.Controls.MetroTextBox();
            this.ttp_sumaWartosci = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.dostepnePrzedmioty = new MetroFramework.Controls.MetroTextBox();
            this.usunMiasto = new MetroFramework.Controls.MetroButton();
            this.stworzPlikDanych = new MetroFramework.Controls.MetroButton();
            this.dodajMiasto = new MetroFramework.Controls.MetroButton();
            this.listaMiast = new MetroFramework.Controls.MetroListView();
            this.miastaID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wspX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wspY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.miastaDostepnePrzedmioty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wsp_y = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.wsp_x = new MetroFramework.Controls.MetroTextBox();
            this.wygenerujPlikDanych = new MetroFramework.Controls.MetroButton();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.plikiDanych = new MetroFramework.Controls.MetroComboBox();
            this.metroPanel1.SuspendLayout();
            this.tabela.SuspendLayout();
            this.przedmioty.SuspendLayout();
            this.miasta.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.usunPlik);
            this.metroPanel1.Controls.Add(this.tabela);
            this.metroPanel1.Controls.Add(this.wygenerujPlikDanych);
            this.metroPanel1.Controls.Add(this.metroLabel6);
            this.metroPanel1.Controls.Add(this.label1);
            this.metroPanel1.Controls.Add(this.plikiDanych);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1040, 723);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 11;
            this.metroPanel1.Click += new System.EventHandler(this.metroPanel1_Click);
            // 
            // usunPlik
            // 
            this.usunPlik.Enabled = false;
            this.usunPlik.Location = new System.Drawing.Point(616, 52);
            this.usunPlik.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usunPlik.Name = "usunPlik";
            this.usunPlik.Size = new System.Drawing.Size(165, 36);
            this.usunPlik.TabIndex = 130;
            this.usunPlik.Text = "Usuń plik";
            this.usunPlik.UseSelectable = true;
            this.usunPlik.Click += new System.EventHandler(this.usunPlik_Click);
            // 
            // tabela
            // 
            this.tabela.Controls.Add(this.przedmioty);
            this.tabela.Controls.Add(this.miasta);
            this.tabela.Location = new System.Drawing.Point(11, 108);
            this.tabela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabela.Name = "tabela";
            this.tabela.SelectedIndex = 0;
            this.tabela.Size = new System.Drawing.Size(1019, 604);
            this.tabela.TabIndex = 116;
            this.tabela.UseSelectable = true;
            // 
            // przedmioty
            // 
            this.przedmioty.Controls.Add(this.textBox1);
            this.przedmioty.Controls.Add(this.metroLabel9);
            this.przedmioty.Controls.Add(this.kp_sumaWag);
            this.przedmioty.Controls.Add(this.kp_sumaWartosci);
            this.przedmioty.Controls.Add(this.metroLabel8);
            this.przedmioty.Controls.Add(this.metroLabel7);
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
            this.przedmioty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.przedmioty.Name = "przedmioty";
            this.przedmioty.Size = new System.Drawing.Size(1011, 562);
            this.przedmioty.TabIndex = 0;
            this.przedmioty.Text = "Przedmioty";
            this.przedmioty.VerticalScrollbarBarColor = true;
            this.przedmioty.VerticalScrollbarHighlightOnWheel = false;
            this.przedmioty.VerticalScrollbarSize = 11;
            this.przedmioty.Click += new System.EventHandler(this.przedmioty_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(511, 477);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(496, 82);
            this.textBox1.TabIndex = 130;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(277, 480);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(75, 20);
            this.metroLabel9.TabIndex = 129;
            this.metroLabel9.Text = "Suma wag:";
            // 
            // kp_sumaWag
            // 
            // 
            // 
            // 
            this.kp_sumaWag.CustomButton.Image = null;
            this.kp_sumaWag.CustomButton.Location = new System.Drawing.Point(102, 1);
            this.kp_sumaWag.CustomButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.kp_sumaWag.CustomButton.Name = "";
            this.kp_sumaWag.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.kp_sumaWag.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.kp_sumaWag.CustomButton.TabIndex = 1;
            this.kp_sumaWag.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.kp_sumaWag.CustomButton.UseSelectable = true;
            this.kp_sumaWag.CustomButton.Visible = false;
            this.kp_sumaWag.Enabled = false;
            this.kp_sumaWag.Lines = new string[] {
        "0"};
            this.kp_sumaWag.Location = new System.Drawing.Point(380, 480);
            this.kp_sumaWag.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kp_sumaWag.MaxLength = 32767;
            this.kp_sumaWag.Multiline = true;
            this.kp_sumaWag.Name = "kp_sumaWag";
            this.kp_sumaWag.PasswordChar = '\0';
            this.kp_sumaWag.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.kp_sumaWag.SelectedText = "";
            this.kp_sumaWag.SelectionLength = 0;
            this.kp_sumaWag.SelectionStart = 0;
            this.kp_sumaWag.ShortcutsEnabled = true;
            this.kp_sumaWag.Size = new System.Drawing.Size(124, 23);
            this.kp_sumaWag.TabIndex = 128;
            this.kp_sumaWag.Text = "0";
            this.kp_sumaWag.UseSelectable = true;
            this.kp_sumaWag.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.kp_sumaWag.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // kp_sumaWartosci
            // 
            // 
            // 
            // 
            this.kp_sumaWartosci.CustomButton.Image = null;
            this.kp_sumaWartosci.CustomButton.Location = new System.Drawing.Point(102, 1);
            this.kp_sumaWartosci.CustomButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.kp_sumaWartosci.CustomButton.Name = "";
            this.kp_sumaWartosci.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.kp_sumaWartosci.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.kp_sumaWartosci.CustomButton.TabIndex = 1;
            this.kp_sumaWartosci.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.kp_sumaWartosci.CustomButton.UseSelectable = true;
            this.kp_sumaWartosci.CustomButton.Visible = false;
            this.kp_sumaWartosci.Enabled = false;
            this.kp_sumaWartosci.Lines = new string[] {
        "0"};
            this.kp_sumaWartosci.Location = new System.Drawing.Point(132, 480);
            this.kp_sumaWartosci.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kp_sumaWartosci.MaxLength = 32767;
            this.kp_sumaWartosci.Multiline = true;
            this.kp_sumaWartosci.Name = "kp_sumaWartosci";
            this.kp_sumaWartosci.PasswordChar = '\0';
            this.kp_sumaWartosci.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.kp_sumaWartosci.SelectedText = "";
            this.kp_sumaWartosci.SelectionLength = 0;
            this.kp_sumaWartosci.SelectionStart = 0;
            this.kp_sumaWartosci.ShortcutsEnabled = true;
            this.kp_sumaWartosci.Size = new System.Drawing.Size(124, 23);
            this.kp_sumaWartosci.TabIndex = 127;
            this.kp_sumaWartosci.Text = "0";
            this.kp_sumaWartosci.UseSelectable = true;
            this.kp_sumaWartosci.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.kp_sumaWartosci.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(148, 480);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(0, 0);
            this.metroLabel8.TabIndex = 126;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(-3, 480);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(101, 20);
            this.metroLabel7.TabIndex = 118;
            this.metroLabel7.Text = "Suma wartości:";
            // 
            // usunPredmiot
            // 
            this.usunPredmiot.Location = new System.Drawing.Point(1, 28);
            this.usunPredmiot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usunPredmiot.Name = "usunPredmiot";
            this.usunPredmiot.Size = new System.Drawing.Size(165, 23);
            this.usunPredmiot.TabIndex = 125;
            this.usunPredmiot.Text = "Usuń przedmiot";
            this.usunPredmiot.UseSelectable = true;
            this.usunPredmiot.Click += new System.EventHandler(this.usunPrzedmiot_Click);
            // 
            // dodajPrzedmiot
            // 
            this.dodajPrzedmiot.Location = new System.Drawing.Point(831, 28);
            this.dodajPrzedmiot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.listaPrzedmiotow.Size = new System.Drawing.Size(1009, 400);
            this.listaPrzedmiotow.TabIndex = 123;
            this.listaPrzedmiotow.UseCompatibleStateImageBehavior = false;
            this.listaPrzedmiotow.UseSelectable = true;
            this.listaPrzedmiotow.View = System.Windows.Forms.View.Details;
            this.listaPrzedmiotow.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.elementZaznaczonyPrzedmioty_Changed);
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
            // przedmiotyWaga
            // 
            this.przedmiotyWaga.Text = "Waga";
            this.przedmiotyWaga.Width = 300;
            // 
            // waga
            // 
            // 
            // 
            // 
            this.waga.CustomButton.Image = null;
            this.waga.CustomButton.Location = new System.Drawing.Point(109, 1);
            this.waga.CustomButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.waga.CustomButton.Name = "";
            this.waga.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.waga.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.waga.CustomButton.TabIndex = 1;
            this.waga.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.waga.CustomButton.UseSelectable = true;
            this.waga.CustomButton.Visible = false;
            this.waga.Lines = new string[0];
            this.waga.Location = new System.Drawing.Point(695, 28);
            this.waga.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.metroLabel2.Location = new System.Drawing.Point(557, 5);
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
            this.wartosc.CustomButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.wartosc.CustomButton.Name = "";
            this.wartosc.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.wartosc.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.wartosc.CustomButton.TabIndex = 1;
            this.wartosc.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.wartosc.CustomButton.UseSelectable = true;
            this.wartosc.CustomButton.Visible = false;
            this.wartosc.Lines = new string[0];
            this.wartosc.Location = new System.Drawing.Point(557, 28);
            this.wartosc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            // miasta
            // 
            this.miasta.Controls.Add(this.metroLabel10);
            this.miasta.Controls.Add(this.ttp_sumaWag);
            this.miasta.Controls.Add(this.ttp_sumaWartosci);
            this.miasta.Controls.Add(this.metroLabel11);
            this.miasta.Controls.Add(this.metroLabel12);
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
            this.miasta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.miasta.Name = "miasta";
            this.miasta.Size = new System.Drawing.Size(1011, 562);
            this.miasta.TabIndex = 1;
            this.miasta.Text = "Miasta";
            this.miasta.VerticalScrollbarBarColor = true;
            this.miasta.VerticalScrollbarHighlightOnWheel = false;
            this.miasta.VerticalScrollbarSize = 11;
            this.miasta.Click += new System.EventHandler(this.miasta_Click);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(277, 480);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(75, 20);
            this.metroLabel10.TabIndex = 139;
            this.metroLabel10.Text = "Suma wag:";
            // 
            // ttp_sumaWag
            // 
            // 
            // 
            // 
            this.ttp_sumaWag.CustomButton.Image = null;
            this.ttp_sumaWag.CustomButton.Location = new System.Drawing.Point(102, 1);
            this.ttp_sumaWag.CustomButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ttp_sumaWag.CustomButton.Name = "";
            this.ttp_sumaWag.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ttp_sumaWag.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ttp_sumaWag.CustomButton.TabIndex = 1;
            this.ttp_sumaWag.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ttp_sumaWag.CustomButton.UseSelectable = true;
            this.ttp_sumaWag.CustomButton.Visible = false;
            this.ttp_sumaWag.Enabled = false;
            this.ttp_sumaWag.Lines = new string[] {
        "0"};
            this.ttp_sumaWag.Location = new System.Drawing.Point(380, 480);
            this.ttp_sumaWag.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ttp_sumaWag.MaxLength = 32767;
            this.ttp_sumaWag.Multiline = true;
            this.ttp_sumaWag.Name = "ttp_sumaWag";
            this.ttp_sumaWag.PasswordChar = '\0';
            this.ttp_sumaWag.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ttp_sumaWag.SelectedText = "";
            this.ttp_sumaWag.SelectionLength = 0;
            this.ttp_sumaWag.SelectionStart = 0;
            this.ttp_sumaWag.ShortcutsEnabled = true;
            this.ttp_sumaWag.Size = new System.Drawing.Size(124, 23);
            this.ttp_sumaWag.TabIndex = 138;
            this.ttp_sumaWag.Text = "0";
            this.ttp_sumaWag.UseSelectable = true;
            this.ttp_sumaWag.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ttp_sumaWag.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ttp_sumaWartosci
            // 
            // 
            // 
            // 
            this.ttp_sumaWartosci.CustomButton.Image = null;
            this.ttp_sumaWartosci.CustomButton.Location = new System.Drawing.Point(102, 1);
            this.ttp_sumaWartosci.CustomButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ttp_sumaWartosci.CustomButton.Name = "";
            this.ttp_sumaWartosci.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ttp_sumaWartosci.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ttp_sumaWartosci.CustomButton.TabIndex = 1;
            this.ttp_sumaWartosci.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ttp_sumaWartosci.CustomButton.UseSelectable = true;
            this.ttp_sumaWartosci.CustomButton.Visible = false;
            this.ttp_sumaWartosci.Enabled = false;
            this.ttp_sumaWartosci.Lines = new string[] {
        "0"};
            this.ttp_sumaWartosci.Location = new System.Drawing.Point(132, 480);
            this.ttp_sumaWartosci.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ttp_sumaWartosci.MaxLength = 32767;
            this.ttp_sumaWartosci.Multiline = true;
            this.ttp_sumaWartosci.Name = "ttp_sumaWartosci";
            this.ttp_sumaWartosci.PasswordChar = '\0';
            this.ttp_sumaWartosci.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ttp_sumaWartosci.SelectedText = "";
            this.ttp_sumaWartosci.SelectionLength = 0;
            this.ttp_sumaWartosci.SelectionStart = 0;
            this.ttp_sumaWartosci.ShortcutsEnabled = true;
            this.ttp_sumaWartosci.Size = new System.Drawing.Size(124, 23);
            this.ttp_sumaWartosci.TabIndex = 137;
            this.ttp_sumaWartosci.Text = "0";
            this.ttp_sumaWartosci.UseSelectable = true;
            this.ttp_sumaWartosci.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ttp_sumaWartosci.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(149, 489);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(0, 0);
            this.metroLabel11.TabIndex = 136;
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(-3, 480);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(101, 20);
            this.metroLabel12.TabIndex = 135;
            this.metroLabel12.Text = "Suma wartości:";
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
            // dostepnePrzedmioty
            // 
            // 
            // 
            // 
            this.dostepnePrzedmioty.CustomButton.Image = null;
            this.dostepnePrzedmioty.CustomButton.Location = new System.Drawing.Point(219, 1);
            this.dostepnePrzedmioty.CustomButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dostepnePrzedmioty.CustomButton.Name = "";
            this.dostepnePrzedmioty.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.dostepnePrzedmioty.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.dostepnePrzedmioty.CustomButton.TabIndex = 1;
            this.dostepnePrzedmioty.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dostepnePrzedmioty.CustomButton.UseSelectable = true;
            this.dostepnePrzedmioty.CustomButton.Visible = false;
            this.dostepnePrzedmioty.Enabled = false;
            this.dostepnePrzedmioty.Lines = new string[0];
            this.dostepnePrzedmioty.Location = new System.Drawing.Point(585, 28);
            this.dostepnePrzedmioty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            // usunMiasto
            // 
            this.usunMiasto.Location = new System.Drawing.Point(1, 28);
            this.usunMiasto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usunMiasto.Name = "usunMiasto";
            this.usunMiasto.Size = new System.Drawing.Size(165, 23);
            this.usunMiasto.TabIndex = 132;
            this.usunMiasto.Text = "Usuń miasto";
            this.usunMiasto.UseSelectable = true;
            this.usunMiasto.Click += new System.EventHandler(this.usunMiasto_Click);
            // 
            // stworzPlikDanych
            // 
            this.stworzPlikDanych.Enabled = false;
            this.stworzPlikDanych.Location = new System.Drawing.Point(831, 469);
            this.stworzPlikDanych.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stworzPlikDanych.Name = "stworzPlikDanych";
            this.stworzPlikDanych.Size = new System.Drawing.Size(176, 32);
            this.stworzPlikDanych.TabIndex = 123;
            this.stworzPlikDanych.Text = "Stwórz plik danch";
            this.stworzPlikDanych.UseSelectable = true;
            this.stworzPlikDanych.Click += new System.EventHandler(this.stworzPlikDanych_Click);
            // 
            // dodajMiasto
            // 
            this.dodajMiasto.Location = new System.Drawing.Point(831, 28);
            this.dodajMiasto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.listaMiast.Size = new System.Drawing.Size(1009, 400);
            this.listaMiast.TabIndex = 130;
            this.listaMiast.UseCompatibleStateImageBehavior = false;
            this.listaMiast.UseSelectable = true;
            this.listaMiast.View = System.Windows.Forms.View.Details;
            this.listaMiast.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.elementZaznaczonyMiasta_Changed);
            // 
            // miastaID
            // 
            this.miastaID.Text = "Indeks";
            this.miastaID.Width = 150;
            // 
            // wspX
            // 
            this.wspX.Text = "Współrzędna X";
            this.wspX.Width = 96;
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
            // wsp_y
            // 
            // 
            // 
            // 
            this.wsp_y.CustomButton.Image = null;
            this.wsp_y.CustomButton.Location = new System.Drawing.Point(109, 1);
            this.wsp_y.CustomButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.wsp_y.CustomButton.Name = "";
            this.wsp_y.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.wsp_y.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.wsp_y.CustomButton.TabIndex = 1;
            this.wsp_y.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.wsp_y.CustomButton.UseSelectable = true;
            this.wsp_y.CustomButton.Visible = false;
            this.wsp_y.Lines = new string[0];
            this.wsp_y.Location = new System.Drawing.Point(448, 28);
            this.wsp_y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.wsp_x.CustomButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.wsp_x.CustomButton.Name = "";
            this.wsp_x.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.wsp_x.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.wsp_x.CustomButton.TabIndex = 1;
            this.wsp_x.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.wsp_x.CustomButton.UseSelectable = true;
            this.wsp_x.CustomButton.Visible = false;
            this.wsp_x.Lines = new string[0];
            this.wsp_x.Location = new System.Drawing.Point(311, 28);
            this.wsp_x.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            // wygenerujPlikDanych
            // 
            this.wygenerujPlikDanych.BackColor = System.Drawing.SystemColors.Control;
            this.wygenerujPlikDanych.Location = new System.Drawing.Point(787, 52);
            this.wygenerujPlikDanych.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wygenerujPlikDanych.Name = "wygenerujPlikDanych";
            this.wygenerujPlikDanych.Size = new System.Drawing.Size(235, 36);
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
            // plikiDanych
            // 
            this.plikiDanych.FormattingEnabled = true;
            this.plikiDanych.ItemHeight = 24;
            this.plikiDanych.Location = new System.Drawing.Point(187, 52);
            this.plikiDanych.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.plikiDanych.Name = "plikiDanych";
            this.plikiDanych.Size = new System.Drawing.Size(423, 30);
            this.plikiDanych.TabIndex = 117;
            this.plikiDanych.UseSelectable = true;
            this.plikiDanych.SelectedIndexChanged += new System.EventHandler(this.plikiDanych_SelectedIndexChanged);
            // 
            // StronaDodaniaPlikowDanych
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 723);
            this.Controls.Add(this.metroPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1058, 770);
            this.MinimumSize = new System.Drawing.Size(1058, 770);
            this.Name = "StronaDodaniaPlikowDanych";
            this.Text = "BiPA - Dodanie Plików Danych";
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
        private MetroFramework.Controls.MetroTextBox kp_sumaWag;
        private MetroFramework.Controls.MetroTextBox kp_sumaWartosci;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroButton usunPlik;
        public MetroFramework.Controls.MetroComboBox plikiDanych;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox ttp_sumaWag;
        private MetroFramework.Controls.MetroTextBox ttp_sumaWartosci;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private System.Windows.Forms.TextBox textBox1;
    }
}