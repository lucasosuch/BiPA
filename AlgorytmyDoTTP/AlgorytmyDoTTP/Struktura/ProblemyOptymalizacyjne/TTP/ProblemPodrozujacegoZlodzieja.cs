using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TSP;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TTP
{
    class ProblemPodrozujacegoZlodzieja : ProblemOptymalizacyjny
    {
        private ushort[][] dostepnePrzedmioty;
        private ProblemPlecakowy problemPlecakowy;
        private ProblemKomiwojazera problemKomiwojazera;

        public ProblemPodrozujacegoZlodzieja(string nazwaPakietu)
        {
            Inicjalizacja(nazwaPakietu);
        }

        private void Inicjalizacja(string nazwaPakietu)
        {
            XmlDocument dokument = new XmlDocument();
            dokument.Load("../../Dane/TTP/" + nazwaPakietu + ".xml");
            XmlNode przypadekTSP = dokument.DocumentElement.SelectSingleNode("/korzen/tsp");
            XmlNode przypadekKP = dokument.DocumentElement.SelectSingleNode("/korzen/kp");

            problemPlecakowy = new ProblemPlecakowy(przypadekKP.InnerText);
            problemKomiwojazera = new ProblemKomiwojazera(przypadekTSP.InnerText);

            XmlNodeList rozmieszczeniePrzedmiotow = dokument.DocumentElement.SelectNodes("/korzen/dostepnePrzedmioty");

            dostepnePrzedmioty = new ushort[problemKomiwojazera.ZwrocDlugoscGenotypu()][];
            for(int i = 0; i < problemKomiwojazera.ZwrocDlugoscGenotypu(); i++)
            {
                dostepnePrzedmioty[i] = new ushort[problemPlecakowy.ZwrocDlugoscGenotypu()];
                Instancja obiektTTP = new Instancja(rozmieszczeniePrzedmiotow[i].InnerText, problemPlecakowy.ZwrocDlugoscGenotypu());

                dostepnePrzedmioty[i] = (ushort[])(obiektTTP.ZwrocPrzedmioty().Clone());
            }
        }

        public override ushort[][] ZwrocDostepnePrzedmioty()
        {
            return dostepnePrzedmioty;
        }

        public ProblemPlecakowy ZwrocProblemPlecakowy()
        {
            return problemPlecakowy;
        }

        public ProblemKomiwojazera ZwrocProblemKomiwojazera()
        {
            return problemKomiwojazera;
        }

        public override Dictionary<string, double[]> ObliczZysk(Dictionary<string, double[]> wektor)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, ushort[]> ZwrocWybraneElementy(ushort[][] wybraneElementy)
        {
            Dictionary<string, ushort[]> wynik = new Dictionary<string, ushort[]>();

            wynik["tsp"] = (ushort[])(wybraneElementy[0].Clone());
            wynik["kp"] = (ushort[])(wybraneElementy[1].Clone());

            return wynik;
        }

        public override ArrayList ZwrocWybraneElementy(ushort[] wybraneElementy)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, double[]> ObliczZysk(ArrayList wektor)
        {
            throw new NotImplementedException();
        }
    }
}
