using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Wynik;
using System;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy
{
    /// <summary>
    /// Klasa konkretna Algorytmu Losowego.
    /// Pozwala na wyszukanie rozwiązania optymalnego danego problemu wg zasad działania Algorytmów Losowego
    /// </summary>
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
            AnalizaRLS_RS analiza = new AnalizaRLS_RS();
            Dictionary<string, string[]> zwracanyTekst = new Dictionary<string, string[]>();

            analiza.RozpocznijPomiarCzasu();
            ReprezentacjaRozwiazania najlepszeRozwiazanie = wynik.ZwrocNajlepszeRozwiazanie();
            Dictionary<string, double[]> najlepszyWynik = wynik.ZwrocNajlepszyWynik();
            analiza.ZakonczPomiarCzasu();

            double czasDzialania = analiza.ZwrocCzasDzialaniaAlgorytmu();
            zwracanyTekst["dziedzina"] = new string[] { "Najlepszy genotyp", analiza.ZwrocNajlepszeRozwiazanie(najlepszeRozwiazanie) };
            zwracanyTekst["maxWartosc"] = new string[] { "Najlepsza funkcja przystosowania (max) ", najlepszyWynik["max"][0].ToString() };
            zwracanyTekst["minWartosc"] = new string[] { "Najlepsza funkcja przystosowania (min) ", najlepszyWynik["min"][0].ToString() };
            zwracanyTekst["czasDzialania"] = new string[] { "Czas dzialania algorytmu", czasDzialania.ToString() };

            return zwracanyTekst;
        }

        public AWynik ZwrocInstancjeWyniku()
        {
            return wynik;
        }
    }
}
