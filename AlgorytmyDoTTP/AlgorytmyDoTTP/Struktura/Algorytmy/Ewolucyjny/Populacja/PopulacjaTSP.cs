using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    class PopulacjaTSP : APopulacja
    {
        public PopulacjaTSP(ushort rozmiarPopulacji, ushort dlugoscGenotypu, ushort maxAllel) : base(rozmiarPopulacji, dlugoscGenotypu, maxAllel){}

        public override ArrayList StworzPopulacjeBazowa()
        {
            return new LosowanieTSP(rozmiarPopulacji, dlugoscGenotypu, maxAllel).LosujRozwiazania();
        }
    }
}
