using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Wynik;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy
{
    class PrzebiegAlgorytmu : Algorytm
    {
        public override IAlgorytm ZbudujAlgorytm(Dictionary<string, string> parametry, ProblemOptymalizacyjny problem)
        {
            AWynik wynik;
            ILosowanie losowanie;

            int iloscRozwiazan = int.Parse(parametry["iloscRozwiazan"]),
                iloscElementow = problem.ZwrocDlugoscGenotypu();

            switch (parametry["problem"])
            {
                case "Problem Plecakowy":
                    losowanie = new LosowanieKP();
                    wynik = new WynikGenotypu1Wymiarowego(losowanie.LosujRozwiazania(problem, iloscRozwiazan), problem);

                    return new RS(wynik);
                case "Problem Komiwojażera":
                    losowanie = new LosowanieTSP();
                    wynik = new WynikGenotypu1Wymiarowego(losowanie.LosujRozwiazania(iloscRozwiazan, iloscElementow), problem);

                    return new RS(wynik);

                case "Problem Podróżującego Złodzieja":
                    losowanie = new LosowanieTTP();
                    wynik = new WynikGenotypu2Wymiarowego(losowanie.LosujRozwiazania(problem, iloscRozwiazan), problem);

                    return new RS(wynik);
            }

            return new RS();
        }
    }
}
