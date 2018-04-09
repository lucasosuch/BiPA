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
            Osobnik rozwiazanie = new Osobnik(problemPlecakowy);

            ushort[] zwyciezca = populacja[0];
            double[] dopasowanieZwyciezcy = rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp(populacja[0]));

            for (int i = 0; i <= 25; i++)
            {
                int k = losowy.Next(populacja.Length - 1);
                double[] dopasowanie = rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp(populacja[k]));

                if(dopasowanieZwyciezcy[1] < dopasowanie[1])
                {
                    zwyciezca = populacja[k];
                    dopasowanieZwyciezcy = dopasowanie;
                }
            }

            return zwyciezca;
        }
    }
}
