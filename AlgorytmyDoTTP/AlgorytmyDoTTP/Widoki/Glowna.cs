using AlgorytmyDoTTP.KonfiguracjaAlgorytmow;
using AlgorytmyDoTTP.Struktura;
using AlgorytmyDoTTP.Widoki;
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
            rodzajKrzyzowania.Items.AddRange(new object[] { "Proste" });
            metodaSelekcji.Items.AddRange(algorytmEwolucyjny.SELEKCJA);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void start_Click(object sender, EventArgs e)
        {
            Badanie badanieTemp = new Badanie(ZwrocParametry());
            badanieTemp.Show();
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
                    break;
            }

            parametry["dane"] = wybierzDane.Text;
            parametry["problem"] = wybierzProblem.Text;
            parametry["algorytm"] = wyborAlgorytmu.Text;

            return parametry;
        }

        private void wybierzProblem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nazwaFolderu = "";
            wybierzDane.Items.Clear();
            
            for (int i = 0; i < srodowisko.PROBLEMY_OPTYMALIZACYJNE.Length; i++)
            {
                if((string)srodowisko.PROBLEMY_OPTYMALIZACYJNE[i] == wybierzProblem.Text)
                {
                    nazwaFolderu = srodowisko.FOLDERY_Z_DANYMI[i];
                    break;
                }
            }

            DirectoryInfo d = new DirectoryInfo("../../Dane/"+ nazwaFolderu);
            FileInfo[] files = d.GetFiles("*.xml"); //Getting Text files
            object[] pliki = new object[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                pliki[i] = files[i].Name.Replace(".xml", "");
            }

            wybierzDane.Items.AddRange(pliki);

            if(wybierzProblem.Text == "Problem Komiwojażera")
            {
                rodzajKrzyzowania.Items.Clear();
                rodzajKrzyzowania.Items.AddRange(algorytmEwolucyjny.KRZYZOWANIE_TSP);
            } else
            {
                rodzajKrzyzowania.Items.Clear();
                rodzajKrzyzowania.Items.AddRange(new object[] { "Proste" });
            }
        }
    }
}
