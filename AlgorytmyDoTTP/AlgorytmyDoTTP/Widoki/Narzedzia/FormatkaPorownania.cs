using AlgorytmyDoTTP.Rozszerzenia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AlgorytmyDoTTP.Widoki.Narzedzia
{
    /// <summary>
    /// Klasa narzędziowa widoku porównywania
    /// </summary>
    class FormatkaPorownania : FormatkaGlowna
    {
        private bool bladPlikuDanych = false;
        private Random losowy = new Random();

        public Series[] ZwrocDaneDlaWykresow(Dictionary<string, string[]> paramentry, int indexDanych, string sortowanie)
        {
            int i = 0;
            string plikDanych = "";
            Series[] seria = new Series[paramentry.Count];

            double[] wartosci = new double[paramentry.Count];
            string[] nazwyBadan = new string[paramentry.Count];
            foreach (KeyValuePair<string, string[]> linia1 in paramentry)
            {
                if (i == 0)
                {
                    plikDanych = linia1.Value[3];
                }
                else
                {
                    if (plikDanych != linia1.Value[3])
                    {
                        throw new Exception("Różne pliki danych");
                    }
                }

                string nazwa = (nazwyBadan.Contains(linia1.Key)) ? "" : linia1.Key;
                double wartosc = (nazwyBadan.Contains(linia1.Key)) ? 0 : double.Parse(linia1.Value[indexDanych]);

                foreach (KeyValuePair<string, string[]> linia2 in paramentry)
                {
                    if(linia1.Key != linia2.Key && !nazwyBadan.Contains(linia2.Key))
                    {
                        double tmpWartosc = double.Parse(linia2.Value[indexDanych]);

                        if (sortowanie == "asc")
                        {
                            if (wartosc <= tmpWartosc)
                            {
                                wartosc = tmpWartosc;
                                nazwa = linia2.Key;
                            }
                        } else
                        {
                            if (wartosc >= tmpWartosc || wartosc == 0)
                            {
                                wartosc = tmpWartosc;
                                nazwa = linia2.Key;
                            }
                        }
                    }
                }

                wartosci[i] = wartosc;
                nazwyBadan[i] = nazwa;

                i++;
            }

            for(int j = 0; j < nazwyBadan.Length; j++)
            {
                seria[j] = new Series();
                seria[j].Name = nazwyBadan[j];
                seria[j].Points.Add(new DataPoint(1, wartosci[j]));
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

        public void ZwrocRaport(Dictionary<string, double[][]> paramentry, int szerokosc, int wysokosc)
        {
            try
            {
                string[] nazwyPlikow = new string[] { LosowyTekst(losowy.Next(2, 10)), LosowyTekst(losowy.Next(2, 10)), LosowyTekst(losowy.Next(2, 10)) };

                double[][] wartosciSrednie = new double[paramentry.Count][],
                           wartosciMin = new double[paramentry.Count][],
                           wartosciMax = new double[paramentry.Count][];

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

                GNUPlot gnuplot = new GNUPlot();
                gnuplot.RysujWykresPorownania(wartosciSrednie, nazwyBadan, szerokosc, wysokosc, "Średnia", nazwyPlikow[0]);
                gnuplot.ZakonczProcesGNUPlot();

                gnuplot = new GNUPlot();
                gnuplot.RysujWykresPorownania(wartosciMin, nazwyBadan, szerokosc, wysokosc, "Minimum", nazwyPlikow[1]);
                gnuplot.ZakonczProcesGNUPlot();

                gnuplot = new GNUPlot();
                gnuplot.RysujWykresPorownania(wartosciMax, nazwyBadan, szerokosc, wysokosc, "Maksimum", nazwyPlikow[2]);
                gnuplot.ZakonczProcesGNUPlot();

                RezultatBadania rezultatBadania = new RezultatBadania();
                rezultatBadania.PokazWykresy(nazwyPlikow);
                rezultatBadania.Show();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bladPlikuDanych = true;
            }
        }

        public bool ZwrocBladPlikuDanych()
        {
            return bladPlikuDanych;
        }

        private string LosowyTekst(int dlugosc)
        {
            const string znaki = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(znaki, dlugosc).Select(s => s[losowy.Next(s.Length)]).ToArray());
        }
    }
}
