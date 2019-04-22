using BiPA.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using BiPA.Struktura.ProblemyOptymalizacyjne.KP;
using System;
using System.Collections.Generic;

namespace BiPA.Struktura.ProblemyOptymalizacyjne.TTP.Model
{
    class TTP2 : ITTP
    {
        public Dictionary<string, float[]> ObliczWartoscFunkcjiCelu(float[] dlugosciTrasy, ushort[][] mapaPrzedmiotow, float[] ograniczeniaProblemu, ProblemPlecakowy problemPlecakowy)
        {
            float sumarycznaWartosc = 0,
                   sumarycznaWaga = 0,
                   czasPodrozy = 0;

            Dictionary<string, float[]> wynik = new Dictionary<string, float[]>();
            Dictionary<string, float[]> wynikTTP1 = new TTP1().ObliczWartoscFunkcjiCelu(dlugosciTrasy, mapaPrzedmiotow, ograniczeniaProblemu, problemPlecakowy);

            for (int i = 0, j = -1; i < mapaPrzedmiotow.Length; i++, j++)
            {
                // zebrane przedmioty dla i-tego miasta
                IPomocniczy[] zebranePrzedmioty = problemPlecakowy.ZwrocWybraneElementy(mapaPrzedmiotow[i]);
                // obliczenie zysku z pobranych przedmiotów dla i-tego miasta
                Dictionary<string, float[]> wynikCzesciowy = problemPlecakowy.ObliczZysk(zebranePrzedmioty);

                // obliczenie prędkości złodzieja, gdzie maksymalna prędkość = 1, minimalna prękość = 0.1
                double predkosc = 1 - sumarycznaWaga * (1 - 0.1) / ograniczeniaProblemu[0];
                // jeżeli prędkość mniejsza od minimalnej, wtedy przypisz minimalną prędkość
                predkosc = (predkosc < 0.1) ? 0.1 : predkosc;

                // przy mieście nr. 1 czas podróży wynosi 0 jednostek
                if (j != -1) czasPodrozy += (float)(dlugosciTrasy[j] / predkosc);

                sumarycznaWaga += wynikCzesciowy["min"][0]; // całkowita waga
                sumarycznaWartosc += (float)(wynikCzesciowy["max"][0] * Math.Pow(ograniczeniaProblemu[1], Math.Floor((wynikTTP1["min"][1] - czasPodrozy) / 10))); // całkowita wartość
            }

            wynik["min"] = new float[] { 0, 0 };
            wynik["max"] = new float[] { 0, 0 };

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
