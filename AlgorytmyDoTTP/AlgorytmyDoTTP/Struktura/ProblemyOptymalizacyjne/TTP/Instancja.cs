using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TTP
{
    class Instancja : IPomocniczy
    {
        private ushort[] przedmioty;

        public Instancja(String dostepnePrzedmioty, int iloscPrzedmiotow)
        {
            dostepnePrzedmioty = dostepnePrzedmioty.Replace(" ", "").Trim();
            string[] elementy = dostepnePrzedmioty.Split(',');

            przedmioty = new ushort[iloscPrzedmiotow];
            for (int i = 0; i < iloscPrzedmiotow; i++)
            {
                for(int j = 0; j < elementy.Length; j++)
                {
                    elementy[j] = elementy[j].Replace(" ", "").Trim();
                    przedmioty[i] = (ushort)(((i + 1) == int.Parse(elementy[j])) ? 1 : 0);
                }
            }
        }

        public ushort[] ZwrocPrzedmioty()
        {
            return przedmioty;
        }

        public double ZwrocDlugosc()
        {
            throw new NotImplementedException();
        }

        public short ZwrocDo()
        {
            throw new NotImplementedException();
        }

        public short ZwrocOd()
        {
            throw new NotImplementedException();
        }

        public double ZwrocWage()
        {
            throw new NotImplementedException();
        }

        public double ZwrocWartosc()
        {
            throw new NotImplementedException();
        }
    }
}
