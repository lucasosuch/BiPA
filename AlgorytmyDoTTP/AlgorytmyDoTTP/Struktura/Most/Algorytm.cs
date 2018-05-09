using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Most
{
    class Algorytm<T>
    {
        private String nazwa;
        private T[] parametry;

        public Algorytm(String nazwa, T[] parametry)
        {
            this.nazwa = nazwa;
            this.parametry = parametry;
        }

        public String ZwrocNazwe()
        {
            return nazwa;
        }

        public T[] ZwrocParamentry()
        {
            return parametry;
        }
    }
}
