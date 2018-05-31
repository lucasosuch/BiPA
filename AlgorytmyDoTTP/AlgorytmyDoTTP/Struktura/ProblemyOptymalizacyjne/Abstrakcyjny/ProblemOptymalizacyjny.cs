using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny
{
    abstract class ProblemOptymalizacyjny
    {
        protected ushort dlugoscGenotypu = 0;
        protected bool czyIstniejaOgraniczenia = false;
        protected IPomocniczy[] instancje;
        protected double[] zwrocOgraniczenia;

        public bool CzyIstniejaOgraniczenia()
        {
            return czyIstniejaOgraniczenia;
        }

        public double[] ZwrocOgraniczeniaProblemu()
        {
            return zwrocOgraniczenia;
        }

        public void UstawOgraniczeniaProblemu(double ograniczenie)
        {
            czyIstniejaOgraniczenia = true;
            zwrocOgraniczenia = new double[] { ograniczenie };
        }

        public void UstawOgraniczeniaProblemu(double[] ograniczenia)
        {
            czyIstniejaOgraniczenia = true;
            zwrocOgraniczenia = (double[])ograniczenia.Clone();
        }

        public ushort ZwrocDlugoscGenotypu()
        {
            return dlugoscGenotypu;
        }

        public abstract Dictionary<string, double[]> ObliczZysk(Dictionary<string, double[]> wektor);

        public abstract Dictionary<string, double[]> ObliczZysk(ArrayList wektor);

        public abstract ArrayList ZwrocWybraneElementy(ushort[] wybraneElementy);

        public abstract Dictionary<string, ushort[]> ZwrocWybraneElementy(ushort[][] wybraneElementy);
    }
}