using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using AlgorytmyDoTTP.Widoki;
using System;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny
{
    interface IAlgorytm
    {
        /// <summary>
        /// Metoda uruchamiająca Algorytm Ewolucyjny
        /// </summary>
        Task Start(IProgress<ProgressReport> progress);

        AAnalityka ZwrocAnalityke();
    }
}
