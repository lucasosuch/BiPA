using BiPA.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using System;
using System.Collections.Generic;
using System.Xml;

namespace BiPA.Struktura.ProblemyOptymalizacyjne.KP
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

        public override IElement[] ZwrocWybraneElementy(ushort[] elementy)
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
            IElement[] wybraneElementy = new IElement[liczbaElementow];
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
            instancje = new Przedmiot[przedmioty.Count];
            dlugoscGenotypu = (ushort)przedmioty.Count;

            for (int i = 0; i < przedmioty.Count; i++)
            {
                float waga = float.Parse(przedmioty[i]["waga"].InnerText),
                      wartosc = float.Parse(przedmioty[i]["wartosc"].InnerText);

                instancje[i] = new Przedmiot(waga, wartosc);
            }
        }

        public override Dictionary<string, float[]> ObliczZysk(IElement[] wektor)
        {
            Dictionary<string, float[]> wynik = new Dictionary<string, float[]>();
            wynik["min"] = new float[] { 0 };
            wynik["max"] = new float[] { 0 };

            foreach (Przedmiot przedmiot in wektor)
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

        public override Dictionary<string, float[]> ObliczZysk(Dictionary<string, ushort[][]> wektor)
        {
            throw new NotImplementedException();
        }

        public override ushort[][] ZwrocDostepnePrzedmioty()
        {
            throw new NotImplementedException();
        }
    }
}
