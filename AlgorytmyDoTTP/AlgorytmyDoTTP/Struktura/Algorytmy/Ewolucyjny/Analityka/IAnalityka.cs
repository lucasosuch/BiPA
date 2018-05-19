using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Analityka
{
    interface IAnalityka
    {
        // Zwraca wartość średnią z funkcji celów w populacji
        double SredniaPopulacji(ArrayList populacja);

        // Zwraca wartość odchylenia standardowego z funkcji celów w populacji
        double OdchylenieStandardowePopulacji(ArrayList populacja, double srednia);

        void ZmienWartoscNiebo(ushort[] geny);

        ushort[] ZwrocNajlepszyGenotyp();

        string ZwrocWartoscNiebo();
    }
}
