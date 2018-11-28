using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
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
        private AnalizaRLS_RS analiza;

        public RS(ALosowanie losowanie, int iloscRozwiazan, int iloscElementow, AnalizaRLS_RS analiza)
        {
            this.losowanie = losowanie;
            this.iloscRozwiazan = iloscRozwiazan;
            this.iloscElementow = iloscElementow;
            this.analiza = analiza;
        }

        public void Start()
        {
            analiza.RozpocznijPomiarCzasu();
            losowanie.SzukajNajlepszegoRozwiazania(iloscRozwiazan, iloscElementow);
            ReprezentacjaRozwiazania najlepszeRozwiazanie = losowanie.ZwrocNajlepszeRozwiazanie();
            Dictionary<string, float[]> najlepszyWynik = losowanie.ZwrocNajlepszyWynik();
            analiza.ZakonczPomiarCzasu();
            
            //return analiza.ZwrocOdpowiedz(najlepszeRozwiazanie, najlepszyWynik);
        }
    }
}
