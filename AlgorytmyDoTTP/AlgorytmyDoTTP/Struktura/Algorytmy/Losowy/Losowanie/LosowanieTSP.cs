using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie
{
    class LosowanieTSP : ALosowanie
    {
        public LosowanieTSP(int iloscRozwiazan, int iloscElementow, int maxAllel) : base(iloscRozwiazan, iloscElementow, maxAllel){}

        public override ArrayList LosujRozwiazania()
        {
            double zroznicowaniePopulacji = 0.7;
            ArrayList rozwiazania = new ArrayList();

            for (int i = 0; i < iloscRozwiazan; i++)
            {
                ushort[] genotyp = new ushort[iloscElementow];

                if (losowy.NextDouble() < zroznicowaniePopulacji)
                {
                    ArrayList wykorzystane = new ArrayList();

                    for (int j = 0; j < iloscElementow; j++)
                    {
                        while (true)
                        {
                            int wynik = (ushort)losowy.Next(1, iloscElementow + 1);

                            if (wykorzystane.IndexOf(wynik) == -1)
                            {
                                wykorzystane.Add(wynik);
                                genotyp[j] = (ushort)wynik;
                                break;
                            }
                        }
                    }

                    wykorzystane.Clear();
                }
                else
                {
                    for (int j = 0; j < iloscElementow; j++)
                    {
                        genotyp[j] = (ushort)(j + 1);
                    }
                }

                rozwiazania.Add(new ReprezentacjaRozwiazania(genotyp));
            }

            return rozwiazania;
        }
    }
}
