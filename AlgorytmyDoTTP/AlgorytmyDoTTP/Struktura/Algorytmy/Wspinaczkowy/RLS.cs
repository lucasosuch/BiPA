using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Wspinaczka;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy
{
    /// <summary>
    /// Klasa konkretna Algorytmu Wspinaczkowego.
    /// Pozwala na wyszukanie rozwiązania optymalnego danego problemu wg zasad działania Algorytmów Wspinaczkowych
    /// </summary>
    class RLS : IAlgorytm
    {
        private AnalizaRLS_RS analiza;
        private AWspinaczka przeszukiwanieLokalne;

        public RLS(AWspinaczka przeszukiwanieLokalne, AnalizaRLS_RS analiza)
        {
            this.analiza = analiza;
            this.przeszukiwanieLokalne = przeszukiwanieLokalne;
        }

        public Dictionary<string, string[]> Start()
        {
            analiza.RozpocznijPomiarCzasu();
            Dictionary<string, double[]> znalezioneOptimum = przeszukiwanieLokalne.ZnajdzOptimum();
            analiza.ZakonczPomiarCzasu();
            ReprezentacjaRozwiazania najlepszeRozwiazanie = przeszukiwanieLokalne.ZwrocRozwiazanie();

            return analiza.ZwrocOdpowiedz(najlepszeRozwiazanie, znalezioneOptimum);
        }
    }
}
