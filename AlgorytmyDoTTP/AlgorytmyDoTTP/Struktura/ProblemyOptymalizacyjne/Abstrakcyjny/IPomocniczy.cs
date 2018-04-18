using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny
{
    interface IPomocniczy
    {
        short ZwrocOd();

        short ZwrocDo();

        double ZwrocDlugosc();

        double ZwrocWage();

        double ZwrocWartosc();
    }
}
