using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System.Diagnostics;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka
{
    class AAnalityka
    {
        protected AOsobnik rozwiazanie;
        protected Stopwatch pomiarCzasu;

        public AAnalityka(AOsobnik rozwiazanie)
        {
            this.rozwiazanie = rozwiazanie;
            pomiarCzasu = new Stopwatch();
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
        public void ZakonczPomiarCzasu()
        {
            pomiarCzasu.Stop();
        }

        /// <summary>
        /// Metoda zwracająca najlepsze rozwiązanie danego problemu optymalizacyjnego, w zależności od wybranego kodowania.
        /// </summary>
        /// <param name="najlepszeRozwiazanie">Najlepsze znalezione rozwiązanie</param>
        /// <returns>Zwraca najlepsze rozwiązanie dla wybranego problemu optymalizacyjnego</returns>
        public string ZwrocNajlepszeRozwiazanie(ReprezentacjaRozwiazania najlepszeRozwiazanie)
        {
            return rozwiazanie.DekodujRozwiazanie(najlepszeRozwiazanie);
        }

        /// <summary>
        /// Metoda zwracająca czas działania algorytmu
        /// </summary>
        /// <returns>Zwraca czas przebiegu w milisekundach</returns>
        public double ZwrocCzasDzialaniaAlgorytmu()
        {
            return pomiarCzasu.Elapsed.TotalMilliseconds;
        }
    }
}
