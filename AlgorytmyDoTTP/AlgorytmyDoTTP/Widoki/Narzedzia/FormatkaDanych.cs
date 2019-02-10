using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AlgorytmyDoTTP.Widoki.Narzedzia
{
    class FormatkaDanych
    {
        private Random losowy = new Random();

        public string generujDanePodTSP(int liczbaMiast, string mapa)
        {
            string nazwa = "tsp" + liczbaMiast + "_" + mapa;
            string[] punkty = mapa.Split("x".ToCharArray());

            XDocument xml = new XDocument();
            XElement korzen = new XElement("korzen"),
                     xmlMapa = new XElement("mapa");

            int maxX = int.Parse(punkty[0]),
                maxY = int.Parse(punkty[1]);

            List<int[]> wykorzystaneMiasta = new List<int[]>();
            for (int i = 0; i < liczbaMiast; i++)
            {
                int wspX = 0,
                    wspY = 0;

                bool znalezionoMiasto = false;
                XElement miasto = new XElement("miasto");

                do
                {
                    znalezionoMiasto = false;

                    wspX = losowy.Next(maxX);
                    wspY = losowy.Next(maxY);

                    for (int j = 0; j < wykorzystaneMiasta.Count; j++)
                    {
                        if (wykorzystaneMiasta[j][0] == wspX && wykorzystaneMiasta[j][1] == wspY)
                        {
                            znalezionoMiasto = true;
                            break;
                        }
                    }
                } while (znalezionoMiasto);

                wykorzystaneMiasta.Add(new int[] { wspX, wspY });

                XElement x = new XElement("x", wspX),
                         y = new XElement("y", wspY);

                miasto.Add(x);
                miasto.Add(y);

                xmlMapa.Add(miasto);
            }

            korzen.Add(xmlMapa);
            korzen.Add(new XElement("hash", korzen.GetHashCode()));
            xml.Add(korzen);
            xml.Save("./Dane/TSP/" + nazwa + ".xml");

            return nazwa;
        }

        public string generujDanePodKP(float sumaWagPrzedmiotow, float sumaWartosciPrzedmiotow, int liczbaPrzedmiotow, int procentRozrzutuWartosci)
        {
            int tmpLiczbaPrzedmiotow = liczbaPrzedmiotow;
            string nazwa = "kp" + liczbaPrzedmiotow + "_" + sumaWagPrzedmiotow + "_" + sumaWartosciPrzedmiotow;

            XDocument xml = new XDocument();
            XElement korzen = new XElement("korzen"),
                     przedmioty = new XElement("przedmioty"),
                     sumaWag = new XElement("sumaWagPrzedmiotow", sumaWagPrzedmiotow.ToString()),
                     sumaWartosci = new XElement("sumaWartosciPrzedmiotow", sumaWartosciPrzedmiotow.ToString());

            for (int i = 0; i < liczbaPrzedmiotow; i++)
            {
                XElement przedmiot = new XElement("przedmiot");

                if (i == (liczbaPrzedmiotow - 1))
                {
                    XElement waga = new XElement("waga", sumaWagPrzedmiotow.ToString()),
                             wartosc = new XElement("wartosc", sumaWartosciPrzedmiotow.ToString());

                    przedmiot.Add(waga);
                    przedmiot.Add(wartosc);
                }
                else
                {
                    float liczba = ObliczLiczbeZPrzedzialu(sumaWagPrzedmiotow, tmpLiczbaPrzedmiotow, procentRozrzutuWartosci);

                    XElement waga = new XElement("waga", liczba.ToString());
                    sumaWagPrzedmiotow -= liczba;

                    liczba = ObliczLiczbeZPrzedzialu(sumaWartosciPrzedmiotow, tmpLiczbaPrzedmiotow, procentRozrzutuWartosci);

                    XElement wartosc = new XElement("wartosc", liczba.ToString());
                    sumaWartosciPrzedmiotow -= liczba;

                    tmpLiczbaPrzedmiotow--;

                    przedmiot.Add(waga);
                    przedmiot.Add(wartosc);
                }

                przedmioty.Add(przedmiot);
            }

            korzen.Add(przedmioty);
            korzen.Add(sumaWag);
            korzen.Add(sumaWartosci);
            korzen.Add(new XElement("hash", korzen.GetHashCode()));

            xml.Add(korzen);
            xml.Save("./Dane/KP/" + nazwa + ".xml");

            return nazwa;
        }

        public string generujDanePodTTP(int liczbaMiast, string mapa, float sumaWagPrzedmiotow, float sumaWartosciPrzedmiotow, int liczbaPrzedmiotow, int procentRozrzutuWartosci)
        {
            string nazwaKP = generujDanePodKP(sumaWagPrzedmiotow, sumaWartosciPrzedmiotow, liczbaPrzedmiotow, procentRozrzutuWartosci),
                   nazwaTSP = generujDanePodTSP(liczbaMiast, mapa),
                   nazwa = "ttp_" + nazwaKP + "_" + nazwaTSP;

            XDocument xml = new XDocument();
            XElement korzen = new XElement("korzen"),
                     dostepnePrzedmioty = new XElement("dostepnePrzedmioty"),
                     kp = new XElement("kp", nazwaKP),
                     tsp = new XElement("tsp", nazwaTSP);

            korzen.Add(kp);
            korzen.Add(tsp);

            for (int i = 0; i < liczbaMiast; i++)
            {
                int losowaDostepnosc = losowy.Next(liczbaPrzedmiotow);
                ArrayList dostepnosc = new ArrayList();

                if (i != 0)
                {
                    for (int j = 0; j < losowaDostepnosc; j++)
                    {
                        int losowaWartosc = losowy.Next(liczbaPrzedmiotow) + 1;

                        if (!dostepnosc.Contains(losowaWartosc))
                        {
                            dostepnosc.Add(losowaWartosc);
                        }
                    }
                }
                else dostepnosc.Add("");

                XElement miasto = new XElement("miasto", string.Join(",", dostepnosc.ToArray()));
                dostepnePrzedmioty.Add(miasto);
            }

            korzen.Add(dostepnePrzedmioty);
            korzen.Add(new XElement("hash", korzen.GetHashCode()));
            korzen.Add(new XElement("sumaWagPrzedmiotow", sumaWagPrzedmiotow));
            korzen.Add(new XElement("sumaWartosciPrzedmiotow", sumaWartosciPrzedmiotow));
            xml.Add(korzen);
            xml.Save("./Dane/TTP/" + nazwa + ".xml");

            return nazwa;
        }

        private float ObliczLiczbeZPrzedzialu(float suma, int liczba, int procentRozrzutuWartosci)
        {
            float srednia = suma / liczba,
                   lewaStrona = srednia * ((float)(100 - procentRozrzutuWartosci) / 100),
                   prawaStrona = srednia * ((float)(100 + procentRozrzutuWartosci) / 100);

            return (float)(losowy.NextDouble() * (prawaStrona - lewaStrona) + lewaStrona);
        }
    }
}
