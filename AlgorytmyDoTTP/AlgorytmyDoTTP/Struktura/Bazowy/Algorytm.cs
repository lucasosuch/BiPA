using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura
{
    abstract class Algorytm
    {
        public abstract IAlgorytm ZbudujAlgorytm(double pwoKrzyzowania, double pwoMutacji);
    }
}
