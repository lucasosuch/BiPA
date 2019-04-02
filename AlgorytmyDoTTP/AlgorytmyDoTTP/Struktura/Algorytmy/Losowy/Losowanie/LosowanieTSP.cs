using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie
{
    /// <summary>
    /// Klasa konkretna odpowiedzialna za losowanie rozwiązań pod Problem Komiwojażera
    /// </summary>
    class LosowanieTSP : ALosowanie
    {
        public LosowanieTSP() { }

        public LosowanieTSP(AOsobnik osobnik) : base(osobnik) { }

        public override ReprezentacjaRozwiazania[] LosujRozwiazania(ProblemOptymalizacyjny problemOptymalizacyjny, int iloscRozwiazan, int iloscElementow)
        {
            Random losowy = new Random();
            ReprezentacjaRozwiazania[] rozwiazania = new ReprezentacjaRozwiazania[iloscRozwiazan];

            int losoweElementy = 0,
                zroznicowaniePopulacji = (int)(0.1 * iloscRozwiazan);

            for (int i = 0; i < iloscRozwiazan; i++)
            {
                ushort[] genotyp = new ushort[iloscElementow + 1];

                genotyp[0] = 1;
                if ((losoweElementy > zroznicowaniePopulacji) && (losowy.Next(100) > 50))
                {
                    ArrayList wykorzystane = new ArrayList();
                    wykorzystane.Add(1);
                    for (int j = 1; j < iloscElementow; j++)
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

                    losoweElementy++;
                    wykorzystane.Clear();
                }
                else
                {
                    for (int j = 1; j < iloscElementow; j++)
                    {
                        genotyp[j] = (ushort)(j + 1);
                    }

                    losoweElementy++;
                }

                genotyp[iloscElementow] = 1;
                rozwiazania[i] = new ReprezentacjaRozwiazania(genotyp);
            }

            return rozwiazania;
        }
    }
}
