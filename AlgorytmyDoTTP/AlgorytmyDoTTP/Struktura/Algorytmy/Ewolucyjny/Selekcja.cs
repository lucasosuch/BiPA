using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny
{
    class Selekcja
    {
        public Random losowy = new Random();
        private ProblemPlecakowy problemPlecakowy;

        public Selekcja(ProblemPlecakowy problemPlecakowy)
        {
            this.problemPlecakowy = problemPlecakowy;
        }

        public ushort[] Turniej(ushort[][] populacja)
        {
            int k1 = losowy.Next(populacja.Length - 1),
                k2 = losowy.Next(populacja.Length - 1);

            Osobnik rozwiazanie = new Osobnik(problemPlecakowy);
            double[] dopasowanie1 = rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp(populacja[k1])),
                     dopasowanie2 = rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp(populacja[k2]));

            if (dopasowanie1[1] > dopasowanie2[1])
            {
                return populacja[k1];
            }
            else
            {
                return populacja[k2];
            }
        }
    }
}
