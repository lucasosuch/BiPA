using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka
{
    /// <summary>
    /// Klasa analityczna.
    /// Podstawowa klasa pod analizę dla algorytmu wspinaczkowego oraz algorytmu losowego.
    /// </summary>
    class AnalizaRLS_RS: AAnalityka
    {
        public AnalizaRLS_RS(AOsobnik rozwiazanie, short liczbaIteracji) : base(rozwiazanie, liczbaIteracji)
        { }

        public override void DopiszWartoscProcesu(short index, float czas, ReprezentacjaRozwiazania genotyp)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string[]> ZwrocOdpowiedz(ReprezentacjaRozwiazania najlepszeRozwiazanie, Dictionary<string, float[]> znalezioneOptimum)
        {
            Dictionary<string, string[]> zwracanyTekst = new Dictionary<string, string[]>();

            zwracanyTekst["dziedzina"] = new string[] { "Najlepszy genotyp", ZwrocNajlepszeRozwiazanie(najlepszeRozwiazanie) };
            zwracanyTekst["maxWartosc"] = new string[] { "Najlepsza funkcja przystosowania (max)", znalezioneOptimum["max"][0].ToString() };
            zwracanyTekst["minWartosc"] = new string[] { "Najlepsza funkcja przystosowania (min)", znalezioneOptimum["min"][0].ToString() };
            zwracanyTekst["czasDzialania"] = new string[] { "Czas dzialania algorytmu", ZwrocCzasDzialaniaAlgorytmu("ms").ToString() + " ms" };

            return zwracanyTekst;
        }
    }
}
