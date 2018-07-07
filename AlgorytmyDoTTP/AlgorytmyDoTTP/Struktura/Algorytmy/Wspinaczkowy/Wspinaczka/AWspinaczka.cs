using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using System;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Wspinaczka
{
    /// <summary>
    /// Klasa abstrakcyjna reprezentująca rozwiązanie dla Algorytmu Wspinaczkowego
    /// </summary>
    abstract class AWspinaczka
    {
        protected ALosowanie losowanie;
        protected Random losowy = new Random();
        protected ReprezentacjaRozwiazania reprezentacjaRozwiazania;

        public AWspinaczka(ALosowanie losowanie)
        {
            this.losowanie = losowanie;
            reprezentacjaRozwiazania = losowanie.ZwrocNajlepszeRozwiazanie();
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
        /// Metoda zwraca instancję odpowiedzialną za losowanie rozwiązań wg wybranego Problemu Optymalizacyjnego
        /// </summary>
        /// <returns>Instancję populacji rozwiązań</returns>
        public ALosowanie ZwrocInstancjeLosowania()
        {
            return losowanie;
        }

        /// <summary>
        /// Metoda przeszukuje przestrzeń rozwiązań szukając optymalnej wartości funkcji celu
        /// </summary>
        /// <returns>Znalezioną optymalną wartość funkcji celu</returns>
        public abstract Dictionary<string, double[]> ZnajdzOptimum();
    }
}
