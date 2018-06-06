using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Rozwiazanie
{
    abstract class ARozwiazanie
    {
        protected ushort[] rozwiazanie;
        protected Random losowy = new Random();
        protected ProblemOptymalizacyjny problem;

        public ARozwiazanie(ProblemOptymalizacyjny problem)
        {
            this.problem = problem;
        }

        public ushort[] ZwrocRozwiazanie()
        {
            return rozwiazanie;
        }

        public void UstawRozwiazanie(ushort[] rozwiazanie)
        {
            this.rozwiazanie = rozwiazanie;
        }

        public ProblemOptymalizacyjny ZwrocProblemOptymalizacyjny()
        {
            return problem;
        }

        public abstract Dictionary<string, double[]> ZnajdzOptimum();
    }
}
