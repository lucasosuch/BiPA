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
        double SredniaPopulacji(ArrayList populacja);
        double OdchylenieStandardowePopulacji(ArrayList populacja, double srednia);
    }
}
