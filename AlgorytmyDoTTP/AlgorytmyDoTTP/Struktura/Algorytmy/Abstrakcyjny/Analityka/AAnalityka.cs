using BiPA.Struktura.Algorytmy.Abstrakcyjny.Osobnik;
using System.Collections.Generic;
using System.Diagnostics;

namespace BiPA.Struktura.Algorytmy.Abstrakcyjny.Analityka
{
    abstract class AAnalityka
    {
        private Stopwatch pomiarCzasu = new Stopwatch();
        protected readonly int[][] liczbaWCzasie;
        protected short czasDzialaniaAlgorytmu;
        protected short liczbaIteracji;
        protected AOsobnik rozwiazanie;
        protected double[][] minWartoscProcesuPoszukiwan;
        protected double[][] maxWartoscProcesuPoszukiwan;
        protected double[][] sredniaWartoscProcesuPoszukiwan;
        protected ReprezentacjaRozwiazania najlepszeRozwiazanie;
        protected Dictionary<string, float[]> najlepszaWartoscFunkcji;

        public AAnalityka(AOsobnik rozwiazanie, short liczbaIteracji, short czasDzialaniaAlgorytmu)
        {
            this.rozwiazanie = rozwiazanie;
            this.liczbaIteracji = liczbaIteracji;
            this.czasDzialaniaAlgorytmu = czasDzialaniaAlgorytmu;

            liczbaWCzasie = new int[liczbaIteracji][];
            najlepszaWartoscFunkcji = new Dictionary<string, float[]>();
            minWartoscProcesuPoszukiwan = new double[liczbaIteracji][];
            maxWartoscProcesuPoszukiwan = new double[liczbaIteracji][];
            sredniaWartoscProcesuPoszukiwan = new double[liczbaIteracji][];

            for (short i = 0; i < liczbaIteracji; i++)
            {
                liczbaWCzasie[i] = new int[czasDzialaniaAlgorytmu + 1];
                minWartoscProcesuPoszukiwan[i] = new double[czasDzialaniaAlgorytmu + 1];
                maxWartoscProcesuPoszukiwan[i] = new double[czasDzialaniaAlgorytmu + 1];
                sredniaWartoscProcesuPoszukiwan[i] = new double[czasDzialaniaAlgorytmu + 1];
            }

            najlepszaWartoscFunkcji["max"] = new float[] { -100000 };
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
        /// Metoda zwracająca najlepsze rozwiązanie danego problemu optymalizacyjnego, w zależności od wybranego kodowania.
        /// </summary>
        /// <param name="najlepszeRozwiazanie">Najlepsze znalezione rozwiązanie</param>
        /// <returns>Zwraca najlepsze rozwiązanie dla wybranego problemu optymalizacyjnego</returns>
        public string ZwrocNajlepszeZnalezioneRozwiazanie()
        {
            return rozwiazanie.DekodujRozwiazanie(najlepszeRozwiazanie);
        }

        /// <summary>
        /// Metoda zwracająca najlepszą znalezioną wartość
        /// </summary>
        /// <returns>Wartość funkcji celu</returns>
        public Dictionary<string, float[]> ZwrocWartoscNiebo()
        {
            return najlepszaWartoscFunkcji;
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
        /// Metoda poszukująca najlepszego rozwiązania znalezionego do tej pory
        /// </summary>
        /// <param name="geny">Tablica definiująca dziedzinę rozwiązania</param>
        public void DopiszWartoscProcesu(short index, int czas, ReprezentacjaRozwiazania genotyp)
        {
            if (czas <= czasDzialaniaAlgorytmu)
            {
                Dictionary<string, float[]> wartosc = rozwiazanie.FunkcjaDopasowania(genotyp);

                if (najlepszaWartoscFunkcji["max"][0] < wartosc["max"][0])
                {
                    najlepszeRozwiazanie = genotyp;
                    najlepszaWartoscFunkcji = wartosc;
                }

                if (minWartoscProcesuPoszukiwan[index][czas] > wartosc["max"][0] || maxWartoscProcesuPoszukiwan[index][czas] == 0)
                {
                    minWartoscProcesuPoszukiwan[index][czas] = wartosc["max"][0];
                }

                if (maxWartoscProcesuPoszukiwan[index][czas] < wartosc["max"][0] || maxWartoscProcesuPoszukiwan[index][czas] == 0)
                {
                    maxWartoscProcesuPoszukiwan[index][czas] = wartosc["max"][0];
                }
                
                liczbaWCzasie[index][czas]++;
                sredniaWartoscProcesuPoszukiwan[index][czas] += wartosc["max"][0];
            }
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
    }
}
