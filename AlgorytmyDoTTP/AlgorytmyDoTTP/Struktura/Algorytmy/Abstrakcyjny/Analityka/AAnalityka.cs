using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System.Diagnostics;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka
{
    abstract class AAnalityka
    {
        protected short czasDzialaniaAlgorytmu;
        protected short liczbaIteracji;
        protected AOsobnik rozwiazanie;
        protected double[][] minWartoscProcesuPoszukiwan;
        protected double[][] maxWartoscProcesuPoszukiwan;
        protected double[][] sredniaWartoscProcesuPoszukiwan;
        private Stopwatch pomiarCzasu = new Stopwatch();

        public AAnalityka(AOsobnik rozwiazanie, short liczbaIteracji, short czasDzialaniaAlgorytmu)
        {
            this.rozwiazanie = rozwiazanie;
            this.liczbaIteracji = liczbaIteracji;
            this.czasDzialaniaAlgorytmu = czasDzialaniaAlgorytmu;
            minWartoscProcesuPoszukiwan = new double[liczbaIteracji][];
            maxWartoscProcesuPoszukiwan = new double[liczbaIteracji][];
            sredniaWartoscProcesuPoszukiwan = new double[liczbaIteracji][];

            for (short i = 0; i < liczbaIteracji; i++)
            {
                minWartoscProcesuPoszukiwan[i] = new double[czasDzialaniaAlgorytmu + 1];
                maxWartoscProcesuPoszukiwan[i] = new double[czasDzialaniaAlgorytmu + 1];
                sredniaWartoscProcesuPoszukiwan[i] = new double[czasDzialaniaAlgorytmu + 1];
            }
        }

        public double[][] ZwrocSredniaWartosciProcesuPoszukiwan()
        {
            return sredniaWartoscProcesuPoszukiwan;
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
        public string ZwrocNajlepszeZnalezioneRozwiazanie(ReprezentacjaRozwiazania najlepszeRozwiazanie)
        {
            return rozwiazanie.DekodujRozwiazanie(najlepszeRozwiazanie);
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

        public abstract void DopiszWartoscProcesu(short index, int czas, ReprezentacjaRozwiazania genotyp);

        public abstract void StworzWykresGNUplot();
    }
}
