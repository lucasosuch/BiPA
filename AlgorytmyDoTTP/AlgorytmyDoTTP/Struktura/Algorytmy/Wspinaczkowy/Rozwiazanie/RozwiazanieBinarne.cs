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
        private ProblemOptymalizacyjny problem;

        public RozwiazanieBinarne(ProblemOptymalizacyjny problem)
        {
            this.problem = problem;
        }

        public override ushort[] WygenerujRozwiazanie()
        {
            ushort[] wynik = new ushort[problem.ZwrocDlugoscGenotypu()];

            for(int i = 0; i < wynik.Length; i++)
            {
                wynik[i] = (ushort)losowy.Next(2);
            }

            return wynik;
        }

        public override Dictionary<string, double[]> ZnajdzOptimum(ushort[] rozwiazanie)
        {
            int poprawy = 0;
            ushort[] tmpRozwiazanie = (ushort[])rozwiazanie.Clone();
            Dictionary<string, double[]> wynik = problem.ObliczZysk(problem.ZwrocWybraneElementy(rozwiazanie));

            do
            {
                poprawy = 0;
                for (int i = 0; i < tmpRozwiazanie.Length; i++)
                {
                    if(i == 0 || i == tmpRozwiazanie.Length - 1)
                    {
                        tmpRozwiazanie[i] = (ushort)((tmpRozwiazanie[i] == 0) ? 1 : 0);
                    } else
                    {
                        int wartosc = losowy.Next(i);
                        tmpRozwiazanie[wartosc - 1] = (ushort)((tmpRozwiazanie[wartosc - 1] == 0) ? 1 : 0);
                        tmpRozwiazanie[wartosc] = (ushort)((tmpRozwiazanie[wartosc] == 0) ? 1 : 0);
                    }

                    Dictionary<string, double[]> tmpWynik = problem.ObliczZysk(problem.ZwrocWybraneElementy(rozwiazanie));

                    if((tmpWynik["max"][0] > wynik["max"][0]) && (tmpWynik["min"][0] <= problem.ZwrocOgraniczeniaProblemu()[0]))
                    {
                        rozwiazanie = (ushort[])tmpRozwiazanie.Clone();
                        poprawy++;
                    } else
                    {
                        tmpRozwiazanie = (ushort[])rozwiazanie.Clone();
                    }
                }
            } while (poprawy > 0);

            return wynik;
        }
    }
}
