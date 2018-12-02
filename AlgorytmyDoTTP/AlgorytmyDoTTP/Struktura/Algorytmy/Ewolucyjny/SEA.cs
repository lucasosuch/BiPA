using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Selekcja;
using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny
{
    /// <summary>
    /// Klasa konkretna Algorytmu Ewolucyjnego.
    /// Pozwala na wyszukanie rozwiązania optymalnego danego problemu wg zasad działania Algorytmów Ewolucyjnych
    /// </summary>
    class SEA : IAlgorytm
    {
        private readonly float pwoKrzyzowania; // prawdopodobieństwo, że zostanie stworzony nowy osobnik
        private ARekombinacja rekombinacja; // klasa odpowiedzialna za tworzenie nowych osobników
        private ASelekcja selekcja; // klasa odpowiedzialna za wybieranie najlepszych osobników do krzyżowania
        private ReprezentacjaRozwiazania[] populacjaBazowa; // klasa zarządzająca populcją osobników
        private AnalizaEwolucyjny analityka; // klasa odpowiedzialna za analizę rozwiązań

        public SEA()
        {
            throw new Exception(); // błąd, nie zbudowano kontekstu pod wybrany problem optymalizacyjny
        }

        public SEA(ASelekcja selekcja, ARekombinacja rekombinacja, AnalizaEwolucyjny analityka, ReprezentacjaRozwiazania[] populacjaBazowa, float pwoKrzyzowania)
        {
            this.selekcja = selekcja;
            this.rekombinacja = rekombinacja;
            this.analityka = analityka;
            this.populacjaBazowa = populacjaBazowa;
            this.pwoKrzyzowania = pwoKrzyzowania;
        }
        
        public void Start()
        {
            short liczbaOsobnikowPopulacji = (short)(populacjaBazowa.Length * 2 * pwoKrzyzowania);

            for (short i = 0; i < analityka.ZwrocLiczbeIteracji(); i++)
            {
                int liczbaPokolen = 0;
                ReprezentacjaRozwiazania[] nowaPopulacja = new ReprezentacjaRozwiazania[liczbaOsobnikowPopulacji];
                analityka.RozpocznijPomiarCzasu(); // rozpoczęcie pomiaru czasu
                ReprezentacjaRozwiazania[]  tmpPopulacja = (ReprezentacjaRozwiazania[])populacjaBazowa.Clone();

                // iterując przez wszystkie pokolenia
                while (analityka.IleCzasuDzialaAlgorytm("s") < analityka.ZwrocCzasDzialaniaAlgorytmu())
                {
                    // wczytujemy pewną liczbę osobników z populacji
                    for (short j = 0; j < liczbaOsobnikowPopulacji; j += 2)
                    {
                        // zależną od prawdopodobieństwa kzyżowania
                        // i przeprowadzamy operację tworzenia nowych osobników, pobierając rodziców z populacji
                        ReprezentacjaRozwiazania mama = selekcja.WybierzOsobnika(tmpPopulacja, liczbaPokolen),
                                                tata = selekcja.WybierzOsobnika(tmpPopulacja, liczbaPokolen),
                                                dziecko1 = rekombinacja.Krzyzowanie(mama, tata), // tworząc 1 dziecko
                                                dziecko2 = rekombinacja.Krzyzowanie(tata, mama); // oraz 2 dziecko

                        // dzieci dodajemy do nowej populacji
                        nowaPopulacja[j] = dziecko1;
                        // sprawdzając czy nie stworzyliśmy najlepszego rozwiązania do tej pory
                        analityka.DopiszWartoscProcesu(i, (short)analityka.IleCzasuDzialaAlgorytm("s"), dziecko1);

                        if (j + 1 < liczbaOsobnikowPopulacji)
                        {
                            nowaPopulacja[j + 1] = dziecko2;
                            analityka.DopiszWartoscProcesu(i, (short)analityka.IleCzasuDzialaAlgorytm("s"), dziecko2);
                        }
                    }

                    // wymieniamy starą populację na nową populację
                    tmpPopulacja = (ReprezentacjaRozwiazania[])nowaPopulacja.Clone();

                    liczbaPokolen++; // zwiększając liczbę pokoleń
                }

                analityka.ResetPomiaruCzasu(); // zakończenie pomiaru czasu
            }

            analityka.ObliczSrednieWartosciProcesu();
        }
    }
}