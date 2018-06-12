using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie
{
    interface ILosowanie
    {
        ArrayList LosujRozwiazania(int iloscRozwiazan, int iloscElementow);

        ArrayList LosujRozwiazania(int iloscRozwiazan, int iloscElementow, int maxAllel);

        ArrayList LosujRozwiazania(int iloscRozwiazan, int iloscElementow, int maxAllel, ushort[][] dostepnoscPrzedmiotow);
    }
}
