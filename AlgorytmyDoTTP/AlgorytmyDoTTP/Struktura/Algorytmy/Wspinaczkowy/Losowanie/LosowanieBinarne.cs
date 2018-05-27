using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Losowanie
{
    class LosowanieBinarne : ALosowanie
    {
        private ProblemOptymalizacyjny problem;

        public LosowanieBinarne(ProblemOptymalizacyjny problem)
        {
            this.problem = problem;
        }

        public override ushort[] WygenerujRozwiazanie()
        {
            ushort[] wynik = new ushort[problem.ZwrocDlugoscGenotypu()];

            for (int i = 0; i < wynik.Length; i++)
            {
                wynik[i] = (ushort)losowy.Next(2);
            }

            return wynik;
        }
    }
}
