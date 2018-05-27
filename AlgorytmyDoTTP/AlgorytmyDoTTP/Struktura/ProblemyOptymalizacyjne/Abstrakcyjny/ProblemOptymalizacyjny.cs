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

        public void UstawFlagePodOgraniczenia(bool czyIstniejaOgraniczenia)
        {
            this.czyIstniejaOgraniczenia = czyIstniejaOgraniczenia;
        }

        public double[] ZwrocOgraniczeniaProblemu()
        {
            return zwrocOgraniczenia;
        }

        public void UstawOgraniczeniaProblemu(double ograniczenie)
        {
            zwrocOgraniczenia = new double[] { ograniczenie };
        }

        public void UstawOgraniczeniaProblemu(double[] ograniczenia)
        {
            zwrocOgraniczenia = (double[])ograniczenia.Clone();
        }

        public ushort ZwrocDlugoscGenotypu()
        {
            return dlugoscGenotypu;
        }

        public abstract Dictionary<string, double[]> ObliczZysk(ArrayList wektor);

        public abstract ArrayList ZwrocWybraneElementy(ushort[] wybraneElementy);
    }
}