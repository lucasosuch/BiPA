using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TSP;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TTP;
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
        private DateTime data = DateTime.Today;
        private Dictionary<string, string[]> wyniki;
        private Dictionary<string, string> parametry;

        public FormatkaBadania(Dictionary<string, string> parametry)
        {
            this.parametry = parametry;
            wyniki = new Dictionary<string, string[]>();
        }

        /// <summary>
        /// Metoda uruchamiająca badanie, tzn. rozpoczęcie rozwiązania wybranego Problemu Optymalizacyjnego za pomocą wybranego Algorytmu
        /// </summary>
        /// <returns>Wyniki czytelne dla człowieka</returns>
        public string UruchomBadanie()
        {
            string wynikiBadania = "";
            ProblemOptymalizacyjny problemOptymalizacyjny = ZwrocWybranyProblem();
            Algorytm algorytm = ZwrocWybranyAlgorytm();

            wyniki.Clear();
            wyniki = algorytm.ZbudujAlgorytm(parametry, problemOptymalizacyjny).Start();

            foreach (KeyValuePair<string, string[]> linia in wyniki)
            {
                wynikiBadania += linia.Value[0] + ": " + linia.Value[1] + Environment.NewLine;
            }

            return wynikiBadania;
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
                problemKP.UstawOgraniczeniaProblemu(double.Parse(parametry["ograniczenie1"]));

                return problemKP;
            }
            else if (parametry["problem"] == "Problem Podróżującego Złodzieja")
            {
                ProblemPodrozujacegoZlodzieja problemTTP = new ProblemPodrozujacegoZlodzieja(parametry["dane"]);
                problemTTP.UstawOgraniczeniaProblemu(new double[] { double.Parse(parametry["ograniczenie1"]), double.Parse(parametry["wyporzyczeniePlecaka"]) });

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
    }
}
