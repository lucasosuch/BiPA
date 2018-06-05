using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    abstract class APopulacja
    {
        protected ushort maxAllel;
        protected ushort dlugoscGenotypu;
        protected ushort rozmiarPopulacji;

        public APopulacja(ushort rozmiarPopulacji, ushort dlugoscGenotypu)
        {
            maxAllel = 2;
            this.dlugoscGenotypu = dlugoscGenotypu;
            this.rozmiarPopulacji = rozmiarPopulacji;
        }

        public APopulacja(ushort rozmiarPopulacji, ushort dlugoscGenotypu, ushort maxAllel)
        {
            this.maxAllel = maxAllel;
            this.dlugoscGenotypu = dlugoscGenotypu;
            this.rozmiarPopulacji = rozmiarPopulacji;
        }

        public abstract ArrayList StworzPopulacjeBazowa();
    }
}
