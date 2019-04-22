namespace BiPA.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny
{
    interface IPomocniczy
    {
        /// <summary>
        /// Metoda zwraca wagę przedmiotu
        /// </summary>
        /// <returns>Waga przedmiotu</returns>
        float ZwrocWage();

        /// <summary>
        /// Metoda zwraca wartość przedmiotu
        /// </summary>
        /// <returns>Wartość przedmiotu</returns>
        float ZwrocWartosc();

        /// <summary>
        /// Metoda zwraca miasto startowe na odcinku
        /// </summary>
        /// <returns>Numer miasta</returns>
        ushort ZwrocOd();

        /// <summary>
        /// Metoda zwraca miasto końcowe na odcinku
        /// </summary>
        /// <returns>Numer miasta</returns>
        ushort ZwrocDo();

        /// <summary>
        /// Metoda zwraca długość odcinka
        /// </summary>
        /// <returns>Długość odcinka</returns>
        float ZwrocDlugosc();

        /// <summary>
        /// Metoda zwraca dostępne 
        /// </summary>
        /// <param name="dostepnePrzedmioty">Dostępne przedmioty w danym mieście w notacji tekstowej</param>
        /// <param name="iloscPrzedmiotow">Ilość dostępnych przedmiotów we wszystkich miastach</param>
        /// <returns>Dostępne przedmioty w notacji tablicowej</returns>
        ushort[] ZwrocPrzedmioty(string dostepnePrzedmioty, ushort iloscPrzedmiotow);
    }
}
