using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace AlgorytmyDoTTP.Widoki.Narzedzia
{
    /// <summary>
    /// Klasa narzędziowa widoku głownego aplikacji
    /// </summary>
    class FormatkaGlowna
    {
        /// <summary> 
        /// Metoda odpowiada za wczytanie wszystkich badań z folderu zawierającego zapisane badania
        /// </summary>
        /// <returns>Elementy historycznych zapisów badań</returns>
        public ListViewItem[] WczytajHistoryczneBadania()
        {
            DirectoryInfo sciezka = new DirectoryInfo("./Badania");
            FileInfo[] pliki = sciezka.GetFiles("*.xml");
            ListViewItem[] elementy = new ListViewItem[pliki.Length];

            for (int i = 0; i < pliki.Length; i++)
            {
                XmlDocument dokument = new XmlDocument();
                dokument.Load("./Badania/" + pliki[i].Name);
                XmlNode dataZapisu = dokument.DocumentElement.SelectSingleNode("/badanie/podstawoweDane/dataZapisu");

                string[] wiersz = new string[] { pliki[i].Name.Replace(".xml", ""), dataZapisu.InnerText };
                elementy[i] = new ListViewItem(wiersz);
            }

            return elementy;
        }

        /// <summary>
        /// Metoda odpowiada za wczytanie badań i ich parametrów
        /// </summary>
        /// <param name="zaznaczoneElementy">Nazwy badań wybranych do porównania</param>
        /// <returns>Parametry z badań potrzebne do porównania</returns>
        public Dictionary<string, string[]> ZbierzDaneDoPorownania(ListView.CheckedListViewItemCollection zaznaczoneElementy)
        {
            Dictionary<string, string[]> paramentry = new Dictionary<string, string[]>();

            foreach (ListViewItem element in zaznaczoneElementy)
            {
                string nazwa = element.SubItems[0].Text;

                XmlDocument dokument = new XmlDocument();
                dokument.Load("./Badania/" + nazwa + ".xml");

                XmlNode maxWartosc = dokument.DocumentElement.SelectSingleNode("/badanie/podstawoweDane/maxWartosc");
                XmlNode czasDzialania = dokument.DocumentElement.SelectSingleNode("/badanie/podstawoweDane/czasDzialania");
                XmlNode nazwaBadania = dokument.DocumentElement.SelectSingleNode("/badanie/podstawoweDane/nazwaBadania");
                XmlNode plikDanych = dokument.DocumentElement.SelectSingleNode("/badanie/podstawoweDane/plikDanych");

                paramentry[nazwa] = new string[] { czasDzialania.InnerText.Replace(" ms", ""), maxWartosc.InnerText, nazwaBadania.InnerText, plikDanych.InnerText };
            }

            return paramentry;
        }

        public void UsunWybraneBadania(ListView.CheckedListViewItemCollection zaznaczoneElementy)
        {
            foreach (ListViewItem element in zaznaczoneElementy)
            {
                string nazwa = element.SubItems[0].Text + ".xml";

                if (File.Exists(@"./Badania/"+ nazwa))
                {
                    File.Delete(@"./Badania/"+ nazwa);
                }
            }
        }

        public string ZwrocDanePodgladanegoBadania(ListView.SelectedListViewItemCollection wybraneElementy)
        {
            string odpowiedz = "";

            foreach (ListViewItem element in wybraneElementy)
            {
                string nazwa = element.SubItems[0].Text;
                XmlDocument dokument = new XmlDocument();
                dokument.Load("./Badania/" + nazwa + ".xml");

                XmlNode maxWartosc = dokument.DocumentElement.SelectSingleNode("/badanie/podstawoweDane/maxWartosc"),
                        czasDzialania = dokument.DocumentElement.SelectSingleNode("/badanie/podstawoweDane/czasDzialania"),
                        nazwaBadania = dokument.DocumentElement.SelectSingleNode("/badanie/podstawoweDane/nazwaBadania"),
                        plikDanych = dokument.DocumentElement.SelectSingleNode("/badanie/podstawoweDane/plikDanych"),
                        dziedzina = dokument.DocumentElement.SelectSingleNode("/badanie/rozwiazanie/dziedzina");

                XmlNodeList dodatkoweDane = dokument.DocumentElement.SelectNodes("/badanie/dodatkoweDane");

                odpowiedz = "Nazwa Badania: " + nazwaBadania.InnerText + Environment.NewLine +
                            "Plik danych: " + plikDanych.InnerText + Environment.NewLine +
                            "Wartość: " + maxWartosc.InnerText + Environment.NewLine +
                            "Czas działania: " + czasDzialania.InnerText + " ms" + Environment.NewLine +
                            "Rozwiązanie: " + dziedzina.InnerText + Environment.NewLine + Environment.NewLine +
                            "Dane dodatkowe: " + Environment.NewLine;

                foreach (XmlNode dane in dodatkoweDane)
                {
                    foreach (XmlNode atrybut in dane.ChildNodes)
                    {
                        odpowiedz += atrybut.Name + ": " + atrybut.InnerText + Environment.NewLine;
                    }
                }
            }

            return odpowiedz;
        }
    }
}
