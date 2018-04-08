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

        public ProblemPlecakowy()
        {
            this.przedmioty = new Instancja[15];
            this.inicjalizacjaPrzypadku();
        }

        public ArrayList zwrocWybraneElementy(ushort[] wybraneElementy)
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

        public void ustawMaxWagePlecaka(double maxWagaPlecaka)
        {
            this.maxWagaPlecaka = maxWagaPlecaka;
        }

        private void inicjalizacjaPrzypadku()
        {
            this.przedmioty[0] = new Instancja(0.1, 10.0);
            this.przedmioty[1] = new Instancja(0.04, 4.0);
            this.przedmioty[2] = new Instancja(0.15, 16.0);
            this.przedmioty[3] = new Instancja(0.4, 9.0);
            this.przedmioty[4] = new Instancja(0.3, 23.0);
            this.przedmioty[5] = new Instancja(0.7, 54.0);
            this.przedmioty[6] = new Instancja(0.8, 16.0);
            this.przedmioty[7] = new Instancja(0.12, 56.0);
            this.przedmioty[8] = new Instancja(0.34, 7.0);
            this.przedmioty[9] = new Instancja(0.41, 78.0);
            this.przedmioty[10] = new Instancja(0.56, 11.0);
            this.przedmioty[11] = new Instancja(0.75, 18.0);
            this.przedmioty[12] = new Instancja(0.87, 100.0);
            this.przedmioty[13] = new Instancja(0.45, 34.0);
            this.przedmioty[14] = new Instancja(0.91, 15.0);
        }

        public double[] obliczZysk(ArrayList wybranePrzedmioty)
        {
            double[] wynik = new double[] {0, 0};

            foreach(Instancja przedmiot in wybranePrzedmioty)
            {
                wynik[0] += przedmiot.zwrocWage();
                wynik[1] += przedmiot.zwrocWartosc();
            }

            if (wynik[0] > maxWagaPlecaka) wynik[1] = 0;

            return wynik;
        }
    }
}
