using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie
{
    class LosowanieKP : ILosowanie
    {
        public ArrayList LosujRozwiazania(int iloscRozwiazan, int iloscElementow)
        {
            Random losowy = new Random();
            ArrayList rozwiazania = new ArrayList();

            for (int i = 0; i < iloscRozwiazan; i++)
            {
                ushort[] elementy = new ushort[iloscElementow];
                for (int j = 0; j < iloscElementow; j++)
                {
                    elementy[j] = (ushort)losowy.Next(2);
                }

                rozwiazania.Add(new ReprezentacjaRozwiazania(elementy));
            }

            return rozwiazania;
        }

        public ArrayList LosujRozwiazania(int iloscRozwiazan, int iloscElementow, int maxAllel)
        {
            throw new NotImplementedException();
        }

        public ArrayList LosujRozwiazania(int iloscRozwiazan, int iloscElementow, int maxAllel, ushort[][] dostepnoscPrzedmiotow)
        {
            throw new NotImplementedException();
        }
    }
}
