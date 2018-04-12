using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny
{
    class Selekcja
    {
        private ushort dlugoscGenotypu;
        private Random losowy = new Random();
        private ProblemPlecakowy problemPlecakowy;

        public Selekcja(ProblemPlecakowy problemPlecakowy, ushort dlugoscGenotypu)
        {
            this.dlugoscGenotypu = dlugoscGenotypu;
            this.problemPlecakowy = problemPlecakowy;
        }

        public ushort[] Turniej(ArrayList populacja)
        {
            Osobnik rozwiazanie = new Osobnik(problemPlecakowy);

            ushort[] zwyciezca = new ushort[dlugoscGenotypu];

            ((ushort[])populacja[0]).CopyTo(zwyciezca, 0);
            double[] dopasowanieZwyciezcy = rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp((ushort[])populacja[0]));

            for (int i = 0; i <= 25; i++)
            {
                int k = losowy.Next(populacja.Count - 1);
                double[] dopasowanie = rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp((ushort[])populacja[k]));

                if(dopasowanieZwyciezcy[1] < dopasowanie[1])
                {
                    zwyciezca = (ushort[])populacja[k];
                    dopasowanieZwyciezcy = dopasowanie;
                }
            }

            return zwyciezca;
        }

        private ArrayList ZwrocWskazniki(ArrayList populacja)
        {
            Osobnik rozwiazanie = new Osobnik(problemPlecakowy);
            ArrayList wskazniki = new ArrayList();
            double suma = 0;

            foreach(ushort[] osobnik in populacja)
            {
                suma += rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp(osobnik))[1];
            }

            double sumaCzesciowa = 0;
            foreach(ushort[] osobnik in populacja)
            {
                double wskaznik = rozwiazanie.FunkcjaDopasowania(rozwiazanie.Fenotyp(osobnik))[1] / suma;

                sumaCzesciowa += wskaznik;
                wskazniki.Add(sumaCzesciowa);
            }

            return wskazniki;
        }

        public ushort[] MetodaRuletki(String typRuletki, ArrayList populacja)
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
            } else
            {
                double srednia = 0;
                foreach(double wskanik in wskazniki)
                {
                    srednia += wskanik;
                }
            }

            return osobnik;
        }
    }
}
