using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Wynik;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy
{
    /// <summary>
    /// Klasa konkretna Algorytmu Losowego.
    /// Pozwala na wyszukanie rozwiązania optymalnego danego problemu wg zasad działania Algorytmów Losowego
    /// </summary>
    class RS : IAlgorytm
    {
        private int iloscRozwiazan;
        private int iloscElementow;
        private ALosowanie losowanie;

        public RS(ALosowanie losowanie, int iloscRozwiazan, int iloscElementow)
        {
            this.losowanie = losowanie;
            this.iloscRozwiazan = iloscRozwiazan;
            this.iloscElementow = iloscElementow;
        }

        public Dictionary<string, string[]> Start()
        {
            AnalizaRLS_RS analiza = new AnalizaRLS_RS();

            analiza.RozpocznijPomiarCzasu();
            losowanie.SzukajNajlepszegoRozwiazania(iloscRozwiazan, iloscElementow);
            ReprezentacjaRozwiazania najlepszeRozwiazanie = losowanie.ZwrocNajlepszeRozwiazanie();
            Dictionary<string, double[]> najlepszyWynik = losowanie.ZwrocNajlepszyWynik();
            analiza.ZakonczPomiarCzasu();
            
            return analiza.ZwrocOdpowiedz(najlepszeRozwiazanie, najlepszyWynik);
        }
    }
}
