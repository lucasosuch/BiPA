using BiPA.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;

namespace BiPA.Struktura.ProblemyOptymalizacyjne.KP
{
    /// <summary>
    /// Klasa reprezentująca przedmiot dla KP
    /// </summary>
    class Instancja : IPomocniczy
    {
        private float waga;
        private float wartosc;

        public Instancja(float waga, float wartosc)
        {
            this.waga = waga;
            this.wartosc = wartosc;
        }

        public float ZwrocDlugosc()
        {
            throw new System.NotImplementedException();
        }

        public ushort ZwrocDo()
        {
            throw new System.NotImplementedException();
        }

        public ushort ZwrocOd()
        {
            throw new System.NotImplementedException();
        }

        public ushort[] ZwrocPrzedmioty(string dostepnePrzedmioty, ushort iloscPrzedmiotow)
        {
            throw new System.NotImplementedException();
        }

        public float ZwrocWage()
        {
            return waga;
        }

        public float ZwrocWartosc()
        {
            return wartosc;
        }
    }
}
