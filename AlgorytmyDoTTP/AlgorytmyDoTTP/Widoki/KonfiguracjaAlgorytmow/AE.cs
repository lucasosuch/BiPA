namespace AlgorytmyDoTTP.Widoki.KonfiguracjaAlgorytmow
{
    /// <summary>
    /// Klasa konkretna reprezentująca opcje podstawowych parametrów konfiguracyjnych Algorytmu Ewolucyjnego
    /// </summary>
    class AE
    {
        public readonly object[] KRZYZOWANIE_WEKTORA = new object[]
        {
            "Proste"
        };

        public readonly object[] KRZYZOWANIE_TSP = new object[]
        {
            "PMX", "OX", "CX"
        };

        public readonly object[] SELEKCJA = new object[]
        {
            "Turniej", "Metoda ruletki"
        };

        public readonly object[] MODELE_TTP = new object[]
        {
            "TTP1", "TTP2"
        };

        // parametry do walidacji
        public readonly string[] parametryCalkowite = new string[] 
        {
            "rozmiarPopulacji", "iloscPokolen", "iloscRozwiazan", "liczbaIteracji"
        };

        public readonly string[] parametryZmiennoPrzecinkowe = new string[] 
        {
            "pwoMutacji", "pwoKrzyzowania", "ograniczenie1"
        };
    }
}
