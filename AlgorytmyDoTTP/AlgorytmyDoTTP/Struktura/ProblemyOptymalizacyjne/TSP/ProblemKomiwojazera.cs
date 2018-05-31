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
            instancje = new Instancja[miasta.Count];
            dlugoscGenotypu = (ushort)miasta.Count;

            for (short i = 0; i < miasta.Count; i++)
            {
                for (short j = (short)(miasta.Count - 1); j > 0; j--)
                {
                    if (i != j)
                    {
                        double x1 = double.Parse(miasta[i]["x"].InnerText),
                               y1 = double.Parse(miasta[i]["y"].InnerText),
                               x2 = double.Parse(miasta[j]["x"].InnerText),
                               y2 = double.Parse(miasta[j]["y"].InnerText),
                               dystans = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));

                        instancje[i] = new Instancja((short)(i + 1), (short)(j + 1), dystans);
                    }
                }
            }
        }

        public override Dictionary<String, double[]> ObliczZysk(ArrayList wektor)
        {
            Dictionary<String, double[]> wynik = new Dictionary<String, double[]>();
            double zysk = ObliczDlugoscTrasy(wektor);

            wynik["min"] = new double[] { zysk };
            wynik["max"] = new double[] { zysk * -1 };

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

        public override ArrayList ZwrocWybraneElementy(ushort[] wybraneElementy)
        {
            ArrayList wynik = new ArrayList();
            wynik.AddRange(wybraneElementy);

            return wynik;
        }

        public override Dictionary<string, ushort[]> ZwrocWybraneElementy(ushort[][] wybraneElementy)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, double[]> ObliczZysk(Dictionary<string, double[]> wektor)
        {
            throw new NotImplementedException();
        }
    }
}