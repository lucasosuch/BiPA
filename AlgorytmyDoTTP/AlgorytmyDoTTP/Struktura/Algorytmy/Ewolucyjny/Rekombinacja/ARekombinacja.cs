using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Genotyp;
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
        protected bool czySprawdzacOgraniczenia = true;

        public ARekombinacja(double pwoMutacji, AOsobnik rozwiazanie)
        {
            this.pwoMutacji = pwoMutacji;
            this.rozwiazanie = rozwiazanie;
            rodzajKrzyzowania = "Proste";
        }

        public ARekombinacja(double pwoMutacji, AOsobnik rozwiazanie, string rodzajKrzyzowania)
        {
            this.pwoMutacji = pwoMutacji;
            this.rozwiazanie = rozwiazanie;
            this.rodzajKrzyzowania = rodzajKrzyzowania;
        }

        public void ZmienSprawdzanieOgraniczen(bool wartosc)
        {
            czySprawdzacOgraniczenia = wartosc;
        }

        public abstract ReprezentacjaGenotypu Krzyzowanie(ReprezentacjaGenotypu przodek1, ReprezentacjaGenotypu przodek2);

        protected abstract ReprezentacjaGenotypu Mutacja(ReprezentacjaGenotypu geny);

        protected abstract ReprezentacjaGenotypu SprawdzNaruszenieOgraniczen(ReprezentacjaGenotypu geny);
    }
}
