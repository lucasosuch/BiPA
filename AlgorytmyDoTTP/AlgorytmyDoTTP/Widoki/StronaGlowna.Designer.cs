namespace AlgorytmyDoTTP
{
    partial class StronaGlowna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StronaGlowna));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.podglad = new System.Windows.Forms.TextBox();
            this.daneHistoryczne = new MetroFramework.Controls.MetroListView();
            this.nazwaBadania = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataBadania = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.skroconaNazwa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.usuniecieBadania = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dodajBadanie = new MetroFramework.Controls.MetroButton();
            this.porownajBadania = new MetroFramework.Controls.MetroButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 12;
            this.metroPanel1.Location = new System.Drawing.Point(13, 15);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1313, 857);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 13;
            // 
            // podglad
            // 
            this.podglad.BackColor = System.Drawing.SystemColors.Window;
            this.podglad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.podglad.Location = new System.Drawing.Point(791, 148);
            this.podglad.Margin = new System.Windows.Forms.Padding(4);
            this.podglad.Multiline = true;
            this.podglad.Name = "podglad";
            this.podglad.ReadOnly = true;
            this.podglad.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.podglad.Size = new System.Drawing.Size(517, 662);
            this.podglad.TabIndex = 11;
            // 
            // daneHistoryczne
            // 
            this.daneHistoryczne.AllowSorting = true;
            this.daneHistoryczne.CheckBoxes = true;
            this.daneHistoryczne.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nazwaBadania,
            this.dataBadania,
            this.skroconaNazwa});
            this.daneHistoryczne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.daneHistoryczne.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.daneHistoryczne.FullRowSelect = true;
            this.daneHistoryczne.Location = new System.Drawing.Point(4, 148);
            this.daneHistoryczne.Margin = new System.Windows.Forms.Padding(4);
            this.daneHistoryczne.Name = "daneHistoryczne";
            this.daneHistoryczne.OwnerDraw = true;
            this.daneHistoryczne.Size = new System.Drawing.Size(779, 662);
            this.daneHistoryczne.TabIndex = 2;
            this.daneHistoryczne.UseCompatibleStateImageBehavior = false;
            this.daneHistoryczne.UseSelectable = true;
            this.daneHistoryczne.View = System.Windows.Forms.View.Details;
            this.daneHistoryczne.SelectedIndexChanged += new System.EventHandler(this.podgladBadania);
            // 
            // nazwaBadania
            // 
            this.nazwaBadania.Text = "Nazwa Badania";
            this.nazwaBadania.Width = 375;
            // 
            // dataBadania
            // 
            this.dataBadania.Text = "Data Badania";
            this.dataBadania.Width = 150;
            // 
            // skroconaNazwa
            // 
            this.skroconaNazwa.Text = "Skrócona nazwa";
            this.skroconaNazwa.Width = 150;
            // 
            // usuniecieBadania
            // 
            this.usuniecieBadania.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usuniecieBadania.Location = new System.Drawing.Point(4, 4);
            this.usuniecieBadania.Margin = new System.Windows.Forms.Padding(4);
            this.usuniecieBadania.Name = "usuniecieBadania";
            this.usuniecieBadania.Size = new System.Drawing.Size(252, 28);
            this.usuniecieBadania.TabIndex = 9;
            this.usuniecieBadania.Text = "Usuń Badanie";
            this.usuniecieBadania.UseSelectable = true;
            this.usuniecieBadania.Click += new System.EventHandler(this.usuniecieBadania_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.daneHistoryczne, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.podglad, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.77843F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.923799F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.18054F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1312, 814);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(781, 104);
            this.label1.TabIndex = 16;
            this.label1.Text = "Historia Badań Algorytmów";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.dodajBadanie, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.porownajBadania, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.usuniecieBadania, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 106);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(781, 36);
            this.tableLayoutPanel3.TabIndex = 13;
            // 
            // dodajBadanie
            // 
            this.dodajBadanie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dodajBadanie.Location = new System.Drawing.Point(264, 4);
            this.dodajBadanie.Margin = new System.Windows.Forms.Padding(4);
            this.dodajBadanie.Name = "dodajBadanie";
            this.dodajBadanie.Size = new System.Drawing.Size(252, 28);
            this.dodajBadanie.TabIndex = 11;
            this.dodajBadanie.Text = "Dodaj Badanie";
            this.dodajBadanie.UseSelectable = true;
            this.dodajBadanie.Click += new System.EventHandler(this.dodajBadanie_Click);
            // 
            // porownajBadania
            // 
            this.porownajBadania.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porownajBadania.Location = new System.Drawing.Point(524, 4);
            this.porownajBadania.Margin = new System.Windows.Forms.Padding(4);
            this.porownajBadania.Name = "porownajBadania";
            this.porownajBadania.Size = new System.Drawing.Size(253, 28);
            this.porownajBadania.TabIndex = 10;
            this.porownajBadania.Text = "Porównaj Badania";
            this.porownajBadania.UseSelectable = true;
            this.porownajBadania.Click += new System.EventHandler(this.porownaj_Click);
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(790, 2);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(519, 100);
            this.textBox2.TabIndex = 15;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(790, 107);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(519, 34);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "UWAGA! W aplikacji obowiązują liczby zmiennoprzecinkowe w formacie z przecinkiem," +
    " a nie z kropką np. 0,5.W razie kłopotów proszę zmienić format liczb zmiennoprze" +
    "cinkowych w preferencjach Windows";
            // 
            // StronaGlowna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1312, 814);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.metroPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "StronaGlowna";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "BiPA - Oprogramowanie do badania i porównywania algorytmów";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.ColumnHeader nazwaBadania;
        private System.Windows.Forms.ColumnHeader dataBadania;
        private MetroFramework.Controls.MetroButton usuniecieBadania;
        private System.Windows.Forms.TextBox podglad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MetroFramework.Controls.MetroButton dodajBadanie;
        private MetroFramework.Controls.MetroButton porownajBadania;
        private System.Windows.Forms.Label label1;
        public MetroFramework.Controls.MetroListView daneHistoryczne;
        private System.Windows.Forms.ColumnHeader skroconaNazwa;
        private System.Windows.Forms.TextBox textBox1;
    }
}

