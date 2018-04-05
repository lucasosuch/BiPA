using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP
{
    class ProblemPlecakowy
    {
        private double wagaPlecaka;
        private double wartoscPlecaka;
        private double maxWagaPlecaka;

        public ProblemPlecakowy(Dictionary<int, double> Macierz)
        {
            Instancja przedmiot = new Instancja();
        }

        public void ustawMaxWagePlecaka(double maxWagaPlecaka)
        {
            this.maxWagaPlecaka = maxWagaPlecaka;
        }
    }
}
