using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Rozwiazanie
{
    class RozwiazanieTTP : ARozwiazanie
    {
        public RozwiazanieTTP(ProblemOptymalizacyjny problem) : base(problem){ }

        public override Dictionary<string, double[]> ZnajdzOptimum()
        {
            ushort[][] dostepnePrzedmioty = (ushort[][])problem.ZwrocDostepnePrzedmioty().Clone();

            int poprawy = 0;
            ushort[][] rozwiazanie = reprezentacjaRozwiazania.ZwrocGenotyp2Wymiarowy(),
                     tmpRozwiazanie = (ushort[][])rozwiazanie.Clone();
            Dictionary<string, double[]> wynik = problem.ObliczZysk(problem.ZwrocWybraneElementy(rozwiazanie));

            do
            {
                // problem plecakowy
                for(int i = 0; i < rozwiazanie.Length; i++)
                {
                    for(int j = 1; j < rozwiazanie[i].Length; j++)
                    {

                    }
                }
                

                // problem komiwojażera
            } while (poprawy > 0);

            return wynik;
        }
    }
}
