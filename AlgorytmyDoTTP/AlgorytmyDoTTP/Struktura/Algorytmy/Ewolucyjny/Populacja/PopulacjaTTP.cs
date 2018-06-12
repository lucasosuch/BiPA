using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using System.Collections;
using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    class PopulacjaTTP : IPopulacja
    {
        public ArrayList StworzPopulacjeBazowa(ushort rozmiarPopulacji, ushort dlugoscGenotypu, ushort maxAllel, ushort[][] dostepnoscPrzedmiotow)
        {
            return new LosowanieTTP().LosujRozwiazania(rozmiarPopulacji, dlugoscGenotypu, maxAllel, dostepnoscPrzedmiotow);
        }

        public ArrayList StworzPopulacjeBazowa(ushort rozmiarPopulacji, ushort dlugoscGenotypu)
        {
            throw new NotImplementedException();
        }

        public ArrayList StworzPopulacjeBazowa(ushort rozmiarPopulacji, ushort dlugoscGenotypu, ushort maxAllel)
        {
            throw new NotImplementedException();
        }
    }
}
