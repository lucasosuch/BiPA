using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Rozwiazanie;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy
{
    class RLS : IAlgorytm
    {
        private ALosowanie losowanie;
        private ARozwiazanie rozwiazanie;

        public RLS()
        {
            throw new Exception();
        }

        public RLS(ALosowanie losowanie, ARozwiazanie rozwiazanie)
        {
            this.losowanie = losowanie;
            this.rozwiazanie = rozwiazanie;
        }

        public Dictionary<string, string[]> Start()
        {
            Dictionary<string, string[]> zwracanyTekst = new Dictionary<string, string[]>();
            ArrayList rozwiazania = losowanie.LosujRozwiazania();



            rozwiazanie.UstawRozwiazanie(wynik);
            Dictionary<string, double[]> znalezioneOptimum = rozwiazanie.ZnajdzOptimum();
            wynik = (ushort[])(rozwiazanie.ZwrocRozwiazanie().Clone());

            zwracanyTekst["dziedzina"] = new string[] { "Najlepszy genotyp", string.Join(",", wynik) };
            zwracanyTekst["maxWartosc"] = new string[] { "Najlepsza funkcja przystosowania", znalezioneOptimum["max"][0].ToString() +" | "+ znalezioneOptimum["min"][0].ToString() };

            return zwracanyTekst;
        }
    }
}
