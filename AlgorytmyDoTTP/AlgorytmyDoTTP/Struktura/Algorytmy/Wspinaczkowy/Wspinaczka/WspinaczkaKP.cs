using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Wspinaczka
{
    /// <summary>
    /// Klasa konkretna reprezentująca rozwiązanie dla Algorytmu Wspinaczkowego pod Problem Plecakowy
    /// </summary>
    class WspinaczkaKP : AWspinaczka
    {
        public WspinaczkaKP(ALosowanie losowanie, int parametrP) : base(losowanie, parametrP) {}

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
                poprawy = 0;
                int wartosc1 = losowy.Next(problemOptymalizacyjny.ZwrocDlugoscGenotypu() / 2),
                    wartosc2 = losowy.Next(problemOptymalizacyjny.ZwrocDlugoscGenotypu()),
                    start = (wartosc1 > wartosc2) ? wartosc2 : wartosc1,
                    koniec = (wartosc1 > wartosc2) ? wartosc1 : wartosc2;

                for (int i = start; i < koniec; i++)
                {
                    tmpGenotyp[i] = (ushort)((tmpGenotyp[i] == 0) ? 1 : 0);
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