using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Wynik;
using AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Rozwiazanie;
using System;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy
{
    /// <summary>
    /// Klasa konkretna Algorytmu Wspinaczkowego.
    /// Pozwala na wyszukanie rozwiązania optymalnego danego problemu wg zasad działania Algorytmów Wspinaczkowych
    /// </summary>
    class RLS : IAlgorytm
    {
        private AWynik wynik;
        private ARozwiazanie rozwiazanie;

        public RLS()
        {
            throw new Exception();
        }

        public RLS(ARozwiazanie rozwiazanie, AWynik wynik)
        {
            this.rozwiazanie = rozwiazanie;
            this.wynik = wynik;
        }

        public Dictionary<string, string[]> Start()
        {
            AnalizaRLS_RS analiza = new AnalizaRLS_RS();
            Dictionary<string, string[]> zwracanyTekst = new Dictionary<string, string[]>();

            analiza.RozpocznijPomiarCzasu();
            ReprezentacjaRozwiazania tymczasoweRozwiazanie = wynik.ZwrocNajlepszeRozwiazanie();
            rozwiazanie.UstawRozwiazanie(tymczasoweRozwiazanie);
            Dictionary<string, double[]> znalezioneOptimum = rozwiazanie.ZnajdzOptimum();
            analiza.ZakonczPomiarCzasu();
            ReprezentacjaRozwiazania najlepszeRozwiazanie = rozwiazanie.ZwrocRozwiazanie();

            return analiza.ZwrocOdpowiedz(najlepszeRozwiazanie, znalezioneOptimum);
        }
    }
}
