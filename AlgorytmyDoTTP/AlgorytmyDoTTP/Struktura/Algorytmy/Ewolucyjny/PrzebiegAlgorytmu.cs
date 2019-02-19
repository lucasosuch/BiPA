using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Selekcja;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny
{
    class PrzebiegAlgorytmu : Algorytm
    {
        public override IAlgorytm ZbudujAlgorytm(Dictionary<string, string> parametry, ProblemOptymalizacyjny problem, string[] nazwyPlikow)
        {
            // Stałe składniki Algorytmu Ewolucyjnego
            ASelekcja selekcja;
            ReprezentacjaRozwiazania[] populacja;
            AOsobnik rozwiazanie;
            ARekombinacja rekombinacja;
            AnalizaEwolucyjny analityka;

            switch (parametry["problem"])
            {
                case "Problem Plecakowy":
                    // konfiguracja algorytmu pod Problem Plecakowy
                    rozwiazanie = new OsobnikKP(problem);
                    analityka = new AnalizaEwolucyjny(rozwiazanie, short.Parse(parametry["liczbaIteracji"]), short.Parse(parametry["czasPoszukiwania"]), nazwyPlikow);
                    selekcja = new SelekcjaWektora(rozwiazanie, problem.ZwrocDlugoscGenotypu(), parametry["metodaSelekcji"]);
                    rekombinacja = new RekombinacjaKP(float.Parse(parametry["pwoMutacji"]), rozwiazanie);
                    populacja = new PopulacjaKP().StworzPopulacjeBazowa(problem, ushort.Parse(parametry["rozmiarPopulacji"]), problem.ZwrocDlugoscGenotypu());

                    return new SEA(selekcja, rekombinacja, analityka, populacja, float.Parse(parametry["pwoKrzyzowania"]));

                case "Problem Komiwojażera":
                    // konfiguracja algorytmu pod Problem Komiwojażera
                    rozwiazanie = new OsobnikTSP(problem);
                    analityka = new AnalizaEwolucyjny(rozwiazanie, short.Parse(parametry["liczbaIteracji"]), short.Parse(parametry["czasPoszukiwania"]), nazwyPlikow);
                    selekcja = new SelekcjaWektora(rozwiazanie, problem.ZwrocDlugoscGenotypu(), parametry["metodaSelekcji"]);
                    rekombinacja = new RekombinacjaTSP(float.Parse(parametry["pwoMutacji"]), rozwiazanie, parametry["rodzajKrzyzowania"]);
                    populacja = new PopulacjaTSP().StworzPopulacjeBazowa(problem, ushort.Parse(parametry["rozmiarPopulacji"]), problem.ZwrocDlugoscGenotypu());

                    return new SEA(selekcja, rekombinacja, analityka, populacja, float.Parse(parametry["pwoKrzyzowania"]));

                case "Problem Podróżującego Złodzieja":
                    // konfiguracja algorytmu pod Problem Podróżującego Złodzieja
                    rozwiazanie = new OsobnikTTP(problem);
                    analityka = new AnalizaEwolucyjny(rozwiazanie, short.Parse(parametry["liczbaIteracji"]), short.Parse(parametry["czasPoszukiwania"]), nazwyPlikow);
                    selekcja = new SelekcjaWektora(rozwiazanie, problem.ZwrocDlugoscGenotypu(), parametry["metodaSelekcji"]);
                    rekombinacja = new RekombinacjaTTP(float.Parse(parametry["pwoMutacji"]), rozwiazanie, parametry["rodzajKrzyzowania"]);
                    populacja = new PopulacjaTTP().StworzPopulacjeBazowa(problem, ushort.Parse(parametry["rozmiarPopulacji"]), problem.ZwrocDlugoscGenotypu());
                    
                    return new SEA(selekcja, rekombinacja, analityka, populacja, float.Parse(parametry["pwoKrzyzowania"]));
            }

            return new SEA();
        }
    }
}
