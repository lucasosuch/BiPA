using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;

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
            throw new System.NotImplementedException();
        }

        public short ZwrocDo()
        {
            throw new System.NotImplementedException();
        }

        public short ZwrocOd()
        {
            throw new System.NotImplementedException();
        }

        public ushort[] ZwrocPrzedmioty(string dostepnePrzedmioty, int iloscPrzedmiotow)
        {
            throw new System.NotImplementedException();
        }

        public double ZwrocWage()
        {
            return waga;
        }

        public double ZwrocWartosc()
        {
            return wartosc;
        }
    }
}
