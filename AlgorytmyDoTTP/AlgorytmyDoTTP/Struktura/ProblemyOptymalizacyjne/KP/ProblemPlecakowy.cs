using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP
{
    /// <summary>
    /// Klasa konkretna reprezentująca Problem Plecakowy
    /// </summary>
    class ProblemPlecakowy : ProblemOptymalizacyjny
    {
        public ProblemPlecakowy(string nazwaPakietu)
        {
            Inicjalizacja(nazwaPakietu);
        }

        public override IPomocniczy[] ZwrocWybraneElementy(ushort[] elementy)
        {
            int liczbaElementow = 0;
            for(int i = 0; i < elementy.Length; i++)
            {
                if (elementy[i] == 1)
                {
                    liczbaElementow++;
                }
            }

            int j = 0;
            IPomocniczy[] wybraneElementy = new IPomocniczy[liczbaElementow];
            for (int i = 0; i < elementy.Length; i++)
            {
                if(elementy[i] == 1)
                {
                    wybraneElementy[j] = instancje[i];
                    j++;
                } 
            }

            return wybraneElementy;
        }

        /// <summary>
        /// Metoda konwertuje dane w pliku XML pod struktury dla C#
        /// </summary>
        /// <param name="nazwaPakietu">Nazwa pliku xml zawierającego dane</param>
        private void Inicjalizacja(string nazwaPakietu)
        {
            XmlDocument dokument = new XmlDocument();
            dokument.Load("./Dane/KP/" + nazwaPakietu + ".xml");

            XmlNodeList przedmioty = dokument.DocumentElement.SelectNodes("/korzen/przedmioty/przedmiot");
            instancje = new Instancja[przedmioty.Count];
            dlugoscGenotypu = (ushort)przedmioty.Count;

            for (int i = 0; i < przedmioty.Count; i++)
            {
                float waga = float.Parse(przedmioty[i]["waga"].InnerText),
                      wartosc = float.Parse(przedmioty[i]["wartosc"].InnerText);

                instancje[i] = new Instancja(waga, wartosc);
            }
        }

        public override Dictionary<String, double[]> ObliczZysk(IPomocniczy[] wektor)
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

        public override Dictionary<string, ushort[][]> ZwrocWybraneElementy(ushort[][] wybraneElementy)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, double[]> ObliczZysk(Dictionary<string, ushort[][]> wektor)
        {
            throw new NotImplementedException();
        }

        public override ushort[][] ZwrocDostepnePrzedmioty()
        {
            throw new NotImplementedException();
        }
    }
}
