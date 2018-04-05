using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny
{
    class Rekombinacja
    {
        private double pwoMutacji;
        public Random losowy = new Random();

        public Rekombinacja(double pwoMutacji)
        {
            this.pwoMutacji = pwoMutacji;
        }

        public ushort Mutacja(ushort geny)
        {
            if (losowy.NextDouble() > pwoMutacji)
            {
                return geny;
            }

            int bit = losowy.Next(12);
            ushort maska = (ushort)(1 << bit);

            return (ushort)(maska ^ geny);
        }

        public ushort Krzyzowanie(ushort mama, ushort tata)
        {
            int ciecie = losowy.Next(1, 12 + 1);
            ushort maska = 0;

            maska = (ushort)~maska;
            maska <<= ciecie;

            ushort dzieciak = (ushort)(maska & mama);
            dzieciak |= (ushort)(~maska & tata);

            return Mutacja(dzieciak);
        }
    }
}
