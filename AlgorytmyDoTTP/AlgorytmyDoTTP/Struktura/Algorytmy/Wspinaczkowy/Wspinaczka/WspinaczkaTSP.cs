using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Wspinaczka
{
    /// <summary>
    /// Klasa konkretna reprezentująca rozwiązanie dla Algorytmu Wspinaczkowego pod Problem Komiwojażera
    /// </summary>
    class WspinaczkaTSP : AWspinaczka
    {
        public WspinaczkaTSP(ALosowanie losowanie) : base(losowanie) { }

        public override Dictionary<string, double[]> ZnajdzOptimum()
        {
            int poprawy = 0;
            ushort[] genotyp = reprezentacjaRozwiazania.ZwrocGenotyp1Wymiarowy(),
                     tmpGenotyp = (ushort[])genotyp.Clone();

            AOsobnik osobnik = losowanie.ZwrocOsobnika();
            ProblemOptymalizacyjny problemOptymalizacyjny = osobnik.ZwrocInstancjeProblemu();
            Dictionary<string, double[]> wynik = osobnik.FunkcjaDopasowania(reprezentacjaRozwiazania);
            ReprezentacjaRozwiazania tmpReprezentacjaRozwiazanie = new ReprezentacjaRozwiazania(tmpGenotyp);

            do
            {
                int start = 0,
                    koniec = problemOptymalizacyjny.ZwrocDlugoscGenotypu() / 2;

                poprawy = 0;
                for (int i = start; i < koniec; i++)
                {
                    int liczba1 = losowy.Next(problemOptymalizacyjny.ZwrocDlugoscGenotypu()),
                        liczba2 = losowy.Next(problemOptymalizacyjny.ZwrocDlugoscGenotypu());

                    ushort tmpWartosc = tmpGenotyp[liczba1];
                    tmpGenotyp[liczba1] = tmpGenotyp[liczba2];
                    tmpGenotyp[liczba2] = tmpWartosc;

                    tmpReprezentacjaRozwiazanie.ZmienGenotyp(tmpGenotyp);

                    Dictionary<string, double[]> tmpWynik = osobnik.FunkcjaDopasowania(tmpReprezentacjaRozwiazanie);

                    if (tmpWynik["max"][0] > wynik["max"][0])
                    {
                        if (problemOptymalizacyjny.CzyIstniejaOgraniczenia() && (tmpWynik["min"][0] > problemOptymalizacyjny.ZwrocOgraniczeniaProblemu()[0])) continue;

                        genotyp = (ushort[])tmpGenotyp.Clone();
                        reprezentacjaRozwiazania.ZmienGenotyp(genotyp);

                        wynik["max"][0] = tmpWynik["max"][0];
                        wynik["min"][0] = tmpWynik["min"][0];
                        poprawy++;
                    }
                    else
                    {
                        tmpGenotyp = (ushort[])genotyp.Clone();
                        tmpReprezentacjaRozwiazanie.ZmienGenotyp(genotyp);
                    }
                }
            } while (poprawy > 0);

            return wynik;
        }
    }
}
