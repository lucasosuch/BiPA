using AlgorytmyDoTTP.Rozszerzenia;
using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka
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
                    srednieMax = new float[minWartosci.Length];

            for (short i = 0; i < minWartosci.Length; i++)
            {
                srednieMin[i] = Srednia(minWartosci[i]);
                srednieAvg[i] = Srednia(srednieWartosci[i]);
                srednieMax[i] = Srednia(maxWartosci[i]);
            }

            for (short i = 0; i < minWartosci.Length; i++)
            {
                float[] maxMax = ZnajdzMax(srednieMax);
                punkty[(int)maxMax[0]] += srednieMax.Length - i;
                srednieMax[(int)maxMax[0]] = -100000;

                float[] maxMin = ZnajdzMax(srednieMin);
                punkty[(int)maxMin[0]] += (float)(srednieMin.Length - (i * 0.5));
                srednieMin[(int)maxMin[0]] = -100000;

                float[] maxAvg = ZnajdzMax(srednieAvg);
                punkty[(int)maxAvg[0]] += (float)(srednieAvg.Length - (i * 0.75));
                srednieAvg[(int)maxAvg[0]] = -100000;
            }

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
