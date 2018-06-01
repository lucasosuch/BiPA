using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    class PopulacjaCykliczna : APopulacja
    {
        private double zroznicowaniePopulacji;

        public PopulacjaCykliczna(ushort rozmiarPopulacji, ushort dlugoscGenotypu, ushort maxAllel) : base(rozmiarPopulacji, dlugoscGenotypu, maxAllel)
        {
            zroznicowaniePopulacji = 0.7;
        }

        public PopulacjaCykliczna(ushort rozmiarPopulacji, ushort dlugoscGenotypu, ushort maxAllel, double zroznicowaniePopulacji) : base(rozmiarPopulacji, dlugoscGenotypu, maxAllel)
        {
            this.zroznicowaniePopulacji = zroznicowaniePopulacji;
        }

        public override ArrayList StworzPopulacjeBazowa()
        {
            for (int i = 0; i < rozmiarPopulacji; i++)
            {
                ushort[] osobnik = new ushort[dlugoscGenotypu];

                if (losowy.NextDouble() < zroznicowaniePopulacji)
                {
                    ArrayList wykorzystane = new ArrayList();

                    for (int j = 0; j < dlugoscGenotypu; j++)
                    {
                        while(true)
                        {
                            int wynik = (ushort)losowy.Next(1, dlugoscGenotypu + 1);

                            if (wykorzystane.IndexOf(wynik) == -1)
                            {
                                wykorzystane.Add(wynik);
                                osobnik[j] = (ushort)wynik;
                                break;
                            }
                        }
                    }

                    wykorzystane.Clear();
                } else
                {
                    for(int j = 0; j < dlugoscGenotypu; j++)
                    {
                        osobnik[j] = (ushort)(j + 1);
                    }
                }

                populacja.Add(osobnik);
            }

            return populacja;
        }
    }
}
