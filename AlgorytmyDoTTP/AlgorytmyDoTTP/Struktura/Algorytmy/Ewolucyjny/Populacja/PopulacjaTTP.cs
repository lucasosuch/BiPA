using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Genotyp;
using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    class PopulacjaTTP : APopulacja
    {
        private ushort[][] dostepnoscPrzedmiotow;
        private PopulacjaCykliczna populacjaCykliczna;

        public PopulacjaTTP(ushort rozmiarPopulacji, ushort dlugoscGenotypu, ushort maxAllel, ushort[][] dostepnoscPrzedmiotow) : base(rozmiarPopulacji, dlugoscGenotypu, maxAllel)
        {
            this.dostepnoscPrzedmiotow = dostepnoscPrzedmiotow;
            populacjaCykliczna = new PopulacjaCykliczna(rozmiarPopulacji, dlugoscGenotypu, maxAllel);
        }

        public override ArrayList StworzPopulacjeBazowa()
        {
            ArrayList populacja = new ArrayList();
            ArrayList populacjaTSP = populacjaCykliczna.StworzPopulacjeBazowa();
            
            for (int i = 0; i < rozmiarPopulacji; i++)
            {
                ushort[] osobnikTSP = ((ushort[])populacjaTSP[i]);
                ushort[][] genotyp = new ushort[osobnikTSP.Length][];

                for (int j = 0; j < osobnikTSP.Length; j++)
                {
                    int index = osobnikTSP[j] - 1;

                    genotyp[index] = new ushort[dostepnoscPrzedmiotow[0].Length + 1];
                    genotyp[index][0] = osobnikTSP[j];

                    for (int k = 1; k < genotyp[index].Length; k++)
                    {
                        if(dostepnoscPrzedmiotow[index][(k - 1)] == 1)
                        {
                            genotyp[index][k] = (ushort)losowy.Next(2);
                        } else
                        {
                            genotyp[index][k] = 0;
                        }
                    }
                }

                populacja.Add(new ReprezentacjaGenotypu(genotyp));
            }

            return populacja;
        }
    }
}
