using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TTP
{
    class ProblemPodrozujacegoZlodzieja : ProblemOptymalizacyjny
    {
        public override Dictionary<string, double[]> ObliczZysk(Dictionary<string, double[]> wektor)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, ushort[]> ZwrocWybraneElementy(ushort[][] wybraneElementy)
        {
            Dictionary<string, ushort[]> wynik = new Dictionary<string, ushort[]>();

            wynik["tsp"] = (ushort[])(wybraneElementy[0].Clone());
            wynik["kp"] = (ushort[])(wybraneElementy[1].Clone());

            return wynik;
        }

        public override ArrayList ZwrocWybraneElementy(ushort[] wybraneElementy)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, double[]> ObliczZysk(ArrayList wektor)
        {
            throw new NotImplementedException();
        }
    }
}
