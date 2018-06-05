using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
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

        public abstract ReprezentacjaRozwiazania Krzyzowanie(ReprezentacjaRozwiazania przodek1, ReprezentacjaRozwiazania przodek2);

        protected abstract ReprezentacjaRozwiazania Mutacja(ReprezentacjaRozwiazania geny);

        protected abstract ReprezentacjaRozwiazania SprawdzNaruszenieOgraniczen(ReprezentacjaRozwiazania geny);
    }
}
