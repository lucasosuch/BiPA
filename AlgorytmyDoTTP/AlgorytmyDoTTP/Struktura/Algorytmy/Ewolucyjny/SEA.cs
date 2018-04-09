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
            int iloscPokolen = 1000;
            ushort rozmiarPopulacji = 700;

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
                             dziecko1 = rekombinacja.Krzyzowanie(mama, tata),
                             dziecko2 = rekombinacja.Krzyzowanie(tata, mama);

                    //Console.WriteLine(string.Join("|", dziecko));

                    ushort[] wybranyPotomek = dziecko1;

                    if(rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp(dziecko1))[1] < rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp(dziecko2))[1])
                    {
                        wybranyPotomek = dziecko2;
                    }

                    nowaPopulacja[i] = wybranyPotomek;
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
