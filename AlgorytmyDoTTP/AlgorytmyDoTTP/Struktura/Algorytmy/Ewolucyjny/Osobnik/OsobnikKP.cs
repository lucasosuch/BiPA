using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik
{
    class OsobnikKP : AOsobnik
    {
        private ProblemPlecakowy problemPlecakowy;

        public OsobnikKP(ProblemPlecakowy problemPlecakowy)
        {
            this.problemPlecakowy = problemPlecakowy;
        }

        public override ArrayList Fenotyp(ushort[] genotyp)
        {
            return problemPlecakowy.ZwrocWybraneElementy(genotyp);
        }

        public override double[] FunkcjaDopasowania(ushort[] genotyp)
        {
            return problemPlecakowy.ObliczZysk(Fenotyp((genotyp)));
        }

        public ProblemPlecakowy ZwrocProblemPlecakowy()
        {
            return problemPlecakowy;
        }
    }
}
