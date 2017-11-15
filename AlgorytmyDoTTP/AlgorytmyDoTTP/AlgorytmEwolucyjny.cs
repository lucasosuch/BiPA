using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP
{
    class AlgorytmEwolucyjny
    {
        private Przedstawiciel[] przedstawiciele;

        public AlgorytmEwolucyjny(int wielkoscPopulacji, int dlugoscChromosomu)
        {
            Random random = new Random();
            przedstawiciele = new Przedstawiciel[wielkoscPopulacji];

            for (int i = 0; i < wielkoscPopulacji; i++)
            {
                int[] chromosom = new int[dlugoscChromosomu];

                for (int j = 0; j < dlugoscChromosomu; j++)
                {
                    chromosom[j] = random.Next(0, 2);
                }

                przedstawiciele[i] = new Przedstawiciel(chromosom, 0, 0, 0, 0, 0);
            }
        }

        public Przedstawiciel[] zwrocPopulacje()
        {
            return this.przedstawiciele;
        }
    }
}
