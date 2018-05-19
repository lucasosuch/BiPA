using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Selekcja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TSP;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja;
using System.Collections.Generic;
using System;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Analityka;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny
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
            ASelekcja selekcja;
            APopulacja populacja;
            IAnalityka analityka;
            AOsobnik rozwiazanie;
            ARekombinacja rekombinacja;

            switch (parametry["problem"])
            {
                case "Problem Plecakowy":
                    rozwiazanie = new OsobnikKP(problem);
                    rekombinacja = new RekombinacjaWektoraBinarnego(double.Parse(parametry["pwoMutacji"]), rozwiazanie);
                    selekcja = new SelekcjaWektora(rozwiazanie, problem.ZwrocDlugoscGenotypu(), parametry["metodaSelekcji"]);
                    analityka = new AnalizaPopulacji(rozwiazanie);
                    populacja = new PopulacjaACykliczna(ushort.Parse(parametry["rozmiarPopulacji"]), problem.ZwrocDlugoscGenotypu());

                    return new SEA(selekcja, rekombinacja, analityka, populacja, short.Parse(parametry["iloscPokolen"]), double.Parse(parametry["pwoKrzyzowania"]));

                case "Problem Komiwojażera":
                    rozwiazanie = new OsobnikTSP(problem);
                    populacja = new PopulacjaCykliczna(ushort.Parse(parametry["rozmiarPopulacji"]), problem.ZwrocDlugoscGenotypu(), problem.ZwrocDlugoscGenotypu());
                    rekombinacja = new RekombinacjaTSP(double.Parse(parametry["pwoMutacji"]), rozwiazanie, parametry["rodzajKrzyzowania"]);
                    analityka = new AnalizaPopulacji(rozwiazanie);
                    selekcja = new SelekcjaWektora(rozwiazanie, problem.ZwrocDlugoscGenotypu(), parametry["metodaSelekcji"]);

                    return new SEA(selekcja, rekombinacja, analityka, populacja, short.Parse(parametry["iloscPokolen"]), double.Parse(parametry["pwoKrzyzowania"]));
            }

            return new SEA();
        }
    }
}
