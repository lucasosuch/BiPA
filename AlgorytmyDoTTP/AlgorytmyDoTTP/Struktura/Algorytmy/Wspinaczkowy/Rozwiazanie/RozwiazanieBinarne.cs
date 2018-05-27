using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Rozwiazanie
{
    class RozwiazanieBinarne : ARozwiazanie
    {
        private ushort[] rozwiazanie;
        private ProblemOptymalizacyjny problem;

        public RozwiazanieBinarne(ProblemOptymalizacyjny problem)
        {
            this.problem = problem;
        }

        public override void UstawRozwiazanie(ushort[] rozwiazanie)
        {
            this.rozwiazanie = rozwiazanie;
        }

        public override Dictionary<string, double[]> ZnajdzOptimum()
        {
            int poprawy = 0;
            ushort[] tmpRozwiazanie = (ushort[])rozwiazanie.Clone();
            Dictionary<string, double[]> wynik = problem.ObliczZysk(problem.ZwrocWybraneElementy(rozwiazanie));

            do
            {
                poprawy = 0;
                int wartosc1 = losowy.Next(problem.ZwrocDlugoscGenotypu()),
                    wartosc2 = losowy.Next(problem.ZwrocDlugoscGenotypu()),
                    start = (wartosc1 > wartosc2) ? wartosc2 : wartosc1,
                    koniec = (wartosc1 > wartosc2) ? wartosc1 : wartosc2;

                for (int i = start; i < koniec; i++)
                {
                    tmpRozwiazanie[i] = (ushort)((tmpRozwiazanie[i] == 0) ? 1 : 0);
                }

                Dictionary<string, double[]> tmpWynik = problem.ObliczZysk(problem.ZwrocWybraneElementy(tmpRozwiazanie));

                if ((tmpWynik["max"][0] > wynik["max"][0]) && (tmpWynik["min"][0] <= problem.ZwrocOgraniczeniaProblemu()[0]))
                {
                    Console.WriteLine("Poprawa z "+ wynik["max"][0] +" na "+ tmpWynik["max"][0]);

                    rozwiazanie = (ushort[])tmpRozwiazanie.Clone();
                    wynik["max"][0] = tmpWynik["max"][0];
                    wynik["min"][0] = tmpWynik["min"][0];
                    poprawy++;
                } else
                {
                    tmpRozwiazanie = (ushort[])rozwiazanie.Clone();
                }
            } while (poprawy > 0);

            return wynik;
        }

        public override ushort[] ZwrocRozwiazanie()
        {
            return rozwiazanie;
        }
    }
}
