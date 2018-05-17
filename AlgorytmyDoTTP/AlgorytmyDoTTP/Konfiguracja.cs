using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP
{
    class Konfiguracja
    {
        public readonly object[] ALGORYTMY = new object[] 
        {
            "Algorytm Ewolucyjny", "Algorytm Wspinaczkowy", "Algorytm Losowy"
        };

        public readonly object[] PROBLEMY_OPTYMALIZACYJNE = new object[] 
        {
            "Problem Plecakowy", "Problem Komiwojażera", "Problem Podróżującego Złodzieja"
        };

        public readonly string[] FOLDERY_Z_DANYMI = new string[] 
        {
            "kp", "tsp", "ttp"
        };

        public readonly object[] KRZYZOWANIE_TSP = new object[] 
        {
            "PMX", "OX", "CX", "Wymiana podtras"
        };

        public readonly object[] SELEKCJA = new object[]
        {
            "Turniej", "Metoda ruletki", "Ruletka turniejowa"
        };
    }
}
