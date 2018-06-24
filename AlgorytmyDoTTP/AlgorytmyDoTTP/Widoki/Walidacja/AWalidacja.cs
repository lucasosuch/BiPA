using System.Collections.Generic;

namespace AlgorytmyDoTTP.Widoki.Walidacja
{
    /// <summary>
    /// Klasa odpowiada za walidację danych pod Algorytm Ewolucyjny
    /// </summary>
    abstract class AWalidacja
    {
        /// <summary>
        /// Metoda sprawdzająca poprawność parametrów zmiennoprzecinkowych
        /// </summary>
        /// <param name="parametry">Parametry algorytmu, problemu optymalizacyjnego</param>
        /// <param name="klucze">Wartości do sprawdzenia</param>
        /// <returns>Czy poprawna są wartości zmiennoprzecinkowe</returns>
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

        /// <summary>
        /// Metoda sprawdzająca poprawność parametrów całkowitych
        /// </summary>
        /// <param name="parametry">Parametry algorytmu, problemu optymalizacyjnego</param>
        /// <param name="klucze">Wartości do sprawdzenia</param>
        /// <returns>Czy poprawne są wartości całkowite</returns>
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

        /// <summary>
        /// Metoda sprawdzająca czy ploe tekstowe jest puste
        /// </summary>
        /// <param name="tekst">Pole tekstowe</param>
        /// <returns>Czy pole tekstowe jest puste</returns>
        public bool CzyPustePoleTekstowe(string tekst)
        {
            return tekst != "";
        }
    }
}
