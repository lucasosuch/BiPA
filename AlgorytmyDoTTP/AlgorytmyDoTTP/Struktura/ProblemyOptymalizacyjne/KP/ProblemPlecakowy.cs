using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP
{
    class ProblemPlecakowy
    {
        private double maxWagaPlecaka;
        private Instancja[] przedmioty;

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
                    listaElementow.Add(przedmioty[i]);
                } 
            }

            return listaElementow;
        }

        public void UstawMaxWagePlecaka(double maxWagaPlecaka)
        {
            this.maxWagaPlecaka = maxWagaPlecaka;
        }

        private void InicjalizacjaPrzypadku(ushort liczbaPrzedmiotow)
        {
            przedmioty = new Instancja[liczbaPrzedmiotow];
            przedmioty[0] = new Instancja(0.1, 10.0);
            przedmioty[1] = new Instancja(0.04, 4.0);
            przedmioty[2] = new Instancja(0.15, 16.0);
            przedmioty[3] = new Instancja(0.4, 9.0);
            przedmioty[4] = new Instancja(0.3, 13.0);
            przedmioty[5] = new Instancja(0.6, 34.0);
            przedmioty[6] = new Instancja(0.8, 16.0);
            przedmioty[7] = new Instancja(0.12, 36.0);
            przedmioty[8] = new Instancja(0.34, 7.0);
            przedmioty[9] = new Instancja(0.41, 68.0);
            przedmioty[10] = new Instancja(0.56, 11.0);
            przedmioty[11] = new Instancja(0.65, 18.0);
            przedmioty[12] = new Instancja(0.87, 100.0);
            przedmioty[13] = new Instancja(0.45, 24.0);
            przedmioty[14] = new Instancja(0.71, 15.0);
            przedmioty[15] = new Instancja(0.23, 30.0);
            przedmioty[16] = new Instancja(0.31, 43.0);
            przedmioty[17] = new Instancja(0.45, 15.0);
            przedmioty[18] = new Instancja(0.33, 68.0);
            przedmioty[19] = new Instancja(1.1, 250.0);
            przedmioty[20] = new Instancja(0.25, 23.0);
            przedmioty[21] = new Instancja(0.01, 70.0);
            przedmioty[22] = new Instancja(0.09, 2.0);
            przedmioty[23] = new Instancja(0.1, 19.0);
            przedmioty[24] = new Instancja(0.63, 99.0);
        }

        public double[] ObliczZysk(ArrayList wybranePrzedmioty)
        {
            double[] wynik = new double[] {0, 0};

            foreach(Instancja przedmiot in wybranePrzedmioty)
            {
                wynik[0] += przedmiot.ZwrocWage();
                wynik[1] += przedmiot.ZwrocWartosc();
            }

            return wynik;
        }

        public double ZwrocMaxWagePlecaka()
        {
            return maxWagaPlecaka;
        }
    }
}
