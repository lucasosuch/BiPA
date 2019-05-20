using BiPA.Struktura.Algorytmy.Abstrakcyjny;
using BiPA.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using BiPA.Struktura.Algorytmy.Abstrakcyjny.Osobnik;
using BiPA.Struktura.Algorytmy.Losowy.Losowanie;
using BiPA.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections.Generic;

namespace BiPA.Struktura.Algorytmy.Losowy
{
    class KonfiguracjaRS : Algorytm
    {
        public override IAlgorytm ZbudujAlgorytm(Dictionary<string, string> parametry, ProblemOptymalizacyjny problem)
        {
            int iloscRozwiazan = 100,
                iloscElementow = problem.ZwrocDlugoscGenotypu();

            AOsobnik osobnik;
            AnalizaRLS_RS analiza;

            switch (parametry["problem"])
            {
                case "Problem Plecakowy":
                    osobnik = new OsobnikKP(problem);
                    analiza = new AnalizaRLS_RS(osobnik, short.Parse(parametry["liczbaIteracji"]), short.Parse(parametry["czasPoszukiwania"]));

                    return new RS(new LosowanieKP(osobnik), iloscRozwiazan, iloscElementow, analiza);
                case "Problem Komiwojażera":
                    osobnik = new OsobnikTSP(problem);
                    analiza = new AnalizaRLS_RS(osobnik, short.Parse(parametry["liczbaIteracji"]), short.Parse(parametry["czasPoszukiwania"]));

                    return new RS(new LosowanieTSP(osobnik), iloscRozwiazan, iloscElementow, analiza);
                case "Problem Podróżującego Złodzieja":
                    osobnik = new OsobnikTTP(problem);
                    analiza = new AnalizaRLS_RS(osobnik, short.Parse(parametry["liczbaIteracji"]), short.Parse(parametry["czasPoszukiwania"]));

                    return new RS(new LosowanieTTP(osobnik), iloscRozwiazan, iloscElementow, analiza);
            }

            throw new Exception();
        }
    }
}
