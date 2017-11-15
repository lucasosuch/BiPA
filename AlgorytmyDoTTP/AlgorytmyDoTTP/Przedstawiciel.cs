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
        private double przydatnosc;
        private int przodek1;
        private int przodek2;
        private int xsite;

        public Przedstawiciel(int[] chromosom, double fenotyp, double przydatnosc, int przodek1, int przodek2, int xsite)
        {
            this.chromosom = chromosom;
            this.fenotyp = fenotyp;
            this.przydatnosc = przydatnosc;
            this.przodek1 = przodek1;
            this.przodek2 = przodek2;
            this.xsite = xsite;
        }

        public int[] zwrocChromosom()
        {
            return chromosom;
        }

        public double zwrocFenotyp()
        {
            return fenotyp;
        }

        public double zwrocPrzydatnosc()
        {
            return przydatnosc;
        }
        
        public int zwrocPrzodka1()
        {
            return przodek1;
        }

        public int zwrocPrzodka2()
        {
            return przodek2;
        }

        public int zwrocXSite()
        {
            return xsite;
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
                    "\nfitness: "+ przydatnosc +
                    "\nprzodek1: "+ przodek1 +
                    "\nprzodek2: "+ przodek2 +
                    "\nxsite: "+ xsite;
        }
    }
}
