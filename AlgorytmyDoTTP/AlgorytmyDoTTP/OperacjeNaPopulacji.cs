using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP
{
    class OperacjeNaPopulacji
    {
        private int liczbaMutacji = 0;
        private double pwoKrzyzowania;
        private double pwoMutacji;
        private Random random = new Random();

        public OperacjeNaPopulacji(double pwoKrzyzowania, double pwoMutacji)
        {
            this.pwoKrzyzowania = pwoKrzyzowania;
            this.pwoMutacji = pwoMutacji;
        }

        public int wybierzOsobniki(int wielkoscPopulacji, double sumaPrzydatnosci, Przedstawiciel[] populacja)
        {
            int indexPopulacji = 0;
            double sumaCzesciowa = 0;

            double wartoscKrytyczna = sumaPrzydatnosci * random.Next(0, 2);
            while (sumaCzesciowa >= wartoscKrytyczna || indexPopulacji == wielkoscPopulacji) {
                indexPopulacji += 1;
                sumaCzesciowa += populacja[indexPopulacji].zwrocPrzydatnosc();
            }

            return indexPopulacji;
        }

        public int[][] krzyzowanie(int[] przodek1, int[] przodek2, int liczbaChromosomow)
        {
            int indexKrzyzowania = 0;
            int przeciecie = 0;
            double krzyzuj = random.NextDouble();
            int[] potomek1 = new int[liczbaChromosomow];
            int[] potomek2 = new int[liczbaChromosomow];

            if (krzyzuj < pwoKrzyzowania) {
                przeciecie = random.Next(1, liczbaChromosomow - 1);
                indexKrzyzowania++;
            } else {
                przeciecie = liczbaChromosomow;
            }

            for (int i = 0; i < przeciecie; i++) {
                potomek1[i] = this.mutacja(przodek1[i]);
                potomek2[i] = this.mutacja(przodek2[i]);
            }

            if (przeciecie != liczbaChromosomow) {
                for (int i = przeciecie+1; i < liczbaChromosomow; i++) {
                    potomek1[i] = this.mutacja(przodek2[i]);
                    potomek2[i] = this.mutacja(przodek1[i]);
                }
            }

            return new int[][] { potomek1, potomek2 };
        }

        private int mutacja(int allel)
        {
            int wynikMutacji;
            double mutuj = random.NextDouble();

            if (mutuj < pwoMutacji) {
                liczbaMutacji++;
                wynikMutacji = (allel == 0) ? 1 : 0;
            }
            else {
                wynikMutacji = allel;
            }

            return wynikMutacji;
        }
    }
}
