using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik
{
    /// <summary>
    /// Klasa abstrakcyjna reprezentująca osobnika w poluacji rozwiązań.
    /// Klasa zawiera szereg metod odpowiedzialnych za działanie na osobniku.
    /// </summary>
    abstract class AOsobnik
    {
        protected ProblemOptymalizacyjny problemOptymalizacyjny;

        public AOsobnik(ProblemOptymalizacyjny problemOptymalizacyjny)
        {
            this.problemOptymalizacyjny = problemOptymalizacyjny;
        }

        /// <summary>
        /// Metoda zwraca wektor osobnika opisanego genotypem
        /// </summary>
        /// <param name="genotyp">Tablica definiująca dziedzinę rozwiązania</param>
        /// <returns>Dziedzinę wartości funkcji celu</returns>
        public abstract ArrayList Fenotyp(ushort[] genotyp);

        /// <summary>
        /// Metoda zwraca wektor osobnika opisanego genotypem
        /// </summary>
        /// <param name="genotyp">Tablica definiująca dziedzinę rozwiązania</param>
        /// <returns>Dziedzinę wartości funkcji celu</returns>
        public abstract Dictionary<string, ushort[][]> Fenotyp(ushort[][] genotyp);

        /// <summary>
        /// Metoda zwraca wartość funkcji celu
        /// </summary>
        /// <param name="genotyp">Tablica definiująca dziedzinę rozwiązania</param>
        /// <returns>Wartość / Wartości funkcji celu</returns>
        public abstract Dictionary<String, double[]> FunkcjaDopasowania(ReprezentacjaRozwiazania reprezentacjaGenotypu);

        /// <summary>
        /// Metoda zwraca instancje problemu optymalizacyjnego
        /// </summary>
        /// <returns>Instancję problemu optymalizacyjnego</returns>
        public ProblemOptymalizacyjny ZwrocInstancjeProblemu()
        {
            return problemOptymalizacyjny;
        }
    }
}
