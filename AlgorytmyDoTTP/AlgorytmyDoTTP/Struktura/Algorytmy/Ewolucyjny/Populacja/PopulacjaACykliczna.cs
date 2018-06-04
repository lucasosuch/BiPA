using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Genotyp;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    class PopulacjaACykliczna : APopulacja
    {
        public PopulacjaACykliczna(ushort rozmiarPopulacji, ushort dlugoscGenotypu) : base(rozmiarPopulacji, dlugoscGenotypu) { }

        public PopulacjaACykliczna(ushort rozmiarPopulacji, ushort dlugoscGenotypu, ushort maxAllel) : base(rozmiarPopulacji, dlugoscGenotypu, maxAllel) { }

        public override ArrayList StworzPopulacjeBazowa()
        {
            for (int i = 0; i < rozmiarPopulacji; i++)
            {
                ushort[] genotyp = new ushort[dlugoscGenotypu];
                for (int j = 0; j < dlugoscGenotypu; j++)
                {
                    genotyp[j] = (ushort)losowy.Next(maxAllel);
                }

                populacja.Add(new ReprezentacjaGenotypu(genotyp));
            }

            return populacja;
        }
    }
}
