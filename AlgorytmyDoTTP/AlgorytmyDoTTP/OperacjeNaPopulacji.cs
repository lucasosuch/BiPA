using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP
{
    class OperacjeNaPopulacji
    {
        private Random random = new Random();

        public int select(int wielkoscPopulacji, double sumaPrzydatnosci, Przedstawiciel[] populacja)
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

        public int mutacja(int allel, double pwoMutacji, int liczbaMutacji)
        {
            int wynikMutacji;
            double mutuj = random.NextDouble();

            if(mutuj < pwoMutacji) {
                liczbaMutacji++;
                wynikMutacji = (allel == 0) ? 1 : 0;
            } else {
                wynikMutacji = allel;
            }

            return wynikMutacji;
        }

        public void krzyzowanie(int[] przodek1, int[] przodek2, double pwoKrzyzowania, double pwoMutacji, int liczbaChromosomow)
        {
            int indexKrzyzowania = 0;
            int przeciecie = 0;
            double krzyzuj = random.NextDouble();
            int[] potomek1 = new int[liczbaChromosomow];
            int[] potomek2 = new int[liczbaChromosomow];

            if(krzyzuj < pwoKrzyzowania) {
                przeciecie = random.Next(1, liczbaChromosomow - 1);
                indexKrzyzowania++;
            } else {
                przeciecie = liczbaChromosomow;
            }

            for(int i = 0; i < przeciecie; i++) {
                potomek1[i] = this.mutacja(przodek1[i], pwoMutacji, 0);
                potomek2[i] = this.mutacja(przodek2[i], pwoMutacji, 0);
            }

            if(przeciecie != liczbaChromosomow) {
                for (int i = przeciecie+1; i < liczbaChromosomow; i++) {
                    potomek1[i] = this.mutacja(przodek2[i], pwoMutacji, 0);
                    potomek2[i] = this.mutacja(przodek1[i], pwoMutacji, 0);
                }
            }
        }
    }
}
