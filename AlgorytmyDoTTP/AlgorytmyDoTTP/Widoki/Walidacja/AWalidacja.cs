using System.Collections.Generic;

namespace AlgorytmyDoTTP.Widoki.Walidacja
{
    abstract class AWalidacja
    {
        public bool CzyPoprawneZmiennoPrzecinkowe(Dictionary<string, string> parametry, string[] klucze)
        {
            bool wynik = true;

            foreach(string klucz in klucze)
            {
                double wartosc;
                
                if (!double.TryParse(parametry[klucz], out wartosc))
                {
                    wynik = false;
                    break;
                }
            }

            return wynik;
        }

        public bool CzyPoprawneCalkowite(Dictionary<string, string> parametry, string[] klucze)
        {
            bool wynik = true;

            foreach (string klucz in klucze)
            {
                int wartosc;

                if(!int.TryParse(parametry[klucz], out wartosc))
                {
                    wynik = false;
                    break;
                }
            }

            return wynik;
        }

        public bool CzyPustePoleTekstowe(string tekst)
        {
            return tekst != "";
        }
    }
}
