using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny
{
    abstract class ProblemOptymalizacyjny
    {
        protected IPomocniczy[] instancje;
        protected double[] ZwrocOgraniczenia;
        protected Boolean CzyIstniejaOgraniczenia = false;

        public void UstawFlagePodOgraniczenia(Boolean CzyIstniejaOgraniczenia)
        {
            this.CzyIstniejaOgraniczenia = CzyIstniejaOgraniczenia;
        }

        public double[] ZwrocOgraniczeniaProblemu()
        {
            return ZwrocOgraniczenia;
        }

        public void UstawOgraniczeniaProblemu(double ograniczenie)
        {
            ZwrocOgraniczenia = new double[] { ograniczenie };
        }

        public void UstawOgraniczeniaProblemu(double[] ograniczenia)
        {
            ZwrocOgraniczenia = (double[])ograniczenia.Clone();
        }

        public abstract Dictionary<String, double[]> ObliczZysk(ArrayList wektor);
    }
}