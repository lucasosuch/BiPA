namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TSP
{
    class Instancja
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
    }
}