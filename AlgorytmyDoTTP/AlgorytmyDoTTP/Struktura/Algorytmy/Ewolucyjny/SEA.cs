using System;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny
{
    class SEA : IAlgorytm
    {
        private double pwoMutacji;
        private double pwoKrzyzowania;

        public SEA(double pwoKrzyzowania, double pwoMutacji)
        {
            this.pwoKrzyzowania = pwoKrzyzowania;
            this.pwoMutacji = pwoMutacji;
        }

        public void Start()
        {
            int iteracje = 100;
            ushort rozmiarPopulacji = 5000;

            ushort[] populacja = StworzPopulacje(rozmiarPopulacji);
            Rekombinacja rekombinacja = new Rekombinacja(pwoMutacji);
            Osobnik rozwiazanie = new Osobnik();
            Selekcja selekcja = new Selekcja();

            while (iteracje > 0)
            {
                ushort[] nowaPopulacja = new ushort[rozmiarPopulacji];

                for (int i = 0; i < rozmiarPopulacji; i++)
                {
                    ushort mama = selekcja.Turniej(populacja),
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

        public ushort[] StworzPopulacje(ushort rozmiarPopulacji)
        {
            Random losowy = new Random();
            ushort[] populacja = new ushort[rozmiarPopulacji];

            for (int i = 0; i < rozmiarPopulacji; i++)
            {
                populacja[i] = (ushort)losowy.Next(5000 + 1);
            }

            return populacja;
        }
    }
}
