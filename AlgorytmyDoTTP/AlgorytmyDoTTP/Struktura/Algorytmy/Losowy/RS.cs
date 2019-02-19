using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using AlgorytmyDoTTP.Widoki.Narzedzia;
using System;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy
{
    /// <summary>
    /// Klasa konkretna Algorytmu Losowego.
    /// Pozwala na wyszukanie rozwiązania optymalnego danego problemu wg zasad działania Algorytmów Losowego
    /// </summary>
    class RS : IAlgorytm
    {
        private readonly int iloscRozwiazan;
        private readonly int iloscElementow;
        private ALosowanie losowanie;
        private AnalizaRLS_RS analityka;

        public RS(ALosowanie losowanie, int iloscRozwiazan, int iloscElementow, AnalizaRLS_RS analityka)
        {
            this.losowanie = losowanie;
            this.iloscRozwiazan = iloscRozwiazan;
            this.iloscElementow = iloscElementow;
            this.analityka = analityka;
        }

        public void Start()
        {
            for (short i = 0; i < analityka.ZwrocLiczbeIteracji(); i++)
            {
                analityka.RozpocznijPomiarCzasu(); // rozpoczęcie pomiaru czasu

                while (analityka.IleCzasuDzialaAlgorytm("s") < analityka.ZwrocCzasDzialaniaAlgorytmu())
                {
                    losowanie.SzukajNajlepszegoRozwiazania(iloscRozwiazan, iloscElementow);
                    analityka.DopiszWartoscProcesu(i, (short)analityka.IleCzasuDzialaAlgorytm("s"), losowanie.ZwrocNajlepszeRozwiazanie());
                }

                analityka.ResetPomiaruCzasu(); // zakończenie pomiaru czasu
            }
            
            analityka.ObliczSrednieWartosciProcesu();
        }

        public Task Start(IProgress<PostepBadania> postep)
        {
            throw new NotImplementedException();
        }

        public AAnalityka ZwrocAnalityke()
        {
            return analityka;
        }
    }
}
