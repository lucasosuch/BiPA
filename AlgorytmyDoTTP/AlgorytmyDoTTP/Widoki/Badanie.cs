using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TSP;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AlgorytmyDoTTP.Widoki
{
    public partial class Badanie : Form
    {
        private ArrayList wyniki;
        private Dictionary<string, string> parametry;

        public Badanie(Dictionary<string, string> parametry)
        {
            InitializeComponent();
            this.parametry = parametry;
            wyniki = new ArrayList();
        }
        
        private void Badanie_Load(object sender, EventArgs e)
        {
            switch (parametry["problem"])
            {
                case "Problem Plecakowy":
                    ProblemOptymalizacyjny problemKP = new ProblemPlecakowy(parametry["dane"]);
                    problemKP.UstawOgraniczeniaProblemu(double.Parse(parametry["ograniczenie1"]));
                    
                    wyniki.Clear();
                    wyniki.AddRange((new Struktura.Algorytmy.Ewolucyjny.PrzebiegAlgorytmu()).ZbudujAlgorytm(parametry, problemKP).Start());
                    break;

                case "Problem Komiwojażera":
                    ProblemOptymalizacyjny problemTSP = new ProblemKomiwojazera(parametry["dane"]);

                    wyniki.Clear();
                    wyniki.AddRange((new Struktura.Algorytmy.Ewolucyjny.PrzebiegAlgorytmu()).ZbudujAlgorytm(parametry, problemTSP).Start());
                    break;
            }

            foreach(string[] linia in wyniki)
            {
                wynikiBadania.Text += linia[0] + ": " + linia[1] + Environment.NewLine;
            }
        }

        private void pobierzCSV_Click(object sender, EventArgs e)
        {
            DateTime data = DateTime.Today;
            StringBuilder csv = new StringBuilder();

            foreach (KeyValuePair<string, string> parametr in parametry)
            {
                string newLine = string.Format("{0}; {1}", parametr.Key, parametr.Value);
                csv.AppendLine(newLine);
            }

            foreach (string[] linia in wyniki)
            {
                string newLine = string.Format("{0}; {1}", linia[0], linia[1]);
                csv.AppendLine(newLine);
            }

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(desktop, "(" + data.ToString("d") + ") "+ parametry["algorytm"] +"_"+ parametry["dane"] + ".csv");

            File.WriteAllText(path, csv.ToString());
        }
    }
}
