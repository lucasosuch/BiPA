using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;

namespace AlgorytmyDoTTP.Struktura
{
    class Config : Algorytm
    {
        public override IAlgorytm ZbudujAlgorytm(double pwoKrzyzowania, double pwoMutacji)
        {
            ProblemPlecakowy problemPlecakowy = new ProblemPlecakowy(25);
            problemPlecakowy.ustawMaxWagePlecaka(10);

            return new SEA(pwoKrzyzowania, pwoMutacji, problemPlecakowy);
        }
    }
}
