using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja.Rozszerzenia;
using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja
{
    class RekombinacjaTSP : ARekombinacja
    {
        public RekombinacjaTSP(double pwoMutacji, AOsobnik rozwiazanie, string rodzajKrzyzowania) : base(pwoMutacji, rozwiazanie, rodzajKrzyzowania){}

        public override ReprezentacjaRozwiazania Krzyzowanie(ReprezentacjaRozwiazania genotyp1, ReprezentacjaRozwiazania genotyp2)
        {
            ushort[] przodek1 = genotyp1.ZwrocGenotyp1Wymiarowy(),
                     przodek2 = genotyp2.ZwrocGenotyp1Wymiarowy(),
                     potomek = new ushort[przodek1.Length];

            switch(rodzajKrzyzowania)
            {
                case "Wymiana podtras":
                    potomek = WymianaPodtras(przodek1, przodek2);
                    break;

                case "PMX":
                    potomek = (ushort[])PMX(przodek1, przodek2).Clone();
                    break;

                case "OX":
                    potomek = (ushort[])OX(przodek1, przodek2).Clone();
                    break;

                case "CX":
                    potomek = (ushort[])CX(przodek1, przodek2).Clone();
                    break;

                default:
                    potomek = NaprzemienneWybieranieKrawedzi(przodek1, przodek2);
                    break;

            }

            ReprezentacjaRozwiazania potomkowyGenotyp = new ReprezentacjaRozwiazania(potomek);
            if (losowy.NextDouble() <= pwoMutacji)
            {
                return Mutacja(potomkowyGenotyp);
            }

            return potomkowyGenotyp;
        }

        protected override ReprezentacjaRozwiazania Mutacja(ReprezentacjaRozwiazania genotyp)
        {
            ushort[] geny = genotyp.ZwrocGenotyp1Wymiarowy();
            int los1 = losowy.Next(0, geny.Length),
                los2 = (los1 + 1 > geny.Length - 1) ? 0 : los1 + 1;
          
            ushort tmp = geny[los1];
            geny[los1] = geny[los2];
            geny[los2] = tmp;

            genotyp.ZmienGenotyp(geny);
            return genotyp;
        }

        private ushort[] NaprzemienneWybieranieKrawedzi(ushort[] przodek1, ushort[] przodek2)
        {
            ushort[] potomek = new ushort[przodek1.Length];

            return potomek;
        }

        private ushort[] WymianaPodtras(ushort[] przodek1, ushort[] przodek2)
        {
            ushort[] potomek = new ushort[przodek1.Length];

            return potomek;
        }

        private ushort[] PMX(ushort[] przodek1, ushort[] przodek2)
        {
            ushort[] potomek = new ushort[przodek1.Length];

            AMetodaKrzyzowania pmx = new PMX(przodek1, przodek2);
            potomek = (ushort[])pmx.ZwrocPotomka().Clone();

            return potomek;
        }

        private ushort[] OX(ushort[] przodek1, ushort[] przodek2)
        {
            ushort[] potomek = new ushort[przodek1.Length];

            AMetodaKrzyzowania ox = new OX(przodek1, przodek2);
            potomek = (ushort[])ox.ZwrocPotomka().Clone();

            return potomek;
        }

        private ushort[] CX(ushort[] przodek1, ushort[] przodek2)
        {
            ushort[] potomek = new ushort[przodek1.Length];

            AMetodaKrzyzowania cx = new CX(przodek1, przodek2);
            potomek = (ushort[])cx.ZwrocPotomka().Clone();

            return potomek;
        }

        protected override ReprezentacjaRozwiazania SprawdzNaruszenieOgraniczen(ReprezentacjaRozwiazania geny)
        {
            throw new NotImplementedException();
        }
    }
}
