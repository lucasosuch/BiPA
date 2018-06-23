using AlgorytmyDoTTP.Widoki.Narzedzia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace AlgorytmyDoTTP.Widoki
{
    public partial class Badanie : Form
    {
        private FormatkaBadania badanie;
        private bool zapisanoBadanie = false;

        public Badanie(Dictionary<string, string> parametry)
        {
            InitializeComponent();
            badanie = new FormatkaBadania(parametry);
        }
        
        private void Badanie_Load(object sender, EventArgs e)
        {
            wynikiBadania.Text = badanie.UruchomBadanie();
        }

        private void pobierzCSV_Click(object sender, EventArgs e)
        {
            try
            {
                string pulpit = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string sciezka = Path.Combine(pulpit, badanie.ZwrocNazwePliku("csv", ""));

                File.WriteAllText(sciezka, badanie.ZwrocDaneDoCSV());
                MessageBox.Show("Pobrano plik CSV, na pulpit!", "Plik CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch(IOException exc)
            {
                Console.WriteLine(exc);
            }
        }

        private void zapiszBadanie_Click(object sender, EventArgs e)
        {
            badanie.ZapiszBadanie();
            MessageBox.Show("Zapisano badanie na dysku!", "Zapis badania", MessageBoxButtons.OK, MessageBoxIcon.Information);
            zapisanoBadanie = true;
            zapiszBadanie.Enabled = false;
            zapiszBadanie.Text = "Zapisano Badanie";
        }

        public bool CzyZapisanoBadanie()
        {
            return zapisanoBadanie;
        }
    }
}
