using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Wynik
{
    /// <summary>
    /// Klasa abstrakcyjna szukająca najlepszego rozwiązania w liście rozwiązań
    /// </summary>
    abstract class AWynik
    {
        protected ReprezentacjaRozwiazania[] listaRozwiazan;
        protected ReprezentacjaRozwiazania najlepszeRozwiazanie;
        protected Dictionary<string, double[]> najlepszyWynik;

        public AWynik(ReprezentacjaRozwiazania[] listaRozwiazan, ProblemOptymalizacyjny problemOptymalizacyjny)
        {
            this.listaRozwiazan = listaRozwiazan;
            najlepszyWynik = new Dictionary<string, double[]>();
        }

        /// <summary>
        /// Metoda zwraca najlepsze znalezione rozwiązanie
        /// </summary>
        /// <returns>Najlepsze rozwiązanie</returns>
        public ReprezentacjaRozwiazania ZwrocNajlepszeRozwiazanie()
        {
            return najlepszeRozwiazanie;
        }

        /// <summary>
        /// Metoda zwraca najlepszy wynik
        /// </summary>
        /// <returns>Najlepszy wynik funkcji</returns>
        public Dictionary<string, double[]> ZwrocNajlepszyWynik()
        {
            return najlepszyWynik;
        }

        /// <summary>
        /// Metoda zwraca listę osobników - rozwiązań
        /// </summary>
        /// <returns>Lista osobników - rozwiązań</returns>
        public ReprezentacjaRozwiazania[] ZwrocListeRozwiazan()
        {
            return listaRozwiazan;
        }
    }
}
