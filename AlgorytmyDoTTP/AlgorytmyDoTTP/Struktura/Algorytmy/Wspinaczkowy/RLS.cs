using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Wynik;
using AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Rozwiazanie;
using System;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy
{
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

            double czasDzialania = analiza.ZwrocCzasDzialaniaAlgorytmu();
            zwracanyTekst["dziedzina"] = new string[] { "Najlepszy genotyp", analiza.ZwrocNajlepszeRozwiazanie(najlepszeRozwiazanie) };
            zwracanyTekst["maxWartosc"] = new string[] { "Najlepsza funkcja przystosowania (max)", znalezioneOptimum["max"][0].ToString() };
            zwracanyTekst["minWartosc"] = new string[] { "Najlepsza funkcja przystosowania (min)", znalezioneOptimum["min"][0].ToString() };
            zwracanyTekst["czasDzialania"] = new string[] { "Czas dzialania algorytmu", czasDzialania.ToString() };

            return zwracanyTekst;
        }
    }
}
