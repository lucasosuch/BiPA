using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja.Rozszerzenia;
using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja
{
    class RekombinacjaTSP : ARekombinacja
    {
        private double pwoMutacji;
        private AOsobnik rozwiazanie;
        private String rodzajKrzyzowania;
        private Random losowy = new Random();

        public RekombinacjaTSP(double pwoMutacji, AOsobnik rozwiazanie, String rodzajKrzyzowania)
        {
            this.pwoMutacji = pwoMutacji;
            this.rozwiazanie = rozwiazanie;
            this.rodzajKrzyzowania = rodzajKrzyzowania;
        }

        public override ushort[] Krzyzowanie(ushort[] przodek1, ushort[] przodek2)
        {
            ushort[] potomek = new ushort[przodek1.Length];

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

            if (losowy.NextDouble() <= pwoMutacji)
            {
                return Mutacja(potomek);
            }

            return potomek;
        }

        protected override ushort[] Mutacja(ushort[] geny)
        {
            int los1 = losowy.Next(0, geny.Length),
                los2 = (los1 + 1 > geny.Length - 1) ? 0 : los1 + 1;

            ushort tmp = geny[los1];
            geny[los1] = geny[los2];
            geny[los2] = tmp;

            return geny;
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

            PMX pmx = new PMX(przodek1, przodek2);
            potomek = (ushort[])pmx.ZwrocPotomka().Clone();

            return potomek;
        }

        private ushort[] OX(ushort[] przodek1, ushort[] przodek2)
        {
            ushort[] potomek = new ushort[przodek1.Length];

            OX ox = new OX(przodek1, przodek2);
            potomek = (ushort[])ox.ZwrocPotomka().Clone();

            return potomek;
        }

        private ushort[] CX(ushort[] przodek1, ushort[] przodek2)
        {
            ushort[] potomek = new ushort[przodek1.Length];

            CX cx = new CX(przodek1, przodek2);
            potomek = (ushort[])cx.ZwrocPotomka().Clone();

            return potomek;
        }

        protected override ushort[] SprawdzNaruszenieOgraniczen(ushort[] geny)
        {
            throw new NotImplementedException();
        }
    }
}
