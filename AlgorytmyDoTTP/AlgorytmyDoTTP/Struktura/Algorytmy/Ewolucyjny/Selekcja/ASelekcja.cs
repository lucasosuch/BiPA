using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Selekcja
{
    /// <summary>
    /// Klasa abstrakcyjna udostępniająca metody służące do wyboru najlepiej przystosowanych osobników
    /// </summary>
    abstract class ASelekcja
    {
        protected int pokolenie;
        protected ushort dlugoscGenotypu;
        protected string typSelekcji;
        protected ArrayList wskazniki;
        protected Random losowy = new Random();
        protected AOsobnik rozwiazanie;

        public ASelekcja(AOsobnik rozwiazanie, ushort dlugoscGenotypu, string typSelekcji)
        {
            this.dlugoscGenotypu = dlugoscGenotypu;
            this.rozwiazanie = rozwiazanie;
            this.typSelekcji = typSelekcji;
        }

        /// <summary>
        /// Metoda odpowiedzialna wybór osobnika z populacji za pomocą dostępnych metod selekcyjnych
        /// </summary>
        /// <param name="populacja">Populacja osobników - rozwiązań</param>
        /// <returns>Osobnik - rozwiązanie</returns>
        public abstract ReprezentacjaRozwiazania WybierzOsobnika(ReprezentacjaRozwiazania[] populacja, int pokolenie);

        /// <summary>
        /// Metoda odpowiedzialna wybór osobnika z populacji za pomocą turnieju - czyli "najlepszego" osobnika z pewnej pod populacji
        /// </summary>
        /// <param name="populacja">Populacja osobników - rozwiązań</param>
        /// <returns>Osobnik - rozwiązanie</returns>
        protected abstract ReprezentacjaRozwiazania Turniej(ReprezentacjaRozwiazania[] populacja);

        /// <summary>
        /// Metoda odpowiedzialna wybór osobnika z populacji za pomocą ruletki - czyli nadania współczynników całej populacji i wyboru za pomocą tych współczynników najlepiej przystosowanych osobników
        /// </summary>
        /// <param name="populacja">Populacja osobników - rozwiązań</param>
        /// <returns>Osobnik - rozwiązanie</returns>
        protected abstract ReprezentacjaRozwiazania MetodaRuletki(ReprezentacjaRozwiazania[] populacja);

        /// <summary>
        /// Metoda nadająca wskaźniki dla całej populacji osobników
        /// </summary>
        /// <param name="populacja">Populacja osobników - rozwiązań</param>
        /// <returns>Lista wskaźników osobników w populacji</returns>
        protected abstract ArrayList ZwrocWskazniki(ReprezentacjaRozwiazania[] populacja);
    }
}
