using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using System.Collections;
using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    class PopulacjaKP : IPopulacja
    {
        public ArrayList StworzPopulacjeBazowa(ushort rozmiarPopulacji, ushort dlugoscGenotypu)
        {
            return new LosowanieKP().LosujRozwiazania(rozmiarPopulacji, dlugoscGenotypu);
        }

        public ArrayList StworzPopulacjeBazowa(ushort rozmiarPopulacji, ushort dlugoscGenotypu, ushort maxAllel)
        {
            throw new NotImplementedException();
        }

        public ArrayList StworzPopulacjeBazowa(ushort rozmiarPopulacji, ushort dlugoscGenotypu, ushort maxAllel, ushort[][] dostepnoscPrzedmiotow)
        {
            throw new NotImplementedException();
        }
    }
}
