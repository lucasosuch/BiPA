using System;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using System.Collections;
using System.Diagnostics;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Selekcja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny
{
    class SEA : IAlgorytm
    {
        private short iloscPokolen;
        private double pwoKrzyzowania;
        private ARekombinacja rekombinacja;
        private ASelekcja selekcja;
        private AOsobnik rozwiazanie;
        private APopulacja populacja;
        private Random losowy = new Random();

        public SEA(ASelekcja selekcja, ARekombinacja rekombinacja, AOsobnik rozwiazanie, APopulacja populacja, short iloscPokolen, double pwoKrzyzowania)
        {
            this.selekcja = selekcja;
            this.rekombinacja = rekombinacja;
            this.rozwiazanie = rozwiazanie;
            this.iloscPokolen = iloscPokolen;
            this.populacja = populacja;
            this.pwoKrzyzowania = pwoKrzyzowania;
        }

        public void Start()
        {
            ArrayList nowaPopulacja = new ArrayList();
            ArrayList populacjaBazowa = populacja.StworzPopulacjeBazowa();

            while (iloscPokolen >= 0)
            {
                for (int i = 0; i < populacjaBazowa.Count; i++)
                {
                    if (losowy.NextDouble() <= pwoKrzyzowania)
                    {
                        ushort[] mama = selekcja.WybierzOsobnika(populacjaBazowa),
                                 tata = selekcja.WybierzOsobnika(populacjaBazowa),
                                 dziecko1 = rekombinacja.Krzyzowanie(mama, tata),
                                 dziecko2 = rekombinacja.Krzyzowanie(tata, mama);

                        nowaPopulacja.Add(dziecko1);
                        nowaPopulacja.Add(dziecko2);
                    }
                }

                populacjaBazowa.Clear();
                populacjaBazowa.AddRange(nowaPopulacja);
                nowaPopulacja.Clear();
                
                --iloscPokolen;
            }

            //double srednia = SredniaPopulacji(populacja),
            //       odchylenieStadowe = OdchylenieStandardowePopulacji(populacja, srednia);
        }

        private double SredniaPopulacji(ArrayList populacja)
        {
            double wynik = 0;
            
            foreach(ushort[] osobnik in populacja)
            {
                wynik += rozwiazanie.FunkcjaDopasowania(osobnik)[1];
            }

            return wynik / populacja.Count;
        }

        private double OdchylenieStandardowePopulacji(ArrayList populacja, double srednia)
        {
            double sumaKwadratow = 0;

            foreach (ushort[] osobnik in populacja)
            {
                sumaKwadratow += Math.Pow(rozwiazanie.FunkcjaDopasowania(osobnik)[1], 2);
            }

            double sredniaSumaKwadratow = sumaKwadratow / (populacja.Count - 1);
            return Math.Sqrt(sredniaSumaKwadratow - (Math.Pow(srednia, 2)));
        }
    }
}