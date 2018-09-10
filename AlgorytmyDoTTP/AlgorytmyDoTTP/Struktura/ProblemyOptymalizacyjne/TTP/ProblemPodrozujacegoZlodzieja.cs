using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.KP;
using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TSP;
using System;
using System.Collections.Generic;
using System.Xml;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TTP
{
    /// <summary>
    /// Klasa konkretna reprezentująca Problem Podróżującego Złodzieja
    /// </summary>
    class ProblemPodrozujacegoZlodzieja : ProblemOptymalizacyjny
    {
        private ushort[][] dostepnePrzedmioty;
        private ProblemPlecakowy problemPlecakowy;
        private ProblemKomiwojazera problemKomiwojazera;

        public ProblemPodrozujacegoZlodzieja(string nazwaPakietu)
        {
            Inicjalizacja(nazwaPakietu);
        }

        /// <summary>
        /// Metoda konwertuje dane w pliku XML pod struktury dla C#
        /// </summary>
        /// <param name="nazwaPakietu">Nazwa pliku xml zawierającego dane</param>
        private void Inicjalizacja(string nazwaPakietu)
        {
            // pobranie pliku z danymi z dysku
            XmlDocument dokument = new XmlDocument();
            dokument.Load("./Dane/TTP/" + nazwaPakietu + ".xml");

            // pobranie danych składowych problemów optymalizacyjnych z dysku
            XmlNode przypadekTSP = dokument.DocumentElement.SelectSingleNode("/korzen/tsp");
            XmlNode przypadekKP = dokument.DocumentElement.SelectSingleNode("/korzen/kp");

            // utworzenie instancji składowych problemów optymalizacyjnych
            problemPlecakowy = new ProblemPlecakowy(przypadekKP.InnerText);
            problemKomiwojazera = new ProblemKomiwojazera(przypadekTSP.InnerText);

            // pobranie inforamcji o dostępnościach przedmiotów w poszczególnych miastach
            XmlNodeList rozmieszczeniePrzedmiotow = dokument.DocumentElement.SelectNodes("/korzen/dostepnePrzedmioty/miasto");
            dlugoscGenotypu = (ushort)rozmieszczeniePrzedmiotow.Count;

            dostepnePrzedmioty = new ushort[problemKomiwojazera.ZwrocDlugoscGenotypu()][];
            for(int i = 0; i < problemKomiwojazera.ZwrocDlugoscGenotypu(); i++)
            {
                // dla każdego i-tego miasta przypisanie dostępności przedmiotów
                dostepnePrzedmioty[i] = new ushort[problemPlecakowy.ZwrocDlugoscGenotypu()];
                dostepnePrzedmioty[i] = (ushort[])((new Instancja()).ZwrocPrzedmioty(
                    rozmieszczeniePrzedmiotow[i].InnerText, 
                    problemPlecakowy.ZwrocDlugoscGenotypu()
                    ).Clone());
            }
        }

        public override ushort[][] ZwrocDostepnePrzedmioty()
        {
            return dostepnePrzedmioty;
        }

        public ProblemPlecakowy ZwrocProblemPlecakowy()
        {
            return problemPlecakowy;
        }

        public ProblemKomiwojazera ZwrocProblemKomiwojazera()
        {
            return problemKomiwojazera;
        }

        public override Dictionary<string, double[]> ObliczZysk(Dictionary<string, ushort[][]> macierz)
        {
            double sumarycznaWartosc = 0,
                   sumarycznaWaga = 0,
                   czasPodrozy = 0;

            // pobranie planu podróży przez miasta
            IPomocniczy[] planPodrozy = problemKomiwojazera.ZwrocWybraneElementy(macierz["tsp"][0]);
            // pobranie długości trasy jako wektora pomiędzy wybranymi miastami
            double[] dlugosciTrasy = problemKomiwojazera.ZwrocDlugoscTrasy(planPodrozy, true);

            for (int i = 0, j = -1; i < macierz["kp"].Length; i++, j++)
            {
                // zebrane przedmioty dla i-tego miasta
                IPomocniczy[] zebranePrzedmioty = problemPlecakowy.ZwrocWybraneElementy(macierz["kp"][i]);
                // obliczenie zysku z pobranych przedmiotów dla i-tego miasta
                Dictionary<String, double[]> wynikCzesciowy = problemPlecakowy.ObliczZysk(zebranePrzedmioty);

                sumarycznaWaga += wynikCzesciowy["min"][0]; // całkowita waga
                sumarycznaWartosc += wynikCzesciowy["max"][0]; // całkowita wartość

                // obliczenie prędkości złodzieja, gdzie maksymalna prędkość = 1, minimalna prękość = 0.1
                double predkosc = 1 - sumarycznaWaga * (1 - 0.1) / ZwrocOgraniczeniaProblemu()[0];
                // jeżeli prędkość mniejsza od minimalnej, wtedy przypisz minimalną prędkość
                predkosc = (predkosc < 0.1) ? 0.1 : predkosc;

                // przy mieście nr. 1 czas podróży wynosi 0 jednostek
                if(j != -1) czasPodrozy += dlugosciTrasy[j] * predkosc;
            }

            Dictionary<String, double[]> wynik = new Dictionary<String, double[]>();
            wynik["min"] = new double[] { 0, 0 };
            wynik["max"] = new double[] { 0, 0 };

            // ustawienie parametrów do minimalizacji
            wynik["min"][0] = sumarycznaWaga;
            wynik["min"][1] = czasPodrozy;
            // obliczenie funkcji zysku dla TTP
            wynik["max"][0] = sumarycznaWartosc - ZwrocOgraniczeniaProblemu()[1] * czasPodrozy;
            wynik["max"][1] = sumarycznaWartosc;

            return wynik;
        }

        public override Dictionary<string, ushort[][]> ZwrocWybraneElementy(ushort[][] wybraneElementy)
        {
            ushort[][] tsp = new ushort[1][],
                       kp = new ushort[wybraneElementy.Length][];

            // TSP będzie reprezentowany jako wektor miast
            tsp[0] = new ushort[wybraneElementy.Length];

            for(int i = 0; i < wybraneElementy.Length; i++)
            {
                // pierwszy element i-tego wiersza macierzy, jest miastem
                tsp[0][i] = wybraneElementy[i][0];
                // reszta elementów w i-tym wierszu to wartości ze zbioru {0,1}
                // odpowiadające czy zebrano dany przedmiot z i-tego miasta
                kp[i] = new ushort[wybraneElementy[0].Length - 1];

                for(int j = 1; j < wybraneElementy[0].Length; j++)
                {
                    // dopisanie wartości ze zbioru {0,1} do i-tego miasta
                    kp[i][j - 1] = wybraneElementy[i][j];
                }
            }

            Dictionary<string, ushort[][]> wynik = new Dictionary<string, ushort[][]>();

            wynik["tsp"] = tsp;
            wynik["kp"] = kp;

            return wynik;
        }

        public override IPomocniczy[] ZwrocWybraneElementy(ushort[] wybraneElementy)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, double[]> ObliczZysk(IPomocniczy[] wektor)
        {
            throw new NotImplementedException();
        }
    }
}
