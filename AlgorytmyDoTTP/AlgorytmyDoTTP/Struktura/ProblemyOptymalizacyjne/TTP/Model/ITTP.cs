using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TTP.Model
{
    interface ITTP 
    {
        Dictionary<string, double[]> ObliczWartoscFunkcjiCelu(double[] dlugosciTrasy, ushort[][] mapaPrzedmiotow, double[] ograniczeniaProblemu, ProblemPlecakowy problemPlecakowy);
    }
}
