using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AlgorytmyDoTTP.Struktura.Most
{
    class Algorytm
    {
        private String nazwa;
        private Dictionary<string, string> parametryAlgorytmu = new Dictionary<string, string>();

        public Algorytm(String nazwa)
        {
            this.nazwa = nazwa;
            this.PobierzPlikXML();
        }

        public void PobierzPlikXML()
        {
            XmlDocument dokument = new XmlDocument();
            dokument.Load("../../Struktura/PlikiKonfiguracyjne/" + nazwa + ".xml");

            XmlNodeList parametry = dokument.DocumentElement.SelectNodes("/Korzen/Jezyk/parametry/parametr");

            foreach (XmlNode parametr in parametry)
            {
                parametryAlgorytmu[parametr.Attributes["klucz"].Value] = parametr.InnerText;
            }
        }

        public String ZwrocNazwe()
        {
            return nazwa;
        }

        public Dictionary<string, string> ZwrocParametryAlgorytmu()
        {
            return parametryAlgorytmu;
        }
    }
}
