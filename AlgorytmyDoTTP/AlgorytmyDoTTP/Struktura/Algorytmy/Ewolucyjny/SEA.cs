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
            int iloscPokolen = 300;
            ushort rozmiarPopulacji = 150;

            ushort[][] populacja = StworzPopulacje(rozmiarPopulacji, 15);
            Rekombinacja rekombinacja = new Rekombinacja(pwoMutacji);
            Osobnik rozwiazanie = new Osobnik(problemPlecakowy);
            Selekcja selekcja = new Selekcja(problemPlecakowy);

            while (iloscPokolen > 0)
            {
                ushort[][] nowaPopulacja = new ushort[rozmiarPopulacji][];

                for (int i = 0; i < rozmiarPopulacji; i++)
                {
                    ushort[] mama = selekcja.Turniej(populacja),
                             tata = selekcja.Turniej(populacja),
                             dziecko = rekombinacja.Krzyzowanie(mama, tata);
                    
                    //Console.WriteLine(string.Join("|", dziecko));

                    nowaPopulacja[i] = dziecko;
                }

                populacja = nowaPopulacja;
                --iloscPokolen;
            }

            for (int i = 0; i < populacja.Length; i++)
            {
                Console.WriteLine("dla x=[");
                foreach (Instancja element in rozwiazanie.Fenotyp(populacja[i]))
                {
                    Console.WriteLine(element.zwrocWage() + "|" + element.zwrocWartosc() + ";");
                }
                Console.WriteLine("] f(x)=" + string.Join("|", rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp(populacja[i]))));
            }

            Console.ReadLine();
        }

        public ushort[][] StworzPopulacje(ushort rozmiarPopulacji, ushort dlugoscGenotypu)
        {
            Random losowy = new Random();
            ushort[][] populacja = new ushort[rozmiarPopulacji][];

            for (int i = 0; i < rozmiarPopulacji; i++)
            {
                populacja[i] = new ushort[dlugoscGenotypu];
                for (int j = 0; j < dlugoscGenotypu; j++)
                {
                    populacja[i][j] = (ushort)losowy.Next(2);
                }
            }

            return populacja;
        }
    }
}
