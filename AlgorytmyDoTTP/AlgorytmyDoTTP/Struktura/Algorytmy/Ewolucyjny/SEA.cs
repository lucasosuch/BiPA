using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Analityka;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Populacja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Selekcja;
using System;
using System.Collections;
using System.Collections.Generic;

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

        public Dictionary<string, string[]> Start()
        {
            ArrayList nowaPopulacja = new ArrayList();
            ArrayList populacjaBazowa = populacja.StworzPopulacjeBazowa();
            Dictionary<string, string[]> zwracanyTekst = new Dictionary<string, string[]>();

            analityka.RozpocznijPomiarCzasu();
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

            analityka.ZakonczPomiarCzasu();

            double czasDzialania = analityka.ZwrocCzasDzialaniaAlgorytmu(),
                   srednia = analityka.SredniaPopulacji(populacjaBazowa),
                   mediana = analityka.MedianaPopulacji(populacjaBazowa),
                   odchylenieStadowe = analityka.OdchylenieStandardowePopulacji(populacjaBazowa, srednia);

            ushort[] wartoscNiebo = analityka.ZwrocNajlepszyGenotyp();

            zwracanyTekst["dziedzina"] = new string[] { "Najlepszy genotyp", string.Join(",", wartoscNiebo) };
            zwracanyTekst["maxWartosc"] = new string[] { "Najlepsza funkcja przystosowania", analityka.ZwrocWartoscNiebo()[0], analityka.ZwrocWartoscNiebo()[1] };
            zwracanyTekst["sredniaWartosc"] = new string[] { "Średnia funkcji przystosowania z populacji", srednia.ToString() };
            zwracanyTekst["medianaWartosci"] = new string[] { "Mediana funkcji przystosowania z populacji", mediana.ToString() };
            zwracanyTekst["odchstdWartosci"] = new string[] { "Odchylenie standardowe funkcji przystosowania z populacji", odchylenieStadowe.ToString() };
            zwracanyTekst["czasDzialania"] = new string[] { "Czas dzialania algorytmu", czasDzialania +" ms" };

            return zwracanyTekst;
        }
    }
}