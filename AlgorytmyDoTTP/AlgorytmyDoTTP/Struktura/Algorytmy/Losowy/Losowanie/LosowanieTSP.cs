using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie
{
    /// <summary>
    /// Klasa konkretna odpowiedzialna za losowanie rozwiązań pod Problem Komiwojażera
    /// </summary>
    class LosowanieTSP : ILosowanie
    {
        public ReprezentacjaRozwiazania[] LosujRozwiazania(int iloscRozwiazan, int iloscElementow)
        {
            Random losowy = new Random();
            double zroznicowaniePopulacji = 0.5;
            ReprezentacjaRozwiazania[] rozwiazania = new ReprezentacjaRozwiazania[iloscRozwiazan];

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

                rozwiazania[i] = new ReprezentacjaRozwiazania(genotyp);
            }

            return rozwiazania;
        }

        public ReprezentacjaRozwiazania[] LosujRozwiazania(ProblemOptymalizacyjny problemOptymalizacyjny, int iloscRozwiazan)
        {
            throw new NotImplementedException();
        }
    }
}
