using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Losowanie
{
    abstract class ALosowanie
    {
        protected Random losowy = new Random();
        protected ProblemOptymalizacyjny problem;

        public ALosowanie(ProblemOptymalizacyjny problem)
        {
            this.problem = problem;
        }

        public abstract ushort[] WygenerujRozwiazanie();
    }
}
