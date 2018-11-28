using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System.Collections;
using System.Diagnostics;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka
{
    abstract class AAnalityka
    {
        protected Stopwatch pomiarCzasu = new Stopwatch();
        protected short liczbaIteracji;
        protected AOsobnik rozwiazanie;
        protected ArrayList[] wartosciProcesuPoszukiwan;

        public AAnalityka(AOsobnik rozwiazanie, short liczbaIteracji)
        {
            this.rozwiazanie = rozwiazanie;
            this.liczbaIteracji = liczbaIteracji;
            wartosciProcesuPoszukiwan = new ArrayList[liczbaIteracji];

            for(short i = 0; i < liczbaIteracji; i++)
            {
                wartosciProcesuPoszukiwan[i] = new ArrayList();
            }
        }

        public ArrayList[] ZwrocWartosciProcesuPoszukiwan()
        {
            return wartosciProcesuPoszukiwan;
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
            pomiarCzasu.Reset();
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
        public double ZwrocCzasDzialaniaAlgorytmu(string rodzaj)
        {
            if(rodzaj == "s") return pomiarCzasu.Elapsed.TotalSeconds;
            else return pomiarCzasu.Elapsed.TotalMilliseconds;
        }

        public short ZwrocLiczbeIteracji()
        {
            return liczbaIteracji;
        }

        public abstract void DopiszWartoscProcesu(short index, float czas, ReprezentacjaRozwiazania genotyp);
    }
}
