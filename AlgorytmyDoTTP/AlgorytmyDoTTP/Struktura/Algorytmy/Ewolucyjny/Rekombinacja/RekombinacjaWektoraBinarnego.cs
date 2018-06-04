using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Genotyp;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja.Ograniczenia;
using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja
{
    class RekombinacjaWektoraBinarnego : ARekombinacja
    {
        public RekombinacjaWektoraBinarnego(double pwoMutacji, AOsobnik rozwiazanie) : base(pwoMutacji, rozwiazanie){}

        public override ReprezentacjaGenotypu Krzyzowanie(ReprezentacjaGenotypu przodek1, ReprezentacjaGenotypu przodek2)
        {
            int ciecie = losowy.Next(0, przodek1.Length);
            ushort[] dzieciak = new ushort[przodek1.Length];

            dzieciak = (ushort[])przodek1.Clone();
            for (int i = 0; i < ciecie; i++)
            {
                dzieciak[i] = przodek2[i];
            }

            if(czySprawdzacOgraniczenia)
            {
                return SprawdzNaruszenieOgraniczen(Mutacja(dzieciak));
            }

            return Mutacja(dzieciak);
        }

        protected override ReprezentacjaGenotypu Mutacja(ReprezentacjaGenotypu geny)
        {
            if (losowy.NextDouble() > pwoMutacji || pwoMutacji == 0)
            {
                return geny;
            }

            int bit = losowy.Next(geny.Length);
            geny[bit] = (ushort)((geny[bit] == 0) ? 1 : 0);

            return geny;
        }

        protected override ReprezentacjaGenotypu SprawdzNaruszenieOgraniczen(ReprezentacjaGenotypu geny)
        {
            double[] ograniczenie = rozwiazanie.ZwrocInstancjeProblemu().ZwrocOgraniczeniaProblemu();

            while (rozwiazanie.FunkcjaDopasowania(geny)["min"][0] > ograniczenie[0])
            {
                ANaprawaGenotypu naprawaOgraniczen = new KP(geny);
                naprawaOgraniczen.NaprawGeny();
                geny = (ushort[])naprawaOgraniczen.ZwrocGeny().Clone();
            }

            return geny;
        }
    }
}
