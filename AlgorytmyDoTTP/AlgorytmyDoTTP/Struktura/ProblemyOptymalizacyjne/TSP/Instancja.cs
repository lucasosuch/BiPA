using System;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TSP
{
    class Instancja : IPomocniczy
    {
        private short prowadziOd;
        private short prowadziDo;
        private double dlugosc;

        public Instancja(short prowadziOd, short prowadziDo, double dlugosc)
        {
            this.prowadziOd = prowadziOd;
            this.prowadziDo = prowadziDo;
            this.dlugosc = dlugosc;
        }

        public short ZwrocOd()
        {
            return prowadziOd;
        }

        public short ZwrocDo()
        {
            return prowadziDo;
        }

        public double ZwrocDlugosc()
        {
            return dlugosc;
        }

        public double ZwrocWage()
        {
            throw new NotImplementedException();
        }

        public double ZwrocWartosc()
        {
            throw new NotImplementedException();
        }
    }
}