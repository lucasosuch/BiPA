using System;
using System.Diagnostics;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka
{
    /// <summary>
    /// Klasa analityczna.
    /// Podstawowa klasa pod analizę dla algorytmu wspinaczkowego oraz algorytmu losowego.
    /// </summary>
    class AnalizaRLS_RS
    {
        private Stopwatch pomiarCzasu;

        public AnalizaRLS_RS()
        {
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
        /// Metoda zwracająca czas działania algorytmu
        /// </summary>
        /// <returns>Zwraca czas przebiegu w milisekundach</returns>
        public double ZwrocCzasDzialaniaAlgorytmu()
        {
            return pomiarCzasu.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// Metoda zwracająca najlepsze rozwiązanie danego problemu optymalizacyjnego, w zależności od wybranego kodowania.
        /// </summary>
        /// <param name="najlepszeRozwiazanie">Najlepsze znalezione rozwiązanie</param>
        /// <returns>Zwraca najlepsze rozwiązanie dla wybranego problemu optymalizacyjnego</returns>
        public string ZwrocNajlepszeRozwiazanie(ReprezentacjaRozwiazania najlepszeRozwiazanie)
        {
            return DekodujRozwiazanie(najlepszeRozwiazanie);
        }

        /// <summary>
        /// Metoda rozkodowująca rozwiązanie danego problemu optymalizacyjnego.
        /// </summary>
        /// <param name="rozwiazanie">Zakodowane rozwiązanie problemu optymalizacyjnego</param>
        /// <returns>Zwraca rozkodowane rozwiązanie problemu optymalizacyjnego</returns>
        protected string DekodujRozwiazanie(ReprezentacjaRozwiazania rozwiazanie)
        {
            string wynik = "";

            // kodowanie dla ushort[]
            if (!(rozwiazanie.ZwrocGenotyp1Wymiarowy() == null || rozwiazanie.ZwrocGenotyp1Wymiarowy().Length == 0))
            {
                wynik = string.Join(",", rozwiazanie.ZwrocGenotyp1Wymiarowy());
            }

            // kodowanie dla ushort[][]
            if (!(rozwiazanie.ZwrocGenotyp2Wymiarowy() == null || rozwiazanie.ZwrocGenotyp2Wymiarowy().Length == 0))
            {
                foreach (ushort[] genotyp in rozwiazanie.ZwrocGenotyp2Wymiarowy())
                {
                    wynik += string.Join(",", genotyp) + Environment.NewLine;
                }
            }

            return wynik;
        }
    }
}
