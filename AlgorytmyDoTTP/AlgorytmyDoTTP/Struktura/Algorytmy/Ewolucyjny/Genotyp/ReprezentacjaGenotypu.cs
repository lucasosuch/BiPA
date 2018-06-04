using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Genotyp
{
    class ReprezentacjaGenotypu
    {
        private ushort[] genotyp1Wymiarowy;
        private ushort[][] genotyp2Wymiarowy;

        public ReprezentacjaGenotypu()
        {
            throw new Exception();
        }

        public ReprezentacjaGenotypu(ushort[] genotyp1Wymiarowy)
        {
            this.genotyp1Wymiarowy = genotyp1Wymiarowy;
        }

        public ReprezentacjaGenotypu(ushort[][] genotyp2Wymiarowy)
        {
            this.genotyp2Wymiarowy = genotyp2Wymiarowy;
        }

        public ushort[] ZwrocGenotyp1Wymiarowy()
        {
            return genotyp1Wymiarowy;
        }

        public ushort[][] ZwrocGenotyp2Wymiarowy()
        {
            return genotyp2Wymiarowy;
        }
    }
}
