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
            
            return analiza.ZwrocOdpowiedz(najlepszeRozwiazanie, najlepszyWynik);
        }

        public AWynik ZwrocInstancjeWyniku()
        {
            return wynik;
        }
    }
}
