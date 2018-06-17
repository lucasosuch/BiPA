using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Losowy.Wynik
{
    abstract class AWynik
    {
        protected ArrayList listaRozwiazan;
        protected ReprezentacjaRozwiazania najlepszeRozwiazanie;
        protected Dictionary<string, double[]> najlepszyWynik;

        public AWynik(ArrayList listaRozwiazan, ProblemOptymalizacyjny problemOptymalizacyjny)
        {
            this.listaRozwiazan = listaRozwiazan;
            najlepszyWynik = new Dictionary<string, double[]>();
        }

        public ReprezentacjaRozwiazania ZwrocNajlepszeRozwiazanie()
        {
            return najlepszeRozwiazanie;
        }

        public Dictionary<string, double[]> ZwrocNajlepszyWynik()
        {
            return najlepszyWynik;
        }

        public ArrayList ZwrocListeRozwiazan()
        {
            return listaRozwiazan;
        }

        //protected void SzukajNajlepszegoRozwiazania(ArrayList listaRozwiazan, ProblemOptymalizacyjny problemOptymalizacyjny)
        //{
        //    najlepszeRozwiazanie = (ReprezentacjaRozwiazania)listaRozwiazan[0];

        //    if(ZwrocKodowanieChromosomu(najlepszeRozwiazanie) == "ushort[]")
        //    {
        //        najlepszyWynik = problemOptymalizacyjny.ObliczZysk(problemOptymalizacyjny.ZwrocWybraneElementy(najlepszeRozwiazanie.ZwrocGenotyp1Wymiarowy()));
        //    } else if(ZwrocKodowanieChromosomu(najlepszeRozwiazanie) == "ushort[][]")
        //    {
        //        najlepszyWynik = problemOptymalizacyjny.ObliczZysk(problemOptymalizacyjny.ZwrocWybraneElementy(najlepszeRozwiazanie.ZwrocGenotyp2Wymiarowy()));
        //    }

        //    int iterator = 1;
        //    while (problemOptymalizacyjny.CzyIstniejaOgraniczenia() && (najlepszyWynik["min"][0] > problemOptymalizacyjny.ZwrocOgraniczeniaProblemu()[0]))
        //    {
        //        najlepszeRozwiazanie = (ReprezentacjaRozwiazania)listaRozwiazan[iterator];
        //        najlepszyWynik = problemOptymalizacyjny.ObliczZysk(problemOptymalizacyjny.ZwrocWybraneElementy(najlepszeRozwiazanie.ZwrocGenotyp2Wymiarowy()));
        //        iterator++;
        //    }

        //    foreach (ReprezentacjaRozwiazania elementy in listaRozwiazan)
        //    {
        //        Dictionary<string, double[]> wynikElementu = problemOptymalizacyjny.ObliczZysk(problemOptymalizacyjny.ZwrocWybraneElementy(elementy.ZwrocGenotyp2Wymiarowy()));

        //        if (wynikElementu["max"][0] > najlepszyWynik["max"][0])
        //        {
        //            if (problemOptymalizacyjny.CzyIstniejaOgraniczenia() && (wynikElementu["min"][0] > problemOptymalizacyjny.ZwrocOgraniczeniaProblemu()[0])) continue;

        //            najlepszeRozwiazanie = elementy;
        //            najlepszyWynik = wynikElementu;
        //        }
        //    }
        //}

        //protected string ZwrocKodowanieChromosomu(ReprezentacjaRozwiazania rozwiazanie)
        //{
        //    string kodowanieChromosomu = "";

        //    if (!(rozwiazanie.ZwrocGenotyp1Wymiarowy() == null || rozwiazanie.ZwrocGenotyp1Wymiarowy().Length == 0))
        //    {
        //        kodowanieChromosomu = "uint[]";
        //    }

        //    if (!(rozwiazanie.ZwrocGenotyp2Wymiarowy() == null || rozwiazanie.ZwrocGenotyp2Wymiarowy().Length == 0))
        //    {
        //        kodowanieChromosomu = "uint[][]";
        //    }

        //    return kodowanieChromosomu;
        //}
    }
}
