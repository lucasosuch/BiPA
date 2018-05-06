using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik
{
    abstract class AOsobnik
    {
        protected ProblemOptymalizacyjny problemOptymalizacyjny;

        public AOsobnik(ProblemOptymalizacyjny problemOptymalizacyjny)
        {
            this.problemOptymalizacyjny = problemOptymalizacyjny;
        }

        // Zwraca wektor osobnika opisanego genotypem
        public abstract ArrayList Fenotyp(ushort[] genotyp);

        // Zwraca wektor osobnika opisanego genotypem
        public Dictionary<String, double[]> FunkcjaDopasowania(ushort[] genotyp)
        {
            return problemOptymalizacyjny.ObliczZysk(Fenotyp(genotyp));
        }

        // Zwraca instancje problemu optymalizacyjnego
        public ProblemOptymalizacyjny ZwrocInstancjeProblemu()
        {
            return problemOptymalizacyjny;
        }
    }
}
