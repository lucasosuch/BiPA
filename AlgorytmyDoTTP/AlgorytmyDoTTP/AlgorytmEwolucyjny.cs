using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP
{
    class AlgorytmEwolucyjny
    {
        private double pwoMutacji;
        private double pwoKrzyzowania;

        public AlgorytmEwolucyjny(double pwoKrzyzowania, double pwoMutacji)
        {
            this.pwoKrzyzowania = pwoKrzyzowania;
            this.pwoMutacji = pwoMutacji;
        }

        public void wykonajEwolucje(int wielkoscPopulacji, int dlugoscChromosomu, int ileRazy)
        {
            OperacjeNaPopulacji operacje = new OperacjeNaPopulacji(pwoKrzyzowania, pwoMutacji);
            Populacja populacjaBazowa = new Populacja(wielkoscPopulacji, dlugoscChromosomu);

            for (int i = 0; i < ileRazy; i++)
            {
                Przedstawiciel[] przedstawiciele = populacjaBazowa.zwrocPopulacje();

                int iter = 0;
                int[][] chromosomy = new int[wielkoscPopulacji][];
                for (int j = 1; j <= wielkoscPopulacji; j += 2)
                {
                    int[][] nastepnaGeneracja = operacje.krzyzowanie(przedstawiciele[j].zwrocChromosom(), przedstawiciele[j - 1].zwrocChromosom(), dlugoscChromosomu);

                    chromosomy[iter] = nastepnaGeneracja[0];
                    iter++;
                    chromosomy[iter] = nastepnaGeneracja[1];
                    iter++;
                }

                wielkoscPopulacji = iter;

                populacjaBazowa.nowaPopulacja(chromosomy, wielkoscPopulacji, i);
            }
        }
    }
}
