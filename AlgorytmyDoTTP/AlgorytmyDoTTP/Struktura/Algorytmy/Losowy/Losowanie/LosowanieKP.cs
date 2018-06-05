using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie
{
    class LosowanieKP : ALosowanie
    {
        public LosowanieKP(int iloscRozwiazan, int iloscElementow, int maxAllel) : base(iloscRozwiazan, iloscElementow, maxAllel){}

        public override ArrayList LosujRozwiazania()
        {
            ArrayList rozwiazania = new ArrayList();

            for (int i = 0; i < iloscRozwiazan; i++)
            {
                ushort[] elementy = new ushort[iloscElementow];
                for (int j = 0; j < iloscElementow; j++)
                {
                    elementy[j] = (ushort)losowy.Next(maxAllel);
                }

                rozwiazania.Add(new ReprezentacjaRozwiazania(elementy));
            }

            return rozwiazania;
        }
    }
}
