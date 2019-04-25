using BiPA.Rozszerzenia;
using System;

namespace BiPA.Struktura.Algorytmy.Abstrakcyjny.Analityka
{
    class WynikiAnalizy
    {
        /// <summary>
        /// Metoda obliczająca średnią wartość funkcji celu z populacji rozwiązań
        /// </summary>
        /// <param name="wartosci">Tablica rozwiązań</param>
        /// <returns>Zwraca wartość średnią</returns>
        public float Srednia(double[] wartosci)
        {
            float wynik = 0;
            for (short i = 0; i < wartosci.Length; i++)
            {
                wynik += (float)wartosci[i];
            }

            wynik /= wartosci.Length;

            return wynik;
        }

        /// <summary>
        /// Metoda wyznaczająca medianę funkcji celu z populacji rozwiązań
        /// </summary>
        /// <param name="Wartosci">Lista rozwiązań</param>
        /// <returns>Zwraca medianę</returns>
        public float Mediana(double[] wartosci)
        {
            int srodek = wartosci.Length / 2;
            if (srodek == 0) throw new IndexOutOfRangeException();
            double[] tmpWartosci = (double[])(wartosci.Clone());

            Array.Sort(tmpWartosci);// sortowanie wyników rosnąco
            return (float)tmpWartosci[srodek];
        }

        /// <summary>
        /// Metoda obliczająca odchylenie standardowe funkcji celu z populacji rozwiązań
        /// </summary>
        /// <param name="wartosci">Lista rozwiązań</param>
        /// <param name="srednia">Średnia z listy rozwiązań</param>
        /// <returns>Zwraca odchylenie standardowe</returns>
        public float OdchylenieStandardowe(double[] wartosci, float srednia)
        {
            float sumaKwadratow = 0;
            foreach (double wartosc in wartosci)
            {
                sumaKwadratow += (float)((wartosc - srednia) * (wartosc - srednia));
            }

            float sredniaSumaKwadratow = sumaKwadratow / (wartosci.Length - 1);
            return (float)Math.Sqrt(sredniaSumaKwadratow);
        }

        private float Minimum(double[] wartosci)
        {
            float wynik = (float)wartosci[0];

            for(int i = 0; i < wartosci.Length; i++)
            {
                if (wynik > wartosci[i]) wynik = (float)wartosci[i];
            }

            return wynik;
        }

        private float Maksimum(double[] wartosci)
        {
            float wynik = (float)wartosci[0];

            for (int i = 0; i < wartosci.Length; i++)
            {
                if (wynik < wartosci[i]) wynik = (float)wartosci[i];
            }

            return wynik;
        }

        private float[] UstalPunktacje(float[] tablica)
        {
            float[] wynik = new float[tablica.Length];
            float[] posortowanaTablica = (float[])tablica.Clone();

            Array.Sort(posortowanaTablica);

            for (int i = 0; i < tablica.Length; i++)
            {
                int k = 0;
                for (int j = posortowanaTablica.Length - 1; j >= 0; j--)
                {
                    if (tablica[i] == posortowanaTablica[j])
                    {
                        wynik[i] = (tablica.Length - k);
                        break;
                    }

                    k++;
                }
            }

            return wynik;
        }

        private float[] ZnajdzMax(float[] tablica)
        {
            float[] wynik = new float[] { 0, tablica[0] };
            for (short i = 1; i < tablica.Length; i++)
            {
                if (tablica[i] > wynik[1])
                {
                    wynik[0] = i;
                    wynik[1] = tablica[i];
                }
            }

            return wynik;
        }

        private float[] ObliczPunkty(float[] punkty, float[] zbiorMin, float[] zbiorSrednich, float[] zbiorMax)
        {
            float[] punktyMin = UstalPunktacje(zbiorMin);
            float[] punktySrednia = UstalPunktacje(zbiorSrednich);
            float[] punktyMax = UstalPunktacje(zbiorMax);

            for(int i = 0; i < punkty.Length; i++)
            {
                punkty[i] += (float)((0.8 * punktyMin[i]) + (0.8 * punktySrednia[i]) + punktyMax[i]);
            }

            return punkty;
        }

        public float[][][] PrzetworzDane(float[][] ranking, double[][] wartosciSrednie, double[][] wartosciMin, double[][] wartosciMax)
        {
            float[][] srednie = new float[ranking.Length][],
                      minima = new float[ranking.Length][],
                      maxima = new float[ranking.Length][];

            for (int i = 0; i < ranking.Length; i++)
            {
                int iteracja = (int)ranking[i][0];
                float[] tmpSrednie = new float[] { Srednia(wartosciSrednie[iteracja]), Srednia(wartosciMin[iteracja]), Srednia(wartosciMax[iteracja]) };

                srednie[i] = new float[] { tmpSrednie[0], Mediana(wartosciSrednie[iteracja]), OdchylenieStandardowe(wartosciSrednie[iteracja], tmpSrednie[0]) };
                minima[i] = new float[] { tmpSrednie[1], Mediana(wartosciMin[iteracja]), OdchylenieStandardowe(wartosciMin[iteracja], tmpSrednie[1]) };
                maxima[i] = new float[] { tmpSrednie[2], Mediana(wartosciMax[iteracja]), OdchylenieStandardowe(wartosciMax[iteracja], tmpSrednie[2]) };
            }

            return new float[][][] { minima,  maxima, srednie};
        }

        public float[][] ZwrocRanking(double[][] minWartosci, double[][] maxWartosci, double[][] srednieWartosci)
        {
            float[] punkty = new float[minWartosci.Length],
                    srednieMin = new float[minWartosci.Length],
                    srednieAvg = new float[minWartosci.Length],
                    srednieMax = new float[minWartosci.Length],
                    minMin = new float[minWartosci.Length],
                    minAvg = new float[minWartosci.Length],
                    minMax = new float[minWartosci.Length],
                    maxMin = new float[minWartosci.Length],
                    maxAvg = new float[minWartosci.Length],
                    maxMax = new float[minWartosci.Length];

            for (short i = 0; i < minWartosci.Length; i++)
            {
                srednieMin[i] = Srednia(minWartosci[i]);
                srednieAvg[i] = Srednia(srednieWartosci[i]);
                srednieMax[i] = Srednia(maxWartosci[i]);

                minMin[i] = Minimum(minWartosci[i]);
                minAvg[i] = Minimum(srednieWartosci[i]);
                minMax[i] = Minimum(maxWartosci[i]);

                maxMin[i] = Maksimum(minWartosci[i]);
                maxAvg[i] = Maksimum(srednieWartosci[i]);
                maxMax[i] = Maksimum(maxWartosci[i]);
            }

            punkty = (float[])(ObliczPunkty(punkty, srednieMin, srednieAvg, srednieMax).Clone());
            punkty = (float[])(ObliczPunkty(punkty, minMin, minAvg, minMax).Clone());
            punkty = (float[])(ObliczPunkty(punkty, maxMin, maxAvg, maxMax).Clone());

            float[][] wyniki = new float[punkty.Length][];
            for (int i = 0; i < punkty.Length; i++)
            {
                float[] max = ZnajdzMax(punkty);
                wyniki[i] = new float[] { max[0], max[1] };
                punkty[(int)max[0]] = -100000;
            }

            return wyniki;
        }

        public string WyswietlInformacjeZwrotna(float[][] ranking, float[][] srednie, float[][] minima, float[][] maxima, string[] nazwyWykresow)
        {
            string tekst = "";

            for (int i = 0; i < srednie.Length; i++)
            {
                tekst += nazwyWykresow[(int)ranking[i][0]] + ", zdobyła " + ranking[i][1] + " punktów" + Environment.NewLine +
                        "---" + Environment.NewLine +
                        "Wykres Średniej z " + nazwyWykresow[(int)ranking[i][0]] + " badania: " + Environment.NewLine +
                        "- średnia: " + srednie[i][0] + Environment.NewLine +
                        "- mediana: " + srednie[i][1] + Environment.NewLine +
                        "- odchylenie standardowe: " + srednie[i][2] + Environment.NewLine +
                        "---" + Environment.NewLine +
                        "Wykres Minimów z " + nazwyWykresow[(int)ranking[i][0]] + " badania: " + Environment.NewLine +
                        "- średnia: " + minima[i][0] + Environment.NewLine +
                        "- mediana: " + minima[i][1] + Environment.NewLine +
                        "- odchylenie standardowe: " + minima[i][2] + Environment.NewLine +
                        "---" + Environment.NewLine +
                        "Wykres Maksimów z " + nazwyWykresow[(int)ranking[i][0]] + " badania: " + Environment.NewLine +
                        "- średnia: " + maxima[i][0] + Environment.NewLine +
                        "- mediana: " + maxima[i][1] + Environment.NewLine +
                        "- odchylenie standardowe: " + maxima[i][2] + Environment.NewLine +
                        "----------------------------------------------------------------------" + Environment.NewLine;
            }

            return tekst;
        }

        public void StworzWykresyGNUplot(int szerokosc, int wysokosc, string[] nazwyWykresow, string[] nazwyPlikow, double[][] minWartosci, double[][] maxWartosci, double[][] srednieWartosci)
        {
            GNUPlot gnuplot = new GNUPlot();
            gnuplot.RysujWykresBadania(srednieWartosci, szerokosc, wysokosc, "Średnia", nazwyPlikow[0], nazwyWykresow);
            gnuplot.ZakonczProcesGNUPlot();

            gnuplot = new GNUPlot();
            gnuplot.RysujWykresBadania(maxWartosci, szerokosc, wysokosc, "Maksimum", nazwyPlikow[1], nazwyWykresow);
            gnuplot.ZakonczProcesGNUPlot();

            gnuplot = new GNUPlot();
            gnuplot.RysujWykresBadania(minWartosci, szerokosc, wysokosc, "Minimum", nazwyPlikow[2], nazwyWykresow);
            gnuplot.ZakonczProcesGNUPlot();
        }
    }
}
