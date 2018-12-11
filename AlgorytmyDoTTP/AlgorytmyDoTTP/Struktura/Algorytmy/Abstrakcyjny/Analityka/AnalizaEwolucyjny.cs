using AlgorytmyDoTTP.Rozszerzenia;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka
{
    /// <summary>
    /// Klasa analityczna.
    /// Rozszerzenie podstawowej klasy analitycznej, dla Algorytmu Ewolucyjnego.
    /// </summary>
    class AnalizaEwolucyjny : AAnalityka
    {
        private readonly short[][] liczbaWCzasie;

        public AnalizaEwolucyjny(AOsobnik rozwiazanie, short liczbaIteracji, short czasDzialania) : base(rozwiazanie, liczbaIteracji, czasDzialania)
        {
            liczbaWCzasie = new short[liczbaIteracji][];
            for(short i = 0; i < liczbaIteracji; i++)
            {
                liczbaWCzasie[i] = new short[czasDzialania + 1];
            }
        }

        

        
        public float SredniaPopulacji(ReprezentacjaRozwiazania[] populacja)
        {
            float wynik = 0;

            foreach (ReprezentacjaRozwiazania osobnik in populacja)
            {
                wynik += rozwiazanie.FunkcjaDopasowania(osobnik)["max"][0];
            }

            return wynik / populacja.Length;
        }

        public override int ZwrocNajlepszaIteracje()
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
