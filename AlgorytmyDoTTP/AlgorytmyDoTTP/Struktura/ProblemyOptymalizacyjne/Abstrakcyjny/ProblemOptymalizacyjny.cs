using System.Collections;
using System.Collections.Generic;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny
{
    /// <summary>
    /// Klasa abstrakcyjna reprezentująca Problemy Optymalizacyjne
    /// </summary>
    abstract class ProblemOptymalizacyjny
    {
        protected ushort dlugoscGenotypu = 0;
        protected bool czyIstniejaOgraniczenia = false;
        protected IPomocniczy[] instancje;
        protected double[] zwrocOgraniczenia;

        /// <summary>
        /// Metoda zwraca wartość prawda, jeżeli problem ma ograniczenia zwenętrzne
        /// </summary>
        /// <returns>Czy istnieją ograniczenia</returns>
        public bool CzyIstniejaOgraniczenia()
        {
            return czyIstniejaOgraniczenia;
        }

        /// <summary>
        /// Metoda zwraca wartości liczbowe ograniczeń
        /// </summary>
        /// <returns>Wartości ograniczeń</returns>
        public double[] ZwrocOgraniczeniaProblemu()
        {
            return zwrocOgraniczenia;
        }

        /// <summary>
        /// Metoda ustawia ograniczenia dla Porblemu Optymalizacyjnego
        /// </summary>
        /// <param name="ograniczenie">Wartość ograniczenia</param>
        public void UstawOgraniczeniaProblemu(double ograniczenie)
        {
            czyIstniejaOgraniczenia = true;
            zwrocOgraniczenia = new double[] { ograniczenie };
        }

        /// <summary>
        /// Metoda ustawia ograniczenia dla Porblemu Optymalizacyjnego
        /// </summary>
        /// <param name="ograniczenie">Wartości ograniczenia</param>
        public void UstawOgraniczeniaProblemu(double[] ograniczenia)
        {
            czyIstniejaOgraniczenia = true;
            zwrocOgraniczenia = (double[])ograniczenia.Clone();
        }

        /// <summary>
        /// Metoda zwraca długość genotypu
        /// </summary>
        /// <returns>Rozpiętość dziedziny</returns>
        public ushort ZwrocDlugoscGenotypu()
        {
            return dlugoscGenotypu;
        }

        /// <summary>
        /// Metoda zwraca dostępne przedmioty dla Problemu Podróżującego Złodzieja
        /// </summary>
        /// <returns>Zwraca dostępne przedmioty pod miasta</returns>
        public abstract ushort[][] ZwrocDostepnePrzedmioty();

        /// <summary>
        /// Metoda oblicza wartość funkcji celu
        /// </summary>
        /// <param name="wektor">Dziedzina problemu</param>
        /// <returns>Zwraca obliczoną wartość funkcji celu</returns>
        public abstract Dictionary<string, double[]> ObliczZysk(Dictionary<string, ushort[][]> wektor);

        /// <summary>
        /// Metoda oblicza wartość funkcji celu
        /// </summary>
        /// <param name="wektor">Dziedzina problemu</param>
        /// <returns>Zwraca obliczoną wartość funkcji celu</returns>
        public abstract Dictionary<string, double[]> ObliczZysk(ArrayList wektor);

        /// <summary>
        /// Metoda zwraca wybrane elementy w reprezentacji listowej
        /// </summary>
        /// <param name="wybraneElementy">Dziedzina problemu</param>
        /// <returns>Zwraca wybrane elementy</returns>
        public abstract ArrayList ZwrocWybraneElementy(ushort[] wybraneElementy);

        /// <summary>
        /// Metoda zwraca wybrane elementy w reprezentacji słownikowej
        /// </summary>
        /// <param name="wybraneElementy">Dziedzina problemu</param>
        /// <returns>Zwraca wybrane elementy</returns>
        public abstract Dictionary<string, ushort[][]> ZwrocWybraneElementy(ushort[][] wybraneElementy);
    }
}