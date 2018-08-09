using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik
{
    /// <summary>
    /// Klasa konkretna reprezentująca osobnika Problemu Podróżującego Złodzieja
    /// </summary>
    class OsobnikTTP : AOsobnik
    {
        public OsobnikTTP(ProblemOptymalizacyjny problemOptymalizacyjny) : base(problemOptymalizacyjny){}

        public override string DekodujRozwiazanie(ReprezentacjaRozwiazania reprezentacjaGenotypu)
        {
            string wynik = "";
            ushort[][] genotyp = reprezentacjaGenotypu.ZwrocGenotyp2Wymiarowy();

            for(int i = 0; i < genotyp.Length; i++)
            {
                wynik += Environment.NewLine + " - Miasto " + genotyp[i][0] +", przedmioty: ";

                bool brakPrzedmiotow = true;
                for(int j = 1; j < genotyp[i].Length; j++)
                {
                    if(genotyp[i][j] == 1)
                    {
                        wynik += (j + " ");
                        if (brakPrzedmiotow) brakPrzedmiotow = false;
                    }
                }

                if (brakPrzedmiotow) wynik += "brak";
            }

            return wynik;
        }

        public override Dictionary<string, ushort[][]> Fenotyp(ushort[][] genotyp)
        {
            return problemOptymalizacyjny.ZwrocWybraneElementy(genotyp);
        }

        public override IPomocniczy[] Fenotyp(ushort[] genotyp)
        {
            throw new System.NotImplementedException();
        }

        public override Dictionary<string, double[]> FunkcjaDopasowania(ReprezentacjaRozwiazania reprezentacjaGenotypu)
        {
            return problemOptymalizacyjny.ObliczZysk(Fenotyp(reprezentacjaGenotypu.ZwrocGenotyp2Wymiarowy()));
        }
    }
}
