using AlgorytmyDoTTP.Widoki;
using AlgorytmyDoTTP.Widoki.Narzedzia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace AlgorytmyDoTTP
{
    /// <summary>
    /// Klasa widoku głownego
    /// </summary>
    public partial class Glowna : Form
    {
        private FormatkaGlowna glowna = new FormatkaGlowna();

        public Glowna()
        {
            InitializeComponent();
            UstawWartosciDomyslne();
        }

        /// <summary>
        /// Metoda ustawia wartości domyślne aplikacji
        /// </summary>
        private void UstawWartosciDomyslne()
        {
            wyborAlgorytmu.Items.AddRange(glowna.ZwrocZmiennaSrodowiskowa().ALGORYTMY);
            wybierzProblem.Items.AddRange(glowna.ZwrocZmiennaSrodowiskowa().PROBLEMY_OPTYMALIZACYJNE);
            wybierzProblemDoKonfiguracji.Items.AddRange(glowna.ZwrocZmiennaSrodowiskowa().PROBLEMY_OPTYMALIZACYJNE);
            rodzajKrzyzowania.Items.AddRange(glowna.ZwrocKonfiguracjeAE().KRZYZOWANIE_WEKTORA);
            metodaSelekcji.Items.AddRange(glowna.ZwrocKonfiguracjeAE().SELEKCJA);
            metodaSelekcji.Text = (string)glowna.ZwrocKonfiguracjeAE().SELEKCJA[0];
            rodzajKrzyzowania.Text = (string)glowna.ZwrocKonfiguracjeAE().KRZYZOWANIE_WEKTORA[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WczytajPlikiBadan();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        /// <summary>
        /// Metoda uruchamia badanie
        /// </summary>
        private void start_Click(object sender, EventArgs e)
        {
            try
            {
                Badanie widokBadania = new Badanie(ZwrocParametry());
                widokBadania.Show();
                
            } catch(Exception exc)
            {
                string wiadomosc = "Wystąpił błąd w formularzu, sprawdź go jeszcze raz!" + Environment.NewLine  + exc;
                MessageBox.Show(wiadomosc, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            start.Text = "Uruchom";
            start.Enabled = true;
        }

        /// <summary>
        /// Metoda zmienia panela w widoku głównym pod Algorytm
        /// </summary>
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

        /// <summary>
        /// Metoda zwraca parametry Algorytmu oraz Problemu Optymalizacyjnego
        /// </summary>
        /// <returns>Parametry Algorytmu oraz Problemu Optymalizacyjnego</returns>
        private Dictionary<string, string> ZwrocParametry()
        {
            start.Text = "Trwa Badanie...";
            start.Enabled = false;
            Dictionary<string, string> parametry = new Dictionary<string, string>();

            switch (wybierzProblem.Text)
            {
                case "Problem Podróżującego Złodzieja":
                    parametry["ograniczenie1"] = maxWaga.Text;
                    parametry["wyporzyczeniePlecaka"] = wyporzyczeniePlecaka.Text;
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
                    break;
                case "Algorytm Wspinaczkowy":
                case "Algorytm Losowy":
                    parametry["iloscRozwiazan"] = iloscRozwiazan.Text;
                    break;
            }
            
            glowna.WalidacjaKluczowychParametrow(wybierzDane.Text);
            glowna.WalidacjaKluczowychParametrow(wybierzProblem.Text);
            glowna.WalidacjaKluczowychParametrow(wyborAlgorytmu.Text);
            glowna.WalidacjaKluczowychParametrow(liczbaIteracji.Text);

            parametry["dane"] = wybierzDane.Text;
            parametry["problem"] = wybierzProblem.Text;
            parametry["algorytm"] = wyborAlgorytmu.Text;
            parametry["liczbaIteracji"] = liczbaIteracji.Text;

            glowna.WalidacjaFormatki(parametry);

            return parametry;
        }

        /// <summary>
        /// Metoda zmienia panela w widoku głównym pod Problem Optymalizacyjny
        /// </summary>
        private void wybierzProblem_SelectedIndexChanged(object sender, EventArgs e)
        {
            WczytajPliki();
            panelKP.Visible = false;
            panelTTP.Visible = false;
            domyslnyProblem.Visible = false;
            wybierzDane.Enabled = true;

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

        /// <summary>
        /// Metoda wczytuje pliki danych pod wybrany Problem Optymalizacyjny
        /// </summary>
        private void WczytajPliki()
        {
            wybierzDane.Items.Clear();
            wybierzDane.Items.AddRange(glowna.WczytajPlikiDanych(wybierzProblem.Text));
        }

        /// <summary>
        /// Metoda wywołuje porównywanie wybranych badań
        /// </summary>
        private void porownaj_Click(object sender, EventArgs e)
        {
            int ilosc = daneHistoryczne.CheckedItems.Count;

            if (ilosc <= 10 && ilosc > 1)
            {
                Porownanie porownanieTemp = new Porownanie(glowna.ZbierzDaneDoPorownania(daneHistoryczne.CheckedItems));
                if(!porownanieTemp.ZwrocBladPlikuDanych())
                {
                    porownanieTemp.Show();
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

        /// <summary>
        /// Metoda ustawia wartości parametrów w zależności od wybranego Problemu Optymalizacyjnego
        /// </summary>
        /// <param name="dane"></param>
        private void UstawRodzajKrzyzowania(object[] dane)
        {
            rodzajKrzyzowania.Items.Clear();
            rodzajKrzyzowania.Items.AddRange(dane);
            rodzajKrzyzowania.Text = (string)dane[0];
        }

        /// <summary>
        /// Metoda wczytuje historyczne badania po zmianie karty
        /// </summary>
        private void zmienKarte(object sender, TabControlCancelEventArgs e)
        {
            WczytajPlikiBadan();
        }

        private void podgladBadania(object sender, EventArgs e)
        {
            podglad.Text = glowna.ZwrocDanePodgladanegoBadania(daneHistoryczne.SelectedItems);
        }

        private void usuniecieBadania_Click(object sender, EventArgs e)
        {
            if(daneHistoryczne.CheckedItems.Count > 0)
            {
                glowna.UsunWybraneBadania(daneHistoryczne.CheckedItems);
                WczytajPlikiBadan();
            }
        }

        private void WczytajPlikiBadan()
        {
            daneHistoryczne.Items.Clear();
            daneHistoryczne.Items.AddRange(glowna.WczytajHistoryczneBadania());
        }

        private void wybierzProblemDoKonfiguracji_SelectedIndexChanged(object sender, EventArgs e)
        {
            konfiguracjaTSP.Visible = false;
            konfiguracjaKP.Visible = false;
            konfiguracjaTTP.Visible = false;
            domyslnaKonfiguracja.Visible = false;

            switch(wybierzProblemDoKonfiguracji.Text)
            {
                case "Problem Komiwojażera":
                    konfiguracjaTSP.Visible = true;
                    break;
                case "Problem Plecakowy":
                    konfiguracjaKP.Visible = true;
                    break;
                case "Problem Podróżującego Złodzieja":
                    konfiguracjaTTP.Visible = true;
                    break;
            }
        }

        private void zapiszKonfigurację_Click(object sender, EventArgs e)
        {
            int liczbaMiast = 0,
                liczbaPrzedmiotow = 0,
                procentRozrzutuWartosci = 0;

            double sumaWagPrzedmiotow = 0,
                   sumaWartosciPrzedmiotow = 0;

            switch (wybierzProblemDoKonfiguracji.Text)
            {
                case "Problem Komiwojażera":
                    liczbaMiast = int.Parse(tsp_liczbaMiast.Text);

                    glowna.generujDanePodTSP(liczbaMiast, tsp_typSiatki.Text);
                    break;
                case "Problem Plecakowy":
                    liczbaPrzedmiotow = int.Parse(kp_liczbaPrzedmiotow.Text);
                    sumaWagPrzedmiotow = double.Parse(kp_sumaWag.Text);
                    sumaWartosciPrzedmiotow = double.Parse(kp_sumaWartosci.Text);
                    procentRozrzutuWartosci = int.Parse(kp_procentRozrzutu.Text);

                    glowna.generujDanePodKP(sumaWagPrzedmiotow, sumaWartosciPrzedmiotow, liczbaPrzedmiotow, procentRozrzutuWartosci);
                    break;
                case "Problem Podróżującego Złodzieja":
                    liczbaMiast = int.Parse(ttp_liczbaMiast.Text);
                    liczbaPrzedmiotow = int.Parse(ttp_liczbaPrzedmiotow.Text);
                    sumaWagPrzedmiotow = double.Parse(ttp_sumaWag.Text);
                    sumaWartosciPrzedmiotow = double.Parse(ttp_sumaWartosci.Text);
                    procentRozrzutuWartosci = int.Parse(ttp_procentRozrzutu.Text);

                    glowna.generujDanePodTTP(liczbaMiast, ttp_typSiatki.Text, sumaWagPrzedmiotow, sumaWartosciPrzedmiotow, liczbaPrzedmiotow, procentRozrzutuWartosci);
                    break;
            }
        }
    }
}
