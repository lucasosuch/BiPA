using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    /// <summary>
    /// Klasa konkretna odpowiedzialna za stworzenie populacji osobników pod Problem Podróżującego Złodzieja
    /// </summary>
    class PopulacjaTTP : IPopulacja
    {
        public ReprezentacjaRozwiazania[] StworzPopulacjeBazowa(ProblemOptymalizacyjny problemOptymalizacyjny, ushort rozmiarPopulacji)
        {
            return new LosowanieTTP().LosujRozwiazania(problemOptymalizacyjny, rozmiarPopulacji);
        }

        public ReprezentacjaRozwiazania[] StworzPopulacjeBazowa(ushort rozmiarPopulacji, ushort dlugoscGenotypu)
        {
            throw new NotImplementedException();
        }
    }
}
