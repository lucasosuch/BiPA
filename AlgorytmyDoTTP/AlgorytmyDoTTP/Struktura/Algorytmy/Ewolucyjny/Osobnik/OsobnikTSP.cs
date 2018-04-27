using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TSP;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik
{
    class OsobnikTSP : AOsobnik
    {
        public OsobnikTSP(ProblemKomiwojazera problemKomiwojazera)
        {
            problemOptymalizacyjny = problemKomiwojazera;
        }

        public override ArrayList Fenotyp(ushort[] genotyp)
        {
            ArrayList wynik = new ArrayList();
            wynik.AddRange(genotyp);

            return wynik;
        }

        public override Dictionary<String, double[]> FunkcjaDopasowania(ushort[] genotyp)
        {
            return problemOptymalizacyjny.ObliczZysk(Fenotyp(genotyp));
        }
    }
}
