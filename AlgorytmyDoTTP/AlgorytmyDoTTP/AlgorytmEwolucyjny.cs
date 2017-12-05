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
        private double najlepszyWynik = 0;

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
                Przedstawiciel[] przedstawiciele = operacje.wybierzOsobniki(populacjaBazowa.zwrocPopulacje());
                wielkoscPopulacji = (przedstawiciele.Length % 2 == 1) ? przedstawiciele.Length - 1 : przedstawiciele.Length;

                int iter = 0;
                int[][] chromosomy = new int[wielkoscPopulacji][];
                for (int j = 1; j <= wielkoscPopulacji; j += 2)
                {
                    if (wielkoscPopulacji <= 2) break;

                    if (przedstawiciele[j].zwrocPrzydatnosc() > this.najlepszyWynik)
                    {
                        this.najlepszyWynik = przedstawiciele[j].zwrocPrzydatnosc();
                    }

                    if (przedstawiciele[j - 1].zwrocPrzydatnosc() > this.najlepszyWynik)
                    {
                        this.najlepszyWynik = przedstawiciele[j-1].zwrocPrzydatnosc();
                    }

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

        public double zwrocNajlepszyWynik()
        {
            return this.najlepszyWynik;
        }
    }
}
