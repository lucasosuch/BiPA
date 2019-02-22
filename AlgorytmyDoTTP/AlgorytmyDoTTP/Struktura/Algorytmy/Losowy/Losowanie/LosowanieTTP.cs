using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie
{
    /// <summary>
    /// Klasa konkretna odpowiedzialna za losowanie rozwiązań pod Problem Podróżującego Złodzieja
    /// </summary>
    class LosowanieTTP : ALosowanie
    {
        public LosowanieTTP() { }

        public LosowanieTTP(AOsobnik osobnik) : base(osobnik) { }

        public override ReprezentacjaRozwiazania[] LosujRozwiazania(ProblemOptymalizacyjny problemOptymalizacyjny, int iloscRozwiazan, int iloscElementow)
        {
            Random losowy = new Random();
            ReprezentacjaRozwiazania[] rozwiazania = new ReprezentacjaRozwiazania[iloscRozwiazan];
            
            ushort[][] dostepnoscPrzedmiotow = problemOptymalizacyjny.ZwrocDostepnePrzedmioty();
            LosowanieTSP losowanieTSP = new LosowanieTSP();
            ReprezentacjaRozwiazania[] rozwiazaniaTSP = losowanieTSP.LosujRozwiazania(problemOptymalizacyjny, iloscRozwiazan, problemOptymalizacyjny.ZwrocDlugoscGenotypu());

            for (int i = 0; i < iloscRozwiazan; i++)
            {
                ushort[] wektorTSP = rozwiazaniaTSP[i].ZwrocGenotyp1Wymiarowy();
                ushort[][] macierzTTP = new ushort[wektorTSP.Length][];

                double polowa = (Math.Pow(iloscRozwiazan, 2) / 2),
                       rozpietosc = Math.Abs(Math.Pow(iloscRozwiazan, 2) - (i + losowy.Next(iloscRozwiazan)) * iloscRozwiazan);

                for (int j = 0; j < wektorTSP.Length; j++)
                {
                    int index = wektorTSP[j] - 1,
                        wartosc = (int)Math.Abs(polowa - rozpietosc);
                    double dziesiecProcent = 0.1 * wartosc;

                    macierzTTP[j] = new ushort[dostepnoscPrzedmiotow[0].Length + 1];
                    macierzTTP[j][0] = wektorTSP[j];

                    for (int k = 1; k < macierzTTP[j].Length; k++)
                    {
                        if ((dostepnoscPrzedmiotow[index][(k - 1)] == 1) && j != 0)
                        {
                            if (polowa >= rozpietosc)
                            {
                                macierzTTP[j][k] = (ushort)((wartosc < dziesiecProcent) ? 1 : 0);
                                if(wartosc > 0) wartosc -= losowy.Next(wartosc);
                            }
                            else
                            {
                                macierzTTP[j][k] = (ushort)((wartosc < dziesiecProcent) ? 1 : 0);
                                if (wartosc > 0) wartosc -= (losowy.Next(wartosc) * 2);
                            }
                        }
                        else
                        {
                            macierzTTP[j][k] = 0;
                        }
                    }
                }

                rozwiazania[i] = new ReprezentacjaRozwiazania(macierzTTP);
            }

            return rozwiazania;
        }
    }
}
