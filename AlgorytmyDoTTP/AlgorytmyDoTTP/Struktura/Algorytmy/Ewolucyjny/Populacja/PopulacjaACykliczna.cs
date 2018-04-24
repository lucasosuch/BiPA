using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    class PopulacjaACykliczna : APopulacja
    {
        public PopulacjaACykliczna(ushort rozmiarPopulacji, ushort dlugoscGenotypu)
        {
            maxAllel = 2;
            this.dlugoscGenotypu = dlugoscGenotypu;
            this.rozmiarPopulacji = rozmiarPopulacji;
        }

        public PopulacjaACykliczna(ushort rozmiarPopulacji, ushort dlugoscGenotypu, ushort maxAllel)
        {
            this.maxAllel = maxAllel;
            this.dlugoscGenotypu = dlugoscGenotypu;
            this.rozmiarPopulacji = rozmiarPopulacji;
        }

        public override ArrayList StworzPopulacjeBazowa()
        {
            for (int i = 0; i < rozmiarPopulacji; i++)
            {
                ushort[] genotyp = new ushort[dlugoscGenotypu];
                for (int j = 0; j < dlugoscGenotypu; j++)
                {
                    genotyp[j] = (ushort)losowy.Next(maxAllel);
                }

                populacja.Add(genotyp);
            }

            return populacja;
        }
    }
}
