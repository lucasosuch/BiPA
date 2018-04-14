using System;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using System.Collections;
using System.Diagnostics;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny
{
    class SEA : IAlgorytm
    {
        private short iloscPokolen;
        private ushort rozmiarPopulacji;
        private ushort liczbaPrzypadkow;
        private double pwoMutacji;
        private double pwoKrzyzowania;
        private Osobnik rozwiazanie;
        private Random losowy = new Random();

        public SEA(double pwoKrzyzowania, double pwoMutacji, ushort liczbaPrzypadkow, Osobnik rozwiazanie, short iloscPokolen, ushort rozmiarPopulacji)
        {
            this.pwoKrzyzowania = pwoKrzyzowania;
            this.pwoMutacji = pwoMutacji;
            this.liczbaPrzypadkow = liczbaPrzypadkow;
            this.rozwiazanie = rozwiazanie;
            this.iloscPokolen = iloscPokolen;
            this.rozmiarPopulacji = rozmiarPopulacji;
        }

        public void Start()
        {
            double wartoscNiebo = 0,
                   procentNajlepszego = 0.8,
                   globalnieNajlepszyOsobnik = 409;

            ushort[] niebo = new ushort[liczbaPrzypadkow];
            Selekcja selekcja = new Selekcja(rozwiazanie, liczbaPrzypadkow);
            Rekombinacja rekombinacja = new Rekombinacja(pwoMutacji, rozwiazanie);

            Stopwatch stopWatch = new Stopwatch();
            ArrayList nowaPopulacja = new ArrayList();
            ArrayList populacja = StworzPopulacje();

            for (int i = 0; i < liczbaPrzypadkow; i++)
            {
                niebo[i] = 0;
            }

            stopWatch.Start();
            while (iloscPokolen >= 0)
            {
                for (int i = 0; i < rozmiarPopulacji; i++)
                {
                    if (losowy.NextDouble() <= pwoKrzyzowania)
                    {
                        ushort[] mama = selekcja.Turniej(populacja),
                                 tata = selekcja.Turniej(populacja),
                                 dziecko1 = rekombinacja.Krzyzowanie(mama, tata),
                                 dziecko2 = rekombinacja.Krzyzowanie(tata, mama);

                        nowaPopulacja.Add(dziecko1);
                        nowaPopulacja.Add(dziecko2);

                        double przystosowanieDziecko1 = rozwiazanie.FunkcjaDopasowania(dziecko1)[1],
                               przystosowanieDziecko2 = rozwiazanie.FunkcjaDopasowania(dziecko2)[1];

                        if (wartoscNiebo < przystosowanieDziecko1)
                        {
                            wartoscNiebo = przystosowanieDziecko1;
                            niebo = (ushort[])dziecko1.Clone();
                        }

                        if (wartoscNiebo < przystosowanieDziecko2)
                        {
                            wartoscNiebo = przystosowanieDziecko2;
                            niebo = (ushort[])dziecko2.Clone();
                        }

                        if(wartoscNiebo >= (procentNajlepszego * globalnieNajlepszyOsobnik))
                        {
                            stopWatch.Stop();
                        }
                    }
                }

                populacja.Clear();
                populacja.AddRange(nowaPopulacja);
                nowaPopulacja.Clear();
                
                --iloscPokolen;
            }

            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("Czas w, którym znaleziono "+ procentNajlepszego + " najlepszego osobnika: " + ts);
            Console.WriteLine("Najlepszy osobnik: Genotyp = ["+string.Join(",", niebo) + "]");

            String fenotyp = "";
            foreach (Instancja element in rozwiazanie.Fenotyp(niebo))
            {
                fenotyp += element.ZwrocWage() +"|"+ element.ZwrocWartosc() +"; ";
            }

            double[] najlepszyOsobnik = rozwiazanie.FunkcjaDopasowania(niebo);

            Console.WriteLine("Fenotyp = ["+ fenotyp +"]");
            Console.WriteLine("Funkcja dopasowania: waga = "+ najlepszyOsobnik[0]+ ", wynik = "+ najlepszyOsobnik[1]);

            double srednia = SredniaPopulacji(populacja),
                   odchylenieStadowe = OdchylenieStandardowePopulacji(populacja, srednia);

            Console.WriteLine("Średnia = " + srednia +", odchylenie standardowe = "+ odchylenieStadowe);
            Console.ReadLine();
        }

        private ArrayList StworzPopulacje()
        {
            ArrayList populacja = new ArrayList();

            for (int i = 0; i < rozmiarPopulacji; i++)
            {
                ushort[] genotyp = new ushort[liczbaPrzypadkow];
                for (int j = 0; j < liczbaPrzypadkow; j++)
                {
                    genotyp[j] = (ushort)losowy.Next(2);
                }

                populacja.Add(genotyp);
            }

            return populacja;
        }

        private double SredniaPopulacji(ArrayList populacja)
        {
            double wynik = 0;
            
            foreach(ushort[] osobnik in populacja)
            {
                wynik += rozwiazanie.FunkcjaDopasowania(osobnik)[1];
            }

            return wynik / populacja.Count;
        }

        private double OdchylenieStandardowePopulacji(ArrayList populacja, double srednia)
        {
            double sumaKwadratow = 0;

            foreach (ushort[] osobnik in populacja)
            {
                sumaKwadratow += Math.Pow(rozwiazanie.FunkcjaDopasowania(osobnik)[1], 2);
            }

            double sredniaSumaKwadratow = sumaKwadratow / (populacja.Count - 1);
            return Math.Sqrt(sredniaSumaKwadratow - (Math.Pow(srednia, 2)));
        }
    }
}