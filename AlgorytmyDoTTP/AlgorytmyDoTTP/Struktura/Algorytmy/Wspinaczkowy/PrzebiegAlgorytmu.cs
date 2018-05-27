using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Losowanie;
using AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Rozwiazanie;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy
{
    /// <summary>
    /// Klasa konfiguracyjna.
    /// Będąca łącznikiem pomiędzy problemami optymalizacyjnymi i algorytmami je rozwiązującymi.
    /// </summary>
    class PrzebiegAlgorytmu : Algorytm
    {
        /// <summary>
        /// Metoda odpowiada za ustawienie parametrów pod algorytm, problem optymalizacyjny.
        /// </summary>
        public override IAlgorytm ZbudujAlgorytm(Dictionary<string, string> parametry, ProblemOptymalizacyjny problem)
        {
            ALosowanie losowanie;
            ARozwiazanie rozwiazanie;

            switch (parametry["problem"])
            {
                case "Problem Plecakowy":
                    losowanie = new LosowanieBinarne(problem);
                    rozwiazanie = new RozwiazanieBinarne(problem);

                    return new RLS(losowanie, rozwiazanie);
                case "Problem Komiwojażera":

                    return new RLS();
            }

            return new RLS();
        }
    }
}
