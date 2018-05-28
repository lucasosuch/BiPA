using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja.Ograniczenia
{
    abstract class ANaprawaGenotypu
    {
        protected ushort[] geny;
        protected Random losowy = new Random();

        public ANaprawaGenotypu(ushort[] geny)
        {
            this.geny = geny;
        }

        public abstract void NaprawGeny();

        public ushort[] ZwrocGeny()
        {
            return geny;
        }
    }
}
