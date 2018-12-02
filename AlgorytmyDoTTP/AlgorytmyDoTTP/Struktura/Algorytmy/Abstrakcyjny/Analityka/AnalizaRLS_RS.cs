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
        public AnalizaRLS_RS(AOsobnik rozwiazanie, short liczbaIteracji, short czasDzialania) : base(rozwiazanie, liczbaIteracji, czasDzialania)
        { }

        public override void DopiszWartoscProcesu(short index, int czas, ReprezentacjaRozwiazania genotyp)
        {
            throw new System.NotImplementedException();
        }

        public override void StworzWykresGNUplot()
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string[]> ZwrocOdpowiedz(ReprezentacjaRozwiazania najlepszeRozwiazanie, Dictionary<string, float[]> znalezioneOptimum)
        {
            Dictionary<string, string[]> zwracanyTekst = new Dictionary<string, string[]>();

            zwracanyTekst["dziedzina"] = new string[] { "Najlepszy genotyp", ZwrocNajlepszeZnalezioneRozwiazanie(najlepszeRozwiazanie) };
            zwracanyTekst["maxWartosc"] = new string[] { "Najlepsza funkcja przystosowania (max)", znalezioneOptimum["max"][0].ToString() };
            zwracanyTekst["minWartosc"] = new string[] { "Najlepsza funkcja przystosowania (min)", znalezioneOptimum["min"][0].ToString() };
            zwracanyTekst["czasDzialania"] = new string[] { "Czas dzialania algorytmu", IleCzasuDzialaAlgorytm("ms").ToString() + " ms" };

            return zwracanyTekst;
        }
    }
}
