using AlgorytmyDoTTP.Widoki;
using AlgorytmyDoTTP.Widoki.Narzedzia;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlgorytmyDoTTP
{
    /// <summary>
    /// Klasa widoku głownego
    /// </summary>
    public partial class StronaGlowna : Form
    {
        private FormatkaGlowna formatkaGlowna = new FormatkaGlowna();

        public StronaGlowna()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WczytajPlikiBadan();
        }

        /// <summary>
        /// Metoda wywołuje porównywanie wybranych badań
        /// </summary>
        private void porownaj_Click(object sender, EventArgs e)
        {
            int ilosc = daneHistoryczne.CheckedItems.Count;

            if (ilosc <= 10 && ilosc > 1)
            {
                try
                {
                    Rectangle ekran = Screen.FromControl(this).Bounds;

                    int szerokosc = ekran.Width,
                        wysokosc = ekran.Height - 100;

                    PomocneFunkcje narzedziaWidokow = new PomocneFunkcje();
                    FormatkaPorownania formatkaPorownania = new FormatkaPorownania();

                    string[] nazwyPlikow = new string[] { narzedziaWidokow.LosowyTekst(2, 10), narzedziaWidokow.LosowyTekst(2, 10), narzedziaWidokow.LosowyTekst(2, 10) };
                    string raport = formatkaPorownania.RysujWykres(formatkaGlowna.ZbierzDaneDoPorownania(daneHistoryczne.CheckedItems), szerokosc, wysokosc, nazwyPlikow);

                    StronaWynikow stronaWynikow = new StronaWynikow();
                    stronaWynikow.PokazWykresy(nazwyPlikow);
                    stronaWynikow.WyswietlTekst(raport);
                    stronaWynikow.Show();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(ilosc < 2)
            {
                MessageBox.Show("Nie wybrano żadnego badania lub wybrano tylko jedno!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Wybrano za dużo elementów do porównania na raz!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void podgladBadania(object sender, EventArgs e)
        {
            podglad.Text = formatkaGlowna.ZwrocDanePodgladanegoBadania(daneHistoryczne.SelectedItems);
        }

        private void usuniecieBadania_Click(object sender, EventArgs e)
        {
            if(daneHistoryczne.CheckedItems.Count > 0)
            {
                formatkaGlowna.UsunWybraneBadania(daneHistoryczne.CheckedItems);
                WczytajPlikiBadan();
            }
        }

        private void dodajBadanie_Click(object sender, EventArgs e)
        {
            StronaBadania widokBadania = new StronaBadania(this);
            widokBadania.Show();
        }

        private void WczytajPlikiBadan()
        {
            daneHistoryczne.Items.Clear();
            daneHistoryczne.Items.AddRange(formatkaGlowna.WczytajHistoryczneBadania());
        }
    }
}
