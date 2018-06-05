using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Analityka;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Selekcja;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny
{
    /// <summary>
    /// Klasa konfiguracyjna.
    /// Będąca łącznikiem pomiędzy problemami optymalizacyjnymi i algorytmem Ewolucyjnym
    /// </summary>
    class PrzebiegAlgorytmu : Algorytm
    {
        /// <summary>
        /// Metoda odpowiedzialna za uruchomienie algorytmu wg wybranego problemu optymalizacyjnego
        /// </summary>
        /// <param name="parametry">Zdefiniowane przez użytkownika parametry</param>
        /// <param name="problem">Wybrany przez użytkownika problem optymalizacyjny</param>
        /// <returns>Dane tekstowe na temat przebiegu algorytmu</returns>
        /// <exception cref="System.Exception">Zwraca wyjątek gdy algorytm nie rozpatruje wybranego przez użytkownika problemu optymalizacyjnego</exception>
        public override IAlgorytm ZbudujAlgorytm(Dictionary<string, string> parametry, ProblemOptymalizacyjny problem)
        {
            // Stałe składniki Algorytmu Ewolucyjnego
            ASelekcja selekcja;
            APopulacja populacja;
            IAnalityka analityka;
            AOsobnik rozwiazanie;
            ARekombinacja rekombinacja;

            switch (parametry["problem"])
            {
                case "Problem Plecakowy":
                    // konfiguracja algorytmu pod Problem Plecakowy
                    rozwiazanie = new OsobnikKP(problem);
                    rekombinacja = new RekombinacjaWektoraBinarnego(double.Parse(parametry["pwoMutacji"]), rozwiazanie);
                    selekcja = new SelekcjaWektora(rozwiazanie, problem.ZwrocDlugoscGenotypu(), parametry["metodaSelekcji"]);
                    analityka = new AnalizaPopulacji(rozwiazanie);
                    populacja = new PopulacjaKP(ushort.Parse(parametry["rozmiarPopulacji"]), problem.ZwrocDlugoscGenotypu());

                    return new SEA(selekcja, rekombinacja, analityka, populacja, short.Parse(parametry["iloscPokolen"]), double.Parse(parametry["pwoKrzyzowania"]));

                case "Problem Komiwojażera":
                    // konfiguracja algorytmu pod Problem Komiwojażera
                    rozwiazanie = new OsobnikTSP(problem);
                    populacja = new PopulacjaTSP(ushort.Parse(parametry["rozmiarPopulacji"]), problem.ZwrocDlugoscGenotypu(), problem.ZwrocDlugoscGenotypu());
                    rekombinacja = new RekombinacjaTSP(double.Parse(parametry["pwoMutacji"]), rozwiazanie, parametry["rodzajKrzyzowania"]);
                    analityka = new AnalizaPopulacji(rozwiazanie);
                    selekcja = new SelekcjaWektora(rozwiazanie, problem.ZwrocDlugoscGenotypu(), parametry["metodaSelekcji"]);

                    return new SEA(selekcja, rekombinacja, analityka, populacja, short.Parse(parametry["iloscPokolen"]), double.Parse(parametry["pwoKrzyzowania"]));

                case "Problem Podróżującego Złodzieja":
                    rozwiazanie = new OsobnikTTP(problem);
                    populacja = new PopulacjaTTP(ushort.Parse(parametry["rozmiarPopulacji"]), problem.ZwrocDlugoscGenotypu(), problem.ZwrocDlugoscGenotypu(), problem.ZwrocDostepnePrzedmioty());
                    rekombinacja = new RekombinacjaTTP(double.Parse(parametry["pwoMutacji"]), rozwiazanie, "PMX");
                    selekcja = new SelekcjaWektora(rozwiazanie, problem.ZwrocDlugoscGenotypu(), parametry["metodaSelekcji"]);
                    analityka = new AnalizaPopulacji(rozwiazanie);

                    return new SEA(selekcja, rekombinacja, analityka, populacja, short.Parse(parametry["iloscPokolen"]), double.Parse(parametry["pwoKrzyzowania"]));
            }

            return new SEA();
        }
    }
}
