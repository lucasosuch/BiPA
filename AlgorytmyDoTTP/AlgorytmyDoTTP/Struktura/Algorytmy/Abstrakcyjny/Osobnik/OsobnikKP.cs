using BiPA.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections.Generic;

namespace BiPA.Struktura.Algorytmy.Abstrakcyjny.Osobnik
{
    /// <summary>
    /// Klasa konkretna reprezentująca osobnika Problemu Plecakowego
    /// </summary>
    class OsobnikKP : AOsobnik
    {
        public OsobnikKP(ProblemOptymalizacyjny problemOptymalizacyjny) : base(problemOptymalizacyjny){}

        public override string DekodujRozwiazanie(ReprezentacjaRozwiazania reprezentacjaGenotypu)
        {
            string wynik = "";
            ushort[] genotyp = reprezentacjaGenotypu.ZwrocGenotyp1Wymiarowy();

            // każdy z wybranych przedmiotów jest zapisywany w rozwiązaniu po spacji
            for(int i = 1; i <= genotyp.Length; i++)
            {
                // tylko wybrane przedmioty
                if (genotyp[i-1] == 1) wynik += (i +" ");
            }

            return wynik;
        }

        public override IElement[] Fenotyp(ushort[] genotyp)
        {
            return problemOptymalizacyjny.ZwrocWybraneElementy(genotyp);
        }

        public override Dictionary<string, ushort[][]> Fenotyp(ushort[][] genotyp)
        {
            throw new System.NotImplementedException();
        }

        public override Dictionary<string, float[]> FunkcjaDopasowania(ReprezentacjaRozwiazania reprezentacjaGenotypu)
        {
            return problemOptymalizacyjny.ObliczZysk(Fenotyp(reprezentacjaGenotypu.ZwrocGenotyp1Wymiarowy()));
        }
    }
}
