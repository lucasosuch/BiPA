using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Rozwiazanie
{
    class RozwiazanieTTP : ARozwiazanie
    {
        public RozwiazanieTTP(ProblemOptymalizacyjny problem) : base(problem){ }

        public override Dictionary<string, double[]> ZnajdzOptimum()
        {
            throw new NotImplementedException();
        }
    }
}
