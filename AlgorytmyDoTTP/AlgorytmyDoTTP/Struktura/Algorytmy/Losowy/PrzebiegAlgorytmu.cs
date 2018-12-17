using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy
{
    class PrzebiegAlgorytmu : Algorytm
    {
        public override IAlgorytm ZbudujAlgorytm(Dictionary<string, string> parametry, ProblemOptymalizacyjny problem, string[] nazwyPlikow)
        {
            int iloscRozwiazan = 100,
                iloscElementow = problem.ZwrocDlugoscGenotypu();

            AOsobnik osobnik;
            AnalizaRLS_RS analiza;

            switch (parametry["problem"])
            {
                case "Problem Plecakowy":
                    osobnik = new OsobnikKP(problem);
                    analiza = new AnalizaRLS_RS(osobnik, short.Parse(parametry["liczbaIteracji"]), short.Parse(parametry["czasPoszukiwania"]), nazwyPlikow);

                    return new RS(new LosowanieKP(osobnik), iloscRozwiazan, iloscElementow, analiza);
                case "Problem Komiwojażera":
                    osobnik = new OsobnikTSP(problem);
                    analiza = new AnalizaRLS_RS(osobnik, short.Parse(parametry["liczbaIteracji"]), short.Parse(parametry["czasPoszukiwania"]), nazwyPlikow);

                    return new RS(new LosowanieTSP(osobnik), iloscRozwiazan, iloscElementow, analiza);
                case "Problem Podróżującego Złodzieja":
                    osobnik = new OsobnikTTP(problem);
                    analiza = new AnalizaRLS_RS(osobnik, short.Parse(parametry["liczbaIteracji"]), short.Parse(parametry["czasPoszukiwania"]), nazwyPlikow);

                    return new RS(new LosowanieTTP(osobnik), iloscRozwiazan, iloscElementow, analiza);
            }

            throw new Exception();
        }
    }
}
