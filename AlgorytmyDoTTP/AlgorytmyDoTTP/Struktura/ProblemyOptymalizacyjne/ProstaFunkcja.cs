using System;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne
{
    class ProstaFunkcja
    {
        public double Fx(double x)
        {
            return x * Math.Sin(x) * Math.Sin(10 * x);
        }
    }
}
