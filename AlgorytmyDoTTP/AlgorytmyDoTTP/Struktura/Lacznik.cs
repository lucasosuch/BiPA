using AlgorytmyDoTTP.Struktura.Most;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura
{
    class Lacznik
    {
        private List<Algorytm> listaAlgorytmow = new List<Algorytm>();
        private List<ProblemOptymalizacyjny> listaProblemow = new List<ProblemOptymalizacyjny>();

        public Lacznik()
        {
            Algorytm ewolucyjny = new Algorytm("Ewolucyjny");
            listaAlgorytmow.Add(ewolucyjny);

            ProblemOptymalizacyjny kp = new ProblemOptymalizacyjny("Problem Plecakowy", "testowa");
            listaProblemow.Add(kp);
        }

        public List<Algorytm> ZwrocListeAlgorytmow()
        {
            return listaAlgorytmow;
        }

        public List<ProblemOptymalizacyjny> ZwrocListeProblemow()
        {
            return listaProblemow;
        }
    }
}
