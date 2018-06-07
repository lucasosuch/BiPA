using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Losowanie;
using AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Rozwiazanie;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy
{
    class RLS : IAlgorytm
    {
        private ALosowanie losowanie;
        private ARozwiazanie rozwiazanie;

        public RLS()
        {
            throw new Exception();
        }

        public RLS(ALosowanie losowanie, ARozwiazanie rozwiazanie)
        {
            this.losowanie = losowanie;
            this.rozwiazanie = rozwiazanie;
        }

        public Dictionary<string, string[]> Start()
        {
            ArrayList listaRozwiazan = losowanie.LosujRozwiazania();
            Dictionary<string, string[]> zwracanyTekst = new Dictionary<string, string[]>();
            
            rozwiazanie.UstawRozwiazanie(ZwrocNajlepszeRozwiazanie(listaRozwiazan));
            Dictionary<string, double[]> znalezioneOptimum = rozwiazanie.ZnajdzOptimum();
            ushort[] wynik = (ushort[])(rozwiazanie.ZwrocRozwiazanie().ZwrocGenotyp1Wymiarowy().Clone());

            zwracanyTekst["dziedzina"] = new string[] { "Najlepszy genotyp", string.Join(",", wynik) };
            zwracanyTekst["maxWartosc"] = new string[] { "Najlepsza funkcja przystosowania", znalezioneOptimum["max"][0].ToString() +" | "+ znalezioneOptimum["min"][0].ToString() };

            return zwracanyTekst;
        }

        private ReprezentacjaRozwiazania ZwrocNajlepszeRozwiazanie(ArrayList listaRozwiazan)
        {
            ProblemOptymalizacyjny problemOptymalizacyjny = rozwiazanie.ZwrocProblemOptymalizacyjny();

            ReprezentacjaRozwiazania najlepszeRozwiazanie = (ReprezentacjaRozwiazania)listaRozwiazan[0];
            Dictionary<string, double[]> najlepszyWynik = problemOptymalizacyjny.ObliczZysk(problemOptymalizacyjny.ZwrocWybraneElementy(najlepszeRozwiazanie.ZwrocGenotyp1Wymiarowy()));

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

            return najlepszeRozwiazanie;
        }
    }
}
