using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP
{
    class Instancja : IPomocniczy
    {
        private double waga;
        private double wartosc;

        public Instancja(double waga, double wartosc)
        {
            this.waga = waga;
            this.wartosc = wartosc;
        }

        public double ZwrocDlugosc()
        {
            throw new NotImplementedException();
        }

        public short ZwrocDo()
        {
            throw new NotImplementedException();
        }

        public short ZwrocOd()
        {
            throw new NotImplementedException();
        }

        public double ZwrocWage()
        {
            return this.waga;
        }

        public double ZwrocWartosc()
        {
            return this.wartosc;
        }
    }
}
