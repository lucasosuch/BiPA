namespace AlgorytmyDoTTP.KonfiguracjaAlgorytmow
{
    class AE
    {
        public readonly object[] KRZYZOWANIE_WEKTORA = new object[]
        {
            "Proste"
        };

        public readonly object[] KRZYZOWANIE_TSP = new object[]
        {
            "PMX", "OX", "CX", "Wymiana podtras"
        };

        public readonly object[] SELEKCJA = new object[]
        {
            "Turniej", "Metoda ruletki", "Ruletka turniejowa"
        };

        public readonly string[] parametryCalkowite = new string[] 
        {
            "rozmiarPopulacji", "iloscPokolen"
        };

        public readonly string[] parametryZmiennoPrzecinkowe = new string[] 
        {
            "pwoMutacji", "pwoKrzyzowania", "ograniczenie1"
        };
    }
}
