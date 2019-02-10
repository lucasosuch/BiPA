using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
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

        public override ReprezentacjaRozwiazania WybierzOsobnika(ReprezentacjaRozwiazania[] populacja, int pokolenie)
        {
            if(typSelekcji == "Metoda ruletki")
            {
                System.Console.WriteLine("Pokolenie: " + this.pokolenie +" != "+ pokolenie);

                if (this.pokolenie != pokolenie || this.pokolenie == 0)
                {
                    wskazniki = ZwrocWskazniki(populacja);
                }

                this.pokolenie = pokolenie;
                return MetodaRuletki(populacja);
            }

            return Turniej(populacja);
        }
        
        protected override ReprezentacjaRozwiazania MetodaRuletki(ReprezentacjaRozwiazania[] populacja)
        {
            ReprezentacjaRozwiazania osobnik = new ReprezentacjaRozwiazania();
            float pwo = (float)losowy.NextDouble(),
                   poprzednik = 0;

            for(int i = 0; i < populacja.Length; i++)
            {
                if (poprzednik <= pwo && pwo < (float)wskazniki[i])
                {
                    osobnik = populacja[i];
                    break;
                }

                poprzednik = (float)wskazniki[i];
            }
            
            return osobnik;
        }

        protected override ArrayList ZwrocWskazniki(ReprezentacjaRozwiazania[] populacja)
        {
            float suma = 0;
            ArrayList wskazniki = new ArrayList();

            foreach (ReprezentacjaRozwiazania osobnik in populacja)
            {
                suma += rozwiazanie.FunkcjaDopasowania(osobnik)["max"][0];
            }

            float sumaCzesciowa = 0;
            foreach (ReprezentacjaRozwiazania osobnik in populacja)
            {
                float wskaznik = rozwiazanie.FunkcjaDopasowania(osobnik)["max"][0] / suma;

                sumaCzesciowa += wskaznik;
                wskazniki.Add(sumaCzesciowa);
            }

            return wskazniki;
        }

        protected override ReprezentacjaRozwiazania Turniej(ReprezentacjaRozwiazania[] populacja)
        {
            ReprezentacjaRozwiazania zwyciezca = populacja[0];
            Dictionary<string, float[]> dopasowanieZwyciezcy = rozwiazanie.FunkcjaDopasowania(populacja[0]);

            for (int i = 0; i <= 5; i++)
            {
                int k = losowy.Next(populacja.Length - 1);
                Dictionary<string, float[]> dopasowanie = rozwiazanie.FunkcjaDopasowania(populacja[k]);

                if (dopasowanieZwyciezcy["max"][0] < dopasowanie["max"][0])
                {
                    zwyciezca = populacja[k];
                    dopasowanieZwyciezcy = dopasowanie;
                }
            }

            return zwyciezca;
        }
    }
}
