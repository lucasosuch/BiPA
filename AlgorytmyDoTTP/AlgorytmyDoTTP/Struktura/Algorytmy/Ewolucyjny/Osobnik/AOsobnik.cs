using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik
{
    abstract class AOsobnik
    {
        protected ProblemOptymalizacyjny problemOptymalizacyjny;
        public abstract ArrayList Fenotyp(ushort[] genotyp);
        public abstract Dictionary<String, double[]> FunkcjaDopasowania(ushort[] genotyp);

        public ProblemOptymalizacyjny ZwrocInstancjeProblemu()
        {
            return problemOptymalizacyjny;
        }
    }
}
