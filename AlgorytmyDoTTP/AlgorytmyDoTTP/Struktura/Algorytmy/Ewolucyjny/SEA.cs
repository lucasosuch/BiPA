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
            int iloscPokolen = 10;
            ushort rozmiarPopulacji = 30;

            ArrayList populacja = StworzPopulacje(rozmiarPopulacji, 15);
            Rekombinacja rekombinacja = new Rekombinacja(pwoMutacji);
            Osobnik rozwiazanie = new Osobnik(problemPlecakowy);
            Selekcja selekcja = new Selekcja(problemPlecakowy);
            Random losowy = new Random();

            while (iloscPokolen >= 0)
            {
                ArrayList nowaPopulacja = new ArrayList();

                for (int i = 0; i < rozmiarPopulacji; i++)
                {
                    if (losowy.NextDouble() <= pwoKrzyzowania)
                    {
                        ushort[] mama = selekcja.Turniej(populacja),
                                 tata = selekcja.Turniej(populacja),
                                 dziecko1 = rekombinacja.Krzyzowanie(mama, tata),
                                 dziecko2 = rekombinacja.Krzyzowanie(tata, mama);

                        Console.WriteLine("Pokolenie:" + iloscPokolen);
                        Console.WriteLine("dziecko1:"+ string.Join("|", dziecko1) +" f(x)="+ string.Join("|", rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp(dziecko1))));
                        Console.WriteLine("dziecko2:" + string.Join("|", dziecko2) + " f(x)="+ string.Join("|", rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp(dziecko2))));
                        nowaPopulacja.Add(dziecko1);
                        nowaPopulacja.Add(dziecko2);

                        for (int j = 0; j < nowaPopulacja.Count; j++)
                        {
                            Console.WriteLine("element "+(j) +": "+ string.Join("|", (ushort[])nowaPopulacja[j]) + " f(x)=" + string.Join("|", rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp((ushort[])nowaPopulacja[j]))));
                        }
                    }
                }

                populacja.Clear();
                populacja.AddRange(nowaPopulacja);
                nowaPopulacja.Clear();
                --iloscPokolen;
            }

            //for (int i = 0; i < populacja.Count; i++)
            //{
            //    Console.WriteLine("dla x=[");
            //    foreach (Instancja element in rozwiazanie.Fenotyp((ushort[])populacja[i]))
            //    {
            //        Console.WriteLine(element.zwrocWage() + "|" + element.zwrocWartosc() + ";");
            //    }
            //    Console.WriteLine("] f(x)=" + string.Join("|", rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp((ushort[])populacja[i]))));
            //}

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
    }
}
