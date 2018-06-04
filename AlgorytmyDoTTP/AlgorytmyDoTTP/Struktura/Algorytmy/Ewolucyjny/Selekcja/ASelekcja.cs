using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Genotyp;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Selekcja
{
    abstract class ASelekcja
    {
        protected ushort dlugoscGenotypu;
        protected string typSelekcji;
        protected Random losowy = new Random();
        protected AOsobnik rozwiazanie;

        public ASelekcja(AOsobnik rozwiazanie, ushort dlugoscGenotypu, string typSelekcji)
        {
            this.dlugoscGenotypu = dlugoscGenotypu;
            this.rozwiazanie = rozwiazanie;
            this.typSelekcji = typSelekcji;
        }

        public abstract ReprezentacjaGenotypu WybierzOsobnika(ArrayList populacja);
        protected abstract ReprezentacjaGenotypu Turniej(ArrayList populacja);
        protected abstract ReprezentacjaGenotypu MetodaRuletki(ArrayList populacja);
    }
}
