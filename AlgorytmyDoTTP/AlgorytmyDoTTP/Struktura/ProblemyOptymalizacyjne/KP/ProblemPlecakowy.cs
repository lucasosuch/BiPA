using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP
{
    class ProblemPlecakowy : ProblemOptymalizacyjny
    {
        public ProblemPlecakowy(string nazwaPakietu)
        {
            Inicjalizacja(nazwaPakietu);
        }

        public ArrayList ZwrocWybraneElementy(ushort[] wybraneElementy)
        {
            ArrayList listaElementow = new ArrayList();

            for (int i = 0; i < wybraneElementy.Length; i++)
            {
                if(wybraneElementy[i] == 1)
                {
                    listaElementow.Add(instancje[i]);
                } 
            }

            return listaElementow;
        }

        private void Inicjalizacja(string nazwaPakietu)
        {
            XmlDocument dokument = new XmlDocument();
            dokument.Load("../../Dane/KP/" + nazwaPakietu + ".xml");

            XmlNodeList przedmioty = dokument.DocumentElement.SelectNodes("/przedmioty/przedmiot");

            foreach (XmlNode przedmiot in przedmioty)
            {
                
            }
        }

        public override Dictionary<String, double[]> ObliczZysk(ArrayList wektor)
        {
            Dictionary<String, double[]> wynik = new Dictionary<String, double[]>();
            wynik["min"] = new double[] { 0 };
            wynik["max"] = new double[] { 0 };

            foreach (Instancja przedmiot in wektor)
            {
                wynik["min"][0] += przedmiot.ZwrocWage();
                wynik["max"][0] += przedmiot.ZwrocWartosc();
            }

            return wynik;
        }
    }
}
