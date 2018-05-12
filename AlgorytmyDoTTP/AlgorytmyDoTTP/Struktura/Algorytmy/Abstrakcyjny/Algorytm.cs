using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny
{
    abstract class Algorytm
    {
        public abstract IAlgorytm ZbudujAlgorytm(Dictionary<string, string> parametry);
    }
}
