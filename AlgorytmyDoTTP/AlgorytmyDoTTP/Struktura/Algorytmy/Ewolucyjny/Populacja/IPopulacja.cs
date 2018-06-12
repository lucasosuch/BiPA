using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    interface IPopulacja
    {
        ArrayList StworzPopulacjeBazowa(ushort rozmiarPopulacji, ushort dlugoscGenotypu);

        ArrayList StworzPopulacjeBazowa(ushort rozmiarPopulacji, ushort dlugoscGenotypu, ushort maxAllel);

        ArrayList StworzPopulacjeBazowa(ushort rozmiarPopulacji, ushort dlugoscGenotypu, ushort maxAllel, ushort[][] dostepnoscPrzedmiotow);
    }
}
