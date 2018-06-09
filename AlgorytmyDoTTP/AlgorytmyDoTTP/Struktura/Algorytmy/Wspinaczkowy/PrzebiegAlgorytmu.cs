﻿using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Wynik;
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
            AWynik wynik;
            ALosowanie losowanie;
            ARozwiazanie rozwiazanie;

            int iloscRozwiazan = int.Parse(parametry["iloscRozwiazan"]),
                iloscElementow = problem.ZwrocDlugoscGenotypu();

            switch (parametry["problem"])
            {
                case "Problem Plecakowy":
                    losowanie = new LosowanieKP(iloscRozwiazan, iloscElementow, 2);
                    rozwiazanie = new RozwiazanieKP(problem);
                    wynik = new WynikGenotypu1Wymiarowego(losowanie, problem);

                    return new RLS(rozwiazanie, wynik);
                case "Problem Komiwojażera":
                    losowanie = new LosowanieTSP(iloscRozwiazan, iloscElementow, iloscElementow);
                    rozwiazanie = new RozwiazanieTSP(problem);
                    wynik = new WynikGenotypu1Wymiarowego(losowanie, problem);

                    return new RLS(rozwiazanie, wynik);
            }

            return new RLS();
        }
    }
}
