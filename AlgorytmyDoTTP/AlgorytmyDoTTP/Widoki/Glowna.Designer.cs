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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Glowna));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.podglad = new System.Windows.Forms.TextBox();
            this.daneHistoryczne = new MetroFramework.Controls.MetroListView();
            this.nazwaBadania = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataBadania = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.usuniecieBadania = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dodajBadanie = new MetroFramework.Controls.MetroButton();
            this.porownajBadania = new MetroFramework.Controls.MetroButton();
            this.odswiezListe = new MetroFramework.Controls.MetroButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(10, 12);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(985, 696);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // podglad
            // 
            this.podglad.BackColor = System.Drawing.SystemColors.Window;
            this.podglad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.podglad.Enabled = false;
            this.podglad.Location = new System.Drawing.Point(520, 105);
            this.podglad.Multiline = true;
            this.podglad.Name = "podglad";
            this.podglad.ReadOnly = true;
            this.podglad.Size = new System.Drawing.Size(339, 478);
            this.podglad.TabIndex = 11;
            // 
            // daneHistoryczne
            // 
            this.daneHistoryczne.AllowSorting = true;
            this.daneHistoryczne.CheckBoxes = true;
            this.daneHistoryczne.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nazwaBadania,
            this.dataBadania});
            this.daneHistoryczne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.daneHistoryczne.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.daneHistoryczne.FullRowSelect = true;
            this.daneHistoryczne.Location = new System.Drawing.Point(3, 105);
            this.daneHistoryczne.Name = "daneHistoryczne";
            this.daneHistoryczne.OwnerDraw = true;
            this.daneHistoryczne.Size = new System.Drawing.Size(511, 478);
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
            this.dataBadania.Width = 299;
            // 
            // usuniecieBadania
            // 
            this.usuniecieBadania.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usuniecieBadania.Location = new System.Drawing.Point(3, 3);
            this.usuniecieBadania.Name = "usuniecieBadania";
            this.usuniecieBadania.Size = new System.Drawing.Size(122, 18);
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.77843F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.923799F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.18054F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(862, 586);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(513, 74);
            this.label1.TabIndex = 16;
            this.label1.Text = "Historia Badań Algorytmów";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.dodajBadanie, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.porownajBadania, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.usuniecieBadania, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.odswiezListe, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 76);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(513, 24);
            this.tableLayoutPanel3.TabIndex = 13;
            // 
            // dodajBadanie
            // 
            this.dodajBadanie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dodajBadanie.Location = new System.Drawing.Point(131, 3);
            this.dodajBadanie.Name = "dodajBadanie";
            this.dodajBadanie.Size = new System.Drawing.Size(122, 18);
            this.dodajBadanie.TabIndex = 11;
            this.dodajBadanie.Text = "Dodaj Badanie";
            this.dodajBadanie.UseSelectable = true;
            this.dodajBadanie.Click += new System.EventHandler(this.dodajBadanie_Click);
            // 
            // porownajBadania
            // 
            this.porownajBadania.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porownajBadania.Location = new System.Drawing.Point(259, 3);
            this.porownajBadania.Name = "porownajBadania";
            this.porownajBadania.Size = new System.Drawing.Size(122, 18);
            this.porownajBadania.TabIndex = 10;
            this.porownajBadania.Text = "Porównaj Badania";
            this.porownajBadania.UseSelectable = true;
            this.porownajBadania.Click += new System.EventHandler(this.porownaj_Click);
            // 
            // odswiezListe
            // 
            this.odswiezListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.odswiezListe.Location = new System.Drawing.Point(386, 2);
            this.odswiezListe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.odswiezListe.Name = "odswiezListe";
            this.odswiezListe.Size = new System.Drawing.Size(125, 20);
            this.odswiezListe.TabIndex = 12;
            this.odswiezListe.Text = "Odśwież listę";
            this.odswiezListe.UseSelectable = true;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(519, 2);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(341, 70);
            this.textBox2.TabIndex = 15;
            // 
            // Glowna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(862, 586);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.metroPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Glowna";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Oprogramowanie do badania i porównywania algorytmów";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        protected MetroFramework.Controls.MetroListView daneHistoryczne;
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
        private MetroFramework.Controls.MetroButton odswiezListe;
    }
}

