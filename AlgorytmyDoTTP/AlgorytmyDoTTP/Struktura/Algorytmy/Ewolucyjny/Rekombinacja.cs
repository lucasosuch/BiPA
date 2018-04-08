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

        public ushort[] Mutacja(ushort[] geny)
        {
            if (losowy.NextDouble() > pwoMutacji)
            {
                return geny;
            }

            int bit = losowy.Next(geny.Length);
            geny[bit] = (ushort)((geny[bit] == 0) ? 1 : 0);

            return geny;
        }

        public ushort[] Krzyzowanie(ushort[] mama, ushort[] tata)
        {
            int ciecie = losowy.Next(0, mama.Length);

            ushort[] dzieciak = 

            return Mutacja(dzieciak);
        }
    }
}
