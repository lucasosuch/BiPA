﻿using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik
{
    class OsobnikTTP : AOsobnik
    {
        public OsobnikTTP(ProblemOptymalizacyjny problemOptymalizacyjny) : base(problemOptymalizacyjny){}

        public override Dictionary<string, ushort[]> Fenotyp(ushort[][] genotyp)
        {
            return problemOptymalizacyjny.ZwrocWybraneElementy(genotyp);
        }

        public override ArrayList Fenotyp(ushort[] genotyp)
        {
            throw new NotImplementedException();
        }
    }
}
