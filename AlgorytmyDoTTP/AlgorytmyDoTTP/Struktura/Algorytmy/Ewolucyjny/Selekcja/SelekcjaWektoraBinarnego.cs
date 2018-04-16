using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Selekcja
{
    class SelekcjaWektoraBinarnego : ASelekcja
    {
        private ushort dlugoscGenotypu;
        private Random losowy = new Random();
        private OsobnikKP rozwiazanie;

        public SelekcjaWektoraBinarnego(OsobnikKP rozwiazanie, ushort dlugoscGenotypu)
        {
            this.dlugoscGenotypu = dlugoscGenotypu;
            this.rozwiazanie = rozwiazanie;
        }

        public override ushort[] Turniej(ArrayList populacja)
        {
            ushort[] zwyciezca = new ushort[dlugoscGenotypu];

            ((ushort[])populacja[0]).CopyTo(zwyciezca, 0);
            double[] dopasowanieZwyciezcy = rozwiazanie.FunkcjaDopasowania((ushort[])populacja[0]);

            for (int i = 0; i <= 25; i++)
            {
                int k = losowy.Next(populacja.Count - 1);
                double[] dopasowanie = rozwiazanie.FunkcjaDopasowania((ushort[])populacja[k]);

                if(dopasowanieZwyciezcy[1] < dopasowanie[1])
                {
                    zwyciezca = (ushort[])populacja[k];
                    dopasowanieZwyciezcy = dopasowanie;
                }
            }

            return zwyciezca;
        }

        public override ushort[] MetodaRuletki(String typRuletki, ArrayList populacja)
        {
            ushort[] osobnik = new ushort[dlugoscGenotypu];
            ArrayList wskazniki = ZwrocWskazniki(populacja);

            if(typRuletki == "Zwykla")
            {
                double pwo = losowy.NextDouble(),
                       poprzednik = 0;

                for(int i = 0; i < populacja.Count; i++)
                {
                    if(poprzednik <= pwo && pwo < (double)wskazniki[i])
                    {
                        osobnik = (ushort[])((ushort[])populacja[i]).Clone();
                        break;
                    }

                    poprzednik = (double)wskazniki[i];
                }
            }

            return osobnik;
        }

        private ArrayList ZwrocWskazniki(ArrayList populacja)
        {
            ArrayList wskazniki = new ArrayList();
            double suma = 0;

            foreach (ushort[] osobnik in populacja)
            {
                suma += rozwiazanie.FunkcjaDopasowania(osobnik)[1];
            }

            double sumaCzesciowa = 0;
            foreach (ushort[] osobnik in populacja)
            {
                double wskaznik = rozwiazanie.FunkcjaDopasowania(osobnik)[1] / suma;

                sumaCzesciowa += wskaznik;
                wskazniki.Add(sumaCzesciowa);
            }

            return wskazniki;
        }
    }
}
