using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja.Rozszerzenia
{
    class PMX
    {
        private Random losowy = new Random();

        public PMX(ushort[] przodek1, ushort[] przodek2)
        {
            int ciecie1 = losowy.Next(0, przodek1.Length),
                ciecie2 = losowy.Next(0, przodek1.Length);

            ushort[] potomek = new ushort[przodek1.Length];

            while (ciecie1 == ciecie2)
            {
                ciecie2 = losowy.Next(0, przodek1.Length);
            }

            int start = (ciecie1 < ciecie2) ? ciecie1 : ciecie2,
                koniec = (ciecie1 < ciecie2) ? ciecie2 : ciecie1;

            potomek = (ushort[])przodek1.Clone();
            for (int i = start; i < koniec; i++)
            {
                potomek[i] = przodek2[i];
            }
        }
    }
}
