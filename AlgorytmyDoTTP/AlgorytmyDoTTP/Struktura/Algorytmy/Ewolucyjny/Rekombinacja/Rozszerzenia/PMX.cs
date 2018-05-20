using System;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja.Rozszerzenia
{
    class PMX
    {
        private ushort[] przodek1;
        private ushort[] przodek2;
        private Random losowy = new Random();

        public PMX(ushort[] przodek1, ushort[] przodek2)
        {
            this.przodek1 = przodek1;
            this.przodek2 = przodek2;
        }

        public ushort[] ZwrocPotomka()
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

            for (int i = 0; i < potomek.Length; i++)
            {
                for (int j = potomek.Length - 1; j > 0; j--)
                {
                    if ((potomek[i] == potomek[j]) && (j != i))
                    {
                        for (int k = 0; k < przodek2.Length; k++)
                        {
                            Boolean zawiera = false;
                            for (int l = 0; l < potomek.Length; l++)
                            {
                                if (przodek2[k] == potomek[l]) zawiera = true;
                            }

                            if (!zawiera) potomek[j] = przodek2[k];
                        }
                    }
                }
            }

            return potomek;
        }
    }
}
