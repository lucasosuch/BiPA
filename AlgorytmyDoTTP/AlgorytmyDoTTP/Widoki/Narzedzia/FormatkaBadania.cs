using AlgorytmyDoTTP.Konfiguracja;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TSP;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace AlgorytmyDoTTP.Widoki.Narzedzia
{
    /// <summary>
    /// Klasa narzędziowa widoku badania
    /// </summary>
    class FormatkaBadania : FormatkaGlowna
    {
        private string nazwaFolderu = "";
        private float[][] ranking = null;
        private IAlgorytm algorytm = null;
        private AAnalityka analityka = null;
        private Dictionary<string, string> parametry;
        private Glowna konfiguracjaSrodowiska = new Glowna();
        private WynikiAnalizy wynikiAnalizy = new WynikiAnalizy();

        public void UstawParametryBadania(Dictionary<string, string> parametry)
        {
            this.parametry = parametry;
        }

        /// <summary>
        /// Metoda uruchamiająca badanie, tzn. rozpoczęcie rozwiązania wybranego Problemu Optymalizacyjnego za pomocą wybranego Algorytmu
        /// </summary>
        /// <returns>Wyniki czytelne dla człowieka</returns>
        public Task UruchomBadanie(Progress<PostepBadania> postep)
        {
            algorytm = ZwrocWybranyAlgorytm().ZbudujAlgorytm(parametry, ZwrocWybranyProblem());
            return algorytm.Start(postep);
        }

        public string wynikiBadania()
        {
            analityka = algorytm.ZwrocAnalityke();
            ranking = wynikiAnalizy.ZwrocRanking(analityka.ZwrocMinWartoscProcesuPoszukiwan(), analityka.ZwrocMaxWartoscProcesuPoszukiwan(), analityka.ZwrocSredniaWartosciProcesuPoszukiwan());

            return  "---" + Environment.NewLine +
                    "Data i czas badania: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + Environment.NewLine +
                    "Rozwiązano "+ parametry["problem"] + ", metodą: "+ parametry["algorytm"] + ",  w czasie ok. " + (analityka.ZwrocLiczbeIteracji() * analityka.ZwrocCzasDzialaniaAlgorytmu()) + "s" + Environment.NewLine +
                    "Najlepszy znaleziony wynik x w toku całego procesu poszukiwań wynosi: " + analityka.ZwrocNajlepszeZnalezioneRozwiazanie() + ", o wartości F(x) = {" + analityka.ZwrocWartoscNiebo()["max"][0] +", "+ analityka.ZwrocWartoscNiebo()["min"][0] + "}"+ Environment.NewLine;
        }

        public AAnalityka ZwrocAnalityke()
        {
            if (analityka == null) throw new Exception("Nie wykonano badania");

            return analityka;
        }

        /// <summary>
        /// Metoda formatuje odpowiedź z badania dla pliku CSV
        /// </summary>
        /// <returns>Zwraca sformatowaną odpowiedź z badania</returns>
        public string ZwrocDaneDoCSV()
        {
            StringBuilder csv = new StringBuilder();
            double[][] wartosciSrednie = analityka.ZwrocSredniaWartosciProcesuPoszukiwan(),
                       wartosciMin = analityka.ZwrocMinWartoscProcesuPoszukiwan(),
                       wartosciMax = analityka.ZwrocMaxWartoscProcesuPoszukiwan();

            foreach (KeyValuePair<string, string> parametr in parametry)
            {
                string newLine = string.Format("{0}; {1}", parametr.Key, parametr.Value);
                csv.AppendLine(newLine);
            }
            
            csv.AppendLine(string.Format(";"));
            csv.AppendLine(string.Format("Iteracja; Czas; Średnia wartość; Minimalna wartość; Maksymalna wartość"));

            for (int i = 0; i < wartosciSrednie.Length; i++)
            {
                for (int j = 0; j < wartosciSrednie[i].Length; j++)
                {
                    string newLine = string.Format("{0}; {1}; {2}; {3}; {4}", (i+1), j, wartosciSrednie[i][j], wartosciMin[i][j], wartosciMax[i][j]);
                    csv.AppendLine(newLine);
                }
            }

            return csv.ToString();
        }

        /// <summary>
        /// Metoda zwraca nazwę pliku
        /// </summary>
        /// <param name="rozszerzenie">Rozszerzenie pliku</param>
        /// <param name="iter">Liczba mówiąca, które jest to badanie Problemu Optymalizacyjnego pod Algorytm tego dnia</param>
        /// <returns>Nazwę pliku</returns>
        public string ZwrocNazwePliku(string rozszerzenie, string iter)
        {
            return "("+ DateTime.Now.ToString("d") +") "+ parametry["algorytm"] +"_"+ parametry["dane"] +""+ iter + rozszerzenie;
        }

        /// <summary>
        /// Metoda zapisuje badanie do pliku XML na dysku
        /// </summary>
        public string[] ZapiszBadanie()
        {
            int iter = 0,
                najlepszaIteracjaBadania = (int)ranking[0][0];
            string[] znalezionePliki;

            do
            {
                iter++;
                znalezionePliki = Directory.GetFiles(@"./Badania/", ZwrocNazwePliku(".xml", "_" + iter));
            } while (znalezionePliki.Length != 0);

            XDocument xml = new XDocument();

            XmlDocument dokument = new XmlDocument();
            dokument.Load("./Dane/"+ nazwaFolderu +"/" + parametry["dane"] +".xml");
            XmlNode hashPlikuDanych = dokument.DocumentElement.SelectSingleNode("/korzen/hash");

            XElement czasDzialania = new XElement("czasDzialania", (analityka.ZwrocCzasDzialaniaAlgorytmu() * analityka.ZwrocLiczbeIteracji())),
                     maxWartosc = new XElement("maxWartosc", analityka.ZwrocWartoscNiebo()["max"][0]),
                     minWartosc = new XElement("minWartosc", analityka.ZwrocWartoscNiebo()["min"][0]),
                     dataZapisu = new XElement("dataZapisu", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")),
                     nazwaBadania = new XElement("nazwaBadania", parametry["algorytm"] + "_" + parametry["dane"] + "_" + iter),
                     krotkiTekst = new XElement("porownawczyTekst", parametry["doPorownania"]),
                     plikDanych = new XElement("plikDanych", parametry["dane"]),
                     hash = new XElement("hash", hashPlikuDanych.InnerText),
                     dziedzina = new XElement("dziedzina", analityka.ZwrocNajlepszeZnalezioneRozwiazanie());

            XElement badanie = new XElement("badanie"),
                     podstawoweDane = new XElement("podstawoweDane"),
                     rozwiazanie = new XElement("rozwiazanie"),
                     przebiegBadania = new XElement("przebiegBadania"),
                     dodatkoweDane = new XElement("dodatkoweDane");

            XElement[] dodatki = new XElement[parametry.Count - 2];

            int i = 0;
            foreach (KeyValuePair<string, string> parametr in parametry)
            {
                if (parametr.Key != "algorytm" && parametr.Key != "dane" && parametr.Key != "doPorownania")
                {
                    dodatki[i] = new XElement(parametr.Key, parametr.Value);
                    i++;
                }
            }

            double[][] wartosciSrednie = analityka.ZwrocSredniaWartosciProcesuPoszukiwan(),
                       wartosciMin = analityka.ZwrocMinWartoscProcesuPoszukiwan(),
                       wartosciMax = analityka.ZwrocMaxWartoscProcesuPoszukiwan();

            XElement srednia = new XElement("srednia"),
                     min = new XElement("minimum"),
                     max = new XElement("maksimum");

            for (int j = 0; j < wartosciSrednie[najlepszaIteracjaBadania].Length; j++)
            {
                srednia.Add(new XElement("x", wartosciSrednie[najlepszaIteracjaBadania][j].ToString()));
                min.Add(new XElement("x", wartosciMin[najlepszaIteracjaBadania][j].ToString()));
                max.Add(new XElement("x", wartosciMax[najlepszaIteracjaBadania][j].ToString()));
            }

            przebiegBadania.Add(srednia);
            przebiegBadania.Add(min);
            przebiegBadania.Add(max);

            dodatkoweDane.Add(dodatki);
            podstawoweDane.Add(nazwaBadania);
            podstawoweDane.Add(krotkiTekst);
            podstawoweDane.Add(dataZapisu);
            podstawoweDane.Add(maxWartosc);
            podstawoweDane.Add(minWartosc);
            podstawoweDane.Add(czasDzialania);
            podstawoweDane.Add(plikDanych);
            podstawoweDane.Add(hash);

            rozwiazanie.Add(dziedzina);
            rozwiazanie.Add(przebiegBadania);

            badanie.Add(podstawoweDane);
            badanie.Add(rozwiazanie);
            badanie.Add(dodatkoweDane);
            xml.Add(badanie);

            xml.Save("./Badania/"+ ZwrocNazwePliku(".xml", "_"+ iter));

            return new string[] { ZwrocNazwePliku("", "_" + iter), DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), parametry["doPorownania"] };
        }

        public string RysujWykres(bool narysowanoWykres, int szerokosc, int wysokosc, string[] nazwyPlikow)
        {
            double[][] wartosciSrednie = analityka.ZwrocSredniaWartosciProcesuPoszukiwan(),
                       wartosciMin = analityka.ZwrocMinWartoscProcesuPoszukiwan(),
                       wartosciMax = analityka.ZwrocMaxWartoscProcesuPoszukiwan();

            float[][][] wyniki = wynikiAnalizy.PrzetworzDane(ranking, wartosciSrednie, wartosciMin, wartosciMax);

            string[] nazwyWykresow = new string[wartosciSrednie.Length];
            for (int i = 0; i < wartosciSrednie.Length; i++)
            {
                nazwyWykresow[i] = "iteracja" + (i+1);
            }

            if (!narysowanoWykres)
            {
                wynikiAnalizy.StworzWykresyGNUplot(szerokosc, wysokosc, nazwyWykresow, nazwyPlikow, analityka.ZwrocMinWartoscProcesuPoszukiwan(), analityka.ZwrocMaxWartoscProcesuPoszukiwan(), analityka.ZwrocSredniaWartosciProcesuPoszukiwan());
            }

            return wynikiAnalizy.WyswietlInformacjeZwrotna(ranking, wyniki[2], wyniki[0], wyniki[1], nazwyWykresow);
        }

        /// <summary>
        /// Metoda zwraca instancję wybranego Problemu Optymalizacyjnego
        /// </summary>
        /// <returns>Instancję Problemu Optymalizacyjnego</returns>
        private ProblemOptymalizacyjny ZwrocWybranyProblem()
        {
            if (parametry["problem"] == "Problem Plecakowy")
            {
                ProblemPlecakowy problemKP = new ProblemPlecakowy(parametry["dane"]);
                problemKP.UstawOgraniczeniaProblemu(float.Parse(parametry["maxWaga"]));

                return problemKP;
            }
            else if (parametry["problem"] == "Problem Podróżującego Złodzieja")
            {
                ProblemPodrozujacegoZlodzieja problemTTP = new ProblemPodrozujacegoZlodzieja(parametry["dane"], parametry["modelTTP"]);
                problemTTP.UstawOgraniczeniaProblemu(new float[] { float.Parse(parametry["maxWaga"]), float.Parse(parametry["wyporzyczeniePlecaka"]) });

                return problemTTP;
            }

            return new ProblemKomiwojazera(parametry["dane"]);
        }

        /// <summary>
        /// Metoda zwraca instancję wybranego Algorytmu
        /// </summary>
        /// <returns>Instancję Algorytmu</returns>
        private Algorytm ZwrocWybranyAlgorytm()
        {
            if (parametry["algorytm"] == "Algorytm Ewolucyjny")
            {
                return new Struktura.Algorytmy.Ewolucyjny.PrzebiegAlgorytmu();
            } else if(parametry["algorytm"] == "Algorytm Wspinaczkowy")
            {
                return new Struktura.Algorytmy.Wspinaczkowy.PrzebiegAlgorytmu();
            }

            return new Struktura.Algorytmy.Losowy.PrzebiegAlgorytmu();
        }

        /// <summary>
        /// Metoda odpowiada za wczytanie plików odpowiadających za konfigurację Problemów Optymalizacyjnych
        /// </summary>
        /// <param name="wybranyProblem">Nazwa Problemu Optymalizacyjnego</param>
        /// <returns>Nazwy plików danych pod wybrany Problem Optymalizacyjny</returns>
        public object[] WczytajPlikiDanych(string wybranyProblem)
        {
            for (int i = 0; i < konfiguracjaSrodowiska.PROBLEMY_OPTYMALIZACYJNE.Length; i++)
            {
                if ((string)konfiguracjaSrodowiska.PROBLEMY_OPTYMALIZACYJNE[i] == wybranyProblem)
                {
                    nazwaFolderu = konfiguracjaSrodowiska.FOLDERY_Z_DANYMI[i];
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
        /// Metoda odpowiada za walidację danych z formatki
        /// </summary>
        /// <param name="parametry">Parametry badania</param>
        /// <exception cref="Exception">Zwraca wyjątek jeżeli jest błąd w formatce</exception>
        public void WalidacjaFormatki(Dictionary<string, string> parametry)
        {
            bool walidacja = true;
            string bladnaWartosc = "";
            string[] polaTekstowe = konfiguracjaSrodowiska.PARAMETRY_TEKSTOWE,
                     polaCalkowite = konfiguracjaSrodowiska.PARAMETRY_CALKOWITE,
                     polaZmiennoprzecinkowe = konfiguracjaSrodowiska.PARAMETRY_ZMIENNOPRZECINKOWE;
                     
            MetodyWalidacji metodyWalidacji = new MetodyWalidacji();

            for (int i = 0; i < polaTekstowe.Length; i++)
            {
                if (parametry.ContainsKey(polaTekstowe[i]))
                {
                    if (!metodyWalidacji.CzyPustePoleTekstowe(parametry[polaTekstowe[i]]))
                    {
                        bladnaWartosc = polaTekstowe[i];
                        walidacja = false;
                        break;
                    }
                }
            }

            if (walidacja)
            {
                for (int i = 0; i < polaCalkowite.Length; i++)
                {
                    if (parametry.ContainsKey(polaCalkowite[i]))
                    {
                        if (!metodyWalidacji.CzyPoprawneCalkowite(parametry[polaCalkowite[i]]))
                        {
                            bladnaWartosc = polaCalkowite[i];
                            walidacja = false;
                            break;
                        }
                    }
                }
            }

            if (walidacja)
            {
                for (int i = 0; i < polaZmiennoprzecinkowe.Length; i++)
                {
                    if (parametry.ContainsKey(polaZmiennoprzecinkowe[i]))
                    {
                        if (!metodyWalidacji.CzyPoprawneZmiennoPrzecinkowe(parametry[polaZmiennoprzecinkowe[i]]))
                        {
                            bladnaWartosc = polaZmiennoprzecinkowe[i];
                            walidacja = false;
                            break;
                        }
                    }
                }
            }

            if (!walidacja)
            {
                throw new Exception("Wartość w polu: " + bladnaWartosc + " ma zły format!");
            }
        }

        /// <summary>
        /// Metoda zwraca instancję konfiguracji środowiskowej
        /// </summary>
        /// <returns>Zwraca instancję konfiguracji środowiska aplikacji</returns>
        public Glowna ZwrocZmiennaSrodowiskowa()
        {
            return konfiguracjaSrodowiska;
        }
    }
}
