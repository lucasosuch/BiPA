using AlgorytmyDoTTP.Widoki.Narzedzia;
using System.Windows.Forms;

namespace AlgorytmyDoTTP.Widoki
{
    public partial class GenerowaniePlikow : Form
    {
        private DodaniePlikowDanych widokDodawaniaPlikow;

        public GenerowaniePlikow(DodaniePlikowDanych widokDodawaniaPlikow)
        {
            InitializeComponent();
            this.widokDodawaniaPlikow = widokDodawaniaPlikow;
        }

        private void zapiszPlik_Click(object sender, System.EventArgs e)
        {
            int liczbaMiast = 0,
                liczbaPrzedmiotow = 0,
                procentRozrzutuWartosci = 0;

            float sumaWagPrzedmiotow = 0,
                   sumaWartosciPrzedmiotow = 0;
            
            liczbaMiast = int.Parse(ttp_liczbaMiast.Text);
            liczbaPrzedmiotow = int.Parse(ttp_liczbaPrzedmiotow.Text);
            sumaWagPrzedmiotow = float.Parse(ttp_sumaWag.Text);
            sumaWartosciPrzedmiotow = float.Parse(ttp_sumaWartosci.Text);
            procentRozrzutuWartosci = int.Parse(ttp_procentRozrzutu.Text);

            widokDodawaniaPlikow.plikiDanych.Items.Insert(0, (new FormatkaDanych()).generujDanePodTTP(liczbaMiast, ttp_typSiatki.Text, sumaWagPrzedmiotow, sumaWartosciPrzedmiotow, liczbaPrzedmiotow, procentRozrzutuWartosci));
            MessageBox.Show("Wygenerowno plik danych!", "Nowy plik danych", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
