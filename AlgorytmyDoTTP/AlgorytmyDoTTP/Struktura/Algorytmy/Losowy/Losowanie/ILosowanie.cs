using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie
{
    interface ILosowanie
    {
        /// <summary>
        /// Metoda odpowiedzialna za wylosowanie rozwiązań, bez uwzględnienia problemu optymalizacyjnego
        /// </summary>
        /// <param name="iloscRozwiazan">Wartość pozwalająca ustalić, czy sprawdzamy ograniczenia</param>
        /// <param name="iloscElementow">Wartość pozwalająca ustalić, czy sprawdzamy ograniczenia</param>
        /// <returns>Lista osobników - rozwiązań</returns>
        ReprezentacjaRozwiazania[] LosujRozwiazania(int iloscRozwiazan, int iloscElementow);

        /// <summary>
        /// Metoda odpowiedzialna za wylosowanie rozwiązań, z uwzględnieniem problemu optymalizacyjnego
        /// </summary>
        /// <param name="problemOptymalizacyjny">Wartość pozwalająca ustalić, czy sprawdzamy ograniczenia</param>
        /// <param name="iloscRozwiazan">Wartość pozwalająca ustalić, czy sprawdzamy ograniczenia</param>
        /// <returns>Lista osobników - rozwiązań</returns>
        ReprezentacjaRozwiazania[] LosujRozwiazania(ProblemOptymalizacyjny problemOptymalizacyjny, int iloscRozwiazan);
    }
}
