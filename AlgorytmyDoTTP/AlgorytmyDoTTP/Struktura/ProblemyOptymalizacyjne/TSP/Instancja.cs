using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TSP
{
    /// <summary>
    /// Klasa reprezentująca krawędź na grafie dla TSP
    /// </summary>
    class Instancja : IPomocniczy
    {
        private ushort prowadziOd;
        private ushort prowadziDo;
        private float dlugosc;

        public Instancja(ushort prowadziOd, ushort prowadziDo, float dlugosc)
        {
            this.prowadziOd = prowadziOd;
            this.prowadziDo = prowadziDo;
            this.dlugosc = dlugosc;
        }

        public ushort ZwrocOd()
        {
            return prowadziOd;
        }

        public ushort ZwrocDo()
        {
            return prowadziDo;
        }

        public float ZwrocDlugosc()
        {
            return dlugosc;
        }

        public float ZwrocWage()
        {
            throw new System.NotImplementedException();
        }

        public float ZwrocWartosc()
        {
            throw new System.NotImplementedException();
        }

        public ushort[] ZwrocPrzedmioty(string dostepnePrzedmioty, ushort iloscPrzedmiotow)
        {
            throw new System.NotImplementedException();
        }
    }
}