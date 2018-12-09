using AlgorytmyDoTTP.Rozszerzenia;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;
using System.Collections;
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
        private readonly short[][] liczbaWCzasie;
        private ReprezentacjaRozwiazania[] najlepszeRozwiazanie;

        public AnalizaEwolucyjny(AOsobnik rozwiazanie, short liczbaIteracji, short czasDzialania) : base(rozwiazanie, liczbaIteracji, czasDzialania)
        {
            liczbaWCzasie = new short[liczbaIteracji][];
            najlepszaWartoscFunkcji = new float[liczbaIteracji];
            najlepszeRozwiazanie = new ReprezentacjaRozwiazania[liczbaIteracji];

            for(short i = 0; i < liczbaIteracji; i++)
            {
                najlepszaWartoscFunkcji[i] = -10000;
                liczbaWCzasie[i] = new short[czasDzialania + 1];
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
            zwracanyTekst["dziedzina"] = new string[] { "Najlepszy genotyp", ZwrocNajlepszeZnalezioneRozwiazanie(najlepszeRozwiazanie[0]) }; // bajpas
            zwracanyTekst["maxWartosc"] = new string[] { "Najlepsza funkcja przystosowania (max)", ZwrocWartoscNiebo()["max"][0].ToString() };
            zwracanyTekst["minWartosc"] = new string[] { "Najlepsza funkcja przystosowania (min)", ZwrocWartoscNiebo()["min"][0].ToString() };
            zwracanyTekst["sredniaWartosc"] = new string[] { "Średnia funkcji przystosowania z populacji", srednia.ToString() };
            zwracanyTekst["medianaWartosci"] = new string[] { "Mediana funkcji przystosowania z populacji", mediana.ToString() };
            zwracanyTekst["odchstdWartosci"] = new string[] { "Odchylenie standardowe funkcji przystosowania z populacji", odchylenieStadowe.ToString() };
            zwracanyTekst["czasDzialania"] = new string[] { "Czas dzialania algorytmu", IleCzasuDzialaAlgorytm("ms").ToString() + " ms" };

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

        public int ZwrocNajlepszaIteracje()
        {
            float[] punkty = new float[liczbaIteracji],
                    srednieMin = new float[liczbaIteracji],
                    srednieAvg = new float[liczbaIteracji],
                    srednieMax = new float[liczbaIteracji];

            for (short i = 0; i < liczbaIteracji; i++)
            {
                srednieMin[i] = Srednia(minWartoscProcesuPoszukiwan[i]);
                srednieAvg[i] = Srednia(sredniaWartoscProcesuPoszukiwan[i]);
                srednieMax[i] = Srednia(maxWartoscProcesuPoszukiwan[i]);
            }

            for (short i = 0; i < liczbaIteracji; i++)
            {   
                float[] maxMax = ZnajdzMax(srednieMax);
                punkty[(int)maxMax[0]] += srednieMax.Length - i;
                srednieMax[(int)maxMax[0]] = -100000;

                float[] maxMin = ZnajdzMax(srednieMin);
                punkty[(int)maxMax[0]] += (float)(srednieMin.Length - (i * 0.5));
                srednieMin[(int)maxMax[0]] = -100000;

                float[] maxAvg = ZnajdzMax(srednieAvg);
                punkty[(int)maxMax[0]] += (float)(srednieAvg.Length - (i * 0.75));
                srednieAvg[(int)maxMax[0]] = -100000;
            }

            return (int)ZnajdzMax(punkty)[0];
        }

        /// <summary>
        /// Metoda poszukująca najlepszego rozwiązania znalezionego do tej pory
        /// </summary>
        /// <param name="geny">Tablica definiująca dziedzinę rozwiązania</param>
        public override void DopiszWartoscProcesu(short index, int czas, ReprezentacjaRozwiazania genotyp)
        {
            float wartosc = rozwiazanie.FunkcjaDopasowania(genotyp)["max"][0];

            if (najlepszaWartoscFunkcji[index] < wartosc)
            {
                najlepszeRozwiazanie[index] = genotyp;
                najlepszaWartoscFunkcji[index] = wartosc;
            }

            if(minWartoscProcesuPoszukiwan[index][czas] > wartosc)
            {
                minWartoscProcesuPoszukiwan[index][czas] = wartosc;
            }
            if (maxWartoscProcesuPoszukiwan[index][czas] < wartosc || maxWartoscProcesuPoszukiwan[index][czas] == 0)
            {
                maxWartoscProcesuPoszukiwan[index][czas] = wartosc;
            }

            liczbaWCzasie[index][czas]++;
            sredniaWartoscProcesuPoszukiwan[index][czas] += wartosc;
        }

        public void ObliczSrednieWartosciProcesu()
        {
            for(short i = 0; i < liczbaIteracji; i++)
            {
                for(short j = 0; j < czasDzialaniaAlgorytmu; j++)
                {
                    sredniaWartoscProcesuPoszukiwan[i][j] /= liczbaWCzasie[i][j];
                }
            }
        }

        public override void StworzWykresyGNUplot(int szerokosc, int wysokosc)
        {
            GNUPlot gnuplot = new GNUPlot(liczbaIteracji, czasDzialaniaAlgorytmu);
            gnuplot.RysujWykres(sredniaWartoscProcesuPoszukiwan, szerokosc, wysokosc, "AVG AE");
            gnuplot.ZakonczProcesGNUPlot();

            gnuplot = new GNUPlot(liczbaIteracji, czasDzialaniaAlgorytmu);
            gnuplot.RysujWykres(maxWartoscProcesuPoszukiwan, szerokosc, wysokosc, "MAX AE");
            gnuplot.ZakonczProcesGNUPlot();

            gnuplot = new GNUPlot(liczbaIteracji, czasDzialaniaAlgorytmu);
            gnuplot.RysujWykres(minWartoscProcesuPoszukiwan, szerokosc, wysokosc, "MIN AE");
            gnuplot.ZakonczProcesGNUPlot();

            ZwrocNajlepszaIteracje();
        }

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

        private float[] ZnajdzMax(float[] tablica)
        {
            float[] wynik = new float[] { 0, tablica[0] };
            for(short i = 1; i < tablica.Length; i++)
            {
                if(tablica[i] > wynik[1])
                {
                    wynik[0] = i;
                    wynik[1] = tablica[i];
                }
            }

            return wynik;
        }
    }
}
