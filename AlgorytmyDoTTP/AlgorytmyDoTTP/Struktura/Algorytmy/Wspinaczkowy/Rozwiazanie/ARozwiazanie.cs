using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Rozwiazanie
{
    abstract class ARozwiazanie
    {
        protected Random losowy = new Random();
        protected ProblemOptymalizacyjny problem;
        protected ReprezentacjaRozwiazania reprezentacjaRozwiazania;

        public ARozwiazanie(ProblemOptymalizacyjny problem)
        {
            this.problem = problem;
        }

        public ReprezentacjaRozwiazania ZwrocRozwiazanie()
        {
            return reprezentacjaRozwiazania;
        }

        public void UstawRozwiazanie(ReprezentacjaRozwiazania reprezentacjaRozwiazania)
        {
            this.reprezentacjaRozwiazania = reprezentacjaRozwiazania;
        }

        public ProblemOptymalizacyjny ZwrocProblemOptymalizacyjny()
        {
            return problem;
        }

        public abstract Dictionary<string, double[]> ZnajdzOptimum();
    }
}
