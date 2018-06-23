using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja
{
    /// <summary>
    /// Klasa abstrakcyjna odpowiedzialna wymianę materiału genetycznego pomiędzy poszczególnymi osobnikami
    /// </summary>
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

        /// <summary>
        /// Metoda odpowiedzialna ustalenie, czy sprawdzamy ograniczenia dziedziny
        /// </summary>
        /// <param name="wartosc">Wartość pozwalająca ustalić, czy sprawdzamy ograniczenia</param>
        public void ZmienSprawdzanieOgraniczen(bool wartosc)
        {
            czySprawdzacOgraniczenia = wartosc;
        }

        /// <summary>
        /// Metoda odpowiedzialna ustalenie, czy sprawdzamy ograniczenia dziedziny
        /// </summary>
        /// <param name="przodek1">1 przodek do krzyżowania</param>
        /// <param name="przodek2">2 przodek do krzyżowania</param>
        public abstract ReprezentacjaRozwiazania Krzyzowanie(ReprezentacjaRozwiazania przodek1, ReprezentacjaRozwiazania przodek2);

        /// <summary>
        /// Metoda odpowiedzialna ustalenie, czy sprawdzamy ograniczenia dziedziny
        /// </summary>
        /// <param name="geny">Genotyp do wykonania na nim operacji mutacji</param>
        protected abstract ReprezentacjaRozwiazania Mutacja(ReprezentacjaRozwiazania geny);

        /// <summary>
        /// Metoda odpowiedzialna ustalenie, czy sprawdzamy ograniczenia dziedziny
        /// </summary>
        /// <param name="geny">Genotyp osobnika, sprawdzany pod kątem błędów</param>
        protected abstract ReprezentacjaRozwiazania SprawdzNaruszenieOgraniczen(ReprezentacjaRozwiazania geny);
    }
}
