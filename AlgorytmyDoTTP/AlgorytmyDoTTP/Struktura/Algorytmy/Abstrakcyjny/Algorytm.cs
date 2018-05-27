using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny
{
    abstract class Algorytm
    {
        /// <summary>
        /// Metoda odpowiedzialna za uruchomienie algorytmu wg wybranego problemu optymalizacyjnego
        /// </summary>
        /// <param name="parametry">Zdefiniowane przez użytkownika parametry</param>
        /// <param name="problem">Wybrany przez użytkownika problem optymalizacyjny</param>
        public abstract IAlgorytm ZbudujAlgorytm(Dictionary<string, string> parametry, ProblemOptymalizacyjny problem);
    }
}
