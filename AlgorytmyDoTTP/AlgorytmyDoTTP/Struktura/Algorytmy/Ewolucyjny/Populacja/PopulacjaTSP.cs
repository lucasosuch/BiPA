using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    /// <summary>
    /// Klasa konkretna odpowiedzialna za stworzenie populacji osobników pod Problem Komiwojażera
    /// </summary>
    class PopulacjaTSP : IPopulacja
    {
        public ReprezentacjaRozwiazania[] StworzPopulacjeBazowa(ushort rozmiarPopulacji, ushort dlugoscGenotypu)
        {
            return new LosowanieTSP().LosujRozwiazania(rozmiarPopulacji, dlugoscGenotypu);
        }

        public ReprezentacjaRozwiazania[] StworzPopulacjeBazowa(ProblemOptymalizacyjny problemOptymalizacyjny, ushort rozmiarPopulacji)
        {
            throw new NotImplementedException();
        }
    }
}
