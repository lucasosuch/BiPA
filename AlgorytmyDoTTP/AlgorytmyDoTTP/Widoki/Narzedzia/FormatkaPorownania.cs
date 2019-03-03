using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Widoki.Narzedzia
{
    /// <summary>
    /// Klasa narzędziowa widoku porównywania
    /// </summary>
    class FormatkaPorownania : FormatkaGlowna
    {
        public string RysujWykres(Dictionary<string, double[][]> paramentry, int szerokosc, int wysokosc, string[] nazwyPlikow)
        {
            double[][] wartosciSrednie = new double[paramentry.Count][],
                       wartosciMin = new double[paramentry.Count][],
                       wartosciMax = new double[paramentry.Count][];
            WynikiAnalizy wynikiAnalizy = new WynikiAnalizy();

            int i = 0;
            string[] nazwyBadan = new string[paramentry.Count];
            foreach (KeyValuePair<string, double[][]> linia in paramentry)
            {
                nazwyBadan[i] = linia.Key;
                wartosciSrednie[i] = linia.Value[0];
                wartosciMin[i] = linia.Value[1];
                wartosciMax[i] = linia.Value[2];
                i++;
            }

            float[][] ranking = wynikiAnalizy.ZwrocRanking(wartosciMin, wartosciMax, wartosciSrednie);
            float[][][] wyniki = wynikiAnalizy.PrzetworzDane(ranking, wartosciSrednie, wartosciMin, wartosciMax);

            wynikiAnalizy.StworzWykresyGNUplot(szerokosc, wysokosc, nazwyBadan, nazwyPlikow, wartosciMin, wartosciMax, wartosciSrednie);

            return wynikiAnalizy.WyswietlInformacjeZwrotna(ranking, wyniki[2], wyniki[0], wyniki[1], nazwyBadan);
        }
    }
}
