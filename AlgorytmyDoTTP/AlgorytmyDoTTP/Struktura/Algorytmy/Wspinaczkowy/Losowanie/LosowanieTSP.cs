using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Losowanie
{
    class LosowanieTSP : ALosowanie
    {
        public LosowanieTSP(ProblemOptymalizacyjny problem) : base(problem){}

        public override ushort[] WygenerujRozwiazanie()
        {
            ushort[] rozwiazanie = new ushort[problem.ZwrocDlugoscGenotypu()];
            ArrayList wykorzystane = new ArrayList();

            for (int j = 0; j < problem.ZwrocDlugoscGenotypu(); j++)
            {
                while (true)
                {
                    int wynik = (ushort)losowy.Next(1, problem.ZwrocDlugoscGenotypu() + 1);

                    if (wykorzystane.IndexOf(wynik) == -1)
                    {
                        wykorzystane.Add(wynik);
                        rozwiazanie[j] = (ushort)wynik;
                        break;
                    }
                }
            }

            wykorzystane.Clear();

            return rozwiazanie;
        }
    }
}
