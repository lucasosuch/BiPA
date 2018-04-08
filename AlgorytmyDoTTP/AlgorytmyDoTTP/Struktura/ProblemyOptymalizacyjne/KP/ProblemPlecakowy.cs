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
        private double wagaPlecaka;
        private double wartoscPlecaka;
        private double maxWagaPlecaka;
        private Instancja[] przedmioty;

        public ProblemPlecakowy(int liczbaPrzedmiotow)
        {
            this.przedmioty = new Instancja[liczbaPrzedmiotow];
            this.inicjalizacjaPrzypadku(liczbaPrzedmiotow);
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

        private void inicjalizacjaPrzypadku(int liczbaPrzedmiotow)
        {
            Random losowy = new Random();

            for(int i = 0; i < liczbaPrzedmiotow; i++)
            {
                double waga = losowy.NextDouble(),
                       wartosc = waga * losowy.NextDouble() * 10;

                this.przedmioty[i] = new Instancja(waga, wartosc);
            }
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
