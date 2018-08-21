using AlgorytmyDoTTP.KonfiguracjaAlgorytmow;
using AlgorytmyDoTTP.Widoki.Walidacja;
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
        private AE algorytmEwolucyjny = new AE();
        private Konfiguracja srodowisko = new Konfiguracja();

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
        /// Metoda odpowiada za wczytanie plików odpowiadających za konfigurację Problemów Optymalizacyjnych
        /// </summary>
        /// <param name="wybranyProblem">Nazwa Problemu Optymalizacyjnego</param>
        /// <returns>Nazwy plików danych pod wybrany Problem Optymalizacyjny</returns>
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

            DirectoryInfo d = new DirectoryInfo("./Dane/" + nazwaFolderu);
            FileInfo[] files = d.GetFiles("*.xml");
            object[] pliki = new object[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                pliki[i] = files[i].Name.Replace(".xml", "");
            }

            return pliki;
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

                paramentry[nazwa] = new string[] { czasDzialania.InnerText, maxWartosc.InnerText, nazwaBadania.InnerText, plikDanych.InnerText };
            }

            return paramentry;
        }

        public void UsunWybraneBadania(ListView.CheckedListViewItemCollection zaznaczoneElementy)
        {
            foreach (ListViewItem element in zaznaczoneElementy)
            {
                string nazwa = element.SubItems[0].Text;

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

                odpowiedz = "Nazwa Badania: " + nazwaBadania.InnerText + Environment.NewLine +
                            "Plik danych: " + plikDanych.InnerText + Environment.NewLine +
                            "Wartość: " + maxWartosc.InnerText + Environment.NewLine +
                            "Czas działania: " + czasDzialania.InnerText + " ms" + Environment.NewLine +
                            "Rozwiązanie: " + dziedzina.InnerText;


            }

            return odpowiedz;
        }

        /// <summary>
        /// Metoda odpowiada za walidację danych z formatki
        /// </summary>
        /// <param name="parametry">Parametry badania</param>
        /// <exception cref="Exception">Zwraca wyjątek jeżeli jest błąd w formatce</exception>
        public void WalidacjaFormatki(Dictionary<string, string> parametry)
        {
            bool walidacja = new WalidacjaAE().CzyPoprawneCalkowite(parametry, algorytmEwolucyjny.parametryCalkowite) && new WalidacjaAE().CzyPoprawneZmiennoPrzecinkowe(parametry, algorytmEwolucyjny.parametryZmiennoPrzecinkowe);

            if (!walidacja)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Metoda odpowiada za walidację podstawowych parametrów odpowiadających za badania
        /// </summary>
        /// <param name="parametry">Parametr badania</param>
        /// <exception cref="Exception">Zwraca wyjątek jeżeli jest błąd w formatce</exception>
        public void WalidacjaKluczowychParametrow(string parametr)
        {
            bool walidacja = new WalidacjaAE().CzyPustePoleTekstowe(parametr);

            if (!walidacja)
            {
                throw new Exception("Parametr "+ parametr +" nie może być pusty!");
            }
        }

        /// <summary>
        /// Metoda zwraca instancję konfiguracji środowiskowej
        /// </summary>
        /// <returns>Zwraca instancję konfiguracji środowiska aplikacji</returns>
        public Konfiguracja ZwrocZmiennaSrodowiskowa()
        {
            return srodowisko;
        }

        /// <summary>
        /// Metoda zwraca instancję konfiguracji Algorytmu Ewolucyjnego
        /// </summary>
        /// <returns>Zwraca instancję konfiguracji Algorytmu Ewolucyjnego</returns>
        public AE ZwrocKonfiguracjeAE()
        {
            return algorytmEwolucyjny;
        }
    }
}
