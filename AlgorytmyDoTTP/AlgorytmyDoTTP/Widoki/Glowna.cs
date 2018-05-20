using AlgorytmyDoTTP.KonfiguracjaAlgorytmow;
using AlgorytmyDoTTP.Struktura;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using AlgorytmyDoTTP.Widoki;
using AlgorytmyDoTTP.Widoki.Walidacja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorytmyDoTTP
{
    public partial class Glowna : Form
    {
        AE algorytmEwolucyjny = new AE();
        Konfiguracja srodowisko = new Konfiguracja();

        public Glowna()
        {
            InitializeComponent();

            wyborAlgorytmu.Items.AddRange(srodowisko.ALGORYTMY);
            wybierzProblem.Items.AddRange(srodowisko.PROBLEMY_OPTYMALIZACYJNE);
            rodzajKrzyzowania.Items.AddRange(algorytmEwolucyjny.KRZYZOWANIE_WEKTORA);
            metodaSelekcji.Items.AddRange(algorytmEwolucyjny.SELEKCJA);

            UstawWartosciDomyslne();
        }

        private void UstawWartosciDomyslne()
        {
            metodaSelekcji.Text = (string)algorytmEwolucyjny.SELEKCJA[0];
            rodzajKrzyzowania.Text = (string)algorytmEwolucyjny.KRZYZOWANIE_WEKTORA[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void start_Click(object sender, EventArgs e)
        {
            try
            {
                Badanie badanieTemp = new Badanie(ZwrocParametry());
                badanieTemp.Show();
            } catch(Exception exc)
            {
                MessageBox.Show("Wystąpił błąd w formularzu, sprawdź go jeszcze raz!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void wyborAlgorytmu_SelectedIndexChanged(object sender, EventArgs e)
        {
            domyslny.Visible = false;

            switch (wyborAlgorytmu.Text)
            {
                case "Algorytm Ewolucyjny":
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

            switch (wyborAlgorytmu.Text)
            {
                case "Algorytm Ewolucyjny":
                    parametry["pwoMutacji"] = pwoMutacji.Text;
                    parametry["pwoKrzyzowania"] = pwoKrzyzowania.Text;
                    parametry["rozmiarPopulacji"] = rozmiarPopulacji.Text;
                    parametry["iloscPokolen"] = iloscPokolen.Text;
                    parametry["metodaSelekcji"] = metodaSelekcji.Text;
                    parametry["rodzajKrzyzowania"] = rodzajKrzyzowania.Text;

                    string[] parametryCalkowite = new string[] { "rozmiarPopulacji", "iloscPokolen" },
                             parametryZmiennoPrzecinkowe = new string[] { "pwoMutacji", "pwoKrzyzowania" };

                    bool walidacja = new WalidacjaAE().CzyPoprawneCalkowite(parametry, parametryCalkowite) && new WalidacjaAE().CzyPoprawneZmiennoPrzecinkowe(parametry, parametryZmiennoPrzecinkowe);

                    if (!walidacja)
                    {
                        throw new Exception();
                    }

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

            domyslnyProblem.Visible = false;

            switch(wybierzProblem.Text)
            {
                case "Problem Komiwojażera":
                    rodzajKrzyzowania.Items.Clear();
                    rodzajKrzyzowania.Items.AddRange(algorytmEwolucyjny.KRZYZOWANIE_TSP);
                    rodzajKrzyzowania.Text = (string)algorytmEwolucyjny.KRZYZOWANIE_TSP[0];

                    domyslnyProblem.Visible = true;
                    break;
                case "Problem Plecakowy":
                    rodzajKrzyzowania.Items.Clear();
                    rodzajKrzyzowania.Items.AddRange(algorytmEwolucyjny.KRZYZOWANIE_WEKTORA);
                    rodzajKrzyzowania.Text = (string)algorytmEwolucyjny.KRZYZOWANIE_WEKTORA[0];

                    panelKP.Visible = true;
                    break;
            }
        }

        private void WczytajPliki()
        {
            string nazwaFolderu = "";
            wybierzDane.Items.Clear();

            for (int i = 0; i < srodowisko.PROBLEMY_OPTYMALIZACYJNE.Length; i++)
            {
                if ((string)srodowisko.PROBLEMY_OPTYMALIZACYJNE[i] == wybierzProblem.Text)
                {
                    nazwaFolderu = srodowisko.FOLDERY_Z_DANYMI[i];
                    break;
                }
            }

            DirectoryInfo d = new DirectoryInfo("../../Dane/" + nazwaFolderu);
            FileInfo[] files = d.GetFiles("*.xml");
            object[] pliki = new object[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                pliki[i] = files[i].Name.Replace(".xml", "");
            }

            wybierzDane.Items.AddRange(pliki);
        }
    }
}
