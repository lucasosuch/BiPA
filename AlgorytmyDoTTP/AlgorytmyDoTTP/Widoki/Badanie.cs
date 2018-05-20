using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
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
                    ProblemOptymalizacyjny problem = new ProblemPlecakowy(parametry["dane"]);
                    problem.UstawOgraniczeniaProblemu(double.Parse(parametry["ograniczenie1"]));

                    wynikiBadania.Text = (new Struktura.Algorytmy.Ewolucyjny.PrzebiegAlgorytmu()).ZbudujAlgorytm(parametry, problem).Start();
                    break;
            }
        }
    }
}
