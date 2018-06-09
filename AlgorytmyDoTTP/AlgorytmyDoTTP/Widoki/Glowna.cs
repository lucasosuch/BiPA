using AlgorytmyDoTTP.Widoki;
using AlgorytmyDoTTP.Widoki.Narzedzia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace AlgorytmyDoTTP
{
    public partial class Glowna : Form
    {
        private FormatkaGlowna glowna = new FormatkaGlowna();

        public Glowna()
        {
            InitializeComponent();
            UstawWartosciDomyslne();
        }

        private void UstawWartosciDomyslne()
        {
            wyborAlgorytmu.Items.AddRange(glowna.ZwrocZmiennaSrodowiskowa().ALGORYTMY);
            wybierzProblem.Items.AddRange(glowna.ZwrocZmiennaSrodowiskowa().PROBLEMY_OPTYMALIZACYJNE);
            rodzajKrzyzowania.Items.AddRange(glowna.ZwrocKonfiguracjeAE().KRZYZOWANIE_WEKTORA);
            metodaSelekcji.Items.AddRange(glowna.ZwrocKonfiguracjeAE().SELEKCJA);
            metodaSelekcji.Text = (string)glowna.ZwrocKonfiguracjeAE().SELEKCJA[0];
            rodzajKrzyzowania.Text = (string)glowna.ZwrocKonfiguracjeAE().KRZYZOWANIE_WEKTORA[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            daneHistoryczne.Items.AddRange(glowna.WczytajHistoryczneBadania());
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void start_Click(object sender, EventArgs e)
        {
            try
            {
                Badanie widokBadania = new Badanie(ZwrocParametry());
                widokBadania.Show();
            } catch(Exception exc)
            {
                Console.WriteLine(exc);
                MessageBox.Show("Wystąpił błąd w formularzu, sprawdź go jeszcze raz!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void wyborAlgorytmu_SelectedIndexChanged(object sender, EventArgs e)
        {
            domyslny.Visible = false;
            ewolucyjny.Visible = false;
            wspinaczkowy_losowy.Visible = false;

            switch (wyborAlgorytmu.Text)
            {
                case "Algorytm Ewolucyjny":
                    ewolucyjny.Visible = true;
                    break;

                case "Algorytm Wspinaczkowy":
                case "Algorytm Losowy":
                    wspinaczkowy_losowy.Visible = true;
                    ewolucyjny.Visible = true;
                    break;

                default:
                    domyslny.Visible = true;
                    break;
            }
        }

        private Dictionary<string, string> ZwrocParametry()
        {
            Dictionary<string, string> parametry = new Dictionary<string, string>();

            switch (wybierzProblem.Text)
            {
                case "Problem Podróżującego Złodzieja":
                    parametry["ograniczenie1"] = maxWaga.Text;
                    parametry["wyporzyczeniePlecaka"] = wyporzyczeniePlecaka.Text;
                    parametry["przypadekTTP"] = przypadekTTP.Text;
                    break;
                case "Problem Plecakowy":
                    parametry["ograniczenie1"] = maxWaga.Text;
                    break;
                default:
                    parametry["ograniczenie1"] = "0";
                    break;
            }

            switch (wyborAlgorytmu.Text)
            {
                case "Algorytm Ewolucyjny":
                    parametry["pwoMutacji"] = pwoMutacji.Text;
                    parametry["pwoKrzyzowania"] = pwoKrzyzowania.Text;
                    parametry["rozmiarPopulacji"] = rozmiarPopulacji.Text;
                    parametry["iloscPokolen"] = iloscPokolen.Text;
                    parametry["metodaSelekcji"] = metodaSelekcji.Text;
                    parametry["rodzajKrzyzowania"] = rodzajKrzyzowania.Text;
                    glowna.WalidacjaFormatki(parametry);
                    break;
                case "Algorytm Wspinaczkowy":
                case "Algorytm Losowy":
                    parametry["iloscRozwiazan"] = iloscRozwiazan.Text;
                    break;
            }

            parametry["dane"] = wybierzDane.Text;
            parametry["problem"] = wybierzProblem.Text;
            parametry["algorytm"] = wyborAlgorytmu.Text;

            return parametry;
        }
        
        private void wybierzProblem_SelectedIndexChanged(object sender, EventArgs e)
        {
            WczytajPliki();
            panelKP.Visible = false;
            panelTTP.Visible = false;
            domyslnyProblem.Visible = false;

            switch (wybierzProblem.Text)
            {
                case "Problem Komiwojażera":
                    UstawRodzajKrzyzowania(glowna.ZwrocKonfiguracjeAE().KRZYZOWANIE_TSP);
                    domyslnyProblem.Visible = true;
                    break;
                case "Problem Plecakowy":
                    UstawRodzajKrzyzowania(glowna.ZwrocKonfiguracjeAE().KRZYZOWANIE_WEKTORA);
                    panelKP.Visible = true;
                    break;
                case "Problem Podróżującego Złodzieja":
                    UstawRodzajKrzyzowania(glowna.ZwrocKonfiguracjeAE().KRZYZOWANIE_TSP);
                    panelKP.Visible = true;
                    panelTTP.Visible = true;
                    break;
            }
        }

        private void WczytajPliki()
        {
            wybierzDane.Items.Clear();
            wybierzDane.Items.AddRange(glowna.WczytajPlikiDanych(wybierzProblem.Text));
        }

        private void porownaj_Click(object sender, EventArgs e)
        {
            int ilosc = daneHistoryczne.CheckedItems.Count;

            if (ilosc <= 5 && ilosc > 0)
            {
                Porownanie porownanieTemp = new Porownanie(glowna.ZbierzDaneDoPorownania(daneHistoryczne.CheckedItems));
                porownanieTemp.Show();
            }
            else if(ilosc == 0)
            {
                MessageBox.Show("Nie wybrano żadnego elementu!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Wybrano za dużo elementów do porównania na raz!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UstawRodzajKrzyzowania(object[] dane)
        {
            rodzajKrzyzowania.Items.Clear();
            rodzajKrzyzowania.Items.AddRange(dane);
            rodzajKrzyzowania.Text = (string)dane[0];
        }
    }
}
