using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka
{
    /// <summary>
    /// Klasa analityczna.
    /// Rozszerzenie podstawowej klasy analitycznej, dla Algorytmu Ewolucyjnego.
    /// </summary>
    class AnalizaEwolucyjny : AAnalityka
    {
        public AnalizaEwolucyjny(AOsobnik rozwiazanie, short liczbaIteracji, short czasDzialania, string[] nazwyPlikow) : base(rozwiazanie, liczbaIteracji, czasDzialania, nazwyPlikow) {}
    }
}
