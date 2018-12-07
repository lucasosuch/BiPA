using AlgorytmyDoTTP.Widoki.Narzedzia;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace AlgorytmyDoTTP.Widoki
{
    /// <summary>
    /// Klasa widoku badania
    /// </summary>
    public partial class Badanie : Form
    {
        private FormatkaBadania badanie = new FormatkaBadania();

        public Badanie()
        {
            InitializeComponent();
            UstawWartosciDomyslne();
        }

        /// <summary>
        /// Metoda ustawia wartości domyślne aplikacji
        /// </summary>
        private void UstawWartosciDomyslne()
        {
            wybierzAlgorytm.Items.AddRange(badanie.ZwrocZmiennaSrodowiskowa().ALGORYTMY);
            wybierzProblem.Items.AddRange(badanie.ZwrocZmiennaSrodowiskowa().PROBLEMY_OPTYMALIZACYJNE);
            ae_rodzajKrzyzowania.Items.AddRange(badanie.ZwrocKonfiguracjeAE().KRZYZOWANIE_WEKTORA);
            ae_rodzajKrzyzowania.Text = (string)badanie.ZwrocKonfiguracjeAE().KRZYZOWANIE_WEKTORA[0];
            ae_metodaSelekcji.Items.AddRange(badanie.ZwrocKonfiguracjeAE().SELEKCJA);
            ae_metodaSelekcji.Text = (string)badanie.ZwrocKonfiguracjeAE().SELEKCJA[0];
            modelTTP.Items.AddRange(badanie.ZwrocKonfiguracjeAE().MODELE_TTP);
            modelTTP.Text = (string)badanie.ZwrocKonfiguracjeAE().MODELE_TTP[0];
        }

        private void Badanie_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Metoda zwraca parametry Algorytmu oraz Problemu Optymalizacyjnego
        /// </summary>
        /// <returns>Parametry Algorytmu oraz Problemu Optymalizacyjnego</returns>
        private Dictionary<string, string> ZwrocParametry()
        {
            Dictionary<string, string> parametry = new Dictionary<string, string>();

            switch (wybierzProblem.Text)
            {
                case "Problem Podróżującego Złodzieja":
                    parametry["modelTTP"] = modelTTP.Text;
                    parametry["ograniczenie1"] = ttp_maxWagaPlecaka.Text;
                    parametry["wyporzyczeniePlecaka"] = wypozyczeniePlecaka.Text;
                    break;
                case "Problem Plecakowy":
                    parametry["ograniczenie1"] = kp_maxWagaPlecaka.Text;
                    break;
                default:
                    parametry["ograniczenie1"] = "0";
                    break;
            }

            switch (wybierzAlgorytm.Text)
            {
                case "Algorytm Ewolucyjny":
                    parametry["pwoMutacji"] = ae_pwoMutacji.Text;
                    parametry["pwoKrzyzowania"] = ae_pwoKrzyzowania.Text;
                    parametry["rozmiarPopulacji"] = ae_rozmiarPopulacji.Text;
                    parametry["metodaSelekcji"] = ae_metodaSelekcji.Text;
                    parametry["rodzajKrzyzowania"] = ae_rodzajKrzyzowania.Text;
                    break;
                case "Algorytm Wspinaczkowy":
                    parametry["parametrP"] = aw_parametrP.Text;
                    break;
            }

            badanie.WalidacjaKluczowychParametrow(wybierzPlikDanych.Text);
            badanie.WalidacjaKluczowychParametrow(wybierzProblem.Text);
            badanie.WalidacjaKluczowychParametrow(wybierzAlgorytm.Text);
            badanie.WalidacjaKluczowychParametrow(liczbaIteracjiAlgorytmu.Text);

            parametry["dane"] = wybierzPlikDanych.Text;
            parametry["problem"] = wybierzProblem.Text;
            parametry["algorytm"] = wybierzAlgorytm.Text;
            parametry["liczbaIteracji"] = liczbaIteracjiAlgorytmu.Text;
            parametry["czasPoszukiwania"] = czasDzialaniaAlgorytmu.Text;

            badanie.WalidacjaFormatki(parametry);

            return parametry;
        }

        /// <summary>
        /// Metoda wczytuje pliki danych pod wybrany Problem Optymalizacyjny
        /// </summary>
        private void WczytajPliki()
        {
            wybierzPlikDanych.Items.Clear();
            wybierzPlikDanych.Items.AddRange(badanie.WczytajPlikiDanych(wybierzProblem.Text));
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
                string sciezka = Path.Combine(pulpit, badanie.ZwrocNazwePliku("csv", ""));

                File.WriteAllText(sciezka, badanie.ZwrocDaneDoCSV(), System.Text.Encoding.UTF8);
                MessageBox.Show("Pobrano plik CSV, na pulpit!", "Plik CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch(IOException exc)
            {
                Console.WriteLine(exc);
            }
        }

        /// <summary>
        /// Metoda odpowiada za zapis pliku badania na dysku
        /// </summary>
        private void zapiszBadanie_Click(object sender, EventArgs e)
        {
            badanie.ZapiszBadanie();
            MessageBox.Show("Zapisano badanie na dysku!", "Zapis badania", MessageBoxButtons.OK, MessageBoxIcon.Information);
            zapiszBadanie.Enabled = false;
            zapiszBadanie.Text = "Zapisano Badanie";
        }

        private void rysujWykes_Click(object sender, EventArgs e)
        {
            string Path = @"C:\Program Files\gnuplot\bin\gnuplot.exe";
            Process GnuplotProcess = new Process();
            GnuplotProcess.StartInfo.FileName = Path;
            GnuplotProcess.StartInfo.UseShellExecute = false;
            GnuplotProcess.StartInfo.RedirectStandardInput = true;
            GnuplotProcess.StartInfo.RedirectStandardOutput = true;
            GnuplotProcess.Start();
            StreamWriter SW = GnuplotProcess.StandardInput;
            StreamReader SR = GnuplotProcess.StandardOutput;

            double[] A = new double[] { 2, 3, 4, 5, 5, 5, 5, 6, 7, 8, 9, 9, 10 };
            double[] B = new double[] { 1, 2, 3, 3, 3, 4, 5, 5, 5, 5, 6, 11, 10 };

            SW.WriteLine("set terminal pngcairo size 1300,1200");
            SW.WriteLine("array A["+ A.Length +"] = ["+ string.Join(", ", A) +"]");
            SW.WriteLine("array B["+ B.Length +"] = ["+ string.Join(", ", B) +"]");
            SW.WriteLine("plot A w lines, B w lines");
            SW.WriteLine("exit");

            Image png = Image.FromStream(SR.BaseStream);
            png.Save(@".\try3a.png");

            GnuplotProcess.Close();
        }

        private void uruchomBadanie_Click(object sender, EventArgs e)
        {
            badanie.UstawParametryBadania(ZwrocParametry());
            wynikiBadania.Text = badanie.UruchomBadanie();
        }

        private void wygenerujPlikDanych_Click(object sender, EventArgs e)
        {

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
                    UstawRodzajKrzyzowania(badanie.ZwrocKonfiguracjeAE().KRZYZOWANIE_TSP);
                    domyslnyProblemPanel.Visible = true;
                    break;
                case "Problem Plecakowy":
                    UstawRodzajKrzyzowania(badanie.ZwrocKonfiguracjeAE().KRZYZOWANIE_WEKTORA);
                    kp_panel.Visible = true;
                    break;
                case "Problem Podróżującego Złodzieja":
                    UstawRodzajKrzyzowania(badanie.ZwrocKonfiguracjeAE().KRZYZOWANIE_TSP);
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
                case "Algorytm Losowy":
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
                ttp_maxWagaPlecaka.Text = (int.Parse(sumaWag.InnerText) * 0.5).ToString();
            }
        }
    }
}
