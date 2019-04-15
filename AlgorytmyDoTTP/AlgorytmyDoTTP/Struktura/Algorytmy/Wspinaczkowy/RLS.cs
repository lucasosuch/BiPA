using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Wspinaczka;
using AlgorytmyDoTTP.Widoki.Narzedzia;
using System;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy
{
    /// <summary>
    /// Klasa konkretna Algorytmu Wspinaczkowego.
    /// Pozwala na wyszukanie rozwiązania optymalnego danego problemu wg zasad działania Algorytmów Wspinaczkowych
    /// </summary>
    class RLS : IAlgorytm
    {
        private AnalizaRLS_RS analityka;
        private AWspinaczka przeszukiwanieLokalne;

        public RLS()
        {
            throw new Exception(); // błąd, nie zbudowano kontekstu pod wybrany problem optymalizacyjny
        }

        public RLS(AWspinaczka przeszukiwanieLokalne, AnalizaRLS_RS analityka)
        {
            this.analityka = analityka;
            this.przeszukiwanieLokalne = przeszukiwanieLokalne;
        }

        public Task Start(IProgress<PostepBadania> postep)
        {
            int czas = 0,
                poprzedniaSekunda = -1,
                calkowityCzas = analityka.ZwrocLiczbeIteracji() * analityka.ZwrocCzasDzialaniaAlgorytmu();
            PostepBadania postepBadania = new PostepBadania();

            return Task.Run(() =>
            {
                for (short i = 0; i < analityka.ZwrocLiczbeIteracji(); i++)
                {
                    analityka.RozpocznijPomiarCzasu(); // rozpoczęcie pomiaru czasu

                    while (analityka.IleCzasuDzialaAlgorytm("s") < analityka.ZwrocCzasDzialaniaAlgorytmu())
                    {
                        przeszukiwanieLokalne.UstawRozwiazanie(przeszukiwanieLokalne.ZwrocInstancjeLosowania().ZwrocNajlepszeRozwiazanie());
                        przeszukiwanieLokalne.ZnajdzOptimum();
                        analityka.DopiszWartoscProcesu(i, (int)analityka.IleCzasuDzialaAlgorytm("s"), przeszukiwanieLokalne.ZwrocRozwiazanie());

                        if (poprzedniaSekunda == -1 || poprzedniaSekunda != (int)analityka.IleCzasuDzialaAlgorytm("s"))
                        {
                            czas++;
                            poprzedniaSekunda = (int)analityka.IleCzasuDzialaAlgorytm("s");
                        }

                        postepBadania.ProcentUkonczenia = (czas * 100 / calkowityCzas) - 1;
                        if (postepBadania.ProcentUkonczenia < 0) postepBadania.ProcentUkonczenia = 0;
                        if (postepBadania.ProcentUkonczenia > 100) postepBadania.ProcentUkonczenia = 100;
                        postep.Report(postepBadania);
                    }

                    analityka.ResetPomiaruCzasu(); // zakończenie pomiaru czasu
                    poprzedniaSekunda = -1;
                }

                analityka.ObliczSrednieWartosciProcesu();
            });
        }

        public AAnalityka ZwrocAnalityke()
        {
            return analityka;
        }
    }
}
