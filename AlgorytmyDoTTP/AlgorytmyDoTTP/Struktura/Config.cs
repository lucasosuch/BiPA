using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;

namespace AlgorytmyDoTTP.Struktura
{
    class Config : Algorytm
    {
        public override IAlgorytm ZbudujAlgorytm()
        {
            short iloscPokolen = 100;
            ushort rozmiarPopulacji = 70;
            double pwoMutacji = 0.3;
            double pwoKrzyzowania = 0.7;

            ProblemPlecakowy problemPlecakowy = new ProblemPlecakowy();
            Osobnik rozwiazanie = new Osobnik(problemPlecakowy);

            problemPlecakowy.UstawMaxWagePlecaka(5);

            return new SEA(pwoKrzyzowania, pwoMutacji, problemPlecakowy.ZwrocLiczbePrzedmiotow(), rozwiazanie, iloscPokolen, rozmiarPopulacji);
        }
    }
}
