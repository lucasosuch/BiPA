using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja
{
    class RekombinacjaTTP : ARekombinacja
    {
        private RekombinacjaTSP rekombinacjaTSP;
        private RekombinacjaWektoraBinarnego rekombinacjaKP;

        public RekombinacjaTTP(double pwoMutacji, AOsobnik rozwiazanie, string rodzajKrzyzowania) : base(pwoMutacji, rozwiazanie, rodzajKrzyzowania)
        {
            rekombinacjaKP = new RekombinacjaWektoraBinarnego(0, rozwiazanie);
            rekombinacjaTSP = new RekombinacjaTSP(pwoMutacji, rozwiazanie, rodzajKrzyzowania);
        }

        public override ushort[][] Krzyzowanie(ushort[][] przodek1, ushort[][] przodek2)
        {
            ushort[][] potomekTTP = new ushort[przodek1.Length][], 
                       przodkowieTSP = new ushort[2][];
            ushort[][][] przodkowieKP = new ushort[przodek1.Length][][];

            for(int i = 0; i < przodkowieTSP.Length; i++)
            {
                przodkowieTSP[i] = new ushort[przodek1.Length];

                for(int j = 0; j < przodek1.Length; j++)
                {
                    przodkowieTSP[i][j] = (i == 0) ? przodek1[j][0] : przodek2[j][0];

                    przodkowieKP[i][przodkowieTSP[i][j]] = new ushort[przodek1[0].Length - 1];
                    if (j > 0)
                    {
                        for (int k = 0; k < przodek1[j].Length; k++)
                        {
                            przodkowieKP[i][przodkowieTSP[i][j]][k] = przodek1[j][k];
                        }
                    }
                }
            }

            ushort[] potomekTSP = (ushort[])(rekombinacjaTSP.Krzyzowanie(przodkowieTSP[0], przodkowieTSP[1]).Clone());
            ushort[][] potomkowieKP = new ushort[przodek1.Length][];

            for(int i = 0; i < przodek1.Length; i++)
            {
                potomkowieKP[i] = new ushort[przodkowieKP[0].Length];
                potomkowieKP[i] = rekombinacjaKP.Krzyzowanie(przodkowieKP[0][i], przodkowieKP[1][i]);
            }

            for (int i = 0; i < potomekTSP.Length; i++)
            {
                potomekTTP[i] = new ushort[potomkowieKP[0].Length + 1];
                potomekTTP[i][0] = potomekTSP[i];

                for(int j = 1; j <= potomkowieKP[0].Length; j++)
                {
                    potomekTTP[i][j] = potomkowieKP[i][(j - 1)];
                }
            }

            return potomekTTP;
        }

        protected override ushort[][] Mutacja(ushort[][] geny)
        {
            throw new NotImplementedException();
        }

        public override ushort[] Krzyzowanie(ushort[] przodek1, ushort[] przodek2)
        {
            throw new NotImplementedException();
        }

        protected override ushort[] Mutacja(ushort[] geny)
        {
            throw new NotImplementedException();
        }

        protected override ushort[] SprawdzNaruszenieOgraniczen(ushort[] geny)
        {
            throw new NotImplementedException();
        }
    }
}
