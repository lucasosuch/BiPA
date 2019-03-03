using AlgorytmyDoTTP.Widoki.Narzedzia;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace AlgorytmyDoTTP.Widoki
{
    /// <summary>
    /// Klasa widoku badania
    /// </summary>
    public partial class StronaBadania : Form
    {
        private string[] nazwyPlikow;
        private bool narysowanoWykres = false;
        private StronaGlowna stronaGlowna;
        private PomocneFunkcje narzedziaWidokow = new PomocneFunkcje();
        private FormatkaBadania formatkaBadania = new FormatkaBadania();

        public StronaBadania(StronaGlowna stronaGlowna)
        {
            InitializeComponent();
            UstawWartosciDomyslne();
            this.stronaGlowna = stronaGlowna;
        }

        private void Badanie_Load(object sender, EventArgs e) {}

        /// <summary>
        /// Metoda ustawia wartości domyślne aplikacji
        /// </summary>
        private void UstawWartosciDomyslne()
        {
            wybierzAlgorytm.Items.AddRange(formatkaBadania.ZwrocZmiennaSrodowiskowa().ALGORYTMY);
            wybierzProblem.Items.AddRange(formatkaBadania.ZwrocZmiennaSrodowiskowa().PROBLEMY_OPTYMALIZACYJNE);
            ae_rodzajKrzyzowania.Items.AddRange(formatkaBadania.ZwrocZmiennaSrodowiskowa().KRZYZOWANIE_WEKTORA);
            ae_rodzajKrzyzowania.Text = (string)formatkaBadania.ZwrocZmiennaSrodowiskowa().KRZYZOWANIE_WEKTORA[0];
            ae_metodaSelekcji.Items.AddRange(formatkaBadania.ZwrocZmiennaSrodowiskowa().SELEKCJA);
            ae_metodaSelekcji.Text = (string)formatkaBadania.ZwrocZmiennaSrodowiskowa().SELEKCJA[0];
            modelTTP.Items.AddRange(formatkaBadania.ZwrocZmiennaSrodowiskowa().MODELE_TTP);
            modelTTP.Text = (string)formatkaBadania.ZwrocZmiennaSrodowiskowa().MODELE_TTP[0];
        }

        /// <summary>
        /// Metoda zwraca parametry Algorytmu oraz Problemu Optymalizacyjnego
        /// </summary>
        /// <returns>Parametry Algorytmu oraz Problemu Optymalizacyjnego</returns>
        private Dictionary<string, string> ZwrocParametry()
        {
            Dictionary<string, string> parametry = new Dictionary<string, string>();

            parametry["doPorownania"] = "";
            switch (wybierzProblem.Text)
            {
                case "Problem Podróżującego Złodzieja":
                    parametry["modelTTP"] = modelTTP.Text;
                    parametry["maxWaga"] = ttp_maxWagaPlecaka.Text.Replace('.', ',');
                    parametry["wyporzyczeniePlecaka"] = wypozyczeniePlecaka.Text;
                    parametry["doPorownania"] = "TTP";
                    break;
                case "Problem Plecakowy":
                    parametry["maxWaga"] = kp_maxWagaPlecaka.Text;
                    parametry["doPorownania"] = "KP";
                    break;
                case "Problem Komiwojażera":
                    parametry["maxWaga"] = "0";
                    parametry["doPorownania"] = "TSP";
                    break;
            }

            switch (wybierzAlgorytm.Text)
            {
                case "Algorytm Ewolucyjny":
                    parametry["doPorownania"] += "_AE";
                    parametry["pwoMutacji"] = ae_pwoMutacji.Text.Replace('.', ',');
                    parametry["pwoKrzyzowania"] = ae_pwoKrzyzowania.Text.Replace('.', ',');
                    parametry["rozmiarPopulacji"] = ae_rozmiarPopulacji.Text;
                    parametry["metodaSelekcji"] = ae_metodaSelekcji.Text;
                    parametry["rodzajKrzyzowania"] = ae_rodzajKrzyzowania.Text;
                    break;
                case "Algorytm Wspinaczkowy":
                    parametry["doPorownania"] += "_AW";
                    parametry["parametrP"] = aw_parametrP.Text;
                    break;
                case "Algorytm Losowy":
                    parametry["doPorownania"] += "_AL";
                    break;
            }

            parametry["doPorownania"] += "_"+narzedziaWidokow.LosowyTekst(3, 3);

            parametry["dane"] = wybierzPlikDanych.Text;
            parametry["problem"] = wybierzProblem.Text;
            parametry["algorytm"] = wybierzAlgorytm.Text;
            parametry["liczbaIteracji"] = liczbaIteracjiAlgorytmu.Text;
            parametry["czasPoszukiwania"] = czasDzialaniaAlgorytmu.Text;

            formatkaBadania.WalidacjaFormatki(parametry);

            return parametry;
        }

        /// <summary>
        /// Metoda wczytuje pliki danych pod wybrany Problem Optymalizacyjny
        /// </summary>
        private void WczytajPliki()
        {
            wybierzPlikDanych.Items.Clear();
            wybierzPlikDanych.Items.AddRange(formatkaBadania.WczytajPlikiDanych(wybierzProblem.Text));
        }

        /// <summary>
        /// Metoda ustawia wartości parametrów w zależności od wybranego Problemu Optymalizacyjnego
        /// </summary>
        /// <param name="dane"></param>
        private void UstawRodzajKrzyzowania(object[] dane)
        {
            ae_rodzajKrzyzowania.Items.Clear();
            ae_rodzajKrzyzowania.Items.AddRange(dane);
            ae_rodzajKrzyzowania.Text = (string)dane[0];
        }

        /// <summary>
        /// Metoda odpowiada za pobranie pliku CSV na pulpit
        /// </summary>
        private void pobierzCSV_Click(object sender, EventArgs e)
        {
            try
            {
                string pulpit = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string sciezka = Path.Combine(pulpit, formatkaBadania.ZwrocNazwePliku(".csv", ""));

                File.WriteAllText(sciezka, formatkaBadania.ZwrocDaneDoCSV(), System.Text.Encoding.UTF8);
                MessageBox.Show("Pobrano plik CSV, na pulpit!", "Plik CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch(IOException exc)
            {
                MessageBox.Show(exc.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metoda odpowiada za zapis pliku badania na dysku
        /// </summary>
        private void zapiszBadanie_Click(object sender, EventArgs e)
        {
            stronaGlowna.daneHistoryczne.Items.Add(new ListViewItem(formatkaBadania.ZapiszBadanie()));
            MessageBox.Show("Zapisano badanie na dysku!", "Zapis badania", MessageBoxButtons.OK, MessageBoxIcon.Information);
            zapiszBadanie.Enabled = false;
            zapiszBadanie.Text = "Zapisano Badanie";
        }

        private void rysujWykes_Click(object sender, EventArgs e)
        {
            Rectangle ekran = Screen.FromControl(this).Bounds;
            int szerokosc = ekran.Width,
                wysokosc = ekran.Height - 100;

            try
            {
                string raport = formatkaBadania.RysujWykres(narysowanoWykres, szerokosc, wysokosc, nazwyPlikow);

                if (!narysowanoWykres) narysowanoWykres = true;

                StronaWynikow rezultatBadania = new StronaWynikow();
                rezultatBadania.PokazWykresy(nazwyPlikow);
                rezultatBadania.WyswietlTekst(raport);
                rezultatBadania.Show();
            } catch( Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void uruchomBadanie_Click(object sender, EventArgs e)
        {   
            try
            {
                formatkaBadania.UstawParametryBadania(ZwrocParametry());

                zapiszBadanie.Enabled = false;
                pobierzPlikCSV.Enabled = false;
                rysujWykes.Enabled = false;
                narysowanoWykres = false;
                uruchomBadanie.Enabled = false;
                nazwyPlikow = new string[] { narzedziaWidokow.LosowyTekst(2, 10), narzedziaWidokow.LosowyTekst(2, 10), narzedziaWidokow.LosowyTekst(2, 10) };

                Progress<PostepBadania> postep = new Progress<PostepBadania>();
                postep.ProgressChanged += (o, report) =>
                {
                    // synchronizacja wartości procentowych
                    uruchomBadanie.Text = string.Format("Postęp...{0}%", report.ProcentUkonczenia);
                    czasDzialaniaBadania.Value = report.ProcentUkonczenia;
                    czasDzialaniaBadania.Update();
                };

                await formatkaBadania.UruchomBadanie(postep);
                string noweWynikiBadania = formatkaBadania.wynikiBadania();

                wynikiBadania.Text = noweWynikiBadania + wynikiBadania.Text;
                zapiszBadanie.Enabled = true;
                pobierzPlikCSV.Enabled = true;
                rysujWykes.Enabled = true;
                uruchomBadanie.Enabled = true;
                zapiszBadanie.Text = "Zapisz Badanie";
                uruchomBadanie.Text = "Uruchom Badanie";
                czasDzialaniaBadania.Value = 100;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void wygenerujPlikDanych_Click(object sender, EventArgs e)
        {
            StronaDodaniaPlikowDanych dodaniePlikowDanych = new StronaDodaniaPlikowDanych(this);
            dodaniePlikowDanych.Show();
        }

        /// <summary>
        /// Metoda zmienia panela w widoku głównym pod Problem Optymalizacyjny
        /// </summary>
        private void wybierzProblem_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            WczytajPliki();
            kp_panel.Visible = false;
            ttp_panel.Visible = false;
            domyslnyProblemPanel.Visible = false;
            wybierzPlikDanych.Enabled = true;

            switch (wybierzProblem.Text)
            {
                case "Problem Komiwojażera":
                    UstawRodzajKrzyzowania(formatkaBadania.ZwrocZmiennaSrodowiskowa().KRZYZOWANIE_TSP);
                    domyslnyProblemPanel.Visible = true;
                    break;
                case "Problem Plecakowy":
                    UstawRodzajKrzyzowania(formatkaBadania.ZwrocZmiennaSrodowiskowa().KRZYZOWANIE_WEKTORA);
                    kp_panel.Visible = true;
                    break;
                case "Problem Podróżującego Złodzieja":
                    UstawRodzajKrzyzowania(formatkaBadania.ZwrocZmiennaSrodowiskowa().KRZYZOWANIE_TSP);
                    kp_panel.Visible = true;
                    ttp_panel.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Metoda zmienia panela w widoku głównym pod Algorytm
        /// </summary>
        private void wybierzAlgorytm_SelectedIndexChanged(object sender, EventArgs e)
        {
            domyslnyAlgorytmPanel.Visible = false;
            ae_panel.Visible = false;
            aw_panel.Visible = false;

            switch (wybierzAlgorytm.Text)
            {
                case "Algorytm Ewolucyjny":
                    ae_panel.Visible = true;
                    break;

                case "Algorytm Wspinaczkowy":
                    aw_panel.Visible = true;
                    ae_panel.Visible = true;
                    break;

                default:
                    domyslnyAlgorytmPanel.Visible = true;
                    break;
            }
        }

        private void wybierzPlikDanych_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool pobierzSumeWag = false;
            string nazwaPliku = "";
            XmlDocument dokument = new XmlDocument();

            if (wybierzProblem.Text == "Problem Plecakowy")
            {
                nazwaPliku = "./Dane/KP/" + wybierzPlikDanych.Text + ".xml";
                pobierzSumeWag = true;
            }

            if (wybierzProblem.Text == "Problem Podróżującego Złodzieja")
            {
                dokument.Load("./Dane/TTP/" + wybierzPlikDanych.Text + ".xml");
                XmlNode kp = dokument.DocumentElement.SelectSingleNode("/korzen/kp");

                nazwaPliku = "./Dane/KP/" + kp.InnerText + ".xml";
                pobierzSumeWag = true;
            }

            if (pobierzSumeWag)
            {
                dokument.Load(nazwaPliku);
                XmlNode sumaWag = dokument.DocumentElement.SelectSingleNode("/korzen/sumaWagPrzedmiotow");
                ttp_maxWagaPlecaka.Text = (double.Parse(sumaWag.InnerText) * 0.5).ToString();
            }
        }
    }
}
