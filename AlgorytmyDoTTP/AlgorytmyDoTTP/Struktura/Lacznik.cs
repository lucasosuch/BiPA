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
        private List<Algorytm<object>> listaAlgorytmow = new List<Algorytm<object>>();
        private List<ProblemOptymalizacyjny> listaProblemow = new List<ProblemOptymalizacyjny>();

        public Lacznik()
        {
            string[] parametryEwolucyjny = new string[] {
                "Ilość pokoleń", "Rozmiar populacji", "Prawdopodobieństwo krzyżowania", "Prawdopodobieństwo mutacji"
            };

            Algorytm<object> ewolucyjny = new Algorytm<object>("Ewolucyjny", parametryEwolucyjny);
            listaAlgorytmow.Add(ewolucyjny);

            ProblemOptymalizacyjny kp = new ProblemOptymalizacyjny("Problem Plecakowy", "testowa");
            listaProblemow.Add(kp);
        }

        public List<Algorytm<object>> ZwrocListeAlgorytmow()
        {
            return listaAlgorytmow;
        }

        public List<ProblemOptymalizacyjny> ZwrocListeProblemow()
        {
            return listaProblemow;
        }
    }
}
