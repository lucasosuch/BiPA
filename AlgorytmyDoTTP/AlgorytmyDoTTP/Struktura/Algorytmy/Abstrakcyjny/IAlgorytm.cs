using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using AlgorytmyDoTTP.Widoki.Narzedzia;
using System;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny
{
    interface IAlgorytm
    {
        /// <summary>
        /// Metoda uruchamiająca Algorytm
        /// </summary>
        Task Start(IProgress<PostepBadania> postep);

        AAnalityka ZwrocAnalityke();
    }
}
