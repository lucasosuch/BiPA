using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja.Rozszerzenia
{
    abstract class AMetodaKrzyzowania
    {
        protected ushort[] przodek1;
        protected ushort[] przodek2;
        protected Random losowy = new Random();

        public AMetodaKrzyzowania(ushort[] przodek1, ushort[] przodek2)
        {
            this.przodek1 = przodek1;
            this.przodek2 = przodek2;
        }

        public abstract ushort[] ZwrocPotomka();
    }
}
