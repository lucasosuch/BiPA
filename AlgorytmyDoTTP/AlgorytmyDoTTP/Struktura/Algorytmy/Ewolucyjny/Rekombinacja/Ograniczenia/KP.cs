using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja.Ograniczenia
{
    class KP : ANaprawaGenotypu
    {
        public KP(ushort[] geny) : base(geny){}

        public override void NaprawGeny()
        {
            int start = losowy.Next(0, geny.Length / 2),
                koniec = losowy.Next(start, geny.Length);

            for (int i = start; i < koniec; i++)
            {
                geny[i] = (ushort)((geny[i] == 0) ? 1 : 0);
            }
        }
    }
}
