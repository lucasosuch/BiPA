using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    class PopulacjaKP : APopulacja
    {
        public PopulacjaKP(ushort rozmiarPopulacji, ushort dlugoscGenotypu) : base(rozmiarPopulacji, dlugoscGenotypu) { }

        public PopulacjaKP(ushort rozmiarPopulacji, ushort dlugoscGenotypu, ushort maxAllel) : base(rozmiarPopulacji, dlugoscGenotypu, maxAllel) { }

        public override ArrayList StworzPopulacjeBazowa()
        {
            return new LosowanieKP(rozmiarPopulacji, dlugoscGenotypu, maxAllel).LosujRozwiazania();
        }
    }
}
