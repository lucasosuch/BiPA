using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik
{
    abstract class AOsobnik
    {
        public abstract ArrayList Fenotyp(ushort[] genotyp);

        public abstract double[] FunkcjaDopasowania(ushort[] genotyp);
    }
}
