using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP
{
    class Populacja
    {
        private Przedstawiciel[] przedstawiciele;

        public Populacja(int wielkoscPopulacji, int dlugoscChromosomu)
        {
            Random random = new Random();
            this.przedstawiciele = new Przedstawiciel[wielkoscPopulacji];

            for (int i = 0; i < wielkoscPopulacji; i++)
            {
                int fenotyp = 0;
                int[] chromosom = new int[dlugoscChromosomu];

                for (int j = 0; j < dlugoscChromosomu; j++)
                {
                    chromosom[j] = random.Next(0, 2);
                    fenotyp += liczFenotyp(chromosom[j], j);
                }

                int funkcjaPrzydatnosci = zwrocFunkcjePrzydatnosci(fenotyp);
                this.przedstawiciele[i] = new Przedstawiciel(chromosom, fenotyp, funkcjaPrzydatnosci, 0);
            }
        }

        private int liczFenotyp(int wartosc, int i)
        {
            return (int)(Math.Pow(wartosc, i));
        }

        private int zwrocFunkcjePrzydatnosci(int fenotyp)
        {
            return (int)Math.Pow(fenotyp, 2);
        }

        public void nowaPopulacja(int[][] chromosomy, int wielkoscPopulacji, int generacja)
        {
            this.przedstawiciele = new Przedstawiciel[wielkoscPopulacji];

            System.Diagnostics.Debug.WriteLine("-------------------------------------------------------------");
            System.Diagnostics.Debug.WriteLine("Generacja: " + generacja + ":\n");
            for (int i = 0; i < wielkoscPopulacji; i++)
            {
                int fenotyp = 0;

                for (int j = 0; j < chromosomy[i].Length; j++)
                {
                    fenotyp += liczFenotyp(chromosomy[i][j], j);
                }

                int funkcjaPrzydatnosci = zwrocFunkcjePrzydatnosci(fenotyp);
                this.przedstawiciele[i] = new Przedstawiciel(chromosomy[i], fenotyp, funkcjaPrzydatnosci, generacja);
                
                System.Diagnostics.Debug.WriteLine(this.przedstawiciele[i].ToString());
            }
        }

        public Przedstawiciel[] zwrocPopulacje()
        {
            return this.przedstawiciele;
        }
    }
}
