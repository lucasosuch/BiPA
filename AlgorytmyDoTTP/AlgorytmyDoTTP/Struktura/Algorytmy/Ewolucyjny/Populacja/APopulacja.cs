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
    }
}
