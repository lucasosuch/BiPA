using AlgorytmyDoTTP.KonfiguracjaAlgorytmow;
using AlgorytmyDoTTP.Widoki;
using AlgorytmyDoTTP.Widoki.Walidacja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml;

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
            DirectoryInfo d = new DirectoryInfo("../../../../Badania");
            FileInfo[] pliki = d.GetFiles("*.xml");

            for (int i = 0; i < pliki.Length; i++)
            {
                XmlDocument dokument = new XmlDocument();
                dokument.Load("../../../../Badania/"+pliki[i].Name); // jak nie ma to automatycznie niech tworzy
                XmlNode dataZapisu = dokument.DocumentElement.SelectSingleNode("/badanie/dataZapisu");

                string[] wiersz = new string[] { pliki[i].Name, dataZapisu.InnerText };
                var elementy = new ListViewItem(wiersz);
                daneHistoryczne.Items.Add(elementy);
            }
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
                Console.WriteLine(exc);
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

            switch (wybierzProblem.Text)
            {
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

                    string[] parametryCalkowite = new string[] { "rozmiarPopulacji", "iloscPokolen" },
                             parametryZmiennoPrzecinkowe = new string[] { "pwoMutacji", "pwoKrzyzowania", "ograniczenie1" };

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

        private void porownaj_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection wybraneElementy = daneHistoryczne.CheckedItems;
            int ilosc = wybraneElementy.Count;

            if (ilosc <= 5 && ilosc > 0)
            {
                Dictionary<string, string[]> paramentry = new Dictionary<string, string[]>();

                foreach (ListViewItem element in wybraneElementy)
                {
                    string nazwa = element.SubItems[0].Text;

                    XmlDocument dokument = new XmlDocument();
                    dokument.Load("../../../../Badania/" + nazwa);

                    XmlNode maxWartosc = dokument.DocumentElement.SelectSingleNode("/badanie/maxWartosc");
                    XmlNode czasDzialania = dokument.DocumentElement.SelectSingleNode("/badanie/czasDzialania");

                    paramentry[nazwa] = new string[] { czasDzialania.InnerText, maxWartosc.InnerText };
                }

                Porownanie porownanieTemp = new Porownanie(paramentry);
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
    }
}
