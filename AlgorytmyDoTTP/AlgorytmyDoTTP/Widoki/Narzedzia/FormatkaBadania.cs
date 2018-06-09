using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TSP;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TTP;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace AlgorytmyDoTTP.Widoki.Narzedzia
{
    class FormatkaBadania
    {
        private DateTime data = DateTime.Today;
        private Dictionary<string, string[]> wyniki;
        private Dictionary<string, string> parametry;

        public FormatkaBadania(Dictionary<string, string> parametry)
        {
            this.parametry = parametry;
            wyniki = new Dictionary<string, string[]>();
        }

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

        public String ZwrocDaneDoCSV()
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

        public string ZwrocNazwePliku(string rozszerzenie)
        {
            return "(" + data.ToString("d") + ") " + parametry["algorytm"] + "_" + parametry["dane"] + "."+ rozszerzenie;
        }

        public void ZapiszBadanie()
        {
            XDocument xml = new XDocument();
            XElement czasDzialania = new XElement("czasDzialania", wyniki["czasDzialania"][1]);
            XElement maxWartosc = new XElement("maxWartosc", wyniki["maxWartosc"][1]);
            XElement dataZapisu = new XElement("dataZapisu", data.ToString("d"));
            XElement nazwaBadania = new XElement("nazwaBadania", parametry["algorytm"] + "_" + parametry["dane"]);

            XElement badanie = new XElement("badanie");
            badanie.Add(nazwaBadania);
            badanie.Add(dataZapisu);
            badanie.Add(maxWartosc);
            badanie.Add(czasDzialania);

            xml.Add(badanie);
            xml.Save("../../../../Badania/"+ ZwrocNazwePliku("xml"));
        }

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
                problemTTP.ZwrocProblemPlecakowy().UstawOgraniczeniaProblemu(double.Parse(parametry["ograniczenie1"]));

                return problemTTP;
            }

            return new ProblemKomiwojazera(parametry["dane"]);
        }

        private Algorytm ZwrocWybranyAlgorytm()
        {
            if (parametry["algorytm"] == "Algorytm Ewolucyjny")
            {
                return new Struktura.Algorytmy.Ewolucyjny.PrzebiegAlgorytmu();
            }

            return new Struktura.Algorytmy.Wspinaczkowy.PrzebiegAlgorytmu();
        }
    }
}
