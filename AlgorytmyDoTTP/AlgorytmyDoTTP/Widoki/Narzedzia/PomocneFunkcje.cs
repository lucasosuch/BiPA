using System;
using System.Linq;

namespace BiPA.Widoki.Narzedzia
{
    class PomocneFunkcje
    {
        private Random losowy = new Random();

        public string LosowyTekst(int poczatek, int dlugosc)
        {
            int liczbaZnakow = losowy.Next(poczatek, dlugosc);

            const string znaki = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(znaki, dlugosc).Select(s => s[losowy.Next(s.Length)]).ToArray());
        }
    }
}
