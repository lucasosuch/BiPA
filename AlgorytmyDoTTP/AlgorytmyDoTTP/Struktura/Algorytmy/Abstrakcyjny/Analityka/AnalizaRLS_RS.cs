using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka
{
    /// <summary>
    /// Klasa analityczna.
    /// Podstawowa klasa pod analizę dla algorytmu wspinaczkowego oraz algorytmu losowego.
    /// </summary>
    class AnalizaRLS_RS: AAnalityka
    {
        public AnalizaRLS_RS(AOsobnik rozwiazanie, short liczbaIteracji, short czasDzialania, string[] nazwyPlikow) : base(rozwiazanie, liczbaIteracji, czasDzialania, nazwyPlikow) {}
    }
}
