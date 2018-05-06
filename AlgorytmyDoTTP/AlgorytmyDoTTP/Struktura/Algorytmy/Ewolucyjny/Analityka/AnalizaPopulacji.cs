using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Analityka
{
    class AnalizaPopulacji : IAnalityka
    {
        private AOsobnik rozwiazanie;

        public AnalizaPopulacji(AOsobnik rozwiazanie)
        {
            this.rozwiazanie = rozwiazanie;
        }

        // Zwraca wartość średnią z funkcji celów w populacji
        public double SredniaPopulacji(ArrayList populacja)
        {
            double wynik = 0;

            foreach (ushort[] osobnik in populacja)
            {
                wynik += rozwiazanie.FunkcjaDopasowania(osobnik)["max"][0];
            }

            return wynik / populacja.Count;
        }

        // Zwraca wartość odchylenia standardowego z funkcji celów w populacji
        public double OdchylenieStandardowePopulacji(ArrayList populacja, double srednia)
        {
            double sumaKwadratow = 0;

            foreach (ushort[] osobnik in populacja)
            {
                sumaKwadratow += Math.Pow(rozwiazanie.FunkcjaDopasowania(osobnik)["max"][0], 2);
            }

            double sredniaSumaKwadratow = sumaKwadratow / (populacja.Count - 1);
            return Math.Sqrt(sredniaSumaKwadratow - (Math.Pow(srednia, 2)));
        }
    }
}
