using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Rozwiazanie
{
    /// <summary>
    /// Klasa abstrakcyjna reprezentująca rozwiązanie dla Algorytmu Wspinaczkowego
    /// </summary>
    abstract class ARozwiazanie
    {
        protected Random losowy = new Random();
        protected ProblemOptymalizacyjny problem;
        protected ReprezentacjaRozwiazania reprezentacjaRozwiazania;

        public ARozwiazanie(ProblemOptymalizacyjny problem)
        {
            this.problem = problem;
        }

        /// <summary>
        /// Metoda zwraca najlepsze znalezione rozwiązanie
        /// </summary>
        /// <returns>Najlepsze rozwiązanie</returns>
        public ReprezentacjaRozwiazania ZwrocRozwiazanie()
        {
            return reprezentacjaRozwiazania;
        }

        /// <summary>
        /// Metoda ustawia rozwiązanie
        /// </summary>
        /// <param name="reprezentacjaRozwiazania">Reprezentacja rozwiązania</param>
        public void UstawRozwiazanie(ReprezentacjaRozwiazania reprezentacjaRozwiazania)
        {
            this.reprezentacjaRozwiazania = reprezentacjaRozwiazania;
        }

        /// <summary>
        /// Metoda zwraca wybrany Problem Optymalizacyjny
        /// </summary>
        /// <returns>Instancję problemu optymalizacyjnego</returns>
        public ProblemOptymalizacyjny ZwrocProblemOptymalizacyjny()
        {
            return problem;
        }

        /// <summary>
        /// Metoda przeszukuje przestrzeń rozwiązań szukając optymalnej wartości funkcji celu
        /// </summary>
        /// <returns>Znalezioną optymalną wartość funkcji celu</returns>
        public abstract Dictionary<string, double[]> ZnajdzOptimum();
    }
}
