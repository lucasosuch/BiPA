using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Wynik
{
    class WynikGenotypu1Wymiarowego : AWynik
    {
        public WynikGenotypu1Wymiarowego(ALosowanie losowanie, ProblemOptymalizacyjny problemOptymalizacyjny) : base(losowanie, problemOptymalizacyjny)
        {
            SzukajNajlepszegoRozwiazania(losowanie, problemOptymalizacyjny);
        }

        private void SzukajNajlepszegoRozwiazania(ALosowanie losowanie, ProblemOptymalizacyjny problemOptymalizacyjny)
        {
            ArrayList listaRozwiazan = losowanie.LosujRozwiazania();

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
