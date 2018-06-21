using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Selekcja;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny
{
    /// <summary>
    /// Klasa konkretna Algorytmu Ewolucyjnego.
    /// Pozwala na wyszukanie rozwiązania optymalnego danego problemu wg zasad działania Algorytmów Ewolucyjnych
    /// </summary>
    class SEA : IAlgorytm
    {
        private short iloscPokolen; // ilość iteracji algorytmu
        private double pwoKrzyzowania; // prawdopodobieństwo, że zostanie stworzony nowy osobnik
        private ARekombinacja rekombinacja; // klasa odpowiedzialna za tworzenie nowych osobników
        private ASelekcja selekcja; // klasa odpowiedzialna za wybieranie najlepszych osobników do krzyżowania
        private AnalizaEwolucyjny analityka; // klasa odpowiedzialna za analizę rozwiązań
        private ArrayList populacjaBazowa; // klasa zarządzająca populcją osobników
        private Random losowy = new Random();

        public SEA()
        {
            throw new Exception(); // błąd, nie zbudowano kontekstu pod wybrany problem optymalizacyjny
        }

        public SEA(ASelekcja selekcja, ARekombinacja rekombinacja, AnalizaEwolucyjny analityka, ArrayList populacjaBazowa, short iloscPokolen, double pwoKrzyzowania)
        {
            this.selekcja = selekcja;
            this.rekombinacja = rekombinacja;
            this.analityka = analityka;
            this.iloscPokolen = iloscPokolen;
            this.populacjaBazowa = populacjaBazowa;
            this.pwoKrzyzowania = pwoKrzyzowania;
        }

        /// <summary>
        /// Metoda uruchamiająca Algorytm Ewolucyjny
        /// </summary>
        /// <returns>Zwraca raport z badania czytelny dla człowieka</returns>
        public Dictionary<string, string[]> Start()
        {
            ArrayList nowaPopulacja = new ArrayList();
            Dictionary<string, string[]> zwracanyTekst = new Dictionary<string, string[]>();

            analityka.RozpocznijPomiarCzasu(); // rozpoczęcie pomiaru czasu
            // iterując przez wszystkie pokolenia
            while (iloscPokolen >= 0)
            {
                // wczytujemy pewną ilość osobników z populacji
                for (int i = 0; i < populacjaBazowa.Count; i++)
                {
                    // zależną od prawdopodobieństwa kzyżowania
                    if (losowy.NextDouble() <= pwoKrzyzowania)
                    {
                        // i przeprowadzamy operację tworzenia nowych osobników, pobierając rodziców z populacji
                        ReprezentacjaRozwiazania mama = selekcja.WybierzOsobnika(populacjaBazowa),
                                              tata = selekcja.WybierzOsobnika(populacjaBazowa),
                                              dziecko1 = rekombinacja.Krzyzowanie(mama, tata), // tworząc 1 dziecko
                                              dziecko2 = rekombinacja.Krzyzowanie(tata, mama); // oraz 2 dziecko

                        // dzieci dodajemy do nowej populacji
                        nowaPopulacja.Add(dziecko1);
                        nowaPopulacja.Add(dziecko2);

                        // sprawdzając czy nie stworzyliśmy najlepszego rozwiązania do tej pory
                        analityka.ZmienWartoscNiebo(dziecko1);
                        analityka.ZmienWartoscNiebo(dziecko2);
                    }
                }

                // wymieniamy starą populację na nową populację
                populacjaBazowa.Clear();
                populacjaBazowa.AddRange(nowaPopulacja);
                nowaPopulacja.Clear();
                
                --iloscPokolen; // zmiejszając ilość pokoleń
            }

            analityka.ZakonczPomiarCzasu(); // zakończenie pomiaru czasu

            // pobieramy wartości statystyczne / analityczne z naszego badania
            double czasDzialania = analityka.ZwrocCzasDzialaniaAlgorytmu(),
                   srednia = analityka.SredniaPopulacji(populacjaBazowa),
                   mediana = analityka.MedianaPopulacji(populacjaBazowa),
                   odchylenieStadowe = analityka.OdchylenieStandardowePopulacji(populacjaBazowa, srednia);

            ReprezentacjaRozwiazania wartoscNiebo = analityka.ZwrocNajlepszyGenotyp();

            // zwracamy raport z badań w formie czytelnej dla człowieka
            zwracanyTekst["dziedzina"] = new string[] { "Najlepszy genotyp", analityka.ZwrocNajlepszeRowziazanie() };
            zwracanyTekst["maxWartosc"] = new string[] { "Najlepsza funkcja przystosowania", analityka.ZwrocWartoscNiebo()[0], analityka.ZwrocWartoscNiebo()[1] };
            zwracanyTekst["sredniaWartosc"] = new string[] { "Średnia funkcji przystosowania z populacji", srednia.ToString() };
            zwracanyTekst["medianaWartosci"] = new string[] { "Mediana funkcji przystosowania z populacji", mediana.ToString() };
            zwracanyTekst["odchstdWartosci"] = new string[] { "Odchylenie standardowe funkcji przystosowania z populacji", odchylenieStadowe.ToString() };
            zwracanyTekst["czasDzialania"] = new string[] { "Czas dzialania algorytmu", czasDzialania.ToString() };

            return zwracanyTekst;
        }
    }
}