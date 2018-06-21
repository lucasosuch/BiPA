using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie
{
    interface ILosowanie
    {
        ArrayList LosujRozwiazania(int iloscRozwiazan, int iloscElementow);

        ArrayList LosujRozwiazania(ProblemOptymalizacyjny problemOptymalizacyjny, int iloscRozwiazan);
    }
}
