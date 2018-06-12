using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using System.Collections;
using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    class PopulacjaTSP : IPopulacja
    {
        public ArrayList StworzPopulacjeBazowa(ushort rozmiarPopulacji, ushort dlugoscGenotypu, ushort maxAllel)
        {
            return new LosowanieTSP().LosujRozwiazania(rozmiarPopulacji, dlugoscGenotypu, maxAllel);
        }

        public ArrayList StworzPopulacjeBazowa(ushort rozmiarPopulacji, ushort dlugoscGenotypu)
        {
            throw new NotImplementedException();
        }

        public ArrayList StworzPopulacjeBazowa(ushort rozmiarPopulacji, ushort dlugoscGenotypu, ushort maxAllel, ushort[][] dostepnoscPrzedmiotow)
        {
            throw new NotImplementedException();
        }
    }
}
