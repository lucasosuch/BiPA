namespace BiPA.Widoki.Narzedzia
{
    /// <summary>
    /// Klasa odpowiada za walidację danych w formatce
    /// </summary>
    public class MetodyWalidacji
    {
        /// <summary>
        /// Metoda sprawdzająca poprawność poprawność liczby zmiennoprzecinkowej
        /// </summary>
        /// <param name="tekst">Pole tekstowe</param>
        /// <returns>Czy poprawna są wartości zmiennoprzecinkowe</returns>
        public bool CzyPoprawneZmiennoPrzecinkowe(string tekst)
        {
            return double.TryParse(tekst, out double wartosc);
        }

        /// <summary>
        /// Metoda sprawdzająca poprawność liczby całkowitej
        /// </summary>
        /// <param name="tekst">Pole tekstowe</param>
        /// <returns>Czy poprawne są wartości całkowite</returns>
        public bool CzyPoprawneCalkowite(string tekst)
        {
            return int.TryParse(tekst, out int wartosc);
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
