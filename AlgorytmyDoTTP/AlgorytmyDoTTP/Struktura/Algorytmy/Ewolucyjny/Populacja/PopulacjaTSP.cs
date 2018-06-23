using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using System.Collections;
using System;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    /// <summary>
    /// Klasa konkretna odpowiedzialna za stworzenie populacji osobników pod Problem Komiwojażera
    /// </summary>
    class PopulacjaTSP : IPopulacja
    {
        public ArrayList StworzPopulacjeBazowa(ushort rozmiarPopulacji, ushort dlugoscGenotypu)
        {
            return new LosowanieTSP().LosujRozwiazania(rozmiarPopulacji, dlugoscGenotypu);
        }

        public ArrayList StworzPopulacjeBazowa(ProblemOptymalizacyjny problemOptymalizacyjny, ushort rozmiarPopulacji)
        {
            throw new NotImplementedException();
        }
    }
}
