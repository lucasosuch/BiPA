using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja.Rozszerzenia
{
    class OX : AMetodaKrzyzowania
    {
        public OX(ushort[] przodek1, ushort[] przodek2) : base(przodek1, przodek2){}

        public override ushort[] ZwrocPotomka()
        {
            int ciecie1 = losowy.Next(0, przodek1.Length),
                ciecie2 = losowy.Next(0, przodek1.Length);

            ushort[] potomek = new ushort[przodek1.Length];

            for (int k = 0; k < potomek.Length; k++)
            {
                potomek[k] = 0;
            }

            while (ciecie1 == ciecie2)
            {
                ciecie2 = losowy.Next(0, przodek1.Length);
            }

            int start = (ciecie1 < ciecie2) ? ciecie1 : ciecie2,
                koniec = (ciecie1 < ciecie2) ? ciecie2 : ciecie1;

            for(int i = start; i <= koniec; i++)
            {
                potomek[i] = przodek1[i];
            }

            for (int i = 0; i < przodek2.Length; i++)
            {
                if (!potomek.Contains(przodek2[i]))
                {
                    for (int j = 0; j < potomek.Length; j++)
                    {
                        if (potomek[j] == 0)
                        {
                            potomek[j] = przodek2[i];
                            break;
                        }
                    }
                }
            }

            return potomek;
        }
    }
}
