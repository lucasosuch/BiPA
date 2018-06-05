using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja
{
    class PopulacjaTTP : APopulacja
    {
        private ushort[][] dostepnoscPrzedmiotow;
        private PopulacjaTSP populacjaCykliczna;

        public PopulacjaTTP(ushort rozmiarPopulacji, ushort dlugoscGenotypu, ushort maxAllel, ushort[][] dostepnoscPrzedmiotow) : base(rozmiarPopulacji, dlugoscGenotypu, maxAllel)
        {
            this.dostepnoscPrzedmiotow = dostepnoscPrzedmiotow;
            populacjaCykliczna = new PopulacjaTSP(rozmiarPopulacji, dlugoscGenotypu, maxAllel);
        }

        public override ArrayList StworzPopulacjeBazowa()
        {
            return new LosowanieTTP(rozmiarPopulacji, dlugoscGenotypu, maxAllel, dostepnoscPrzedmiotow).LosujRozwiazania();
        }
    }
}
