using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Wspinaczka;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy
{
    class PrzebiegAlgorytmu : Algorytm
    {
        public override IAlgorytm ZbudujAlgorytm(Dictionary<string, string> parametry, ProblemOptymalizacyjny problem)
        {
            ALosowanie losowanie;
            AWspinaczka przeszukiwanieLokalne;

            int iloscRozwiazan = int.Parse(parametry["iloscRozwiazan"]),
                iloscElementow = problem.ZwrocDlugoscGenotypu();

            switch (parametry["problem"])
            {
                case "Problem Plecakowy":
                    losowanie = new LosowanieKP(new OsobnikKP(problem));
                    losowanie.SzukajNajlepszegoRozwiazania(iloscRozwiazan, iloscElementow);

                    przeszukiwanieLokalne = new WspinaczkaKP(losowanie);

                    return new RLS(przeszukiwanieLokalne);
                case "Problem Komiwojażera":
                    losowanie = new LosowanieTSP(new OsobnikKP(problem));
                    losowanie.SzukajNajlepszegoRozwiazania(iloscRozwiazan, iloscElementow);

                    przeszukiwanieLokalne = new WspinaczkaTSP(losowanie);

                    return new RLS(przeszukiwanieLokalne);
                case "Problem Podróżującego Złodzieja":
                    losowanie = new LosowanieTTP(new OsobnikKP(problem));
                    losowanie.SzukajNajlepszegoRozwiazania(iloscRozwiazan, iloscElementow);

                    przeszukiwanieLokalne = new WspinaczkaTTP(losowanie);

                    return new RLS(przeszukiwanieLokalne);
            }

            throw new Exception();
        }
    }
}
