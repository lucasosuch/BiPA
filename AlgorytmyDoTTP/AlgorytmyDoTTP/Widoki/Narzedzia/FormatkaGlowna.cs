using AlgorytmyDoTTP.KonfiguracjaAlgorytmow;
using AlgorytmyDoTTP.Widoki.Walidacja;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace AlgorytmyDoTTP.Widoki.Narzedzia
{
    class FormatkaGlowna
    {
        private AE algorytmEwolucyjny = new AE();
        private Konfiguracja srodowisko = new Konfiguracja();

        public ListViewItem[] WczytajHistoryczneBadania()
        {
            DirectoryInfo sciezka = new DirectoryInfo("../../../../Badania");
            FileInfo[] pliki = sciezka.GetFiles("*.xml");
            ListViewItem[] elementy = new ListViewItem[pliki.Length];

            for (int i = 0; i < pliki.Length; i++)
            {
                XmlDocument dokument = new XmlDocument();
                dokument.Load("../../../../Badania/" + pliki[i].Name);
                XmlNode dataZapisu = dokument.DocumentElement.SelectSingleNode("/badanie/dataZapisu");

                string[] wiersz = new string[] { pliki[i].Name, dataZapisu.InnerText };
                elementy[i] = new ListViewItem(wiersz);
            }

            return elementy;
        }

        public object[] WczytajPlikiDanych(string wybranyProblem)
        {
            string nazwaFolderu = "";

            for (int i = 0; i < srodowisko.PROBLEMY_OPTYMALIZACYJNE.Length; i++)
            {
                if ((string)srodowisko.PROBLEMY_OPTYMALIZACYJNE[i] == wybranyProblem)
                {
                    nazwaFolderu = srodowisko.FOLDERY_Z_DANYMI[i];
                    break;
                }
            }

            DirectoryInfo d = new DirectoryInfo("../../Dane/" + nazwaFolderu);
            FileInfo[] files = d.GetFiles("*.xml");
            object[] pliki = new object[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                pliki[i] = files[i].Name.Replace(".xml", "");
            }

            return pliki;
        }

        public Dictionary<string, string[]> ZbierzDaneDoPorownania(ListView.CheckedListViewItemCollection zaznaczoneElementy)
        {
            Dictionary<string, string[]> paramentry = new Dictionary<string, string[]>();

            foreach (ListViewItem element in zaznaczoneElementy)
            {
                string nazwa = element.SubItems[0].Text;

                XmlDocument dokument = new XmlDocument();
                dokument.Load("../../../../Badania/" + nazwa);

                XmlNode maxWartosc = dokument.DocumentElement.SelectSingleNode("/badanie/maxWartosc");
                XmlNode czasDzialania = dokument.DocumentElement.SelectSingleNode("/badanie/czasDzialania");

                paramentry[nazwa] = new string[] { czasDzialania.InnerText, maxWartosc.InnerText };
            }

            return paramentry;
        }

        public void WalidacjaFormatki(Dictionary<string, string> parametry)
        {
            bool walidacja = new WalidacjaAE().CzyPoprawneCalkowite(parametry, algorytmEwolucyjny.parametryCalkowite) && new WalidacjaAE().CzyPoprawneZmiennoPrzecinkowe(parametry, algorytmEwolucyjny.parametryZmiennoPrzecinkowe);

            if (!walidacja)
            {
                throw new Exception();
            }
        }

        public Konfiguracja ZwrocZmiennaSrodowiskowa()
        {
            return srodowisko;
        }

        public AE ZwrocKonfiguracjeAE()
        {
            return algorytmEwolucyjny;
        }
    }
}
