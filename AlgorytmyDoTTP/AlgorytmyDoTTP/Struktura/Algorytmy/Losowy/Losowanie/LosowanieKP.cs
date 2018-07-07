using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie
{
    /// <summary>
    /// Klasa konkretna odpowiedzialna za losowanie rozwiązań pod Problem Plecakowy
    /// </summary>
    class LosowanieKP : ALosowanie
    {
        public LosowanieKP() { }

        public LosowanieKP(AOsobnik osobnik) : base(osobnik) { }

        public override ReprezentacjaRozwiazania[] LosujRozwiazania(ProblemOptymalizacyjny problemOptymalizacyjny, int iloscRozwiazan)
        {
            Random losowy = new Random();
            ReprezentacjaRozwiazania[] rozwiazania = new ReprezentacjaRozwiazania[iloscRozwiazan];
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

                rozwiazania[i] = new ReprezentacjaRozwiazania(elementy);
            }

            return rozwiazania;
        }

        public override ReprezentacjaRozwiazania[] LosujRozwiazania(int iloscRozwiazan, int iloscElementow)
        {
            throw new NotImplementedException();
        }
    }
}
