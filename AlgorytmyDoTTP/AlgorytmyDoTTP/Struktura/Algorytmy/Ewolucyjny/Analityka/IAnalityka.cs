using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Genotyp;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Analityka
{
    interface IAnalityka
    {
        /// <summary>
        /// Metoda obliczająca średnią wartość funkcji celu z populacji rozwiązań
        /// </summary>
        /// <param name="populacja">Lista rozwiązań</param>
        double SredniaPopulacji(ArrayList populacja);

        /// <summary>
        /// Metoda wyznaczająca medianę funkcji celu z populacji rozwiązań
        /// </summary>
        /// <param name="populacja">Lista rozwiązań</param>
        double MedianaPopulacji(ArrayList populacja);

        /// <summary>
        /// Metoda obliczająca odchylenie standardowe funkcji celu z populacji rozwiązań
        /// </summary>
        /// <param name="populacja">Lista rozwiązań</param>
        /// <param name="srednia">Średnia z listy rozwiązań</param>
        double OdchylenieStandardowePopulacji(ArrayList populacja, double srednia);

        /// <summary>
        /// Metoda poszukująca najlepszego rozwiązania znalezionego do tej pory
        /// </summary>
        /// <param name="geny">Tablica definiująca dziedzinę rozwiązania</param>
        void ZmienWartoscNiebo(ReprezentacjaGenotypu geny);

        /// <summary>
        /// Metoda zwracająca najlepszą dziedzinę rozwiązania
        /// </summary>
        ReprezentacjaGenotypu ZwrocNajlepszyGenotyp();

        /// <summary>
        /// Metoda zwracająca najlepszą znalezioną wartość
        /// </summary>
        string[] ZwrocWartoscNiebo();

        /// <summary>
        /// Metoda rozpoczynająca odliczanie czasu
        /// </summary>
        void RozpocznijPomiarCzasu();

        /// <summary>
        /// Metoda zakańczająca odliczanie czasu
        /// </summary>
        void ZakonczPomiarCzasu();

        /// <summary>
        /// Metoda zwracająca czas działania algorytmu
        /// </summary>
        double ZwrocCzasDzialaniaAlgorytmu();
    }
}
