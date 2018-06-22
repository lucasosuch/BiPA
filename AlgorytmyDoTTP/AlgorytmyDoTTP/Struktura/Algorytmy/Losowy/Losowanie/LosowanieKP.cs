using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie
{
    class LosowanieKP : ILosowanie
    {
        public ArrayList LosujRozwiazania(ProblemOptymalizacyjny problemOptymalizacyjny, int iloscRozwiazan)
        {
            Random losowy = new Random();
            ArrayList rozwiazania = new ArrayList();
            int iloscElementow = problemOptymalizacyjny.ZwrocDlugoscGenotypu();
            double[] ograniczeniaProblemu = problemOptymalizacyjny.ZwrocOgraniczeniaProblemu();

            for (int i = 0; i < iloscRozwiazan; i++)
            {
                ushort[] elementy = new ushort[iloscElementow];
                
                for (int j = 0; j < iloscElementow; j++)
                {
                    elementy[j] = (ushort)losowy.Next(2);
                    Dictionary<string, double[]> zysk = problemOptymalizacyjny.ObliczZysk(problemOptymalizacyjny.ZwrocWybraneElementy(elementy));

                    if (zysk["min"][0] > ograniczeniaProblemu[0]) elementy[j] = 0;
                }

                rozwiazania.Add(new ReprezentacjaRozwiazania(elementy));
            }

            return rozwiazania;
        }

        public ArrayList LosujRozwiazania(int iloscRozwiazan, int iloscElementow)
        {
            throw new NotImplementedException();
        }
    }
}
