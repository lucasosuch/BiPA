using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Osobnik;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka
{
    /// <summary>
    /// Klasa analityczna.
    /// Podstawowa klasa pod analizę dla algorytmu wspinaczkowego oraz algorytmu losowego.
    /// </summary>
    class AnalizaRLS_RS: AAnalityka
    {
        public AnalizaRLS_RS(AOsobnik rozwiazanie, short liczbaIteracji, short czasDzialania) : base(rozwiazanie, liczbaIteracji, czasDzialania) {}
    }
}
