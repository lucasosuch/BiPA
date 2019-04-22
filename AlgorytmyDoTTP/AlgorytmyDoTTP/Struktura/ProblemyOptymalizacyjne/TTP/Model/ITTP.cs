using BiPA.Struktura.ProblemyOptymalizacyjne.KP;
using System.Collections.Generic;

namespace BiPA.Struktura.ProblemyOptymalizacyjne.TTP.Model
{
    interface ITTP 
    {
        Dictionary<string, float[]> ObliczWartoscFunkcjiCelu(float[] dlugosciTrasy, ushort[][] mapaPrzedmiotow, float[] ograniczeniaProblemu, ProblemPlecakowy problemPlecakowy);
    }
}
