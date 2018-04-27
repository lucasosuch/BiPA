using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja
{
    class RekombinacjaWektoraBinarnego : ARekombinacja
    {
        private double pwoMutacji;
        private AOsobnik rozwiazanie;
        private Random losowy = new Random();

        public RekombinacjaWektoraBinarnego(double pwoMutacji, AOsobnik rozwiazanie)
        {
            this.pwoMutacji = pwoMutacji;
            this.rozwiazanie = rozwiazanie;
        }

        public override ushort[] Krzyzowanie(ushort[] przodek1, ushort[] przodek2)
        {
            int ciecie = losowy.Next(0, przodek1.Length);
            ushort[] dzieciak = new ushort[przodek1.Length];

            dzieciak = (ushort[])przodek1.Clone();
            for (int i = 0; i < ciecie; i++)
            {
                dzieciak[i] = przodek2[i];
            }

            return SprawdzNaruszenieOgraniczen(Mutacja(dzieciak));
        }

        protected override ushort[] Mutacja(ushort[] geny)
        {
            if (losowy.NextDouble() > pwoMutacji)
            {
                return geny;
            }

            int bit = losowy.Next(geny.Length);
            geny[bit] = (ushort)((geny[bit] == 0) ? 1 : 0);

            return geny;
        }

        private ushort[] SprawdzNaruszenieOgraniczen(ushort[] geny)
        {
            double[] ograniczenie = rozwiazanie.ZwrocInstancjeProblemu().ZwrocOgraniczeniaProblemu();

            while (rozwiazanie.FunkcjaDopasowania(geny)["min"][0] > ograniczenie[0])
            {
                for(int i = 0; i < geny.Length; i++)
                {
                    if(geny[i] == 1)
                    {
                        geny[i] = 0;
                        break;
                    }
                }
            }

            return geny;
        }
    }
}
