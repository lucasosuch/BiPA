using AlgorytmyDoTTP.Rozszerzenia;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka
{
    abstract class AAnalityka
    {
        private Stopwatch pomiarCzasu = new Stopwatch();
        protected string[] nazwyPlikow;
        protected readonly short[][] liczbaWCzasie;
        protected short czasDzialaniaAlgorytmu;
        protected short liczbaIteracji;
        protected AOsobnik rozwiazanie;
        protected float[] najlepszaWartoscFunkcji;
        protected double[][] minWartoscProcesuPoszukiwan;
        protected double[][] maxWartoscProcesuPoszukiwan;
        protected double[][] sredniaWartoscProcesuPoszukiwan;
        protected ReprezentacjaRozwiazania[] najlepszeRozwiazanie;

        public AAnalityka(AOsobnik rozwiazanie, short liczbaIteracji, short czasDzialaniaAlgorytmu, string[] nazwyPlikow)
        {
            this.rozwiazanie = rozwiazanie;
            this.nazwyPlikow = nazwyPlikow;
            this.liczbaIteracji = liczbaIteracji;
            this.czasDzialaniaAlgorytmu = czasDzialaniaAlgorytmu;

            liczbaWCzasie = new short[liczbaIteracji][];
            najlepszaWartoscFunkcji = new float[liczbaIteracji];
            minWartoscProcesuPoszukiwan = new double[liczbaIteracji][];
            maxWartoscProcesuPoszukiwan = new double[liczbaIteracji][];
            sredniaWartoscProcesuPoszukiwan = new double[liczbaIteracji][];
            najlepszeRozwiazanie = new ReprezentacjaRozwiazania[liczbaIteracji];

            for (short i = 0; i < liczbaIteracji; i++)
            {
                liczbaWCzasie[i] = new short[czasDzialaniaAlgorytmu + 1];
                najlepszaWartoscFunkcji[i] = -10000;
                minWartoscProcesuPoszukiwan[i] = new double[czasDzialaniaAlgorytmu + 1];
                maxWartoscProcesuPoszukiwan[i] = new double[czasDzialaniaAlgorytmu + 1];
                sredniaWartoscProcesuPoszukiwan[i] = new double[czasDzialaniaAlgorytmu + 1];
            }
        }

        public double[][] ZwrocSredniaWartosciProcesuPoszukiwan()
        {
            return sredniaWartoscProcesuPoszukiwan;
        }

        public double[][] ZwrocMaxWartoscProcesuPoszukiwan()
        {
            return maxWartoscProcesuPoszukiwan;
        }

        public double[][] ZwrocMinWartoscProcesuPoszukiwan()
        {
            return minWartoscProcesuPoszukiwan;
        }
        
        /// <summary>
        /// Metoda rozpoczynająca odliczanie czasu
        /// </summary>
        public void RozpocznijPomiarCzasu()
        {
            pomiarCzasu.Start();
        }

        /// <summary>
        /// Metoda zakańczająca odliczanie czasu
        /// </summary>
        public void ResetPomiaruCzasu()
        {
            pomiarCzasu.Reset();
        }

        /// <summary>
        /// Metoda zwracająca najlepszą dziedzinę rozwiązania
        /// </summary>
        /// <returns>Dziedzina rozwiązania</returns>
        public ReprezentacjaRozwiazania ZwrocNajlepszyGenotyp()
        {
            short najlepszyIndex = 0;
            float maxWartosc = -1000000;

            for (short i = 1; i < najlepszaWartoscFunkcji.Length; i++)
            {
                if (najlepszaWartoscFunkcji[i] > maxWartosc)
                {
                    najlepszyIndex = i;
                    maxWartosc = najlepszaWartoscFunkcji[i];
                }
            }

            Console.WriteLine("Najlepszy index: " + najlepszyIndex + ", maxWartosc: " + maxWartosc);
            Console.WriteLine("test1: " + rozwiazanie.FunkcjaDopasowania(najlepszeRozwiazanie[najlepszyIndex])["max"][0]);
            return najlepszeRozwiazanie[najlepszyIndex];
        }

        /// <summary>
        /// Metoda zwracająca najlepsze rozwiązanie danego problemu optymalizacyjnego, w zależności od wybranego kodowania.
        /// </summary>
        /// <param name="najlepszeRozwiazanie">Najlepsze znalezione rozwiązanie</param>
        /// <returns>Zwraca najlepsze rozwiązanie dla wybranego problemu optymalizacyjnego</returns>
        public string ZwrocNajlepszeZnalezioneRozwiazanie()
        {
            return rozwiazanie.DekodujRozwiazanie(ZwrocNajlepszyGenotyp());
        }

        /// <summary>
        /// Metoda zwracająca najlepszą znalezioną wartość
        /// </summary>
        /// <returns>Wartość funkcji celu</returns>
        public Dictionary<string, float[]> ZwrocWartoscNiebo()
        {
            Console.WriteLine("test2: "+ rozwiazanie.FunkcjaDopasowania(ZwrocNajlepszyGenotyp())["max"][0]);
            return rozwiazanie.FunkcjaDopasowania(ZwrocNajlepszyGenotyp());
        }

        /// <summary>
        /// Metoda zwracająca czas działania algorytmu
        /// </summary>
        /// <returns>Zwraca czas przebiegu w milisekundach</returns>
        public double IleCzasuDzialaAlgorytm(string rodzaj)
        {
            if(rodzaj == "s") return pomiarCzasu.Elapsed.TotalSeconds;
            else return pomiarCzasu.Elapsed.TotalMilliseconds;
        }

        public short ZwrocLiczbeIteracji()
        {
            return liczbaIteracji;
        }

        public short ZwrocCzasDzialaniaAlgorytmu()
        {
            return czasDzialaniaAlgorytmu;
        }

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

            Array.Sort(wartosci);// sortowanie wyników rosnąco
            return (float)wartosci[srodek];
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

        /// <summary>
        /// Metoda poszukująca najlepszego rozwiązania znalezionego do tej pory
        /// </summary>
        /// <param name="geny">Tablica definiująca dziedzinę rozwiązania</param>
        public void DopiszWartoscProcesu(short index, int czas, ReprezentacjaRozwiazania genotyp)
        {
            float wartosc = rozwiazanie.FunkcjaDopasowania(genotyp)["max"][0];

            if (najlepszaWartoscFunkcji[index] < wartosc)
            {
                najlepszeRozwiazanie[index] = genotyp;
                najlepszaWartoscFunkcji[index] = wartosc;
            }

            if(minWartoscProcesuPoszukiwan[index][czas] > wartosc || maxWartoscProcesuPoszukiwan[index][czas] == 0)
            {
                minWartoscProcesuPoszukiwan[index][czas] = wartosc;
            }
            if (maxWartoscProcesuPoszukiwan[index][czas] < wartosc || maxWartoscProcesuPoszukiwan[index][czas] == 0)
            {
                maxWartoscProcesuPoszukiwan[index][czas] = wartosc;
            }

            liczbaWCzasie[index][czas]++;
            sredniaWartoscProcesuPoszukiwan[index][czas] += wartosc;
        }

        public int ZwrocNajlepszaIteracje()
        {
            float[] punkty = new float[liczbaIteracji],
                    srednieMin = new float[liczbaIteracji],
                    srednieAvg = new float[liczbaIteracji],
                    srednieMax = new float[liczbaIteracji];

            for (short i = 0; i < liczbaIteracji; i++)
            {
                srednieMin[i] = Srednia(minWartoscProcesuPoszukiwan[i]);
                srednieAvg[i] = Srednia(sredniaWartoscProcesuPoszukiwan[i]);
                srednieMax[i] = Srednia(maxWartoscProcesuPoszukiwan[i]);
            }

            for (short i = 0; i < liczbaIteracji; i++)
            {
                float[] maxMax = ZnajdzMax(srednieMax);
                punkty[(int)maxMax[0]] += srednieMax.Length - i;
                srednieMax[(int)maxMax[0]] = -100000;

                float[] maxMin = ZnajdzMax(srednieMin);
                punkty[(int)maxMax[0]] += (float)(srednieMin.Length - (i * 0.5));
                srednieMin[(int)maxMax[0]] = -100000;

                float[] maxAvg = ZnajdzMax(srednieAvg);
                punkty[(int)maxMax[0]] += (float)(srednieAvg.Length - (i * 0.75));
                srednieAvg[(int)maxMax[0]] = -100000;
            }

            return (int)ZnajdzMax(punkty)[0];
        }

        public void ObliczSrednieWartosciProcesu()
        {
            for (short i = 0; i < liczbaIteracji; i++)
            {
                for (short j = 0; j < liczbaWCzasie[i].Length; j++)
                {
                    sredniaWartoscProcesuPoszukiwan[i][j] /= liczbaWCzasie[i][j];
                }
            }
        }

        public void StworzWykresyGNUplot(int szerokosc, int wysokosc)
        {
            GNUPlot gnuplot = new GNUPlot();
            gnuplot.RysujWykresBadania(sredniaWartoscProcesuPoszukiwan, szerokosc, wysokosc, "Średnia", nazwyPlikow[0]);
            gnuplot.ZakonczProcesGNUPlot();

            gnuplot = new GNUPlot();
            gnuplot.RysujWykresBadania(minWartoscProcesuPoszukiwan, szerokosc, wysokosc, "Minimum", nazwyPlikow[1]);
            gnuplot.ZakonczProcesGNUPlot();

            gnuplot = new GNUPlot();
            gnuplot.RysujWykresBadania(maxWartoscProcesuPoszukiwan, szerokosc, wysokosc, "Maksimum", nazwyPlikow[2]);
            gnuplot.ZakonczProcesGNUPlot();

            ZwrocNajlepszaIteracje();
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
    }
}
