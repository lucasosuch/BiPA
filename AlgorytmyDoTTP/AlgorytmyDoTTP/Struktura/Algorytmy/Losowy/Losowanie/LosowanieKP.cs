using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie
{
    class LosowanieKP : ILosowanie
    {
        public ArrayList LosujRozwiazania(ProblemOptymalizacyjny problemOptymalizacyjny, int iloscRozwiazan)
        {
            Random losowy = new Random();
            ArrayList rozwiazania = new ArrayList();

            for (int i = 0; i < iloscRozwiazan; i++)
            {
                ushort[] elementy = new ushort[problemOptymalizacyjny.ZwrocDlugoscGenotypu()];
                for (int j = 0; j < problemOptymalizacyjny.ZwrocDlugoscGenotypu(); j++)
                {
                    elementy[j] = (ushort)losowy.Next(2);
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
