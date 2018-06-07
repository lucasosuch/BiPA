using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Rozwiazanie
{
    class RozwiazanieKP : ARozwiazanie
    {
        public RozwiazanieKP(ProblemOptymalizacyjny problem) : base(problem){}

        public override Dictionary<string, double[]> ZnajdzOptimum()
        {
            int poprawy = 0;
            ushort[] rozwiazanie = reprezentacjaRozwiazania.ZwrocGenotyp1Wymiarowy(),
                     tmpRozwiazanie = (ushort[])rozwiazanie.Clone();

            Dictionary<string, double[]> wynik = problem.ObliczZysk(problem.ZwrocWybraneElementy(rozwiazanie));

            do
            {
                poprawy = 0;
                int wartosc1 = losowy.Next(problem.ZwrocDlugoscGenotypu() / 2),
                    wartosc2 = losowy.Next(problem.ZwrocDlugoscGenotypu()),
                    start = (wartosc1 > wartosc2) ? wartosc2 : wartosc1,
                    koniec = (wartosc1 > wartosc2) ? wartosc1 : wartosc2;

                for (int i = start; i < koniec; i++)
                {
                    tmpRozwiazanie[i] = (ushort)((tmpRozwiazanie[i] == 0) ? 1 : 0);
                    Dictionary<string, double[]> tmpWynik = problem.ObliczZysk(problem.ZwrocWybraneElementy(tmpRozwiazanie));

                    if (tmpWynik["max"][0] > wynik["max"][0])
                    {
                        if (problem.CzyIstniejaOgraniczenia() && (tmpWynik["min"][0] > problem.ZwrocOgraniczeniaProblemu()[0])) continue;
                        
                        rozwiazanie = (ushort[])tmpRozwiazanie.Clone();
                        reprezentacjaRozwiazania.ZmienGenotyp(rozwiazanie);

                        wynik["max"][0] = tmpWynik["max"][0];
                        wynik["min"][0] = tmpWynik["min"][0];
                        poprawy++;
                    }
                    else
                    {
                        tmpRozwiazanie = (ushort[])rozwiazanie.Clone();
                    }
                }
            } while (poprawy > 0);

            return wynik;
        }
    }
}