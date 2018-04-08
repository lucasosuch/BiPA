using System;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;

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
            int iteracje = 100;
            ushort rozmiarPopulacji = 5000;

            ushort[][] populacja = StworzPopulacje(rozmiarPopulacji, 25);
            Rekombinacja rekombinacja = new Rekombinacja(pwoMutacji);
            Osobnik rozwiazanie = new Osobnik(problemPlecakowy);
            Selekcja selekcja = new Selekcja(problemPlecakowy);

            while (iteracje > 0)
            {
                ushort[] nowaPopulacja = new ushort[rozmiarPopulacji];

                for (int i = 0; i < rozmiarPopulacji; i++)
                {
                    ushort[] mama = selekcja.Turniej(populacja),
                             tata = selekcja.Turniej(populacja),
                             dziecko = rekombinacja.Krzyzowanie(mama, tata);

                    nowaPopulacja[i] = dziecko;
                }

                populacja = nowaPopulacja;
                --iteracje;
            }

            for (int i = 0; i < populacja.Length; i++)
            {
                Console.WriteLine("dla x=" + rozwiazanie.Fenotyp(populacja[i]) + " f(x)=" + rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp(populacja[i])));
            }

            Console.ReadLine();
        }

        public ushort[][] StworzPopulacje(ushort rozmiarPopulacji, ushort dlugoscGenotypu)
        {
            Random losowy = new Random();
            ushort[][] populacja = new ushort[rozmiarPopulacji][];

            for (int i = 0; i < rozmiarPopulacji; i++)
            {
                for(int j = 0; j < dlugoscGenotypu; j++)
                {
                    populacja[i][j] = (ushort)losowy.Next(1);
                }
            }

            return populacja;
        }
    }
}
