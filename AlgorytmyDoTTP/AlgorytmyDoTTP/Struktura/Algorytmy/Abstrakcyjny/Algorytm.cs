using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny
{
    /// <summary>
    /// Klasa konfiguracyjna.
    /// Będąca łącznikiem pomiędzy problemami optymalizacyjnymi i algorytmem Ewolucyjnym
    /// </summary>
    abstract class Algorytm
    {
        /// <summary>
        /// Metoda odpowiedzialna za uruchomienie algorytmu wg wybranego problemu optymalizacyjnego
        /// </summary>
        /// <param name="parametry">Zdefiniowane przez użytkownika parametry</param>
        /// <param name="problem">Wybrany przez użytkownika problem optymalizacyjny</param>
        /// <returns>Dane tekstowe na temat przebiegu algorytmu</returns>
        /// <exception cref="System.Exception">Zwraca wyjątek gdy algorytm nie rozpatruje wybranego przez użytkownika problemu optymalizacyjnego</exception>
        public abstract IAlgorytm ZbudujAlgorytm(Dictionary<string, string> parametry, ProblemOptymalizacyjny problem);
    }
}
