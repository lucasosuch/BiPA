using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny
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
        void ZmienWartoscNiebo(ReprezentacjaRozwiazania geny);

        /// <summary>
        /// Metoda zwracająca najlepszą dziedzinę rozwiązania
        /// </summary>
        ReprezentacjaRozwiazania ZwrocNajlepszyGenotyp();

        string ZwrocNajlepszeRowziazanie();

        /// <summary>
        /// Metoda zwracająca najlepszą znalezioną wartość
        /// </summary>
        string[] ZwrocWartoscNiebo();
    }
}
