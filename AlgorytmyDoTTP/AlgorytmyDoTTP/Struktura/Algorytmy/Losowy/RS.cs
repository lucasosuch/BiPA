using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Wynik;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy
{
    class RS : IAlgorytm
    {
        private AWynik wynik;

        public RS()
        {
            throw new Exception();
        }

        public RS(AWynik wynik)
        {
            this.wynik = wynik;
        }

        public Dictionary<string, string[]> Start()
        {
            Dictionary<string, string[]> zwracanyTekst = new Dictionary<string, string[]>();
            ReprezentacjaRozwiazania najlepszeRozwiazanie = wynik.ZwrocNajlepszeRozwiazanie();
            Dictionary<string, double[]> najlepszyWynik = wynik.ZwrocNajlepszyWynik();

            ArrayList listaRozwiazan = wynik.ZwrocListeRozwiazan();

            zwracanyTekst["dziedzina"] = new string[] { "Najlepszy genotyp", string.Join(",", najlepszeRozwiazanie.ZwrocGenotyp1Wymiarowy()) };
            zwracanyTekst["maxWartosc"] = new string[] { "Najlepsza funkcja przystosowania", najlepszyWynik["max"][0].ToString() + " | " + najlepszyWynik["min"][0].ToString() };

            return zwracanyTekst;
        }

        public AWynik ZwrocInstancjeWyniku()
        {
            return wynik;
        }
    }
}
