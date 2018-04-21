using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TSP;
using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik
{
    class OsobnikTSP : AOsobnik
    {
        private ProblemKomiwojazera problemKomiwojazera;

        public OsobnikTSP(ProblemKomiwojazera problemKomiwojazera)
        {
            this.problemKomiwojazera = problemKomiwojazera;
        }

        public override ArrayList Fenotyp(ushort[] genotyp)
        {
            ArrayList wynik = new ArrayList();
            wynik.AddRange(genotyp);

            return wynik;
        }

        public override double[] FunkcjaDopasowania(ushort[] genotyp)
        {
            return problemKomiwojazera.ObliczZysk(Fenotyp(genotyp));
        }
    }
}
