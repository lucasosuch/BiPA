using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka
{
    /// <summary>
    /// Klasa analityczna.
    /// Rozszerzenie podstawowej klasy analitycznej, dla Algorytmu Ewolucyjnego.
    /// </summary>
    class AnalizaEwolucyjny : AAnalityka
    {
        private float[] najlepszaWartoscFunkcji;
        private ReprezentacjaRozwiazania[] najlepszeRozwiazanie;

        public AnalizaEwolucyjny(AOsobnik rozwiazanie, short liczbaIteracji) : base(rozwiazanie, liczbaIteracji)
        {
            najlepszaWartoscFunkcji = new float[liczbaIteracji];
            najlepszeRozwiazanie = new ReprezentacjaRozwiazania[liczbaIteracji];

            for(short i = 0; i < liczbaIteracji; i++)
            {
                najlepszaWartoscFunkcji[i] = -10000;
            }
        }

        /// <summary>
        /// Metoda zwracająca wyniki przeprowadzonego badania
        /// </summary>
        /// <param name="populacja">Lista rozwiązań</param>
        /// <returns>Zwraca raport z wynikami</returns>
        public Dictionary<string, string[]> ZwrocOdpowiedz(ReprezentacjaRozwiazania[] populacja)
        {
            // pobieramy wartości statystyczne / analityczne z naszego badania
            float srednia = SredniaPopulacji(populacja),
                   mediana = MedianaPopulacji(populacja),
                   odchylenieStadowe = OdchylenieStandardowePopulacji(populacja, srednia);
            Dictionary<string, string[]> zwracanyTekst = new Dictionary<string, string[]>();

            // zwracamy raport z badań w formie czytelnej dla człowieka
            zwracanyTekst["dziedzina"] = new string[] { "Najlepszy genotyp", ZwrocNajlepszeRozwiazanie(najlepszeRozwiazanie[0]) }; // bajpas
            zwracanyTekst["maxWartosc"] = new string[] { "Najlepsza funkcja przystosowania (max)", ZwrocWartoscNiebo()["max"][0].ToString() };
            zwracanyTekst["minWartosc"] = new string[] { "Najlepsza funkcja przystosowania (min)", ZwrocWartoscNiebo()["min"][0].ToString() };
            zwracanyTekst["sredniaWartosc"] = new string[] { "Średnia funkcji przystosowania z populacji", srednia.ToString() };
            zwracanyTekst["medianaWartosci"] = new string[] { "Mediana funkcji przystosowania z populacji", mediana.ToString() };
            zwracanyTekst["odchstdWartosci"] = new string[] { "Odchylenie standardowe funkcji przystosowania z populacji", odchylenieStadowe.ToString() };
            zwracanyTekst["czasDzialania"] = new string[] { "Czas dzialania algorytmu", ZwrocCzasDzialaniaAlgorytmu("ms").ToString() + " ms" };

            return zwracanyTekst;
        }

        /// <summary>
        /// Metoda wyznaczająca medianę funkcji celu z populacji rozwiązań
        /// </summary>
        /// <param name="populacja">Lista rozwiązań</param>
        /// <returns>Zwraca medianę</returns>
        public float MedianaPopulacji(ReprezentacjaRozwiazania[] populacja)
        {
            int srodek = populacja.Length / 2;
            float[] wynikiPopulacji = new float[populacja.Length]; // tablica zawierająca wartości funkcji celu z listy rozwiązań

            if (srodek == 0) throw new IndexOutOfRangeException();

            for (int i = 0; i < populacja.Length; i++)
            {
                wynikiPopulacji[i] = rozwiazanie.FunkcjaDopasowania(populacja[i])["max"][0];
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
        public float SredniaPopulacji(ReprezentacjaRozwiazania[] populacja)
        {
            float wynik = 0;

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
        public float OdchylenieStandardowePopulacji(ReprezentacjaRozwiazania[] populacja, float srednia)
        {
            float sumaKwadratow = 0;

            foreach (ReprezentacjaRozwiazania osobnik in populacja)
            {
                Dictionary<string, float[]> wartosc = rozwiazanie.FunkcjaDopasowania(osobnik);
                sumaKwadratow += (wartosc["max"][0] - srednia) * (wartosc["max"][0] - srednia);
            }

            float sredniaSumaKwadratow = sumaKwadratow / (populacja.Length - 1);
            return (float)Math.Sqrt(sredniaSumaKwadratow);
        }

        /// <summary>
        /// Metoda zwracająca najlepszą dziedzinę rozwiązania
        /// </summary>
        /// <returns>Dziedzina rozwiązania</returns>
        public ReprezentacjaRozwiazania ZwrocNajlepszyGenotyp()
        {
            return najlepszeRozwiazanie[0];
        }

        /// <summary>
        /// Metoda zwracająca najlepszą znalezioną wartość
        /// </summary>
        /// <returns>Wartość funkcji celu</returns>
        public Dictionary<string, float[]> ZwrocWartoscNiebo()
        {
            return rozwiazanie.FunkcjaDopasowania(najlepszeRozwiazanie[0]);
        }

        /// <summary>
        /// Metoda poszukująca najlepszego rozwiązania znalezionego do tej pory
        /// </summary>
        /// <param name="geny">Tablica definiująca dziedzinę rozwiązania</param>
        public override void DopiszWartoscProcesu(short index, float czas, ReprezentacjaRozwiazania genotyp)
        {
            float wartosc = rozwiazanie.FunkcjaDopasowania(genotyp)["max"][0];
            Console.WriteLine(index + " " + czas + " " + wartosc);

            if (najlepszaWartoscFunkcji[index] < wartosc)
            {
                najlepszeRozwiazanie[index] = genotyp;
                najlepszaWartoscFunkcji[index] = wartosc;

                wartosciProcesuPoszukiwan[index].Add(new float[] { czas, wartosc });
            }
        }
    }
}
