using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;
using System.Linq;

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
            int ciecie1 = losowy.Next(0, przodek1.Length),
                ciecie2 = losowy.Next(0, przodek1.Length);

            ushort[] potomek = new ushort[przodek1.Length];

            while (ciecie1 == ciecie2)
            {
                ciecie2 = losowy.Next(0, przodek1.Length);
            }

            int start = (ciecie1 < ciecie2) ? ciecie1 : ciecie2,
                koniec = (ciecie1 < ciecie2) ? ciecie2 : ciecie1;

            potomek = (ushort[])przodek1.Clone();
            for (int i = start; i < koniec; i++)
            {
                potomek[i] = przodek2[i];
            }

            for (int i = 0; i < potomek.Length; i++)
            {
                for (int j = potomek.Length - 1; j > 0; j--)
                {
                    if ((potomek[i] == potomek[j]) && (j != i))
                    {
                        for (int k = 0; k < przodek2.Length; k++)
                        {
                            Boolean zawiera = false;
                            for (int l = 0; l < potomek.Length; l++)
                            {
                                if (przodek2[k] == potomek[l]) zawiera = true;
                            }

                            if (!zawiera) potomek[j] = przodek2[k];
                        }
                    }
                }
            }

            return potomek;
        }

        private ushort[] OX(ushort[] przodek1, ushort[] przodek2)
        {
            int ciecie1 = losowy.Next(0, przodek1.Length),
                ciecie2 = losowy.Next(0, przodek1.Length);

            ushort[] potomek = new ushort[przodek1.Length];

            for (int k = 0; k < potomek.Length; k++)
            {
                potomek[k] = 0;
            }

            while (ciecie1 == ciecie2)
            {
                ciecie2 = losowy.Next(0, przodek1.Length);
            }

            int start = (ciecie1 < ciecie2) ? ciecie1 : ciecie2,
                koniec = (ciecie1 < ciecie2) ? ciecie2 : ciecie1;

            for (int i = start; i <= koniec; i++)
            {
                potomek[i] = przodek1[i];
            }

            for (int i = 0; i < przodek2.Length; i++)
            {
                if (!potomek.Contains(przodek2[i]))
                {
                    for (int j = 0; j < potomek.Length; j++)
                    {
                        if (potomek[j] == 0)
                        {
                            potomek[j] = przodek2[i];
                            break;
                        }
                    }
                }
            }

            return potomek;
        }

        private ushort[] CX(ushort[] przodek1, ushort[] przodek2)
        {
            ushort i = 0;
            ushort[] potomek = new ushort[przodek1.Length];

            for (int k = 0; k < potomek.Length; k++)
            {
                potomek[k] = 0;
            }

            while (!potomek.Contains(przodek2[i]))
            {
                ushort j = (ushort)(przodek2[i] - 1);
                potomek[j] = przodek1[j];
                i = j;
            }

            for (int k = 0; k < potomek.Length; k++)
            {
                if (potomek[k] == 0)
                {
                    potomek[k] = przodek2[k];
                }
            }

            return potomek;
        }

        protected override ReprezentacjaRozwiazania SprawdzNaruszenieOgraniczen(ReprezentacjaRozwiazania geny)
        {
            throw new NotImplementedException();
        }
    }
}
