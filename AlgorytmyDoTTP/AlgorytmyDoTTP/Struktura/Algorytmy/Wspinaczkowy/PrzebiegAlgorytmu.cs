using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
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
        public override IAlgorytm ZbudujAlgorytm(Dictionary<string, string> parametry, ProblemOptymalizacyjny problem, string[] nazwyPlikow)
        {
            AOsobnik osobnik;
            ALosowanie losowanie;
            AnalizaRLS_RS analiza;
            AWspinaczka przeszukiwanieLokalne;

            int iloscRozwiazan = 100,
                iloscElementow = problem.ZwrocDlugoscGenotypu();

            switch (parametry["problem"])
            {
                case "Problem Plecakowy":
                    osobnik = new OsobnikKP(problem);
                    losowanie = new LosowanieKP(osobnik);
                    analiza = new AnalizaRLS_RS(osobnik, short.Parse(parametry["liczbaIteracji"]), short.Parse(parametry["czasPoszukiwania"]), nazwyPlikow);
                    losowanie.SzukajNajlepszegoRozwiazania(iloscRozwiazan, iloscElementow);

                    przeszukiwanieLokalne = new WspinaczkaKP(losowanie, int.Parse(parametry["parametrP"]));

                    return new RLS(przeszukiwanieLokalne, analiza);
                case "Problem Komiwojażera":
                    osobnik = new OsobnikTSP(problem);
                    losowanie = new LosowanieTSP(osobnik);
                    analiza = new AnalizaRLS_RS(osobnik, short.Parse(parametry["liczbaIteracji"]), short.Parse(parametry["czasPoszukiwania"]), nazwyPlikow);
                    losowanie.SzukajNajlepszegoRozwiazania(iloscRozwiazan, iloscElementow);

                    przeszukiwanieLokalne = new WspinaczkaTSP(losowanie, int.Parse(parametry["parametrP"]));

                    return new RLS(przeszukiwanieLokalne, analiza);
                case "Problem Podróżującego Złodzieja":
                    osobnik = new OsobnikTTP(problem);
                    losowanie = new LosowanieTTP(osobnik);
                    analiza = new AnalizaRLS_RS(osobnik, short.Parse(parametry["liczbaIteracji"]), short.Parse(parametry["czasPoszukiwania"]), nazwyPlikow);
                    losowanie.SzukajNajlepszegoRozwiazania(iloscRozwiazan, iloscElementow);

                    przeszukiwanieLokalne = new WspinaczkaTTP(losowanie, int.Parse(parametry["parametrP"]));

                    return new RLS(przeszukiwanieLokalne, analiza);
            }

            throw new Exception();
        }
    }
}
