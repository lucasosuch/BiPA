using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy
{
    /// <summary>
    /// Klasa konkretna Algorytmu Wspinaczkowego.
    /// Pozwala na wyszukanie rozwiązania optymalnego danego problemu wg zasad działania Algorytmów Wspinaczkowych
    /// </summary>
    class RLS : IAlgorytm
    {
        private ARozwiazanie rozwiazanie;

        public RLS(ARozwiazanie rozwiazanie)
        {
            this.rozwiazanie = rozwiazanie;
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
