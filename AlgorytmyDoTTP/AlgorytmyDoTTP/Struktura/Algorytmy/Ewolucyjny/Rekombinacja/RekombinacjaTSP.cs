using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Osobnik;
using System;
using System.Linq;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja
{
    /// <summary>
    /// Klasa konkretna odpowiedzialna za wymianę materiału genetycznego pomiędzy osobnikami - rozwiązaniami Problemu Komiwojażera
    /// </summary>
    class RekombinacjaTSP : ARekombinacja
    {
        public RekombinacjaTSP(float pwoMutacji, AOsobnik rozwiazanie, string rodzajKrzyzowania) : base(pwoMutacji, rozwiazanie, rodzajKrzyzowania){}

        public override ReprezentacjaRozwiazania Krzyzowanie(ReprezentacjaRozwiazania genotyp1, ReprezentacjaRozwiazania genotyp2)
        {
            // zwrócenie rozwiązań dla wektora rozwiązania Problemu Komiwojażera
            ushort[] przodek1 = genotyp1.ZwrocGenotyp1Wymiarowy(),
                     przodek2 = genotyp2.ZwrocGenotyp1Wymiarowy(),
                     potomek = new ushort[przodek1.Length];

            // określenie rodzaju krzyżowania dla Problemu Komiwojażera
            switch(rodzajKrzyzowania)
            {
                case "PMX":
                    potomek = (ushort[])PMX(przodek1, przodek2).Clone();
                    break;

                case "OX":
                    potomek = (ushort[])OX(przodek1, przodek2).Clone();
                    break;

                case "CX":
                    potomek = (ushort[])CX(przodek1, przodek2).Clone();
                    break;

                default:
                    throw new Exception();

            }
            
            return new ReprezentacjaRozwiazania((ushort[])Mutacja(potomek).Clone());
        }

        protected override ushort[] Mutacja(ushort[] geny)
        {
            if (losowy.NextDouble() <= pwoMutacji)
            {
                return geny;
            }

            // mutacja polega na zamianie miejscami indeksów miast w wektorze
            int koniec = losowy.Next(2, geny.Length - 2),
                poczatek = koniec - 1;
          
            ushort tmp = geny[koniec];
            geny[koniec] = geny[poczatek];
            geny[poczatek] = tmp;
            
            return geny;
        }

        /// <summary>
        /// Metoda krzyżuje genotypy funkcją PMX
        /// </summary>
        /// <param name="przodek1">1 przodek do krzyżowania</param>
        /// <param name="przodek2">2 przodek do krzyżowania</param>
        /// <seealso cref="https://blog.x5ff.xyz/blog/ai-rust-javascript-pmx/"/>
        private ushort[] PMX(ushort[] przodek1, ushort[] przodek2)
        {
            ushort[] potomek = new ushort[przodek1.Length];
            int ciecie1 = losowy.Next(1, przodek1.Length - 1),
                ciecie2 = losowy.Next(ciecie1, przodek1.Length - 1),
                start = (ciecie1 < ciecie2) ? ciecie1 : ciecie2,
                koniec = (ciecie1 < ciecie2) ? ciecie2 : ciecie1;

            
            potomek = (ushort[])przodek1.Clone();
            for (int i = start; i < koniec; i++)
            {
                potomek[i] = przodek2[i];
            }

            for (int i = 1; i < potomek.Length - 1; i++)
            {
                for (int j = potomek.Length - 2; j > 0; j--)
                {
                    if ((potomek[i] == potomek[j]) && (j != i))
                    {
                        for (int k = 1; k < przodek2.Length - 1; k++)
                        {
                            bool zawiera = false;
                            for (int l = 1; l < potomek.Length - 1; l++)
                            {
                                if (przodek2[k] == potomek[l])
                                {
                                    zawiera = true;
                                    break;
                                }
                            }

                            if (!zawiera)
                            {
                                potomek[j] = przodek2[k];
                            }
                        }

                        break;
                    }
                }
            }

            return potomek;
        }

        /// <summary>
        /// Metoda krzyżuje genotypy funkcją OX
        /// </summary>
        /// <param name="przodek1">1 przodek do krzyżowania</param>
        /// <param name="przodek2">2 przodek do krzyżowania</param>
        /// <seealso cref="https://www.researchgate.net/figure/The-order-based-crossover-OX-a-and-the-insertion-mutation-b-operators_fig2_224330103"/>
        private ushort[] OX(ushort[] przodek1, ushort[] przodek2)
        {
            ushort[] potomek = new ushort[przodek1.Length];
            int ciecie1 = losowy.Next(1, przodek1.Length - 1),
                ciecie2 = losowy.Next(ciecie1, przodek1.Length - 1),
                start = (ciecie1 < ciecie2) ? ciecie1 : ciecie2,
                koniec = (ciecie1 < ciecie2) ? ciecie2 : ciecie1;

            potomek[0] = 1;
            potomek[potomek.Length - 1] = 1;

            for (int k = 1; k < potomek.Length - 1; k++)
            {
                potomek[k] = 0;
            }

            // od pewnego punktu `start` do punktu `koniec` przepisanie wartosci wektora
            for (int i = start; i <= koniec; i++)
            {
                potomek[i] = przodek1[i];
            }

            for (int i = 1; i < przodek2.Length - 1; i++)
            {
                // jeżeli potomny wektor nie zawiera miasta o zadanym numerze
                if (!potomek.Contains(przodek2[i]))
                {
                    for (int j = 1; j < potomek.Length - 1; j++)
                    {
                        // wyszukanie indeksu, gdzie mozna dopisać miasto
                        if (potomek[j] == 0)
                        {
                            // dopisz miasto, które nie zostało jeszcze użyte
                            potomek[j] = przodek2[i];
                            break;
                        }
                    }
                }
            }
            
            return potomek;
        }

        /// <summary>
        /// Metoda krzyżuje genotypy funkcją CX
        /// </summary>
        /// <param name="przodek1">1 przodek do krzyżowania</param>
        /// <param name="przodek2">2 przodek do krzyżowania</param>
        /// <seealso cref="https://www.youtube.com/watch?v=85pIA2TYsUs"/>
        private ushort[] CX(ushort[] przodek1, ushort[] przodek2)
        {
            ushort i = 1;
            ushort[] potomek = new ushort[przodek1.Length];

            potomek[0] = 1;
            potomek[potomek.Length - 1] = 1;

            for (int k = 1; k < potomek.Length - 1; k++)
            {
                potomek[k] = 0;
            }

            // wykonanie najdłuższego zamknietego cyklu
            while (potomek.Contains(przodek2[i]))
            {
                ushort j = (ushort)(przodek2[i] - 1);
                potomek[j] = przodek1[j];
                i = j;
            }

            // dopisanie reszty miast
            for (int k = 1; k < potomek.Length - 1; k++)
            {
                if (potomek[k] == 0)
                {
                    potomek[k] = przodek2[k];
                }
            }

            return potomek;
        }

        protected override ReprezentacjaRozwiazania SprawdzNaruszenieOgraniczen(ReprezentacjaRozwiazania genotyp)
        {
            throw new NotImplementedException();
        }
    }
}
