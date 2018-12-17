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
        public WspinaczkaTSP(ALosowanie losowanie, int parametrP) : base(losowanie, parametrP) { }

        public override void ZnajdzOptimum()
        {
            int poprawy = 0;
            ushort[] genotyp = reprezentacjaRozwiazania.ZwrocGenotyp1Wymiarowy(),
                     tmpGenotyp = (ushort[])genotyp.Clone();

            AOsobnik osobnik = losowanie.ZwrocOsobnika();
            ProblemOptymalizacyjny problemOptymalizacyjny = osobnik.ZwrocInstancjeProblemu();
            Dictionary<string, float[]> wynik = osobnik.FunkcjaDopasowania(reprezentacjaRozwiazania);
            ReprezentacjaRozwiazania tmpReprezentacjaRozwiazanie = new ReprezentacjaRozwiazania(tmpGenotyp);

            do
            {
                int start = 1,
                    koniec = problemOptymalizacyjny.ZwrocDlugoscGenotypu() - 1;

                poprawy = 0;
                for (int i = start; i < koniec; i++)
                {
                    int liczba1 = losowy.Next(2, problemOptymalizacyjny.ZwrocDlugoscGenotypu()),
                        liczba2 = losowy.Next(2, problemOptymalizacyjny.ZwrocDlugoscGenotypu());

                    ushort tmpWartosc = tmpGenotyp[liczba1];
                    tmpGenotyp[liczba1] = tmpGenotyp[liczba2];
                    tmpGenotyp[liczba2] = tmpWartosc;

                    tmpReprezentacjaRozwiazanie.ZmienGenotyp(tmpGenotyp);

                    Dictionary<string, float[]> tmpWynik = osobnik.FunkcjaDopasowania(tmpReprezentacjaRozwiazanie);

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
        }
    }
}
