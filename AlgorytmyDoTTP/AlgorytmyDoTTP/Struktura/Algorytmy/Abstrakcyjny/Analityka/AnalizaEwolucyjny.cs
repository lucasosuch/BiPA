using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;
using System.Collections;
using System.Diagnostics;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny
{
    class AnalizaEwolucyjny : IAnalityka
    {
        private double najlepszaWartoscFunkcji;
        private ReprezentacjaRozwiazania najlepszeRozwiazanie;
        private Stopwatch pomiarCzasu;
        private AOsobnik rozwiazanie;

        public AnalizaEwolucyjny(AOsobnik rozwiazanie)
        {
            this.rozwiazanie = rozwiazanie;
            najlepszaWartoscFunkcji = -10000;
            najlepszeRozwiazanie = new ReprezentacjaRozwiazania();
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
        /// Metoda wyznaczająca medianę funkcji celu z populacji rozwiązań
        /// </summary>
        /// <param name="populacja">Lista rozwiązań</param>
        /// <returns>Zwraca medianę</returns>
        public double MedianaPopulacji(ArrayList populacja)
        {
            int srodek = populacja.Count / 2;
            double[] wynikiPopulacji = new double[populacja.Count]; // tablica zawierająca wartości funkcji celu z listy rozwiązań

            for(int i = 0; i < populacja.Count; i++)
            {
                wynikiPopulacji[i] = rozwiazanie.FunkcjaDopasowania((ReprezentacjaRozwiazania)populacja[i])["max"][0];
            }

            // sortowanie wyników rosnąco
            Array.Sort(wynikiPopulacji);

            return wynikiPopulacji[srodek];
        }

        /// <summary>
        /// Metoda obliczająca średnią wartość funkcji celu z populacji rozwiązań
        /// </summary>
        /// <param name="populacja">Lista rozwiązań</param>
        /// <returns>Zwraca wartość średnią</returns>
        public double SredniaPopulacji(ArrayList populacja)
        {
            double wynik = 0;

            foreach (ReprezentacjaRozwiazania osobnik in populacja)
            {
                wynik += rozwiazanie.FunkcjaDopasowania(osobnik)["max"][0];
            }

            return wynik / populacja.Count;
        }

        /// <summary>
        /// Metoda obliczająca odchylenie standardowe funkcji celu z populacji rozwiązań
        /// </summary>
        /// <returns>Zwraca odchylenie standardowe</returns>
        /// <param name="populacja">Lista rozwiązań</param>
        /// <param name="srednia">Średnia z listy rozwiązań</param>
        public double OdchylenieStandardowePopulacji(ArrayList populacja, double srednia)
        {
            double sumaKwadratow = 0;

            foreach (ReprezentacjaRozwiazania osobnik in populacja)
            {
                sumaKwadratow += Math.Pow(rozwiazanie.FunkcjaDopasowania(osobnik)["max"][0], 2);
            }

            double sredniaSumaKwadratow = sumaKwadratow / (populacja.Count - 1);
            return Math.Sqrt(sredniaSumaKwadratow - (Math.Pow(srednia, 2)));
        }

        /// <summary>
        /// Metoda poszukująca najlepszego rozwiązania znalezionego do tej pory
        /// </summary>
        /// <param name="geny">Tablica definiująca dziedzinę rozwiązania</param>
        public void ZmienWartoscNiebo(ReprezentacjaRozwiazania genotyp)
        {
            if(najlepszaWartoscFunkcji < rozwiazanie.FunkcjaDopasowania(genotyp)["max"][0])
            {
                najlepszeRozwiazanie = genotyp;
                najlepszaWartoscFunkcji = rozwiazanie.FunkcjaDopasowania(genotyp)["max"][0];
            }
        }

        /// <summary>
        /// Metoda zwracająca najlepszą dziedzinę rozwiązania
        /// </summary>
        /// <returns>Dziedzina rozwiązania</returns>
        public ReprezentacjaRozwiazania ZwrocNajlepszyGenotyp()
        {
            return najlepszeRozwiazanie;
        }

        public string ZwrocNajlepszeRowziazanie()
        {
            string wynik = "";

            if(!(najlepszeRozwiazanie.ZwrocGenotyp1Wymiarowy() == null || najlepszeRozwiazanie.ZwrocGenotyp1Wymiarowy().Length == 0))
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

        /// <summary>
        /// Metoda zwracająca najlepszą znalezioną wartość
        /// </summary>
        /// <returns>Wartość funkcji celu</returns>
        public string[] ZwrocWartoscNiebo()
        {
            return new string[] {
                rozwiazanie.FunkcjaDopasowania(najlepszeRozwiazanie)["max"][0].ToString(),
                rozwiazanie.FunkcjaDopasowania(najlepszeRozwiazanie)["min"][0].ToString()
            };
        }
    }
}
