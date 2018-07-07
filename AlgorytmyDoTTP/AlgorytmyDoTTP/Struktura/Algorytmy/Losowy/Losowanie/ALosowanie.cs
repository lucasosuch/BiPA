using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie
{
    abstract class ALosowanie
    {
        protected AOsobnik osobnik;
        protected ReprezentacjaRozwiazania najlepszeRozwiazanie;
        protected Dictionary<string, double[]> najlepszyWynik;

        public ALosowanie() { }

        public ALosowanie(AOsobnik osobnik)
        {
            this.osobnik = osobnik;
        }

        /// <summary>
        /// Metoda zwraca najlepsze znalezione rozwiązanie
        /// </summary>
        /// <returns>Najlepsze rozwiązanie</returns>
        public ReprezentacjaRozwiazania ZwrocNajlepszeRozwiazanie()
        {
            return najlepszeRozwiazanie;
        }

        /// <summary>
        /// Metoda zwraca najlepszy wynik
        /// </summary>
        /// <returns>Najlepszy wynik funkcji</returns>
        public Dictionary<string, double[]> ZwrocNajlepszyWynik()
        {
            return najlepszyWynik;
        }

        /// <summary>
        /// Metoda przeszukuje przestrzeń w celu znalezienia najlepszego rozwiązania dla tablicy 1 wymiarowej
        /// </summary>
        /// <param name="listaRozwiazan">Wartość pozwalająca ustalić, czy sprawdzamy ograniczenia</param>
        public void SzukajNajlepszegoRozwiazania(int iloscRozwiazan, int iloscElementow)
        {
            ReprezentacjaRozwiazania[] listaRozwiazan = LosujRozwiazania(iloscRozwiazan, iloscElementow);

            najlepszeRozwiazanie = listaRozwiazan[0];
            najlepszyWynik = osobnik.FunkcjaDopasowania(listaRozwiazan[0]);
            ProblemOptymalizacyjny problemOptymalizacyjny = osobnik.ZwrocInstancjeProblemu();

            int iterator = 1;
            while (problemOptymalizacyjny.CzyIstniejaOgraniczenia() && (najlepszyWynik["min"][0] > problemOptymalizacyjny.ZwrocOgraniczeniaProblemu()[0]))
            {
                najlepszeRozwiazanie = listaRozwiazan[iterator];
                najlepszyWynik = osobnik.FunkcjaDopasowania(listaRozwiazan[iterator]);
                iterator++;
            }

            foreach (ReprezentacjaRozwiazania rozwiazanie in listaRozwiazan)
            {
                Dictionary<string, double[]> wynikElementu = osobnik.FunkcjaDopasowania(rozwiazanie);

                if (wynikElementu["max"][0] > najlepszyWynik["max"][0])
                {
                    if (problemOptymalizacyjny.CzyIstniejaOgraniczenia() && (wynikElementu["min"][0] > problemOptymalizacyjny.ZwrocOgraniczeniaProblemu()[0])) continue;

                    najlepszeRozwiazanie = rozwiazanie;
                    najlepszyWynik = wynikElementu;
                }
            }
        }

        /// <summary>
        /// Metoda odpowiedzialna za wylosowanie rozwiązań, bez uwzględnienia problemu optymalizacyjnego
        /// </summary>
        /// <param name="iloscRozwiazan">Wartość pozwalająca ustalić, czy sprawdzamy ograniczenia</param>
        /// <param name="iloscElementow">Wartość pozwalająca ustalić, czy sprawdzamy ograniczenia</param>
        /// <returns>Lista osobników - rozwiązań</returns>
        public abstract ReprezentacjaRozwiazania[] LosujRozwiazania(int iloscRozwiazan, int iloscElementow);

        /// <summary>
        /// Metoda odpowiedzialna za wylosowanie rozwiązań, z uwzględnieniem problemu optymalizacyjnego
        /// </summary>
        /// <param name="problemOptymalizacyjny">Wartość pozwalająca ustalić, czy sprawdzamy ograniczenia</param>
        /// <param name="iloscRozwiazan">Wartość pozwalająca ustalić, czy sprawdzamy ograniczenia</param>
        /// <returns>Lista osobników - rozwiązań</returns>
        public abstract ReprezentacjaRozwiazania[] LosujRozwiazania(ProblemOptymalizacyjny problemOptymalizacyjny, int iloscRozwiazan);
    }
}
