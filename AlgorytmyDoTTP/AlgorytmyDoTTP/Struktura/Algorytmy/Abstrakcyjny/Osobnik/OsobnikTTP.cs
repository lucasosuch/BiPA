using BiPA.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections.Generic;

namespace BiPA.Struktura.Algorytmy.Abstrakcyjny.Osobnik
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

            // przechodząc po całej macierzy
            for(int i = 0; i < genotyp.Length; i++)
            {
                // w pierwszej kolejności wypisujemy numer miasta
                wynik += Environment.NewLine + " - Miasto " + genotyp[i][0] +", przedmioty: ";

                bool brakPrzedmiotow = true;
                for(int j = 1; j < genotyp[i].Length; j++)
                {
                    // jeżeli zebraliśmy przedmioty z danego miasta to
                    if(genotyp[i][j] == 1)
                    {
                        wynik += (j + " "); // wypisujemy je po spacji, przy danym mieście
                        if (brakPrzedmiotow) brakPrzedmiotow = false;
                    }
                }

                // w innym wypadku wypisujemy, ze nie pobieramy przedmiotów z `i-tego` miasta
                if (brakPrzedmiotow) wynik += "brak";
            }

            return wynik;
        }

        public override Dictionary<string, ushort[][]> Fenotyp(ushort[][] genotyp)
        {
            return problemOptymalizacyjny.ZwrocWybraneElementy(genotyp);
        }

        public override IElement[] Fenotyp(ushort[] genotyp)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, float[]> FunkcjaDopasowania(ReprezentacjaRozwiazania reprezentacjaGenotypu)
        {
            return problemOptymalizacyjny.ObliczZysk(Fenotyp(reprezentacjaGenotypu.ZwrocGenotyp2Wymiarowy()));
        }
    }
}
