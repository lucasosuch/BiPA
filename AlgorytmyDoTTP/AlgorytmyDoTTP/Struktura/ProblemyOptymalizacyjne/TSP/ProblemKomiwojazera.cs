using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TSP
{
    class ProblemKomiwojazera : ProblemOptymalizacyjny
    {
        public ProblemKomiwojazera(string nazwaPakietu)
        {
            Inicjalizacja(nazwaPakietu);
        }

        private void Inicjalizacja(string nazwaPakietu)
        {
            XmlDocument dokument = new XmlDocument();
            dokument.Load("../../Dane/TSP/" + nazwaPakietu + ".xml");

            XmlNodeList miasta = dokument.DocumentElement.SelectNodes("/mapa/miasto");

            foreach (XmlNode miasto in miasta)
            {

            }
        }

        public override Dictionary<String, double[]> ObliczZysk(ArrayList wektor)
        {
            Dictionary<String, double[]> wynik = new Dictionary<String, double[]>();
            wynik["min"] = new double[] { 0 };
            wynik["max"] = new double[] { ObliczDlugoscTrasy(wektor) * -1 };

            return wynik;
        }

        private double ObliczDlugoscTrasy(ArrayList wektor)
        {
            double wynik = 0;
            int dlugoscWekotra = wektor.Count;

            for (int i = 0; i < dlugoscWekotra; i++)
            {
                int j = (i == 0) ? dlugoscWekotra - 1 : i - 1;

                foreach (Instancja instancja in instancje)
                {
                    if (instancja.ZwrocOd() == (ushort)wektor[j] && instancja.ZwrocDo() == (ushort)wektor[i])
                    {
                        wynik += instancja.ZwrocDlugosc();
                    }
                    else if (instancja.ZwrocDo() == (ushort)wektor[j] && instancja.ZwrocOd() == (ushort)wektor[i])
                    {
                        wynik += instancja.ZwrocDlugosc();
                    }
                }
            }

            return wynik;
        }
    }
}