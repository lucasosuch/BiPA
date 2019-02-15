using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Wspinaczka;
using AlgorytmyDoTTP.Widoki;
using System;
using System.Collections.Generic;
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

        public RLS(AWspinaczka przeszukiwanieLokalne, AnalizaRLS_RS analityka)
        {
            this.analityka = analityka;
            this.przeszukiwanieLokalne = przeszukiwanieLokalne;
        }

        public void Start()
        {
            for (short i = 0; i < analityka.ZwrocLiczbeIteracji(); i++)
            {
                analityka.RozpocznijPomiarCzasu(); // rozpoczęcie pomiaru czasu

                while (analityka.IleCzasuDzialaAlgorytm("s") < analityka.ZwrocCzasDzialaniaAlgorytmu())
                {
                    przeszukiwanieLokalne.UstawRozwiazanie(przeszukiwanieLokalne.ZwrocInstancjeLosowania().ZwrocNajlepszeRozwiazanie());
                    przeszukiwanieLokalne.ZnajdzOptimum();
                    analityka.DopiszWartoscProcesu(i, (short)analityka.IleCzasuDzialaAlgorytm("s"), przeszukiwanieLokalne.ZwrocRozwiazanie());
                }

                analityka.ResetPomiaruCzasu(); // zakończenie pomiaru czasu
            }

            analityka.ObliczSrednieWartosciProcesu();
        }

        public Task Start(IProgress<ProgressReport> progress)
        {
            throw new NotImplementedException();
        }

        public AAnalityka ZwrocAnalityke()
        {
            return analityka;
        }
    }
}
