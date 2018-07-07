using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Wynik;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy
{
    class PrzebiegAlgorytmu : Algorytm
    {
        public override IAlgorytm ZbudujAlgorytm(Dictionary<string, string> parametry, ProblemOptymalizacyjny problem)
        {
            int iloscRozwiazan = int.Parse(parametry["iloscRozwiazan"]),
                iloscElementow = problem.ZwrocDlugoscGenotypu();

            switch (parametry["problem"])
            {
                case "Problem Plecakowy":
                    return new RS(new LosowanieKP(new OsobnikKP(problem)), iloscRozwiazan, iloscElementow);
                case "Problem Komiwojażera":
                    return new RS(new LosowanieTSP(new OsobnikTSP(problem)), iloscRozwiazan, iloscElementow);
                case "Problem Podróżującego Złodzieja":
                    return new RS(new LosowanieTTP(new OsobnikTTP(problem)), iloscRozwiazan, iloscElementow);
            }

            throw new Exception();
        }
    }
}
