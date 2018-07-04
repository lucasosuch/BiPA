using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka
{
    /// <summary>
    /// Klasa analityczna.
    /// Rozszerzenie podstawowej klasy analitycznej, dla Algorytmu Ewolucyjnego.
    /// </summary>
    class AnalizaEwolucyjny : AnalizaRLS_RS
    {
        private AOsobnik rozwiazanie;
        private double najlepszaWartoscFunkcji;
        private ReprezentacjaRozwiazania najlepszeRozwiazanie;

        public AnalizaEwolucyjny(AOsobnik rozwiazanie)
        {
            this.rozwiazanie = rozwiazanie;
            najlepszaWartoscFunkcji = -10000;
            najlepszeRozwiazanie = new ReprezentacjaRozwiazania();
        }

        //public double DominantaPopulacji(ArrayList populacja)
        //{
        //    double wynik = rozwiazanie.FunkcjaDopasowania((ReprezentacjaRozwiazania)populacja[0])["max"][0];

        //    Dictionary<double, int> wartosci = new Dictionary<double, int>();

        //    for (int i = 0; i < populacja.Count; i++)
        //    {
        //        wartosci[rozwiazanie.FunkcjaDopasowania((ReprezentacjaRozwiazania)populacja[i])["max"][0]] =
        //    }

        //    return wynik;
        //}

        public Dictionary<string, string[]> ZwrocOdpowiedz(ReprezentacjaRozwiazania[] populacja)
        {
            // pobieramy wartości statystyczne / analityczne z naszego badania
            double srednia = SredniaPopulacji(populacja),
                   mediana = MedianaPopulacji(populacja),
                   odchylenieStadowe = OdchylenieStandardowePopulacji(populacja, srednia);
            Dictionary<string, string[]> zwracanyTekst = new Dictionary<string, string[]>();

            // zwracamy raport z badań w formie czytelnej dla człowieka
            zwracanyTekst["dziedzina"] = new string[] { "Najlepszy genotyp", ZwrocNajlepszeRowziazanie() };
            zwracanyTekst["maxWartosc"] = new string[] { "Najlepsza funkcja przystosowania (max)", ZwrocWartoscNiebo()["max"][0].ToString() };
            zwracanyTekst["minWartosc"] = new string[] { "Najlepsza funkcja przystosowania (min)", ZwrocWartoscNiebo()["min"][0].ToString() };
            zwracanyTekst["sredniaWartosc"] = new string[] { "Średnia funkcji przystosowania z populacji", srednia.ToString() };
            zwracanyTekst["medianaWartosci"] = new string[] { "Mediana funkcji przystosowania z populacji", mediana.ToString() };
            zwracanyTekst["odchstdWartosci"] = new string[] { "Odchylenie standardowe funkcji przystosowania z populacji", odchylenieStadowe.ToString() };
            zwracanyTekst["czasDzialania"] = new string[] { "Czas dzialania algorytmu", ZwrocCzasDzialaniaAlgorytmu().ToString() };

            return zwracanyTekst;
        }

        /// <summary>
        /// Metoda wyznaczająca medianę funkcji celu z populacji rozwiązań
        /// </summary>
        /// <param name="populacja">Lista rozwiązań</param>
        /// <returns>Zwraca medianę</returns>
        public double MedianaPopulacji(ReprezentacjaRozwiazania[] populacja)
        {
            int srodek = populacja.Length / 2;
            double[] wynikiPopulacji = new double[populacja.Length]; // tablica zawierająca wartości funkcji celu z listy rozwiązań

            if (srodek == 0) throw new IndexOutOfRangeException();

            for (int i = 0; i < populacja.Length; i++)
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
        public double SredniaPopulacji(ReprezentacjaRozwiazania[] populacja)
        {
            double wynik = 0;

            foreach (ReprezentacjaRozwiazania osobnik in populacja)
            {
                wynik += rozwiazanie.FunkcjaDopasowania(osobnik)["max"][0];
            }

            return wynik / populacja.Length;
        }

        /// <summary>
        /// Metoda obliczająca odchylenie standardowe funkcji celu z populacji rozwiązań
        /// </summary>
        /// <param name="populacja">Lista rozwiązań</param>
        /// <param name="srednia">Średnia z listy rozwiązań</param>
        /// <returns>Zwraca odchylenie standardowe</returns>
        public double OdchylenieStandardowePopulacji(ReprezentacjaRozwiazania[] populacja, double srednia)
        {
            double sumaKwadratow = 0;

            foreach (ReprezentacjaRozwiazania osobnik in populacja)
            {
                sumaKwadratow += Math.Pow(rozwiazanie.FunkcjaDopasowania(osobnik)["max"][0], 2);
            }

            double sredniaSumaKwadratow = sumaKwadratow / (populacja.Length - 1);
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

        /// <summary>
        /// Metoda zwracająca najlepsze rozwiązanie danego problemu optymalizacyjnego, w zależności od wybranego kodowania.
        /// </summary>
        /// <returns>Zwraca najlepsze rozwiązanie dla wybranego problemu optymalizacyjnego</returns>
        public string ZwrocNajlepszeRowziazanie()
        {
            return DekodujRozwiazanie(najlepszeRozwiazanie);
        }

        /// <summary>
        /// Metoda zwracająca najlepszą znalezioną wartość
        /// </summary>
        /// <returns>Wartość funkcji celu</returns>
        public Dictionary<string, double[]> ZwrocWartoscNiebo()
        {
            return rozwiazanie.FunkcjaDopasowania(najlepszeRozwiazanie);
        }
    }
}
