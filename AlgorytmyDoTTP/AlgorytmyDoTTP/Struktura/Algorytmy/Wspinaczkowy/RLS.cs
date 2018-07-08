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
        private AWspinaczka przeszukiwanieLokalne;

        public RLS(AWspinaczka przeszukiwanieLokalne)
        {
            this.przeszukiwanieLokalne = przeszukiwanieLokalne;
        }

        public Dictionary<string, string[]> Start()
        {
            AnalizaRLS_RS analiza = new AnalizaRLS_RS();
            Dictionary<string, string[]> zwracanyTekst = new Dictionary<string, string[]>();

            analiza.RozpocznijPomiarCzasu();
            Dictionary<string, double[]> znalezioneOptimum = przeszukiwanieLokalne.ZnajdzOptimum();
            analiza.ZakonczPomiarCzasu();
            ReprezentacjaRozwiazania najlepszeRozwiazanie = przeszukiwanieLokalne.ZwrocRozwiazanie();

            return analiza.ZwrocOdpowiedz(najlepszeRozwiazanie, znalezioneOptimum);
        }
    }
}
