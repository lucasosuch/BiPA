using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie
{
    abstract class ALosowanie
    {
        protected int maxAllel;
        protected int iloscElementow;
        protected int iloscRozwiazan;
        protected Random losowy = new Random();

        public ALosowanie(int iloscRozwiazan, int iloscElementow, int maxAllel)
        {
            this.maxAllel = maxAllel;
            this.iloscRozwiazan = iloscRozwiazan;
            this.iloscElementow = iloscElementow;
        }

        public abstract ArrayList LosujRozwiazania();
    }
}
