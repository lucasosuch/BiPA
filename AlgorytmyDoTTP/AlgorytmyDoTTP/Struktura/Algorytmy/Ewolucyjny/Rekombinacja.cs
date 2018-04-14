using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny
{
    class Rekombinacja
    {
        private double pwoMutacji;
        private Random losowy = new Random();

        public Rekombinacja(double pwoMutacji)
        {
            this.pwoMutacji = pwoMutacji;
        }

        private ushort[] Mutacja(ushort[] geny)
        {
            if (losowy.NextDouble() > pwoMutacji)
            {
                return geny;
            }

            int bit = losowy.Next(geny.Length);
            geny[bit] = (ushort)((geny[bit] == 0) ? 1 : 0);

            return geny;
        }

        public ushort[] Krzyzowanie(ushort[] przodek1, ushort[] przodek2)
        {
            int ciecie = losowy.Next(0, przodek1.Length);
            ushort[] dzieciak = new ushort[przodek1.Length];

            dzieciak = (ushort[])przodek1.Clone();
            for(int i = 0; i < ciecie; i++)
            {
                dzieciak[i] = przodek2[i];
            }

            return Mutacja(dzieciak);
        }
    }
}
