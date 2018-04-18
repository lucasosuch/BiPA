using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny
{
    abstract class ProblemOptymalizacyjny
    {
        public abstract double[] ObliczZysk(ArrayList wektor);
    }
}
