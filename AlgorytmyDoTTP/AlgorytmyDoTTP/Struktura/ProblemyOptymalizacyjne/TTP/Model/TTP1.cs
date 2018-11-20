using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TTP.Model
{
    class TTP1 : ITTP
    {
        public Dictionary<string, double[]> ObliczWartoscFunkcjiCelu(double[] dlugosciTrasy, ushort[][] mapaPrzedmiotow, double[] ograniczeniaProblemu, ProblemPlecakowy problemPlecakowy)
        {
            double sumarycznaWartosc = 0,
                   sumarycznaWaga = 0,
                   czasPodrozy = 0;

            Dictionary<string, double[]> wynik = new Dictionary<string, double[]>();

            for (int i = 0, j = -1; i < mapaPrzedmiotow.Length; i++, j++)
            {
                // zebrane przedmioty dla i-tego miasta
                IPomocniczy[] zebranePrzedmioty = problemPlecakowy.ZwrocWybraneElementy(mapaPrzedmiotow[i]);
                // obliczenie zysku z pobranych przedmiotów dla i-tego miasta
                Dictionary<string, double[]> wynikCzesciowy = problemPlecakowy.ObliczZysk(zebranePrzedmioty);

                sumarycznaWaga += wynikCzesciowy["min"][0]; // całkowita waga
                sumarycznaWartosc += wynikCzesciowy["max"][0]; // całkowita wartość

                // obliczenie prędkości złodzieja, gdzie maksymalna prędkość = 1, minimalna prękość = 0.1
                double predkosc = 1 - sumarycznaWaga * (1 - 0.1) / ograniczeniaProblemu[0];
                // jeżeli prędkość mniejsza od minimalnej, wtedy przypisz minimalną prędkość
                predkosc = (predkosc < 0.1) ? 0.1 : predkosc;

                // przy mieście nr. 1 czas podróży wynosi 0 jednostek
                if (j != -1) czasPodrozy += dlugosciTrasy[j] * predkosc;
            }

            wynik["min"] = new double[] { 0, 0 };
            wynik["max"] = new double[] { 0, 0 };

            // ustawienie parametrów do minimalizacji
            wynik["min"][0] = sumarycznaWaga;
            wynik["min"][1] = czasPodrozy;
            // obliczenie funkcji zysku dla TTP
            wynik["max"][0] = sumarycznaWartosc - ograniczeniaProblemu[1] * czasPodrozy;
            wynik["max"][1] = sumarycznaWartosc;

            return wynik;
        }
    }
}
