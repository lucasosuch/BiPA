using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny
{
    class Selekcja
    {
        public Random losowy = new Random();

        public ushort Turniej(ushort[] populacja)
        {
            int k1 = losowy.Next(populacja.Length - 1),
                k2 = losowy.Next(populacja.Length - 1);

            Osobnik rozwiazanie = new Osobnik();
            double dopasowanie1 = rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp(populacja[k1])),
                   dopasowanie2 = rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp(populacja[k2]));

            if (dopasowanie1 > dopasowanie2)
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
