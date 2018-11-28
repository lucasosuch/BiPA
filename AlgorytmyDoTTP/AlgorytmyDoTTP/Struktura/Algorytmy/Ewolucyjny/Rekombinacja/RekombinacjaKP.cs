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
            ushort[] przodek1 = genotyp1.ZwrocGenotyp1Wymiarowy(),
                     przodek2 = genotyp2.ZwrocGenotyp1Wymiarowy(),
                     dzieciak = new ushort[przodek1.Length];

            int ciecie = losowy.Next(0, przodek1.Length);

            dzieciak = (ushort[])przodek1.Clone();
            for (int i = 0; i < ciecie; i++)
            {
                dzieciak[i] = przodek2[i];
            }

            ReprezentacjaRozwiazania genotypDziecka = new ReprezentacjaRozwiazania((ushort[])Mutacja(dzieciak).Clone());

            if (czySprawdzacOgraniczenia)
            {
                return SprawdzNaruszenieOgraniczen(genotypDziecka);
            }

            return genotypDziecka;
        }

        protected override ushort[] Mutacja(ushort[] geny)
        {
            if (losowy.NextDouble() > pwoMutacji || pwoMutacji == 0)
            {
                return geny;
            }

            int bit = losowy.Next(geny.Length);
            geny[bit] = (ushort)((geny[bit] == 0) ? 1 : 0);
            
            return geny;
        }

        protected override ushort[] Mutacja(ushort[] genotyp, ushort[] dostepnoscPrzedmiotow)
        {
            throw new System.NotImplementedException();
        }

        protected override ReprezentacjaRozwiazania SprawdzNaruszenieOgraniczen(ReprezentacjaRozwiazania genotyp)
        {
            ushort[] geny = genotyp.ZwrocGenotyp1Wymiarowy();
            float[] ograniczenie = rozwiazanie.ZwrocInstancjeProblemu().ZwrocOgraniczeniaProblemu();

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
            int start = losowy.Next(0, geny.Length / 2),
                koniec = losowy.Next(start, geny.Length);

            for (int i = start; i < koniec; i++)
            {
                geny[i] = (ushort)((geny[i] == 0) ? 1 : 0);
            }

            return geny;
        }
    }
}
