using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TSP;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AlgorytmyDoTTP.Widoki
{
    public partial class Badanie : Form
    {
        private Dictionary<string, string> parametry;

        public Badanie(Dictionary<string, string> parametry)
        {
            InitializeComponent();
            this.parametry = parametry;
        }
        
        private void Badanie_Load(object sender, EventArgs e)
        {
            switch(parametry["problem"])
            {
                case "Problem Plecakowy":
                    ProblemOptymalizacyjny problemKP = new ProblemPlecakowy(parametry["dane"]);
                    problemKP.UstawOgraniczeniaProblemu(double.Parse(parametry["ograniczenie1"]));

                    wynikiBadania.Text = (new Struktura.Algorytmy.Ewolucyjny.PrzebiegAlgorytmu()).ZbudujAlgorytm(parametry, problemKP).Start();
                    break;

                case "Problem Komiwojażera":
                    ProblemOptymalizacyjny problemTSP = new ProblemKomiwojazera(parametry["dane"]);

                    wynikiBadania.Text = (new Struktura.Algorytmy.Ewolucyjny.PrzebiegAlgorytmu()).ZbudujAlgorytm(parametry, problemTSP).Start();
                    break;
            }
        }
    }
}
