using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;
using System.Collections;
using System.Diagnostics;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Analityka
{
    class AnalizaPopulacji : IAnalityka
    {
        private double najlepszaWartoscFunkcji;
        private ushort[] najlepszyGenotyp;
        private Stopwatch pomiarCzasu;
        private AOsobnik rozwiazanie;

        public AnalizaPopulacji(AOsobnik rozwiazanie)
        {
            this.rozwiazanie = rozwiazanie;
            najlepszaWartoscFunkcji = -10000;
            najlepszyGenotyp = new ushort[rozwiazanie.ZwrocInstancjeProblemu().ZwrocDlugoscGenotypu()];
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
                wynikiPopulacji[i] = rozwiazanie.FunkcjaDopasowania((ushort[])populacja[i])["max"][0];
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

            foreach (ushort[] osobnik in populacja)
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

            foreach (ushort[] osobnik in populacja)
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
        public void ZmienWartoscNiebo(ushort[] geny)
        {
            if(najlepszaWartoscFunkcji < rozwiazanie.FunkcjaDopasowania(geny)["max"][0])
            {
                najlepszyGenotyp = (ushort[])geny.Clone();
                najlepszaWartoscFunkcji = rozwiazanie.FunkcjaDopasowania(geny)["max"][0];
            }
        }

        /// <summary>
        /// Metoda zwracająca najlepszą dziedzinę rozwiązania
        /// </summary>
        /// <returns>Dziedzina rozwiązania</returns>
        public ushort[] ZwrocNajlepszyGenotyp()
        {
            return najlepszyGenotyp;
        }

        /// <summary>
        /// Metoda zwracająca najlepszą znalezioną wartość
        /// </summary>
        /// <returns>Wartość funkcji celu</returns>
        public string[] ZwrocWartoscNiebo()
        {
            return new string[] {
                rozwiazanie.FunkcjaDopasowania(najlepszyGenotyp)["max"][0].ToString(),
                rozwiazanie.FunkcjaDopasowania(najlepszyGenotyp)["min"][0].ToString()
            };
        }
    }
}
