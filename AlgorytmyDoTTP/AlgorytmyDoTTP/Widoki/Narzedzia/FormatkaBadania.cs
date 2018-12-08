using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TSP;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TTP;
using AlgorytmyDoTTP.Widoki.KonfiguracjaAlgorytmow;
using AlgorytmyDoTTP.Widoki.Walidacja;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace AlgorytmyDoTTP.Widoki.Narzedzia
{
    /// <summary>
    /// Klasa narzędziowa widoku badania
    /// </summary>
    class FormatkaBadania : FormatkaGlowna
    {
        private AAnalityka analityka = null;
        private DateTime data = DateTime.Today;
        private Dictionary<string, string[]> wyniki;
        private Dictionary<string, string> parametry;
        private AE algorytmEwolucyjny = new AE();
        private Konfiguracja srodowisko = new Konfiguracja();

        public FormatkaBadania()
        {
            wyniki = new Dictionary<string, string[]>();
        }

        public void UstawParametryBadania(Dictionary<string, string> parametry)
        {
            this.parametry = parametry;
        }

        /// <summary>
        /// Metoda uruchamiająca badanie, tzn. rozpoczęcie rozwiązania wybranego Problemu Optymalizacyjnego za pomocą wybranego Algorytmu
        /// </summary>
        /// <returns>Wyniki czytelne dla człowieka</returns>
        public string UruchomBadanie()
        {
            //int liczbaIteracji = int.Parse(parametry["liczbaIteracji"]);
            //float[] zbiorWynikowMax = new float[liczbaIteracji];
            //float[] zbiorWynikowMin = new float[liczbaIteracji];

            //Dictionary<string, string[]> najlepszeWyniki = new Dictionary<string, string[]>();
            //najlepszeWyniki["maxWartosc"] = new string[] { "Najlepsza funkcja przystosowania (max)", (-100000).ToString() };

            IAlgorytm algorytm = ZwrocWybranyAlgorytm().ZbudujAlgorytm(parametry, ZwrocWybranyProblem());
            algorytm.Start();

            analityka = algorytm.ZwrocAnalityke();
            //for (int i = 0; i < liczbaIteracji; i++)
            //{
            //    wyniki.Clear();


            //    zbiorWynikowMax[i] = float.Parse(wyniki["maxWartosc"][1]);
            //    zbiorWynikowMin[i] = float.Parse(wyniki["minWartosc"][1]);
            //    if (float.Parse(najlepszeWyniki["maxWartosc"][1]) < float.Parse(wyniki["maxWartosc"][1]))
            //    {
            //        najlepszeWyniki = new Dictionary<string, string[]>(wyniki);
            //    }
            //}

            //wynikiBadania += "Najlepsze znalezione badanie: " + Environment.NewLine;
            //foreach (KeyValuePair<string, string[]> linia in najlepszeWyniki)
            //{
            //    wynikiBadania += linia.Value[0] + ": " + linia.Value[1] + Environment.NewLine;
            //}

            //if (liczbaIteracji > 1)
            //{
            //    float srednia = Srednia(zbiorWynikowMax);
            //    wynikiBadania += "----------------------------" + Environment.NewLine;
            //    wynikiBadania += "Średnia wartość maks z badań: " + srednia + Environment.NewLine;
            //    wynikiBadania += "Mediana wartości maks z badań: " + Mediana(zbiorWynikowMax) + Environment.NewLine;
            //    wynikiBadania += "Odchylenie standardowe wartości maks z badań: " + OdchylenieStandardowe(zbiorWynikowMax, srednia) + Environment.NewLine;

            //    srednia = Srednia(zbiorWynikowMin);
            //    wynikiBadania += "---" + Environment.NewLine;
            //    wynikiBadania += "Średnia wartość min z badań: " + srednia + Environment.NewLine;
            //    wynikiBadania += "Mediana wartości min z badań: " + Mediana(zbiorWynikowMin) + Environment.NewLine;
            //    wynikiBadania += "Odchylenie standardowe wartości min z badań: " + OdchylenieStandardowe(zbiorWynikowMin, srednia) + Environment.NewLine;
            //}

            //wyniki = new Dictionary<string, string[]>(najlepszeWyniki);

            return "Poszło!!!";
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

            foreach (KeyValuePair<string, string> parametr in parametry)
            {
                string newLine = string.Format("{0}; {1}", parametr.Key, parametr.Value);
                csv.AppendLine(newLine);
            }

            foreach (KeyValuePair<string, string[]> linia in wyniki)
            {
                string newLine = string.Format("{0}; {1}", linia.Value[0], linia.Value[1]);
                csv.AppendLine(newLine);
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
            return "("+ data.ToString("d") +") "+ parametry["algorytm"] +"_"+ parametry["dane"] +""+ iter +"."+ rozszerzenie;
        }

        /// <summary>
        /// Metoda zapisuje badanie do pliku XML na dysku
        /// </summary>
        public void ZapiszBadanie()
        {
            int iter = 0;
            string[] znalezionePliki;

            do
            {
                iter++;
                znalezionePliki = Directory.GetFiles(@"./Badania/", ZwrocNazwePliku("xml", "_" + iter));
            } while (znalezionePliki.Length != 0);

            XDocument xml = new XDocument();
            XElement czasDzialania = new XElement("czasDzialania", wyniki["czasDzialania"][1]),
                     maxWartosc = new XElement("maxWartosc", wyniki["maxWartosc"][1]),
                     dataZapisu = new XElement("dataZapisu", data.ToString("d")),
                     nazwaBadania = new XElement("nazwaBadania", parametry["algorytm"] + "_" + parametry["dane"] + "_" + iter),
                     plikDanych = new XElement("plikDanych", parametry["dane"]),
                     dziedzina = new XElement("dziedzina", wyniki["dziedzina"][1]);

            XElement badanie = new XElement("badanie"),
                     podstawoweDane = new XElement("podstawoweDane"),
                     rozwiazanie = new XElement("rozwiazanie"),
                     dodatkoweDane = new XElement("dodatkoweDane");

            XElement[] dodatki = new XElement[parametry.Count - 2];

            int i = 0;
            foreach (KeyValuePair<string, string> parametr in parametry)
            {
                if (parametr.Key != "algorytm" && parametr.Key != "dane")
                {
                    dodatki[i] = new XElement(parametr.Key, parametr.Value);
                    i++;
                }
            }

            dodatkoweDane.Add(dodatki);
            podstawoweDane.Add(nazwaBadania);
            podstawoweDane.Add(dataZapisu);
            podstawoweDane.Add(maxWartosc);
            podstawoweDane.Add(czasDzialania);
            podstawoweDane.Add(plikDanych);
            rozwiazanie.Add(dziedzina);

            badanie.Add(podstawoweDane);
            badanie.Add(rozwiazanie);
            badanie.Add(dodatkoweDane);
            xml.Add(badanie);

            xml.Save("./Badania/"+ ZwrocNazwePliku("xml", "_"+ iter));
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
                problemKP.UstawOgraniczeniaProblemu(float.Parse(parametry["ograniczenie1"]));

                return problemKP;
            }
            else if (parametry["problem"] == "Problem Podróżującego Złodzieja")
            {
                ProblemPodrozujacegoZlodzieja problemTTP = new ProblemPodrozujacegoZlodzieja(parametry["dane"], parametry["modelTTP"]);
                problemTTP.UstawOgraniczeniaProblemu(new float[] { float.Parse(parametry["ograniczenie1"]), float.Parse(parametry["wyporzyczeniePlecaka"]) });

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
                throw new Exception("Parametr " + parametr + " nie może być pusty!");
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

        /// <summary>
        /// Metoda wyznaczająca medianę funkcji celu z populacji rozwiązań
        /// </summary>
        /// <param name="populacja">Lista rozwiązań</param>
        /// <returns>Zwraca medianę</returns>
        private float Mediana(float[] zbior)
        {
            int srodek = zbior.Length / 2;
            float[] wynikiPopulacji = new float[zbior.Length]; // tablica zawierająca wartości funkcji celu z listy rozwiązań

            if (srodek == 0) throw new IndexOutOfRangeException();

            for (int i = 0; i < zbior.Length; i++)
            {
                wynikiPopulacji[i] = zbior[i];
            }

            // sortowanie wyników rosnąco
            Array.Sort(wynikiPopulacji);

            return wynikiPopulacji[srodek];
        }

        /// <summary>
        /// Metoda obliczająca średnią wartość funkcji celu z populacji rozwiązań
        /// </summary>
        /// <param name="populacja">Lista rozwiązań</param>
        /// <returns>Zwraca wartość średnią</returns>
        private float Srednia(float[] zbior)
        {
            float wynik = 0;

            foreach (float wartosc in zbior)
            {
                wynik += wartosc;
            }

            return wynik / zbior.Length;
        }

        /// <summary>
        /// Metoda obliczająca odchylenie standardowe funkcji celu z populacji rozwiązań
        /// </summary>
        /// <param name="populacja">Lista rozwiązań</param>
        /// <param name="srednia">Średnia z listy rozwiązań</param>
        /// <returns>Zwraca odchylenie standardowe</returns>
        private float OdchylenieStandardowe(float[] zbior, float srednia)
        {
            float sumaKwadratow = 0;

            foreach (float wartosc in zbior)
            {
                sumaKwadratow += (wartosc - srednia) * (wartosc - srednia);
            }

            float sredniaSumaKwadratow = sumaKwadratow / (zbior.Length - 1);

            return (float)Math.Sqrt(sredniaSumaKwadratow);
        }
    }
}
