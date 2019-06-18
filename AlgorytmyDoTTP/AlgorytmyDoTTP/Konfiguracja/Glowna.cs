namespace BiPA.Konfiguracja
{
    class Glowna
    {
        // liczba algorytmów dostępnych w aplikacji
        public readonly object[] ALGORYTMY = new object[] 
        {
            "Algorytm Ewolucyjny", "Algorytm Wspinaczkowy", "Algorytm Losowy"
        };

        // liczba zadań optymalizacyjnych dostępnych w aplikacji
        public readonly object[] PROBLEMY_OPTYMALIZACYJNE = new object[] 
        {
            "Problem Plecakowy", "Problem Komiwojażera", "Problem Podróżującego Złodzieja"
        };

        // nazwy folderów z plikami danych dla zaimplementowanych problemów optymalizacyjnych
        public readonly string[] FOLDERY_Z_DANYMI = new string[] 
        {
            "kp", "tsp", "ttp"
        };

        // krzyżowanie wektora dla Problemu Plecakowego
        public readonly object[] KRZYZOWANIE_WEKTORA = new object[]
        {
            "Proste"
        };

        // krzyżowanie wektora dla Problemu Komiwojażera
        public readonly object[] KRZYZOWANIE_TSP = new object[]
        {
            "PMX", "OX", "CX"
        };
        
        // rodzaje selekcji osobnika dla algorytmu ewolucyjnego
        public readonly object[] SELEKCJA = new object[]
        {
            "Turniej", "Metoda ruletki"
        };

        // liczba dostępnych modeli dla Problemu Podróżującego Złodzieja
        public readonly object[] MODELE_TTP = new object[]
        {
            "TTP1", "TTP2"
        };

        // parametry dla walidacji tekstowej
        public readonly string[] PARAMETRY_TEKSTOWE = new string[]
        {
            "dane", "problem", "algorytm"
        };

        // parametry dla walidacji jako liczby całkowite
        public readonly string[] PARAMETRY_CALKOWITE = new string[]
        {
            "rozmiarPopulacji", "liczbaIteracji", "parametrP", "liczbaIteracji", "czasPoszukiwania"
        };

        // parametry dla walidacji jako liczby zmiennoprzecinkowe
        public readonly string[] PARAMETRY_ZMIENNOPRZECINKOWE = new string[]
        {
            "pwoMutacji", "pwoKrzyzowania", "maxWaga", "wyporzyczeniePlecaka"
        };
    }
}
