using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP
{
    class Instancja
    {
        private double waga;
        private double wartosc;

        public Instancja(double waga, double wartosc)
        {
            this.waga = waga;
            this.wartosc = wartosc;
        }

        public double zwrocWage()
        {
            return this.waga;
        }

        public double zwrocWartosc()
        {
            return this.wartosc;
        }
    }
}
