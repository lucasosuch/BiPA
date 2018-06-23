using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie
{
    class LosowanieTTP : ILosowanie
    {
        public ArrayList LosujRozwiazania(ProblemOptymalizacyjny problemOptymalizacyjny, int iloscRozwiazan)
        {
            Random losowy = new Random();
            ArrayList rozwiazania = new ArrayList();
            
            ushort[][] dostepnoscPrzedmiotow = problemOptymalizacyjny.ZwrocDostepnePrzedmioty();
            LosowanieTSP losowanieTSP = new LosowanieTSP();
            ArrayList rozwiazaniaTSP = losowanieTSP.LosujRozwiazania(iloscRozwiazan, problemOptymalizacyjny.ZwrocDlugoscGenotypu());

            for (int i = 0; i < iloscRozwiazan; i++)
            {
                ushort[] wektorTSP = ((ReprezentacjaRozwiazania)rozwiazaniaTSP[i]).ZwrocGenotyp1Wymiarowy();
                ushort[][] macierzTTP = new ushort[wektorTSP.Length][];

                double rozpietosc = Math.Abs(100 - i * 100 / iloscRozwiazan);

                for (int j = 0; j < wektorTSP.Length; j++)
                {
                    int index = wektorTSP[j] - 1;

                    macierzTTP[index] = new ushort[dostepnoscPrzedmiotow[0].Length + 1];
                    macierzTTP[index][0] = wektorTSP[j];
                    
                    for (int k = 1; k < macierzTTP[index].Length; k++)
                    {
                        if (dostepnoscPrzedmiotow[index][(k - 1)] == 1)
                        {
                            if (losowy.Next(100) > rozpietosc) macierzTTP[index][k] = (ushort)losowy.Next(2);
                            else macierzTTP[index][k] = 0;
                        }
                        else
                        {
                            macierzTTP[index][k] = 0;
                        }
                    }
                }

                Dictionary<string, double[]> zysk = problemOptymalizacyjny.ObliczZysk(problemOptymalizacyjny.ZwrocWybraneElementy(macierzTTP));

                rozwiazania.Add(new ReprezentacjaRozwiazania(macierzTTP));
            }

            return rozwiazania;
        }

        public ArrayList LosujRozwiazania(int iloscRozwiazan, int iloscElementow)
        {
            throw new NotImplementedException();
        }
    }
}
