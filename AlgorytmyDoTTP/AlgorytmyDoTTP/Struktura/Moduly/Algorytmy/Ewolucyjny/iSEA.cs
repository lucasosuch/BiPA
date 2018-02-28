using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Moduly.Algorytmy.Ewolucyjny
{
    interface iSEA
    {
        ushort Turniej(ushort[] populacja);
        ushort[] StworzPopulacje(ushort rozmiarPopulacji);
        double FunkcjaDopasowania(double x);
        double Fenotyp(ushort genotyp);
        ushort Krzyzowanie(ushort mama, ushort tata);
        ushort Mutacja(ushort geny);
    }
}
