﻿using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja
{
    /// <summary>
    /// Klasa konkretna odpowiedzialna za wymianę materiału genetycznego pomiędzy osobnikami - rozwiązaniami Problemu Podróżującego Złodzieja
    /// </summary>
    class RekombinacjaTTP : ARekombinacja
    {
        private RekombinacjaTSP rekombinacjaTSP;
        private RekombinacjaKP rekombinacjaKP;

        public RekombinacjaTTP(double pwoMutacji, AOsobnik rozwiazanie, string rodzajKrzyzowania) : base(pwoMutacji, rozwiazanie, rodzajKrzyzowania)
        {
            rekombinacjaTSP = new RekombinacjaTSP(pwoMutacji, rozwiazanie, rodzajKrzyzowania);
            rekombinacjaKP = new RekombinacjaKP(0, rozwiazanie);
            rekombinacjaKP.ZmienSprawdzanieOgraniczen(false);
        }

        public override ReprezentacjaRozwiazania Krzyzowanie(ReprezentacjaRozwiazania genotyp1, ReprezentacjaRozwiazania genotyp2)
        {
            ushort[][] przodek1 = genotyp1.ZwrocGenotyp2Wymiarowy(),
                       przodek2 = genotyp2.ZwrocGenotyp2Wymiarowy(),
                       potomekTTP = new ushort[przodek1.Length][], 
                       przodkowieTSP = new ushort[2][];
            ushort[][][] przodkowieKP = new ushort[przodek1.Length][][];
            
            for (int i = 0; i < przodkowieTSP.Length; i++)
            {
                przodkowieTSP[i] = new ushort[przodek1.Length];
                przodkowieKP[i] = new ushort[przodek1.Length][];

                for (int j = 0; j < przodek1.Length; j++)
                {
                    przodkowieTSP[i][j] = (ushort)(((i == 0) ? przodek1[j][0] : przodek2[j][0]) - 1);
                    przodkowieKP[i][przodkowieTSP[i][j]] = new ushort[przodek1[0].Length - 1];

                    for (int k = 1; k <= przodkowieKP[i][przodkowieTSP[i][j]].Length; k++)
                    {
                        przodkowieKP[i][przodkowieTSP[i][j]][k-1] = (i == 0) ? przodek1[j][k] : przodek2[j][k];
                    }
                }
            }

            ReprezentacjaRozwiazania przodekTSP1 = new ReprezentacjaRozwiazania(przodkowieTSP[0]),
                                     przodekTSP2 = new ReprezentacjaRozwiazania(przodkowieTSP[1]),
                                     genotypPotomkaTSP = rekombinacjaTSP.Krzyzowanie(przodekTSP1, przodekTSP2);

            ushort[] potomekTSP = genotypPotomkaTSP.ZwrocGenotyp1Wymiarowy();
            ushort[][] potomkowieKP = new ushort[przodek1.Length][];

            for (int i = 0; i < przodek1.Length; i++)
            {
                ReprezentacjaRozwiazania przodekKP1 = new ReprezentacjaRozwiazania(przodkowieKP[0][i]),
                                         przodekKP2 = new ReprezentacjaRozwiazania(przodkowieKP[1][i]);
                
                potomkowieKP[i] = new ushort[przodkowieKP[0].Length];
                ReprezentacjaRozwiazania genotypPotomkaKP = rekombinacjaKP.Krzyzowanie(przodekKP1, przodekKP2);
                potomkowieKP[i] = genotypPotomkaKP.ZwrocGenotyp1Wymiarowy();
            }

            ushort[][] dostepnoscPrzedmiotow = rozwiazanie.ZwrocInstancjeProblemu().ZwrocDostepnePrzedmioty();

            for (int i = 0; i < potomekTSP.Length; i++)
            {
                potomekTTP[i] = new ushort[potomkowieKP[0].Length + 1];
                potomekTTP[i][0] = (ushort)(potomekTSP[i] + 1);

                for (int j = 1; j <= potomkowieKP[0].Length; j++)
                {
                    potomekTTP[i][j] = potomkowieKP[potomekTSP[i]][(j - 1)];
                }

                potomekTTP[i] = (ushort[])(Mutacja(potomekTTP[i], dostepnoscPrzedmiotow[potomekTSP[i]]).Clone());
            }

            potomekTTP = (ushort[][])SprawdzNaruszenieOgraniczen(potomekTTP).Clone();
            ReprezentacjaRozwiazania genotypPotomkaTTP = new ReprezentacjaRozwiazania(potomekTTP);

            return genotypPotomkaTTP;
        }

        private ushort[] Mutacja(ushort[] genotyp, ushort[] dostepnoscPrzedmiotow)
        {
            double test = losowy.NextDouble();
            if (test > pwoMutacji) return genotyp;
            
            for(int i = 1; i < genotyp.Length; i++)
            {
                if(dostepnoscPrzedmiotow[i - 1] == 1)
                {
                    genotyp[i] = (ushort)((genotyp[i] == 0) ? 1 : 0);

                    if (losowy.NextDouble() > pwoMutacji) break;
                }
            }
            
            return genotyp;
        }

        private ushort[][] SprawdzNaruszenieOgraniczen(ushort[][] genotyp)
        {
            Dictionary<string, double[]> zysk = rozwiazanie.ZwrocInstancjeProblemu().ObliczZysk(rozwiazanie.ZwrocInstancjeProblemu().ZwrocWybraneElementy(genotyp));

            if (zysk["min"][0] > rozwiazanie.ZwrocInstancjeProblemu().ZwrocOgraniczeniaProblemu()[0])
            {
                while (true)
                {
                    int wspolczynnik = (int)(zysk["min"][0] / rozwiazanie.ZwrocInstancjeProblemu().ZwrocOgraniczeniaProblemu()[0]);

                    for (int i = 0; i < genotyp.Length; i++)
                    {
                        for(int j = 1; j < genotyp[i].Length; j++)
                        {
                            if(genotyp[i][j] == 1)
                            {
                                if(wspolczynnik > 1)
                                {
                                    if (losowy.Next(wspolczynnik) != 0) genotyp[i][j] = 0;
                                } else
                                {
                                    genotyp[i][j] = 0;
                                    break;
                                }
                            }
                        }
                    }

                    zysk = rozwiazanie.ZwrocInstancjeProblemu().ObliczZysk(rozwiazanie.ZwrocInstancjeProblemu().ZwrocWybraneElementy(genotyp));
                    
                    if (zysk["min"][0] <= rozwiazanie.ZwrocInstancjeProblemu().ZwrocOgraniczeniaProblemu()[0]) break;
                }
            }

            return genotyp;
        }

        protected override ReprezentacjaRozwiazania Mutacja(ReprezentacjaRozwiazania geny)
        {
            throw new NotImplementedException();
        }

        protected override ReprezentacjaRozwiazania SprawdzNaruszenieOgraniczen(ReprezentacjaRozwiazania geny)
        {
            throw new NotImplementedException();
        }
    }
}
