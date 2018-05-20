using System;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using System.Collections;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Selekcja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Analityka;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny
{
    class SEA : IAlgorytm
    {
        private short iloscPokolen;
        private double pwoKrzyzowania;
        private ARekombinacja rekombinacja;
        private ASelekcja selekcja;
        private IAnalityka analityka;
        private APopulacja populacja;
        private Random losowy = new Random();

        public SEA()
        {
            throw new Exception();
        }

        public SEA(ASelekcja selekcja, ARekombinacja rekombinacja, IAnalityka analityka, APopulacja populacja, short iloscPokolen, double pwoKrzyzowania)
        {
            this.selekcja = selekcja;
            this.rekombinacja = rekombinacja;
            this.analityka = analityka;
            this.iloscPokolen = iloscPokolen;
            this.populacja = populacja;
            this.pwoKrzyzowania = pwoKrzyzowania;
        }

        public string Start()
        {
            string tekst = "";
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
                                 dziecko1 = (ushort[])rekombinacja.Krzyzowanie(mama, tata).Clone(),
                                 dziecko2 = (ushort[])rekombinacja.Krzyzowanie(tata, mama).Clone();

                        nowaPopulacja.Add(dziecko1);
                        nowaPopulacja.Add(dziecko2);

                        analityka.ZmienWartoscNiebo(dziecko1);
                        analityka.ZmienWartoscNiebo(dziecko2);
                    }
                }
                
                //foreach (ushort[] osobnik in nowaPopulacja)
                //{
                //    tekst += String.Join(", ", osobnik) + Environment.NewLine;
                //}

                //Console.WriteLine(iloscPokolen);
                //Console.WriteLine(tekst);

                populacjaBazowa.Clear();
                populacjaBazowa.AddRange(nowaPopulacja);
                nowaPopulacja.Clear();
                
                --iloscPokolen;
            }

            double srednia = analityka.SredniaPopulacji(populacjaBazowa),
                   mediana = analityka.MedianaPopulacji(populacjaBazowa),
                   odchylenieStadowe = analityka.OdchylenieStandardowePopulacji(populacjaBazowa, srednia);

            ushort[] wartoscNiebo = analityka.ZwrocNajlepszyGenotyp();

            tekst += "Najlepszy genotyp: " + string.Join(",", wartoscNiebo) + " o wartości: " + analityka.ZwrocWartoscNiebo() + Environment.NewLine;
            tekst += "Średnia: "+ srednia + Environment.NewLine;
            tekst += "Mediana: " + mediana + Environment.NewLine;
            tekst += "Odchstd:"+ odchylenieStadowe + Environment.NewLine;

            return tekst;
        }
    }
}