using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using System.Collections;
using System;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    /// <summary>
    /// Klasa konkretna odpowiedzialna za stworzenie populacji osobników pod Problem Plecakowy
    /// </summary>
    class PopulacjaKP : IPopulacja
    {
        public ArrayList StworzPopulacjeBazowa(ProblemOptymalizacyjny problemOptymalizacyjny, ushort rozmiarPopulacji)
        {
            return new LosowanieKP().LosujRozwiazania(problemOptymalizacyjny, rozmiarPopulacji);
        }

        public ArrayList StworzPopulacjeBazowa(ushort rozmiarPopulacji, ushort dlugoscGenotypu)
        {
            throw new NotImplementedException();
        }
    }
}
