using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Losowanie
{
    abstract class ALosowanie
    {
        protected Random losowy = new Random();

        public abstract ushort[] WygenerujRozwiazanie();
    }
}
