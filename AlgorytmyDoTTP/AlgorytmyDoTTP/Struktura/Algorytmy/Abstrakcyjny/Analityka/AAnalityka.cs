using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka
{
    abstract class AAnalityka
    {
        private Stopwatch pomiarCzasu = new Stopwatch();

        protected short czasDzialaniaAlgorytmu;
        protected short liczbaIteracji;
        protected AOsobnik rozwiazanie;
        protected float[] najlepszaWartoscFunkcji;
        protected double[][] minWartoscProcesuPoszukiwan;
        protected double[][] maxWartoscProcesuPoszukiwan;
        protected double[][] sredniaWartoscProcesuPoszukiwan;
        protected ReprezentacjaRozwiazania[] najlepszeRozwiazanie;

        public AAnalityka(AOsobnik rozwiazanie, short liczbaIteracji, short czasDzialaniaAlgorytmu)
        {
            this.rozwiazanie = rozwiazanie;
            this.liczbaIteracji = liczbaIteracji;
            this.czasDzialaniaAlgorytmu = czasDzialaniaAlgorytmu;

            najlepszaWartoscFunkcji = new float[liczbaIteracji];
            minWartoscProcesuPoszukiwan = new double[liczbaIteracji][];
            maxWartoscProcesuPoszukiwan = new double[liczbaIteracji][];
            sredniaWartoscProcesuPoszukiwan = new double[liczbaIteracji][];
            najlepszeRozwiazanie = new ReprezentacjaRozwiazania[liczbaIteracji];

            for (short i = 0; i < liczbaIteracji; i++)
            {
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

        public abstract void DopiszWartoscProcesu(short index, int czas, ReprezentacjaRozwiazania genotyp);

        public abstract void StworzWykresyGNUplot(int szerokosc, int wysokosc);

        public abstract int ZwrocNajlepszaIteracje();
    }
}
