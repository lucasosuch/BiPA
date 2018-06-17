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

            string text = "";

            foreach(ushort[] genotyp in najlepszeRozwiazanie.ZwrocGenotyp2Wymiarowy())
            {
                text += string.Join(",", genotyp) + Environment.NewLine;
            }

            zwracanyTekst["dziedzina"] = new string[] { "Najlepszy genotyp", text };
            zwracanyTekst["maxWartosc"] = new string[] { "Najlepsza funkcja przystosowania", najlepszyWynik["max"][0].ToString() + " | " + najlepszyWynik["min"][0].ToString() };

            return zwracanyTekst;
        }

        public AWynik ZwrocInstancjeWyniku()
        {
            return wynik;
        }
    }
}
