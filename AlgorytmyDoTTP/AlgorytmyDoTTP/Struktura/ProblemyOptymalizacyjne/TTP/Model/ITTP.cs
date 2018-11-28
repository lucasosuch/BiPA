using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TTP.Model
{
    interface ITTP 
    {
        Dictionary<string, float[]> ObliczWartoscFunkcjiCelu(float[] dlugosciTrasy, ushort[][] mapaPrzedmiotow, float[] ograniczeniaProblemu, ProblemPlecakowy problemPlecakowy);
    }
}
