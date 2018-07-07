using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Wspinaczka
{
    /// <summary>
    /// Klasa konkretna reprezentująca rozwiązanie dla Algorytmu Wspinaczkowego pod Problem Podróżującego Złodzieja
    /// </summary>
    class WspinaczkaTTP : AWspinaczka
    {
        public WspinaczkaTTP(ALosowanie losowanie) : base(losowanie) { }

        public override Dictionary<string, double[]> ZnajdzOptimum()
        {
            int poprawy = 0;
            ushort[] genotyp = reprezentacjaRozwiazania.ZwrocGenotyp1Wymiarowy(),
                     tmpGenotyp = (ushort[])genotyp.Clone();

            AOsobnik osobnik = losowanie.ZwrocOsobnika();
            ProblemOptymalizacyjny problemOptymalizacyjny = osobnik.ZwrocInstancjeProblemu();
            Dictionary<string, double[]> wynik = osobnik.FunkcjaDopasowania(reprezentacjaRozwiazania);
            ReprezentacjaRozwiazania tmpReprezentacjaRozwiazanie = new ReprezentacjaRozwiazania(tmpGenotyp);
            ushort[][] dostepnePrzedmioty = (ushort[][])problemOptymalizacyjny.ZwrocDostepnePrzedmioty().Clone();

            do
            {
                poprawy = 0;
                double wspolczynnik = wynik["min"][0] / problemOptymalizacyjny.ZwrocOgraniczeniaProblemu()[0];

                // problem plecakowy
                for(int i = 0; i < tmpRozwiazanie.Length; i++)
                {
                    for(int j = 1; j < tmpRozwiazanie[i].Length; j++)
                    {
                        if(dostepnePrzedmioty[i][j - 1] == 1)
                        {
                            if(wspolczynnik < 1)
                            {
                                tmpRozwiazanie[i][j] = 1;
                            } else
                            {
                                tmpRozwiazanie[i][j] = 0;
                            }

                            tmpWynik = problemOptymalizacyjny.ObliczZysk(problemOptymalizacyjny.ZwrocWybraneElementy(tmpRozwiazanie));
                            wspolczynnik = tmpWynik["min"][0] / problemOptymalizacyjny.ZwrocOgraniczeniaProblemu()[0];
                        }
                    }
                }

                // problem komiwojażera
                for (int i = 0; i < tmpRozwiazanie.Length; i++)
                {
                    int los = losowy.Next(tmpRozwiazanie.Length);

                    ushort[] tmp = tmpRozwiazanie[i];
                    tmpRozwiazanie[i] = tmpRozwiazanie[los];
                    tmpRozwiazanie[los] = tmp;
                }

                tmpWynik = problem.ObliczZysk(problem.ZwrocWybraneElementy(tmpRozwiazanie));

                if(tmpWynik["min"][0] > problem.ZwrocOgraniczeniaProblemu()[0])
                {
                    tmpRozwiazanie = (ushort[][])rozwiazanie.Clone();
                    poprawy++;
                } else
                {
                    if (tmpWynik["max"][0] > wynik["max"][0]) {
                        wynik = tmpWynik;
                        rozwiazanie = (ushort[][])tmpRozwiazanie.Clone();
                        poprawy++;
                    }
                }

            } while (poprawy > 0);

            return wynik;
        }
    }
}
