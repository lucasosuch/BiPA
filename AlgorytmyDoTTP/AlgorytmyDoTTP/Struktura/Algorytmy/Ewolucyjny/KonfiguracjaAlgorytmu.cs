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

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny
{
    /// <summary>
    /// Klasa konfiguracyjna.
    /// Będąca łącznikiem pomiędzy problemami optymalizacyjnymi i algorytmami je rozwiązującymi.
    /// </summary>
    class KonfiguracjaAlgorytmu : Algorytm
    {
        /// <summary>
        /// Metoda odpowiada za ustawienie parametrów pod algorytm, problem optymalizacyjny.
        /// </summary>
        public override IAlgorytm ZbudujAlgorytm(Dictionary<string, string> parametry)
        {
            ushort dlugoscGenotypu = 15;

            ProblemKomiwojazera problemKomiwojazera = new ProblemKomiwojazera(dlugoscGenotypu);

            //ProblemPlecakowy problemPlecakowy = new ProblemPlecakowy(dlugoscGenotypu);
            //OsobnikKP rozwiazanie = new OsobnikKP(problemPlecakowy);
            //problemPlecakowy.UstawMaxWagePlecaka(7);
            //ARekombinacja rekombinacja = new RekombinacjaWektoraBinarnego(pwoMutacji, rozwiazanie);

            APopulacja populacja = new PopulacjaCykliczna(ushort.Parse(parametry["rozmiarPopulacji"]), dlugoscGenotypu, dlugoscGenotypu);
            AOsobnik rozwiazanie = new OsobnikTSP(problemKomiwojazera);
            ARekombinacja rekombinacja = new RekombinacjaTSP(double.Parse(parametry["pwoMutacji"]), rozwiazanie, "PMX");
            ASelekcja selekcja = new SelekcjaWektora(rozwiazanie, dlugoscGenotypu, "Turniej");
            IAnalityka analityka = new AnalizaPopulacji(rozwiazanie);

            return new SEA(selekcja, rekombinacja, analityka, populacja, short.Parse(parametry["iloscPokolen"]), double.Parse(parametry["pwoKrzyzowania"]));
        }
    }
}
