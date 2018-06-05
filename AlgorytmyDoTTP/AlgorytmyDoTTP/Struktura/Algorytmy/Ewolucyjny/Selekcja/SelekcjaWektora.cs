using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Genotyp;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Selekcja
{
    class SelekcjaWektora : ASelekcja
    {
        public SelekcjaWektora(AOsobnik rozwiazanie, ushort dlugoscGenotypu, string typSelekcji) : base(rozwiazanie, dlugoscGenotypu, typSelekcji){}

        public override ReprezentacjaGenotypu WybierzOsobnika(ArrayList populacja)
        {
            if(typSelekcji == "Turniej")
            {
                return Turniej(populacja);
            }

            return MetodaRuletki(populacja);
        }

        protected override ReprezentacjaGenotypu Turniej(ArrayList populacja)
        {
            ReprezentacjaGenotypu zwyciezca = (ReprezentacjaGenotypu)populacja[0];
            Dictionary<String, double[]> dopasowanieZwyciezcy = rozwiazanie.FunkcjaDopasowania((ReprezentacjaGenotypu)populacja[0]);

            for (int i = 0; i <= 3; i++)
            {
                int k = losowy.Next(populacja.Count - 1);
                Dictionary<String, double[]> dopasowanie = rozwiazanie.FunkcjaDopasowania((ReprezentacjaGenotypu)populacja[k]);

                if (dopasowanieZwyciezcy["max"][0] < dopasowanie["max"][0])
                {
                    zwyciezca = (ReprezentacjaGenotypu)populacja[k];
                    dopasowanieZwyciezcy = dopasowanie;
                }
            }

            return zwyciezca;
        }

        protected override ReprezentacjaGenotypu MetodaRuletki(ArrayList populacja)
        {
            ReprezentacjaGenotypu osobnik = new ReprezentacjaGenotypu();
            ArrayList wskazniki = ZwrocWskazniki(populacja);
            double pwo = losowy.NextDouble(),
                   poprzednik = 0;

            for(int i = 0; i < populacja.Count; i++)
            {
                if(poprzednik <= pwo && pwo < (double)wskazniki[i])
                {
                    osobnik = (ReprezentacjaGenotypu)populacja[i];
                    break;
                }

                poprzednik = (double)wskazniki[i];
            }

            return osobnik;
        }

        private ArrayList ZwrocWskazniki(ArrayList populacja)
        {
            double suma = 0;
            ArrayList wskazniki = new ArrayList();

            foreach (ReprezentacjaGenotypu osobnik in populacja)
            {
                suma += rozwiazanie.FunkcjaDopasowania(osobnik)["max"][0];
            }

            double sumaCzesciowa = 0;
            foreach (ReprezentacjaGenotypu osobnik in populacja)
            {
                double wskaznik = rozwiazanie.FunkcjaDopasowania(osobnik)["max"][0] / suma;

                sumaCzesciowa += wskaznik;
                wskazniki.Add(sumaCzesciowa);
            }

            return wskazniki;
        }
    }
}
