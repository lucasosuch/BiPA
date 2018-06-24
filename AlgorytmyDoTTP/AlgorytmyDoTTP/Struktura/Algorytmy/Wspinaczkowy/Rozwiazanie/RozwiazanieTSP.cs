using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Rozwiazanie
{
    /// <summary>
    /// Klasa konkretna reprezentująca rozwiązanie dla Algorytmu Wspinaczkowego pod Problem Komiwojażera
    /// </summary>
    class RozwiazanieTSP : ARozwiazanie
    {
        public RozwiazanieTSP(ProblemOptymalizacyjny problem) : base(problem){}

        public override Dictionary<string, double[]> ZnajdzOptimum()
        {
            int poprawy = 0;
            ushort[] rozwiazanie = reprezentacjaRozwiazania.ZwrocGenotyp1Wymiarowy(),
                     tmpRozwiazanie = (ushort[])rozwiazanie.Clone();
            Dictionary<string, double[]> wynik = problem.ObliczZysk(problem.ZwrocWybraneElementy(rozwiazanie));

            do
            {
                int start = 0,
                    koniec = problem.ZwrocDlugoscGenotypu() / 2;

                poprawy = 0;
                for (int i = start; i < koniec; i++)
                {
                    int liczba1 = losowy.Next(problem.ZwrocDlugoscGenotypu()),
                        liczba2 = losowy.Next(problem.ZwrocDlugoscGenotypu());

                    ushort tmpWartosc = tmpRozwiazanie[liczba1];
                    tmpRozwiazanie[liczba1] = tmpRozwiazanie[liczba2];
                    tmpRozwiazanie[liczba2] = tmpWartosc;

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
