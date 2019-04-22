using BiPA.Struktura.Algorytmy.Abstrakcyjny;
using BiPA.Struktura.Algorytmy.Losowy.Losowanie;
using BiPA.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;

namespace BiPA.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    /// <summary>
    /// Klasa konkretna odpowiedzialna za stworzenie populacji osobników pod Problem Komiwojażera
    /// </summary>
    class PopulacjaTSP : IPopulacja
    {
        public ReprezentacjaRozwiazania[] StworzPopulacjeBazowa(ProblemOptymalizacyjny problemOptymalizacyjny, ushort rozmiarPopulacji, ushort dlugoscGenotypu)
        {
            return new LosowanieTSP().LosujRozwiazania(problemOptymalizacyjny, rozmiarPopulacji, dlugoscGenotypu);
        }
    }
}
