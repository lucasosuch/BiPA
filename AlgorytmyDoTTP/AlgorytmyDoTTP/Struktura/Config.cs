using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny;

namespace AlgorytmyDoTTP.Struktura
{
    class Config : Algorytm
    {
        public override IAlgorytm ZbudujAlgorytm(double pwoKrzyzowania, double pwoMutacji)
        {
            return new SEA(pwoKrzyzowania, pwoMutacji);
        }
    }
}
