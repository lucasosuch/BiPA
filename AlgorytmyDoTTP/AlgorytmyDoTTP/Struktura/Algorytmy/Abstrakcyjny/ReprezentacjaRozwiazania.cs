namespace AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny
{
    /// <summary>
    /// Klasa pełniąca rolę genotypu / zakodowanego rozwiązania w dowolnej strukturze danych
    /// </summary>
    class ReprezentacjaRozwiazania
    {
        private ushort[] genotyp1Wymiarowy;
        private ushort[][] genotyp2Wymiarowy;

        public ReprezentacjaRozwiazania(){}

        public ReprezentacjaRozwiazania(ushort[] genotyp1Wymiarowy)
        {
            this.genotyp1Wymiarowy = genotyp1Wymiarowy;
        }

        public ReprezentacjaRozwiazania(ushort[][] genotyp2Wymiarowy)
        {
            this.genotyp2Wymiarowy = genotyp2Wymiarowy;
        }

        /// <summary>
        /// Metoda wymieniająca zakodowane rozwiązanie
        /// </summary>
        /// <param name="genotyp1Wymiarowy">Rozwiązanie zakodowane jako 1 wymiarowa tablica ushort</param>
        public void ZmienGenotyp(ushort[] genotyp1Wymiarowy)
        {
            this.genotyp1Wymiarowy = (ushort[])genotyp1Wymiarowy.Clone();
        }

        /// <summary>
        /// Metoda wymieniająca zakodowane rozwiązanie
        /// </summary>
        /// <param name="genotyp1Wymiarowy">Rozwiązanie zakodowane jako 2 wymiarowa tablica ushort</param>
        public void ZmienGenotyp(ushort[][] genotyp2Wymiarowy)
        {
            this.genotyp2Wymiarowy = (ushort[][])genotyp2Wymiarowy.Clone();
        }

        /// <summary>
        /// Metoda zwraca zakodowane rozwiązanie
        /// </summary>
        /// <returns>Zwraca rozwiązanie zakodowane jako 1 wymiarową tablicę ushort</returns>
        public ushort[] ZwrocGenotyp1Wymiarowy()
        {
            return genotyp1Wymiarowy;
        }

        /// <summary>
        /// Metoda zwraca zakodowane rozwiązanie
        /// </summary>
        /// <returns>Zwraca rozwiązanie zakodowane jako 1 wymiarową tablicę ushort</returns>
        public ushort[][] ZwrocGenotyp2Wymiarowy()
        {
            return genotyp2Wymiarowy;
        }
    }
}
