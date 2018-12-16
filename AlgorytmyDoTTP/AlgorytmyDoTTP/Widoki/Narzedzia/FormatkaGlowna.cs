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
        public Dictionary<string, double[][]> ZbierzDaneDoPorownania(ListView.CheckedListViewItemCollection zaznaczoneElementy)
        {
            //int iter = 0;
            //string hash = "";
            Dictionary<string, double[][]> paramentry = new Dictionary<string, double[][]>();

            foreach (ListViewItem element in zaznaczoneElementy)
            {
                //XmlDocument plikDanych = new XmlDocument();
                //plikDanych.Load("./Dane/" + nazwa + ".xml");

                //if (iter == 0)
                //{
                //    hash = linia1.Value[3];
                //}
                //else
                //{
                //    if (hash != linia1.Value[3])
                //    {
                //        throw new Exception("Różne pliki danych");
                //    }
                //}

                string nazwa = element.SubItems[0].Text;

                XmlDocument dokument = new XmlDocument();
                dokument.Load("./Badania/" + nazwa + ".xml");

                XmlNodeList srednia = dokument.DocumentElement.SelectNodes("/badanie/rozwiazanie/przebiegBadania/srednia/x"),
                            minimum = dokument.DocumentElement.SelectNodes("/badanie/rozwiazanie/przebiegBadania/minimum/x"),
                            maksimum = dokument.DocumentElement.SelectNodes("/badanie/rozwiazanie/przebiegBadania/maksimum/x");
                
                int i = 0;
                double[] avg = new double[srednia.Count];
                foreach (XmlNode dane in srednia)
                {
                    avg[i] = double.Parse(dane.InnerText);
                    i++;
                }
                
                i = 0;
                double[] min = new double[minimum.Count];
                foreach (XmlNode dane in minimum)
                {
                    min[i] = double.Parse(dane.InnerText);
                    i++;
                }
                
                i = 0;
                double[] max = new double[maksimum.Count];
                foreach (XmlNode dane in maksimum)
                {
                    max[i] = double.Parse(dane.InnerText);
                    i++;
                }

                string nazwaBadania = dokument.DocumentElement.SelectSingleNode("/badanie/podstawoweDane/nazwaBadania").InnerText.Replace(" ", "").Trim();
                paramentry[nazwaBadania] = new double[][] { avg, min, max };

                //iter++;
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
                            "Czas działania: " + czasDzialania.InnerText + " s" + Environment.NewLine +
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
