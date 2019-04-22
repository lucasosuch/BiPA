using BiPA.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using BiPA.Widoki.Narzedzia;
using System;
using System.Threading.Tasks;

namespace BiPA.Struktura.Algorytmy.Abstrakcyjny
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
