using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP
{
    class Przedstawiciel
    {
        private int[] chromosom;
        private double fenotyp;
        private double fitness;
        private int przodek1;
        private int przodek2;
        private int xsite;

        public Przedstawiciel(int[] chromosom, double fenotyp, double fitnes, int przodek1, int przodek2, int xsite)
        {
            this.chromosom = chromosom;
            this.fenotyp = fenotyp;
            this.fitness = fitnes;
            this.przodek1 = przodek1;
            this.przodek2 = przodek2;
            this.xsite = xsite;
        }

        override
        public String ToString()
        {
            String chromosomStr = "";
            foreach(int bit in chromosom)
            {
                chromosomStr += (bit + "");
            }

            return "Chromosom: "+ chromosomStr +
                    "\nfenotyp: "+ fenotyp +
                    "\nfitness: "+ fitness +
                    "\nprzodek1: "+ przodek1 +
                    "\nprzodek2: "+ przodek2 +
                    "\nxsite: "+ xsite;
        }
    }
}
