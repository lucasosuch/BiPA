using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny
{
    class Osobnik
    {
        public double Fenotyp(ushort genotyp)
        {
            return -1 + genotyp / 1000;
        }

        public double FunkcjaDopasowania(double x)
        {
            ProstaFunkcja funkcja = new ProstaFunkcja();

            return funkcja.Fx(x);
        }
    }
}
