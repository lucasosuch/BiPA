using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja.Ograniczenia
{
    class KP
    {
        private ushort[] geny;
        private Random losowy = new Random();

        public KP(ushort[] geny)
        {
            this.geny = geny;
        }

        public void NaprawGeny()
        {
            //Console.WriteLine("Początek: "+ string.Join(",", geny));

            int start = losowy.Next(0, geny.Length / 2),
                koniec = losowy.Next(start, geny.Length);

            //Console.WriteLine("start: " + start + " koniec: "+ koniec);

            for (int i = start; i < koniec; i++)
            {
                geny[i] = (ushort)((geny[i] == 0) ? 1 : 0);
            }

            //Console.WriteLine("Koniec: " + string.Join(",", geny));
        }

        public ushort[] ZwrocGeny()
        {
            return geny;
        }
    }
}
