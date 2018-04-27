using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik
{
    class OsobnikKP : AOsobnik
    {
        public OsobnikKP(ProblemOptymalizacyjny problemPlecakowy)
        {
            problemOptymalizacyjny = problemPlecakowy;
        }

        public override ArrayList Fenotyp(ushort[] genotyp)
        {
            return ((ProblemPlecakowy)problemOptymalizacyjny).ZwrocWybraneElementy(genotyp);
        }

        public override Dictionary<String, double[]> FunkcjaDopasowania(ushort[] genotyp)
        {
            return problemOptymalizacyjny.ObliczZysk(Fenotyp((genotyp)));
        }
    }
}
