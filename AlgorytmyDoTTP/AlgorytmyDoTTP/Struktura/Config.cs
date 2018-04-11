using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;

namespace AlgorytmyDoTTP.Struktura
{
    class Config : Algorytm
    {
        public override IAlgorytm ZbudujAlgorytm()
        {
            double pwoMutacji = 0.3;
            double pwoKrzyzowania = 0.7;

            ProblemPlecakowy problemPlecakowy = new ProblemPlecakowy();
            problemPlecakowy.ustawMaxWagePlecaka(5);

            return new SEA(pwoKrzyzowania, pwoMutacji, problemPlecakowy);
        }
    }
}
