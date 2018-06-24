using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Wynik
{
    /// <summary>
    /// Klasa konkretna szukająca najlepszego rozwiązania w liście rozwiązań dla 1 wymiarowej tablicy
    /// </summary>
    class WynikGenotypu1Wymiarowego : AWynik
    {
        public WynikGenotypu1Wymiarowego(ArrayList listaRozwiazan, ProblemOptymalizacyjny problemOptymalizacyjny) : base(listaRozwiazan, problemOptymalizacyjny)
        {
            SzukajNajlepszegoRozwiazania(listaRozwiazan, problemOptymalizacyjny);
        }

        /// <summary>
        /// Metoda przeszukuje przestrzeń w celu znalezienia najlepszego rozwiązania dla tablicy 1 wymiarowej
        /// </summary>
        /// <param name="listaRozwiazan">Wartość pozwalająca ustalić, czy sprawdzamy ograniczenia</param>
        /// <param name="problemOptymalizacyjny">Wartość pozwalająca ustalić, czy sprawdzamy ograniczenia</param>
        private void SzukajNajlepszegoRozwiazania(ArrayList listaRozwiazan, ProblemOptymalizacyjny problemOptymalizacyjny)
        {
            najlepszeRozwiazanie = (ReprezentacjaRozwiazania)listaRozwiazan[0];
            najlepszyWynik = problemOptymalizacyjny.ObliczZysk(problemOptymalizacyjny.ZwrocWybraneElementy(najlepszeRozwiazanie.ZwrocGenotyp1Wymiarowy()));

            int iterator = 1;
            while (problemOptymalizacyjny.CzyIstniejaOgraniczenia() && (najlepszyWynik["min"][0] > problemOptymalizacyjny.ZwrocOgraniczeniaProblemu()[0]))
            {
                najlepszeRozwiazanie = (ReprezentacjaRozwiazania)listaRozwiazan[iterator];
                najlepszyWynik = problemOptymalizacyjny.ObliczZysk(problemOptymalizacyjny.ZwrocWybraneElementy(najlepszeRozwiazanie.ZwrocGenotyp1Wymiarowy()));
                iterator++;
            }

            foreach (ReprezentacjaRozwiazania elementy in listaRozwiazan)
            {
                Dictionary<string, double[]> wynikElementu = problemOptymalizacyjny.ObliczZysk(problemOptymalizacyjny.ZwrocWybraneElementy(elementy.ZwrocGenotyp1Wymiarowy()));

                if (wynikElementu["max"][0] > najlepszyWynik["max"][0])
                {
                    if (problemOptymalizacyjny.CzyIstniejaOgraniczenia() && (wynikElementu["min"][0] > problemOptymalizacyjny.ZwrocOgraniczeniaProblemu()[0])) continue;

                    najlepszeRozwiazanie = elementy;
                    najlepszyWynik = wynikElementu;
                }
            }
        }
    }
}
