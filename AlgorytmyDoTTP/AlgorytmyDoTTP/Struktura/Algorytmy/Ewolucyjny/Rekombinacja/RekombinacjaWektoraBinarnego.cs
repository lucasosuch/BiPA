﻿using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja.Ograniczenia;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja
{
    class RekombinacjaWektoraBinarnego : ARekombinacja
    {
        public RekombinacjaWektoraBinarnego(double pwoMutacji, AOsobnik rozwiazanie) : base(pwoMutacji, rozwiazanie){}

        public override ReprezentacjaRozwiazania Krzyzowanie(ReprezentacjaRozwiazania genotyp1, ReprezentacjaRozwiazania genotyp2)
        {
            ushort[] przodek1 = genotyp1.ZwrocGenotyp1Wymiarowy(),
                     przodek2 = genotyp2.ZwrocGenotyp1Wymiarowy(),
                     dzieciak = new ushort[przodek1.Length];

            int ciecie = losowy.Next(0, przodek1.Length);

            dzieciak = (ushort[])przodek1.Clone();
            for (int i = 0; i < ciecie; i++)
            {
                dzieciak[i] = przodek2[i];
            }

            ReprezentacjaRozwiazania genotypDziecka = new ReprezentacjaRozwiazania(dzieciak);

            if (czySprawdzacOgraniczenia)
            {
                return SprawdzNaruszenieOgraniczen(Mutacja(genotypDziecka));
            }

            return Mutacja(genotypDziecka);
        }

        protected override ReprezentacjaRozwiazania Mutacja(ReprezentacjaRozwiazania genotyp)
        {
            ushort[] geny = genotyp.ZwrocGenotyp1Wymiarowy();
            if (losowy.NextDouble() > pwoMutacji || pwoMutacji == 0)
            {
                return genotyp;
            }

            int bit = losowy.Next(geny.Length);
            geny[bit] = (ushort)((geny[bit] == 0) ? 1 : 0);

            genotyp.ZmienGenotyp(geny);
            return genotyp;
        }

        protected override ReprezentacjaRozwiazania SprawdzNaruszenieOgraniczen(ReprezentacjaRozwiazania genotyp)
        {
            ushort[] geny = genotyp.ZwrocGenotyp1Wymiarowy();
            double[] ograniczenie = rozwiazanie.ZwrocInstancjeProblemu().ZwrocOgraniczeniaProblemu();

            while (rozwiazanie.FunkcjaDopasowania(genotyp)["min"][0] > ograniczenie[0])
            {
                ANaprawaGenotypu naprawaOgraniczen = new KP(geny);
                naprawaOgraniczen.NaprawGeny();
                genotyp.ZmienGenotyp((ushort[])naprawaOgraniczen.ZwrocGeny().Clone());
            }

            return genotyp;
        }
    }
}
