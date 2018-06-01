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
                ushort[][] osobnik = new ushort[populacjaTSP.Count][];
                for (int j = 0; j < populacjaTSP.Count; j++)
                {
                    osobnik[j] = new ushort[dostepnoscPrzedmiotow.Length + 1];
                    osobnik[j][0] = (ushort)populacjaTSP[j];

                    for (int k = 1; k <= osobnik.Length; k++)
                    {
                        if(dostepnoscPrzedmiotow[j][(k - 1)] == 1)
                        {
                            osobnik[j][k] = (ushort)losowy.Next(2);
                        }
                    }
                }

                populacja.Add(osobnik);
            }

            return populacja;
        }
    }
}
