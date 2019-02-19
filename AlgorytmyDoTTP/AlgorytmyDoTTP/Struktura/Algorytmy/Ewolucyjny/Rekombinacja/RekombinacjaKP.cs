using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Osobnik;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja
{
    /// <summary>
    /// Klasa konkretna odpowiedzialna za wymianę materiału genetycznego pomiędzy osobnikami - rozwiązaniami Problemu Plecakowego
    /// </summary>
    class RekombinacjaKP : ARekombinacja
    {
        public RekombinacjaKP(float pwoMutacji, AOsobnik rozwiazanie) : base(pwoMutacji, rozwiazanie){}

        public override ReprezentacjaRozwiazania Krzyzowanie(ReprezentacjaRozwiazania genotyp1, ReprezentacjaRozwiazania genotyp2)
        {
            // pobranie wektorów rozwiązań dla Problemu Plecakowego
            ushort[] przodek1 = genotyp1.ZwrocGenotyp1Wymiarowy(),
                     przodek2 = genotyp2.ZwrocGenotyp1Wymiarowy(),
                     dzieciak = new ushort[przodek1.Length];

            // punkt w którym tniemy dwa wektory rozwiązań
            int ciecie = losowy.Next(0, przodek1.Length);

            dzieciak = (ushort[])przodek1.Clone(); // przepisanie 1 do 1 genów z pierwszego przodka
            for (int i = 0; i < ciecie; i++)
            {
                try
                {
                    dzieciak[i] = przodek2[i]; // od puktu cięcia zmiana genów na te z przo drugiego
                } catch(System.Exception e)
                {
                    System.Console.WriteLine(e);
                    System.Console.WriteLine(dzieciak.Length + " " + dzieciak[i]);
                    System.Console.WriteLine(przodek2.Length + " " + przodek2[i]);
                }
            }

            ReprezentacjaRozwiazania genotypDziecka = new ReprezentacjaRozwiazania((ushort[])Mutacja(dzieciak).Clone());

            if (czySprawdzacOgraniczenia)
            {
                return SprawdzNaruszenieOgraniczen(genotypDziecka); // sprawdzanie czy nie przekraczamy wagi plecaka
            }

            return genotypDziecka;
        }

        protected override ushort[] Mutacja(ushort[] geny)
        {
            if (losowy.NextDouble() > pwoMutacji || pwoMutacji == 0)
            {
                return geny;
            }

            // zmiana losowego genu
            int bit = losowy.Next(geny.Length);
            geny[bit] = (ushort)((geny[bit] == 0) ? 1 : 0);
            
            return geny;
        }

        protected override ReprezentacjaRozwiazania SprawdzNaruszenieOgraniczen(ReprezentacjaRozwiazania genotyp)
        {
            ushort[] geny = genotyp.ZwrocGenotyp1Wymiarowy();
            float[] ograniczenie = rozwiazanie.ZwrocInstancjeProblemu().ZwrocOgraniczeniaProblemu();

            // naprawa genów do momentu spełniania ograniczeń
            while (rozwiazanie.FunkcjaDopasowania(genotyp)["min"][0] > ograniczenie[0])
            {
                genotyp.ZmienGenotyp((ushort[])NaprawGenotypKP(geny).Clone());
            }

            return genotyp;
        }

        /// <summary>
        /// Metoda naprawiająca losowy ciąg genów w genotypie
        /// </summary>
        /// <param name="geny">Tablica reprezentująca geny osobnika</param>
        private ushort[] NaprawGenotypKP(ushort[] geny)
        {
            // naprawa genów od punktu `start` do punktu `koniec`
            int start = losowy.Next(0, geny.Length / 2),
                koniec = losowy.Next(start, geny.Length);

            // zamiana genów w losowym podwektorze w wektorze rozwiązania Problemu Plecakowego
            for (int i = start; i < koniec; i++)
            {
                geny[i] = (ushort)((geny[i] == 0) ? 1 : 0);
            }

            return geny;
        }
    }
}
