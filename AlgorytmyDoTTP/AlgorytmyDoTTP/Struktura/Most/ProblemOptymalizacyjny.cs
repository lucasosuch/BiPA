using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Most
{
    class ProblemOptymalizacyjny
    {
        private string nazwa;
        private string sciezka;

        public ProblemOptymalizacyjny(string nazwa, string sciezka)
        {
            this.nazwa = nazwa;
            this.sciezka = sciezka;
        }

        public string ZwrocNazwe()
        {
            return nazwa;
        }

        public string ZwrocSciezke()
        {
            return sciezka;
        }
    }
}
