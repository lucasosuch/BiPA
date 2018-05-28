using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja.Rozszerzenia
{
    class CX : AMetodaKrzyzowania
    {
        public CX(ushort[] przodek1, ushort[] przodek2) : base(przodek1, przodek2){}

        public override ushort[] ZwrocPotomka()
        {
            ushort i = 0;
            ushort[] potomek = new ushort[przodek1.Length];

            for(int k = 0; k < potomek.Length; k++)
            {
                potomek[k] = 0;
            }
            
            while(!potomek.Contains(przodek2[i]))
            {
                ushort j = (ushort)(przodek2[i] - 1);
                potomek[j] = przodek1[j];
                i = j;
            }

            for(int k = 0; k < potomek.Length; k++)
            {
                if(potomek[k] == 0)
                {
                    potomek[k] = przodek2[k];
                }
            }

            return potomek;
        }
    }
}
