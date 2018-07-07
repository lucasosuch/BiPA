using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik
{
    /// <summary>
    /// Klasa konkretna reprezentująca osobnika Problemu Komiwojażera
    /// </summary>
    class OsobnikTSP : AOsobnik
    {
        public OsobnikTSP(ProblemOptymalizacyjny problemOptymalizacyjny) : base(problemOptymalizacyjny){}
        
        public override IPomocniczy[] Fenotyp(ushort[] genotyp)
        {
            return problemOptymalizacyjny.ZwrocWybraneElementy(genotyp);
        }

        public override Dictionary<string, ushort[][]> Fenotyp(ushort[][] genotyp)
        {
            throw new System.NotImplementedException();
        }

        public override Dictionary<string, double[]> FunkcjaDopasowania(ReprezentacjaRozwiazania reprezentacjaGenotypu)
        {
            return problemOptymalizacyjny.ObliczZysk(Fenotyp(reprezentacjaGenotypu.ZwrocGenotyp1Wymiarowy()));
        }
    }
}
