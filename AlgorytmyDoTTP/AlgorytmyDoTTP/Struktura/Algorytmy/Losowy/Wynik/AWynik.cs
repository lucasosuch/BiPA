using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Wynik
{
    abstract class AWynik
    {
        protected ReprezentacjaRozwiazania najlepszeRozwiazanie;
        protected Dictionary<string, double[]> najlepszyWynik;

        public AWynik(ALosowanie losowanie, ProblemOptymalizacyjny problemOptymalizacyjny)
        {

        }

        public ReprezentacjaRozwiazania ZwrocNajlepszeRozwiazanie()
        {
            return najlepszeRozwiazanie;
        }

        public Dictionary<string, double[]> ZwrocNajlepszyWynik()
        {
            return najlepszyWynik;
        }
    }
}
