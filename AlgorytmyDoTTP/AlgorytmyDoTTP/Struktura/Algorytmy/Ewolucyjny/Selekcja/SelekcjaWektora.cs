using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Selekcja
{
    /// <summary>
    /// Klasa konkretna odpowiedzialna za wybór osobników z populacji na podstawie ich przystosowania
    /// </summary>
    class SelekcjaWektora : ASelekcja
    {
        public SelekcjaWektora(AOsobnik rozwiazanie, ushort dlugoscGenotypu, string typSelekcji) : base(rozwiazanie, dlugoscGenotypu, typSelekcji){}

        public override ReprezentacjaRozwiazania WybierzOsobnika(ArrayList populacja, int pokolenie)
        {
            if(typSelekcji == "Metoda ruletki")
            {
                if(this.pokolenie != pokolenie)
                {
                    wskazniki = ZwrocWskazniki(populacja);
                }

                this.pokolenie = pokolenie;
                return MetodaRuletki(populacja);
            }

            return Turniej(populacja);
        }

        protected override ReprezentacjaRozwiazania Turniej(ArrayList populacja)
        {
            ReprezentacjaRozwiazania zwyciezca = (ReprezentacjaRozwiazania)populacja[0];
            Dictionary<String, double[]> dopasowanieZwyciezcy = rozwiazanie.FunkcjaDopasowania((ReprezentacjaRozwiazania)populacja[0]);

            for (int i = 0; i <= 5; i++)
            {
                int k = losowy.Next(populacja.Count - 1);
                Dictionary<String, double[]> dopasowanie = rozwiazanie.FunkcjaDopasowania((ReprezentacjaRozwiazania)populacja[k]);

                if (dopasowanieZwyciezcy["max"][0] < dopasowanie["max"][0])
                {
                    zwyciezca = (ReprezentacjaRozwiazania)populacja[k];
                    dopasowanieZwyciezcy = dopasowanie;
                }
            }

            return zwyciezca;
        }

        protected override ReprezentacjaRozwiazania MetodaRuletki(ArrayList populacja)
        {
            ReprezentacjaRozwiazania osobnik = new ReprezentacjaRozwiazania();
            double pwo = losowy.NextDouble(),
                   poprzednik = 0;
            
            for(int i = 0; i < populacja.Count; i++)
            {
                if(poprzednik <= pwo && pwo < (double)wskazniki[i])
                {
                    osobnik = (ReprezentacjaRozwiazania)populacja[i];
                    break;
                }

                poprzednik = (double)wskazniki[i];
            }

            return osobnik;
        }

        protected override ArrayList ZwrocWskazniki(ArrayList populacja)
        {
            double suma = 0;
            ArrayList wskazniki = new ArrayList();

            foreach (ReprezentacjaRozwiazania osobnik in populacja)
            {
                suma += rozwiazanie.FunkcjaDopasowania(osobnik)["max"][0];
            }

            double sumaCzesciowa = 0;
            foreach (ReprezentacjaRozwiazania osobnik in populacja)
            {
                double wskaznik = rozwiazanie.FunkcjaDopasowania(osobnik)["max"][0] / suma;

                sumaCzesciowa += wskaznik;
                wskazniki.Add(sumaCzesciowa);
            }

            return wskazniki;
        }
    }
}
