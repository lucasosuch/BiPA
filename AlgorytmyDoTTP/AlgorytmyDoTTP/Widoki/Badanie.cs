using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TSP;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AlgorytmyDoTTP.Widoki
{
    public partial class Badanie : Form
    {
        private Dictionary<string, string[]> wyniki;
        private Dictionary<string, string> parametry;
        private DateTime data = DateTime.Today;

        public Badanie(Dictionary<string, string> parametry)
        {
            InitializeComponent();
            this.parametry = parametry;
            wyniki = new Dictionary<string, string[]>();
        }
        
        private void Badanie_Load(object sender, EventArgs e)
        {
            switch (parametry["problem"])
            {
                case "Problem Plecakowy":
                    ProblemOptymalizacyjny problemKP = new ProblemPlecakowy(parametry["dane"]);
                    problemKP.UstawOgraniczeniaProblemu(double.Parse(parametry["ograniczenie1"]));
                    
                    wyniki.Clear();
                    wyniki = (new Struktura.Algorytmy.Ewolucyjny.PrzebiegAlgorytmu()).ZbudujAlgorytm(parametry, problemKP).Start();
                    break;

                case "Problem Komiwojażera":
                    ProblemOptymalizacyjny problemTSP = new ProblemKomiwojazera(parametry["dane"]);

                    wyniki.Clear();
                    wyniki = (new Struktura.Algorytmy.Ewolucyjny.PrzebiegAlgorytmu()).ZbudujAlgorytm(parametry, problemTSP).Start();
                    break;
            }

            foreach (KeyValuePair<string, string[]> linia in wyniki)
            {
                wynikiBadania.Text += linia.Value[0] + ": " + linia.Value[1] + Environment.NewLine;
            }
        }

        private void pobierzCSV_Click(object sender, EventArgs e)
        {
            StringBuilder csv = new StringBuilder();

            foreach (KeyValuePair<string, string> parametr in parametry)
            {
                string newLine = string.Format("{0}; {1}", parametr.Key, parametr.Value);
                csv.AppendLine(newLine);
            }

            foreach(KeyValuePair<string, string[]> linia in wyniki)
            {
                string newLine = string.Format("{0}; {1}", linia.Value[0], linia.Value[1]);
                csv.AppendLine(newLine);
            }

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(desktop, "(" + data.ToString("d") + ") "+ parametry["algorytm"] +"_"+ parametry["dane"] + ".csv");

            try
            {
                File.WriteAllText(path, csv.ToString());
            } catch(IOException exc)
            {
                Console.WriteLine(exc);
            }
        }

        private void zapiszBadanie_Click(object sender, EventArgs e)
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
            xml.Save("../../../../Badania/test.xml");
        }
    }
}
