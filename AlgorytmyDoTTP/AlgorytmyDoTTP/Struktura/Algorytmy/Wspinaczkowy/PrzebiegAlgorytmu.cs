using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Wynik;
using AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Rozwiazanie;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy
{
    class PrzebiegAlgorytmu : Algorytm
    {
        public override IAlgorytm ZbudujAlgorytm(Dictionary<string, string> parametry, ProblemOptymalizacyjny problem)
        {
            AWynik wynik;
            ILosowanie losowanie;
            ARozwiazanie rozwiazanie;

            int iloscRozwiazan = int.Parse(parametry["iloscRozwiazan"]),
                iloscElementow = problem.ZwrocDlugoscGenotypu();

            switch (parametry["problem"])
            {
                case "Problem Plecakowy":
                    losowanie = new LosowanieKP();
                    rozwiazanie = new RozwiazanieKP(problem);
                    wynik = new WynikGenotypu1Wymiarowego(losowanie.LosujRozwiazania(problem, iloscRozwiazan), problem);

                    return new RLS(rozwiazanie, wynik);
                case "Problem Komiwojażera":
                    losowanie = new LosowanieTSP();
                    rozwiazanie = new RozwiazanieTSP(problem);
                    wynik = new WynikGenotypu1Wymiarowego(losowanie.LosujRozwiazania(iloscRozwiazan, iloscElementow), problem);

                    return new RLS(rozwiazanie, wynik);
                case "Problem Podróżującego Złodzieja":
                    losowanie = new LosowanieTTP();
                    rozwiazanie = new RozwiazanieTTP(problem);
                    wynik = new WynikGenotypu2Wymiarowego(losowanie.LosujRozwiazania(problem, iloscRozwiazan), problem);

                    return new RLS(rozwiazanie, wynik);
            }

            return new RLS();
        }
    }
}
