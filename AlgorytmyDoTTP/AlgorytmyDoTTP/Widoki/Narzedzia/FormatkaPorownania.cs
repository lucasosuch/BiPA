using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace AlgorytmyDoTTP.Widoki.Narzedzia
{
    /// <summary>
    /// Klasa narzędziowa widoku porównywania
    /// </summary>
    class FormatkaPorownania : FormatkaGlowna
    {
        public Series[] ZwrocDaneDlaWykresow(Dictionary<string, string[]> paramentry, int indexDanych)
        {
            int i = 0;
            string plikDanych = "";
            Series[] seria = new Series[paramentry.Count];

            foreach (KeyValuePair<string, string[]> linia in paramentry)
            {
                if (i == 0)
                {
                    plikDanych = linia.Value[3];
                }
                else
                {
                    if (plikDanych != linia.Value[3])
                    {
                        throw new Exception();
                    }
                }

                seria[i] = new Series();
                seria[i].Name = linia.Value[2];
                seria[i].Points.Add(new DataPoint(1, linia.Value[indexDanych]));

                i++;
            }

            return seria;
        }

        public string ZwrocDaneTekstowe(Dictionary<string, string[]> paramentry)
        {
            string wynik = "";
            double sredniCzas = 0,
                   sredniaWartosc = 0;

            foreach (KeyValuePair<string, string[]> linia in paramentry)
            {
                sredniCzas += double.Parse(linia.Value[0]);
                sredniaWartosc += double.Parse(linia.Value[1]);
            }

            sredniCzas /= paramentry.Count;
            sredniaWartosc /= paramentry.Count;

            wynik += "1. Dla wybranych badań: " + Environment.NewLine +
                     " - średni czas: " + sredniCzas +" ms" + Environment.NewLine +
                     " - średnia wartość: " + sredniaWartosc + Environment.NewLine + Environment.NewLine;

            Dictionary<string, double[]> badania = new Dictionary<string, double[]>();
            foreach (KeyValuePair<string, string[]> linia in paramentry)
            {
                badania[linia.Key] = new double[2];

                badania[linia.Key][0] = sredniCzas - double.Parse(linia.Value[0]);
                badania[linia.Key][1] = double.Parse(linia.Value[1]) - sredniaWartosc;
            }

            Dictionary<string, int[]> ranking = new Dictionary<string, int[]>();
            foreach (KeyValuePair<string, double[]> badanie1 in badania)
            {
                ranking[badanie1.Key] = new int[] { 0, 0, 0 };

                foreach (KeyValuePair<string, double[]> badanie2 in badania)
                {
                    if(badanie1.Key != badanie2.Key)
                    {
                        if (badanie1.Value[0] > badanie2.Value[0]) ranking[badanie1.Key][0]++;
                        if (badanie1.Value[1] > badanie2.Value[1]) ranking[badanie1.Key][1]++;
                    }
                }

                ranking[badanie1.Key][2] = ranking[badanie1.Key][0] + ranking[badanie1.Key][1];
            }

            int max = 0;
            string maxBadanie = "";
            foreach (KeyValuePair<string, int[]> ocena in ranking)
            {
                if (max < ocena.Value[2])
                {
                    max = ocena.Value[2];
                    maxBadanie = ocena.Key;
                }
            }

            wynik += "2. Dla najlepszego badania [ "+ maxBadanie +" ]: " + Environment.NewLine +
                     " - odległość od średniego czasu: " + badania[maxBadanie][0] + " ms" + Environment.NewLine +
                     " - czas działania badania: " + paramentry[maxBadanie][0] + " ms" + Environment.NewLine +
                     " - odległość od średniej wartości: " + badania[maxBadanie][1] + Environment.NewLine +
                     " - znaleziona wartość dla badania: " + paramentry[maxBadanie][1];
            
            return wynik;
        }
    }
}
