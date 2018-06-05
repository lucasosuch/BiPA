using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie
{
    class LosowanieTTP : ALosowanie
    {
        private ushort[][] dostepnoscPrzedmiotow;
        private LosowanieTSP losowanieTSP;

        public LosowanieTTP(int iloscRozwiazan, int iloscElementow, int maxAllel, ushort[][] dostepnoscPrzedmiotow) : base(iloscRozwiazan, iloscElementow, maxAllel)
        {
            this.dostepnoscPrzedmiotow = dostepnoscPrzedmiotow;
            losowanieTSP = new LosowanieTSP(iloscRozwiazan, iloscElementow, maxAllel);
        }

        public override ArrayList LosujRozwiazania()
        {
            ArrayList rozwiazania = new ArrayList();
            ArrayList rozwiazaniaTSP = losowanieTSP.LosujRozwiazania();

            for (int i = 0; i < iloscRozwiazan; i++)
            {
                ushort[] wektorTSP = ((ReprezentacjaRozwiazania)rozwiazaniaTSP[i]).ZwrocGenotyp1Wymiarowy();
                ushort[][] macierzTTP = new ushort[wektorTSP.Length][];

                for (int j = 0; j < wektorTSP.Length; j++)
                {
                    int index = wektorTSP[j] - 1;

                    macierzTTP[index] = new ushort[dostepnoscPrzedmiotow[0].Length + 1];
                    macierzTTP[index][0] = wektorTSP[j];

                    for (int k = 1; k < macierzTTP[index].Length; k++)
                    {
                        if (dostepnoscPrzedmiotow[index][(k - 1)] == 1)
                        {
                            macierzTTP[index][k] = (ushort)losowy.Next(2);
                        }
                        else
                        {
                            macierzTTP[index][k] = 0;
                        }
                    }
                }

                rozwiazania.Add(new ReprezentacjaRozwiazania(macierzTTP));
            }

            return rozwiazania;
        }
    }
}
