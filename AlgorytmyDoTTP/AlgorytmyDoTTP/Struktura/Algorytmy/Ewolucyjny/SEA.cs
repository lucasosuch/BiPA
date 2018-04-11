using System;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny
{
    class SEA : IAlgorytm
    {
        private double pwoMutacji;
        private double pwoKrzyzowania;
        private ProblemPlecakowy problemPlecakowy;

        public SEA(double pwoKrzyzowania, double pwoMutacji, ProblemPlecakowy problemPlecakowy)
        {
            this.pwoKrzyzowania = pwoKrzyzowania;
            this.pwoMutacji = pwoMutacji;
            this.problemPlecakowy = problemPlecakowy;
        }

        public void Start()
        {
            short iloscPokolen = 100;
            ushort rozmiarPopulacji = 70,
                   dlugoscGenotypu = 15;

            ArrayList populacja = StworzPopulacje(rozmiarPopulacji, dlugoscGenotypu);
            Rekombinacja rekombinacja = new Rekombinacja(pwoMutacji);
            Osobnik rozwiazanie = new Osobnik(problemPlecakowy);
            Selekcja selekcja = new Selekcja(problemPlecakowy);
            Random losowy = new Random();
            ArrayList nowaPopulacja = new ArrayList();

            ushort[] niebo, mama, tata, dziecko1, dziecko2 = new ushort[dlugoscGenotypu];

            double wartoscNiebo = 0,
                    globalnieNajlepszyOsobnik = 409;

            while (iloscPokolen >= 0)
            {
                for (int i = 0; i < rozmiarPopulacji; i++)
                {
                    if (losowy.NextDouble() <= pwoKrzyzowania)
                    {
                        mama = selekcja.Turniej(populacja, dlugoscGenotypu);
                        tata = selekcja.Turniej(populacja, dlugoscGenotypu);
                        dziecko1 = rekombinacja.Krzyzowanie(mama, tata);
                        dziecko2 = rekombinacja.Krzyzowanie(tata, mama);
                        
                        nowaPopulacja.Add(dziecko1);
                        nowaPopulacja.Add(dziecko2);

                        double przystosowanieDziecko1 = rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp(dziecko1))[1],
                               przystosowanieDziecko2 = rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp(dziecko2))[1];

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
                    }
                }

                populacja.Clear();
                populacja.AddRange(nowaPopulacja);
                nowaPopulacja.Clear();


                --iloscPokolen;
            }

            Console.WriteLine("Maxymalna znaleziona wartosc: "+ wartoscNiebo);
            Console.ReadLine();
        }

        public ArrayList StworzPopulacje(ushort rozmiarPopulacji, ushort dlugoscGenotypu)
        {
            Random losowy = new Random();
            ArrayList populacja = new ArrayList();

            for (int i = 0; i < rozmiarPopulacji; i++)
            {
                ushort[] genotyp = new ushort[dlugoscGenotypu];
                for (int j = 0; j < dlugoscGenotypu; j++)
                {
                    genotyp[j] = (ushort)losowy.Next(2);
                }

                populacja.Add(genotyp);
            }

            return populacja;
        }

        public Boolean KryteriumStopu(String wybor, object parametr)
        {
            Boolean wynik = true;

            switch(wybor)
            {
                case "Pokolenia":
                    wynik = (short)parametr >= 0;
                    break;

                case "Czas":

                    break;

                case "Poprawa":

                    break;

                case "Roznorodnosc":

                    break;
            }

            return wynik;
        }
    }
}
