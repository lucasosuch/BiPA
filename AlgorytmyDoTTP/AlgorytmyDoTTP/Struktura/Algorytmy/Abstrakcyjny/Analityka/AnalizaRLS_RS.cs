using System;
using System.Diagnostics;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka
{
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

        public string ZwrocNajlepszeRozwiazanie(ReprezentacjaRozwiazania najlepszeRozwiazanie)
        {
            string wynik = "";

            if (!(najlepszeRozwiazanie.ZwrocGenotyp1Wymiarowy() == null || najlepszeRozwiazanie.ZwrocGenotyp1Wymiarowy().Length == 0))
            {
                wynik = string.Join(",", najlepszeRozwiazanie.ZwrocGenotyp1Wymiarowy());
            }

            if (!(najlepszeRozwiazanie.ZwrocGenotyp2Wymiarowy() == null || najlepszeRozwiazanie.ZwrocGenotyp2Wymiarowy().Length == 0))
            {
                foreach (ushort[] genotyp in najlepszeRozwiazanie.ZwrocGenotyp2Wymiarowy())
                {
                    wynik += string.Join(",", genotyp) + Environment.NewLine;
                }
            }

            return wynik;
        }
    }
}
