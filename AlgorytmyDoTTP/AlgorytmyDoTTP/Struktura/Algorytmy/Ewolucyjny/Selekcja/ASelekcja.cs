using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Selekcja
{
    abstract class ASelekcja
    {
        protected ushort dlugoscGenotypu;
        protected Random losowy = new Random();
        protected AOsobnik rozwiazanie;
        protected String typSelekcji;

        public ASelekcja(AOsobnik rozwiazanie, ushort dlugoscGenotypu, String typSelekcji)
        {
            this.dlugoscGenotypu = dlugoscGenotypu;
            this.rozwiazanie = rozwiazanie;
            this.typSelekcji = typSelekcji;
        }

        public abstract ushort[] WybierzOsobnika(ArrayList populacja);
        protected abstract ushort[] Turniej(ArrayList populacja);
        protected abstract ushort[] MetodaRuletki(ArrayList populacja);
    }
}
