namespace BiPA.Konfiguracja
{
    class Glowna
    {
        public readonly object[] ALGORYTMY = new object[] 
        {
            "Algorytm Ewolucyjny", "Algorytm Wspinaczkowy", "Algorytm Losowy"
        };

        public readonly object[] PROBLEMY_OPTYMALIZACYJNE = new object[] 
        {
            "Problem Plecakowy", "Problem Komiwojażera", "Problem Podróżującego Złodzieja"
        };

        public readonly string[] FOLDERY_Z_DANYMI = new string[] 
        {
            "kp", "tsp", "ttp"
        };

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
        public readonly string[] PARAMETRY_TEKSTOWE = new string[]
        {
            "dane", "problem", "algorytm"
        };

        public readonly string[] PARAMETRY_CALKOWITE = new string[]
        {
            "rozmiarPopulacji", "liczbaIteracji", "parametrP", "liczbaIteracji", "czasPoszukiwania"
        };

        public readonly string[] PARAMETRY_ZMIENNOPRZECINKOWE = new string[]
        {
            "pwoMutacji", "pwoKrzyzowania", "maxWaga", "wyporzyczeniePlecaka"
        };
    }
}
