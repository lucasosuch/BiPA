using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Analityka
{
    interface IAnalityka
    {
        // Zwraca wartość średnią z funkcji celów w populacji
        double SredniaPopulacji(ArrayList populacja);

        // Zwraca wartość odchylenia standardowego z funkcji celów w populacji
        double OdchylenieStandardowePopulacji(ArrayList populacja, double srednia);
    }
}
