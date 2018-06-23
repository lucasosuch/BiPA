using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny
{
    interface IAlgorytm
    {
        /// <summary>
        /// Metoda uruchamiająca Algorytm Ewolucyjny
        /// </summary>
        /// <returns>Zwraca raport z badania czytelny dla człowieka</returns>
        Dictionary<string, string[]> Start();
    }
}
