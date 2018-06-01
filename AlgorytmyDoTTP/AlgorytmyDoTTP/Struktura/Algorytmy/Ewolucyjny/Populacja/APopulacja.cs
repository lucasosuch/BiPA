using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    abstract class APopulacja
    {
        protected ushort maxAllel;
        protected ushort dlugoscGenotypu;
        protected ushort rozmiarPopulacji;
        protected Random losowy = new Random();
        protected ArrayList populacja = new ArrayList();
        public abstract ArrayList StworzPopulacjeBazowa();

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
    }
}
