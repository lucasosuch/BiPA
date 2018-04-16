using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Selekcja
{
    abstract class ASelekcja
    {
        public abstract ushort[] Turniej(ArrayList populacja);

        public abstract ushort[] MetodaRuletki(String typRuletki, ArrayList populacja);
    }
}
