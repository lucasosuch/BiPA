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
        protected Dictionary<string, float[]> najlepszyWynik;

        public ALosowanie() { }

        public ALosowanie(AOsobnik osobnik)
        {
            this.osobnik = osobnik;
        }

        /// <summary>
        /// Metoda zwraca instancję osobnika / rozwiązania Problemu Optymalizacyjnego
        /// </summary>
        /// <returns>Instancję osobnika</returns>
        public AOsobnik ZwrocOsobnika()
        {
            return osobnik;
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
        public Dictionary<string, float[]> ZwrocNajlepszyWynik()
        {
            return najlepszyWynik;
        }

        /// <summary>
        /// Metoda przeszukuje przestrzeń w celu znalezienia najlepszego rozwiązania dla tablicy 1 wymiarowej
        /// </summary>
        /// <param name="listaRozwiazan">Wartość pozwalająca ustalić, czy sprawdzamy ograniczenia</param>
        public void SzukajNajlepszegoRozwiazania(int iloscRozwiazan, int iloscElementow)
        {
            ProblemOptymalizacyjny problemOptymalizacyjny = osobnik.ZwrocInstancjeProblemu();
            ReprezentacjaRozwiazania[] listaRozwiazan = LosujRozwiazania(problemOptymalizacyjny, iloscRozwiazan, iloscElementow);

            if (!problemOptymalizacyjny.CzyIstniejaOgraniczenia())
            {
                najlepszeRozwiazanie = listaRozwiazan[0];
                najlepszyWynik = osobnik.FunkcjaDopasowania(listaRozwiazan[0]);
            }

            //System.Console.WriteLine(najlepszyWynik["max"][0] + " " + najlepszyWynik["min"][0]);

            int iterator = 1;
            while (problemOptymalizacyjny.CzyIstniejaOgraniczenia())
            {
                if(osobnik.FunkcjaDopasowania(listaRozwiazan[iterator])["min"][0] <= problemOptymalizacyjny.ZwrocOgraniczeniaProblemu()[0])
                {
                    najlepszeRozwiazanie = listaRozwiazan[iterator];
                    najlepszyWynik = osobnik.FunkcjaDopasowania(listaRozwiazan[iterator]);
                }
                    
                iterator++;

                if (listaRozwiazan.Length == iterator) break;
            }

            foreach (ReprezentacjaRozwiazania rozwiazanie in listaRozwiazan)
            {
                Dictionary<string, float[]> wynikElementu = osobnik.FunkcjaDopasowania(rozwiazanie);

                if ((najlepszyWynik != null) && (wynikElementu["max"][0] > najlepszyWynik["max"][0]))
                {
                    if (problemOptymalizacyjny.CzyIstniejaOgraniczenia() && (wynikElementu["min"][0] > problemOptymalizacyjny.ZwrocOgraniczeniaProblemu()[0])) continue;

                    najlepszeRozwiazanie = rozwiazanie;
                    najlepszyWynik = wynikElementu;
                }
            }
        }

        /// <summary>
        /// Metoda odpowiedzialna za wylosowanie rozwiązań, z uwzględnieniem problemu optymalizacyjnego
        /// </summary>
        /// <param name="problemOptymalizacyjny">Wartość pozwalająca ustalić, czy sprawdzamy ograniczenia</param>
        /// <param name="iloscRozwiazan">Wartość pozwalająca ustalić, czy sprawdzamy ograniczenia</param>
        /// <returns>Lista osobników - rozwiązań</returns>
        public abstract ReprezentacjaRozwiazania[] LosujRozwiazania(ProblemOptymalizacyjny problemOptymalizacyjny, int iloscRozwiazan, int iloscElementow);
    }
}
