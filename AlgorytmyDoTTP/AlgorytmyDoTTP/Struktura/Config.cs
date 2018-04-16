using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Selekcja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;

namespace AlgorytmyDoTTP.Struktura
{
    class Config : Algorytm
    {
        public override IAlgorytm ZbudujAlgorytm()
        {
            short iloscPokolen = 200;
            ushort rozmiarPopulacji = 90,
                   dlugoscGenotypu = 25;
            double pwoMutacji = 0.2,
                   pwoKrzyzowania = 0.8;

            ProblemPlecakowy problemPlecakowy = new ProblemPlecakowy(dlugoscGenotypu);
            OsobnikKP rozwiazanie = new OsobnikKP(problemPlecakowy);
            ARekombinacja rekombinacja = new RekombinacjaWektoraBinarnego(pwoMutacji, rozwiazanie);
            ASelekcja selekcja = new SelekcjaWektoraBinarnego(rozwiazanie, dlugoscGenotypu);

            problemPlecakowy.UstawMaxWagePlecaka(7);

            return new SEA(selekcja, rekombinacja, rozwiazanie, rozmiarPopulacji, iloscPokolen, dlugoscGenotypu, pwoKrzyzowania);
        }
    }
}
