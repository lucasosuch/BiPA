using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja
{
    abstract class ARekombinacja
    {
        protected double pwoMutacji;
        protected AOsobnik rozwiazanie;
        protected string rodzajKrzyzowania;
        protected Random losowy = new Random();

        public ARekombinacja(double pwoMutacji, AOsobnik rozwiazanie)
        {
            this.pwoMutacji = pwoMutacji;
            this.rozwiazanie = rozwiazanie;
            this.rodzajKrzyzowania = "Proste";
        }

        public ARekombinacja(double pwoMutacji, AOsobnik rozwiazanie, string rodzajKrzyzowania)
        {
            this.pwoMutacji = pwoMutacji;
            this.rozwiazanie = rozwiazanie;
            this.rodzajKrzyzowania = rodzajKrzyzowania;
        }

        public abstract ushort[] Krzyzowanie(ushort[] przodek1, ushort[] przodek2);

        protected abstract ushort[] Mutacja(ushort[] geny);

        protected abstract ushort[] SprawdzNaruszenieOgraniczen(ushort[] geny);
    }
}
