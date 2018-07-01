using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    interface IPopulacja
    {
        /// <summary>
        /// Metoda populację osobników dla Algorytmu Ewolucyjnego
        /// </summary>
        /// <param name="rozmiarPopulacji">Liczba osobników w populacji</param>
        /// <param name="dlugoscGenotypu">Informacja o wielkości dziedziny</param>
        /// <returns>Populacja osobników - rozwiązań</returns>
        ReprezentacjaRozwiazania[] StworzPopulacjeBazowa(ushort rozmiarPopulacji, ushort dlugoscGenotypu);

        /// <summary>
        /// Metoda populację osobników dla Algorytmu Ewolucyjnego
        /// </summary>
        /// <param name="rozmiarPopulacji">Liczba osobników w populacji</param>
        /// <param name="dlugoscGenotypu">Informacja o wielkości dziedziny</param>
        /// <returns>Populacja osobników - rozwiązań</returns>
        ReprezentacjaRozwiazania[] StworzPopulacjeBazowa(ProblemOptymalizacyjny problemOptymalizacyjny, ushort rozmiarPopulacji);
    }
}
