using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP
{
    class ProblemPlecakowy : ProblemOptymalizacyjny
    {
        public ProblemPlecakowy(ushort liczbaPrzedmiotow)
        {
            InicjalizacjaPrzypadku(liczbaPrzedmiotow);
        }

        public ArrayList ZwrocWybraneElementy(ushort[] wybraneElementy)
        {
            ArrayList listaElementow = new ArrayList();

            for (int i = 0; i < wybraneElementy.Length; i++)
            {
                if(wybraneElementy[i] == 1)
                {
                    listaElementow.Add(instancje[i]);
                } 
            }

            return listaElementow;
        }

        private void InicjalizacjaPrzypadku(ushort liczbaPrzedmiotow)
        {
            instancje = new Instancja[liczbaPrzedmiotow];
            instancje[0] = new Instancja(0.1, 10.0);
            instancje[1] = new Instancja(0.04, 4.0);
            instancje[2] = new Instancja(0.15, 16.0);
            instancje[3] = new Instancja(0.4, 9.0);
            instancje[4] = new Instancja(0.3, 13.0);
            instancje[5] = new Instancja(0.6, 34.0);
            instancje[6] = new Instancja(0.8, 16.0);
            instancje[7] = new Instancja(0.12, 36.0);
            instancje[8] = new Instancja(0.34, 7.0);
            instancje[9] = new Instancja(0.41, 68.0);
            instancje[10] = new Instancja(0.56, 11.0);
            instancje[11] = new Instancja(0.65, 18.0);
            instancje[12] = new Instancja(0.87, 100.0);
            instancje[13] = new Instancja(0.45, 24.0);
            instancje[14] = new Instancja(0.71, 15.0);
            instancje[15] = new Instancja(0.23, 30.0);
            instancje[16] = new Instancja(0.31, 43.0);
            instancje[17] = new Instancja(0.45, 15.0);
            instancje[18] = new Instancja(0.33, 68.0);
            instancje[19] = new Instancja(1.1, 250.0);
            instancje[20] = new Instancja(0.25, 23.0);
            instancje[21] = new Instancja(0.01, 70.0);
            instancje[22] = new Instancja(0.09, 2.0);
            instancje[23] = new Instancja(0.1, 19.0);
            instancje[24] = new Instancja(0.63, 99.0);
        }

        public override Dictionary<String, double[]> ObliczZysk(ArrayList wektor)
        {
            Dictionary<String, double[]> wynik = new Dictionary<String, double[]>();
            wynik["min"] = new double[] { 0 };
            wynik["max"] = new double[] { 0 };

            foreach (Instancja przedmiot in wektor)
            {
                wynik["min"][0] += przedmiot.ZwrocWage();
                wynik["max"][0] += przedmiot.ZwrocWartosc();
            }

            return wynik;
        }
    }
}
