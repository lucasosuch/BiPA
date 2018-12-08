using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny
{
    interface IAlgorytm
    {
        /// <summary>
        /// Metoda uruchamiająca Algorytm Ewolucyjny
        /// </summary>
        void Start();

        AAnalityka ZwrocAnalityke();
    }
}
