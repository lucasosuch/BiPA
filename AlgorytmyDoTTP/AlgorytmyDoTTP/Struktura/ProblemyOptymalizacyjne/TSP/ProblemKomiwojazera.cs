using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TSP
{
    class ProblemKomiwojazera : ProblemOptymalizacyjny
    {
        private Instancja[] instancje;

        public ProblemKomiwojazera(ushort iloscWierzcholkow)
        {
            this.Inicjalizacja(iloscWierzcholkow);
        }

        private void Inicjalizacja(ushort iloscWierzcholkow)
        {
            instancje = new Instancja[iloscWierzcholkow * (iloscWierzcholkow - 1)];

            instancje[0] = new Instancja(1, 2, 10.0);
            instancje[1] = new Instancja(1, 3, 5.0);
            instancje[2] = new Instancja(1, 4, 7.0);
            instancje[3] = new Instancja(1, 5, 6.5);
            instancje[4] = new Instancja(1, 6, 5.5);
            instancje[5] = new Instancja(2, 3, 6.0);
            instancje[6] = new Instancja(2, 4, 3.0);
            instancje[7] = new Instancja(2, 5, 8.0);
            instancje[8] = new Instancja(2, 6, 2.5);
            instancje[9] = new Instancja(3, 4, 9.5);
            instancje[10] = new Instancja(3, 5, 1.5);
            instancje[11] = new Instancja(3, 6, 4.0);
            instancje[12] = new Instancja(4, 5, 8.0);
            instancje[13] = new Instancja(4, 6, 7.0);
            instancje[14] = new Instancja(5, 6, 3.0);
        }

        private double ObliczDlugoscTrasy(ArrayList wektor)
        {
            double wynik = 0;
            int dlugoscWekotra = wektor.Count;

            for (int i = 0; i < dlugoscWekotra; i++)
            {
                int j = (i == 0) ? dlugoscWekotra - 1 : i - 1;

                foreach (Instancja instancja in instancje)
                {
                    if (instancja.ZwrocOd() == (short)wektor[j] && instancja.ZwrocDo() == (short)wektor[i])
                    {
                        wynik += instancja.ZwrocDlugosc();
                    } else if(instancja.ZwrocDo() == (short)wektor[j] && instancja.ZwrocOd() == (short)wektor[i])
                    {
                        wynik += instancja.ZwrocDlugosc();
                    }
                }
            }

            return wynik;
        }

        public override double[] ObliczZysk(ArrayList wektor)
        {
            return new double[] { ObliczDlugoscTrasy(wektor) * -1 };
        }
    }
}