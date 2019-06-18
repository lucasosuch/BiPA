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
        /// <param name="postep">Odpowiada za ustawianie postępu badania</param>
        Task Start(IProgress<PostepBadania> postep);

        /// <summary>
        /// Metoda zwracająca obiekt analityki porównawczo-badawczej
        /// </summary>
        AAnalityka ZwrocAnalityke();
    }
}
