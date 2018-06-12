using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Wynik
{
    abstract class AWynik
    {
        protected ArrayList listaRozwiazan;
        protected ReprezentacjaRozwiazania najlepszeRozwiazanie;
        protected Dictionary<string, double[]> najlepszyWynik;

        public AWynik(ArrayList listaRozwiazan, ProblemOptymalizacyjny problemOptymalizacyjny)
        {
            this.listaRozwiazan = listaRozwiazan;
        }

        public ReprezentacjaRozwiazania ZwrocNajlepszeRozwiazanie()
        {
            return najlepszeRozwiazanie;
        }

        public Dictionary<string, double[]> ZwrocNajlepszyWynik()
        {
            return najlepszyWynik;
        }

        public ArrayList ZwrocListeRozwiazan()
        {
            return listaRozwiazan;
        }
    }
}
