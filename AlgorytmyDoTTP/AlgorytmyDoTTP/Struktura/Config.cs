using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;

namespace AlgorytmyDoTTP.Struktura
{
    class Config : Algorytm
    {
        public override IAlgorytm ZbudujAlgorytm()
        {
            short iloscPokolen = 200;
            ushort rozmiarPopulacji = 90,
                   liczbaPrzedmiotow = 15;
            double pwoMutacji = 0.2,
                   pwoKrzyzowania = 0.8;

            ProblemPlecakowy problemPlecakowy = new ProblemPlecakowy(liczbaPrzedmiotow);
            Osobnik rozwiazanie = new Osobnik(problemPlecakowy);

            problemPlecakowy.UstawMaxWagePlecaka(3);

            return new SEA(pwoKrzyzowania, pwoMutacji, liczbaPrzedmiotow, rozwiazanie, iloscPokolen, rozmiarPopulacji);
        }
    }
}
