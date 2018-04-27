using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Selekcja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TSP;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja;
using System.Collections;
using System;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Analityka;

namespace AlgorytmyDoTTP.Struktura
{
    class Config : Algorytm
    {
        public override IAlgorytm ZbudujAlgorytm()
        {
            short iloscPokolen = 200;
            ushort rozmiarPopulacji = 90,
                   dlugoscGenotypu = 15;
            double pwoMutacji = 0.2,
                   pwoKrzyzowania = 0.8;

            //ProblemPlecakowy problemPlecakowy = new ProblemPlecakowy(dlugoscGenotypu);
            //OsobnikKP rozwiazanie = new OsobnikKP(problemPlecakowy);
            //problemPlecakowy.UstawMaxWagePlecaka(7);
            //ARekombinacja rekombinacja = new RekombinacjaWektoraBinarnego(pwoMutacji, rozwiazanie);
            
            APopulacja populacja = new PopulacjaCykliczna(rozmiarPopulacji, dlugoscGenotypu, dlugoscGenotypu);

            ProblemKomiwojazera problemKomiwojazera = new ProblemKomiwojazera(15);
            AOsobnik rozwiazanie = new OsobnikTSP(problemKomiwojazera);
            ARekombinacja rekombinacja = new RekombinacjaTSP(pwoMutacji, rozwiazanie, "PMX");
            ASelekcja selekcja = new SelekcjaWektora(rozwiazanie, dlugoscGenotypu, "Turniej");

            IAnalityka analityka = new AnalizaPopulacji(rozwiazanie);

            return new SEA(selekcja, rekombinacja, analityka, populacja, iloscPokolen, pwoKrzyzowania);
        }
    }
}
