using BiPA.Struktura.Algorytmy.Abstrakcyjny;
using BiPA.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;

namespace BiPA.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    interface IPopulacja
    {
        /// <summary>
        /// Metoda populację osobników dla Algorytmu Ewolucyjnego
        /// </summary>
        /// <param name="rozmiarPopulacji">Liczba osobników w populacji</param>
        /// <param name="dlugoscGenotypu">Informacja o wielkości dziedziny</param>
        /// <returns>Populacja osobników - rozwiązań</returns>
        ReprezentacjaRozwiazania[] StworzPopulacjeBazowa(ProblemOptymalizacyjny problemOptymalizacyjny, ushort rozmiarPopulacji, ushort dlugoscGenotypu);
    }
}
