using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;
using System;
using System.Collections;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Analityka
{
    class AnalizaPopulacji : IAnalityka
    {
        private AOsobnik rozwiazanie;
        private ushort[] najlepszyGenotyp;

        public AnalizaPopulacji(AOsobnik rozwiazanie)
        {
            this.rozwiazanie = rozwiazanie;

            najlepszyGenotyp = new ushort[rozwiazanie.ZwrocInstancjeProblemu().ZwrocDlugoscGenotypu()];
            for (int i = 0; i < rozwiazanie.ZwrocInstancjeProblemu().ZwrocDlugoscGenotypu(); i++)
            {
                najlepszyGenotyp[i] = 0;
            }
        }

        public double MedianaPopulacji(ArrayList populacja)
        {
            int srodek = populacja.Count / 2;
            double[] wynikiPopulacji = new double[populacja.Count];

            for(int i = 0; i < populacja.Count; i++)
            {
                wynikiPopulacji[i] = rozwiazanie.FunkcjaDopasowania((ushort[])populacja[i])["max"][0];
            }

            Array.Sort(wynikiPopulacji);

            return wynikiPopulacji[srodek];
        }

        // Zwraca wartość średnią z funkcji celów w populacji
        public double SredniaPopulacji(ArrayList populacja)
        {
            double wynik = 0;

            foreach (ushort[] osobnik in populacja)
            {
                wynik += rozwiazanie.FunkcjaDopasowania(osobnik)["max"][0];
            }

            return wynik / populacja.Count;
        }

        // Zwraca wartość odchylenia standardowego z funkcji celów w populacji
        public double OdchylenieStandardowePopulacji(ArrayList populacja, double srednia)
        {
            double sumaKwadratow = 0;

            foreach (ushort[] osobnik in populacja)
            {
                sumaKwadratow += Math.Pow(rozwiazanie.FunkcjaDopasowania(osobnik)["max"][0], 2);
            }

            double sredniaSumaKwadratow = sumaKwadratow / (populacja.Count - 1);
            return Math.Sqrt(sredniaSumaKwadratow - (Math.Pow(srednia, 2)));
        }

        public void ZmienWartoscNiebo(ushort[] geny)
        {
            if(rozwiazanie.FunkcjaDopasowania(najlepszyGenotyp)["max"][0] < rozwiazanie.FunkcjaDopasowania(geny)["max"][0])
            {
                najlepszyGenotyp = (ushort[])geny.Clone();
            }
        }

        public ushort[] ZwrocNajlepszyGenotyp()
        {
            return najlepszyGenotyp;
        }

        public string ZwrocWartoscNiebo()
        {
            return " max: "+ rozwiazanie.FunkcjaDopasowania(najlepszyGenotyp)["max"][0] + " | min: "+ rozwiazanie.FunkcjaDopasowania(najlepszyGenotyp)["min"][0];
        }
    }
}
