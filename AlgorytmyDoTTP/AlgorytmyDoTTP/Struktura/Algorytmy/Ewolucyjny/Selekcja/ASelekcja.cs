using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Selekcja
{
    abstract class ASelekcja
    {
        public abstract ushort[] WybierzOsobnika(ArrayList populacja);
        protected abstract ushort[] Turniej(ArrayList populacja);
        protected abstract ushort[] MetodaRuletki(ArrayList populacja);
    }
}
