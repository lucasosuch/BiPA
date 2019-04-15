using AlgorytmyDoTTP.Widoki.Narzedzia;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace AlgorytmyDoTTP.Widoki
{
    public partial class StronaDodaniaPlikowDanych : Form
    {
        private int edycjaMiasta = -1;
        private int edycjaPrzedmiotu = -1;
        private FormatkaBadania badanie = new FormatkaBadania();
        private StronaBadania stronaBadania;

        public StronaDodaniaPlikowDanych(StronaBadania stronaBadania)
        {
            InitializeComponent();
            WczytajPlikiDanych("< Nowy plik >");
            this.stronaBadania = stronaBadania;
        }

        private void wygenerujPlikDanych_Click(object sender, EventArgs e)
        {
            // stworzenie losowej plików danych dla TTP, TSP, KP
            StronaGenerowaniaPlikow stronaGenerowaniaPlikow = new StronaGenerowaniaPlikow(this);
            stronaGenerowaniaPlikow.Show();
        }

        private void stworzPlikDanych_Click(object sender, EventArgs e)
        {
            if (listaMiast.Items.Count != 0 && listaPrzedmiotow.Items.Count != 0)
            {
                if (plikiDanych.Text != "< Nowy plik >")
                {
                    UsunPlikDanych();
                }

                // wygenerowanie 3 plików XML na podstawie zadanej konfiguracji
                XDocument xml = new XDocument();
                XElement korzen = new XElement("korzen"),
                         przedmioty = new XElement("przedmioty");

                double sumaWagPrzedmiotow = 0,
                      sumaWartosciPrzedmiotow = 0;
                foreach (ListViewItem p in listaPrzedmiotow.Items)
                {
                    XElement przedmiot = new XElement("przedmiot");

                    przedmiot.Add(new XElement("waga", p.SubItems[2].Text));
                    przedmiot.Add(new XElement("wartosc", p.SubItems[1].Text));
                    przedmioty.Add(przedmiot);

                    sumaWagPrzedmiotow += double.Parse(p.SubItems[2].Text);
                    sumaWartosciPrzedmiotow += double.Parse(p.SubItems[1].Text);
                }

                sumaWagPrzedmiotow = Math.Round(sumaWagPrzedmiotow);
                sumaWartosciPrzedmiotow = Math.Round(sumaWartosciPrzedmiotow);

                XElement sumaWag = new XElement("sumaWagPrzedmiotow", sumaWagPrzedmiotow.ToString()),
                         sumaWartosci = new XElement("sumaWartosciPrzedmiotow", sumaWartosciPrzedmiotow.ToString());

                korzen.Add(przedmioty);
                korzen.Add(sumaWag);
                korzen.Add(sumaWartosci);
                korzen.Add(new XElement("hash", korzen.GetHashCode()));
                xml.Add(korzen);

                string nazwaKP = "kp" + listaPrzedmiotow.Items.Count + "_" + sumaWagPrzedmiotow + "_" + sumaWartosciPrzedmiotow;
                xml.Save("./Dane/KP/" + nazwaKP + ".xml");

                xml = new XDocument();
                short maxX = -1,
                      maxY = -1;
                korzen = new XElement("korzen");
                XElement xmlMapa = new XElement("mapa");

                foreach (ListViewItem m in listaMiast.Items)
                {
                    XElement miasto = new XElement("miasto");

                    miasto.Add(new XElement("x", m.SubItems[1].Text));
                    miasto.Add(new XElement("y", m.SubItems[2].Text));
                    xmlMapa.Add(miasto);

                    if (maxX < short.Parse(m.SubItems[1].Text)) maxX = short.Parse(m.SubItems[1].Text);
                    if (maxY < short.Parse(m.SubItems[2].Text)) maxY = short.Parse(m.SubItems[2].Text);
                }

                korzen.Add(xmlMapa);
                korzen.Add(new XElement("hash", korzen.GetHashCode()));
                xml.Add(korzen);

                string nazwaTSP = "tsp" + listaMiast.Items.Count + "_" + maxX + "x" + maxY;
                xml.Save("./Dane/TSP/" + nazwaTSP + ".xml");

                xml = new XDocument();
                XElement dostepnePrzedmioty = new XElement("dostepnePrzedmioty"),
                         kp = new XElement("kp", nazwaKP),
                         tsp = new XElement("tsp", nazwaTSP);

                korzen = new XElement("korzen");
                korzen.Add(kp);
                korzen.Add(tsp);

                sumaWagPrzedmiotow = 0;
                sumaWartosciPrzedmiotow = 0;
                foreach (ListViewItem m in listaMiast.Items)
                {
                    string zwalidowaneDostepnePrzedmioty = "";
                    if (m.SubItems[3].Text != "")
                    {
                        foreach (string p in m.SubItems[3].Text.Split(','))
                        {
                            int indeks = int.Parse(p.Trim());

                            try
                            {
                                zwalidowaneDostepnePrzedmioty += listaPrzedmiotow.Items[(indeks - 1)].SubItems[0].Text + ", ";

                                sumaWagPrzedmiotow += double.Parse(listaPrzedmiotow.Items[(indeks - 1)].SubItems[2].Text);
                                sumaWartosciPrzedmiotow += double.Parse(listaPrzedmiotow.Items[(indeks - 1)].SubItems[1].Text);
                            } catch (Exception)
                            {}
                        }

                        zwalidowaneDostepnePrzedmioty = (zwalidowaneDostepnePrzedmioty.Trim());
                        zwalidowaneDostepnePrzedmioty = zwalidowaneDostepnePrzedmioty.TrimEnd(',');
                    }

                    dostepnePrzedmioty.Add(new XElement("miasto", zwalidowaneDostepnePrzedmioty));
                }

                sumaWag = new XElement("sumaWagPrzedmiotow", Math.Round(sumaWagPrzedmiotow).ToString());
                sumaWartosci = new XElement("sumaWartosciPrzedmiotow", Math.Round(sumaWartosciPrzedmiotow).ToString());

                korzen.Add(sumaWag);
                korzen.Add(sumaWartosci);
                korzen.Add(dostepnePrzedmioty);
                korzen.Add(new XElement("hash", korzen.GetHashCode()));
                xml.Add(korzen);
                xml.Save("./Dane/TTP/ttp_" + nazwaKP + "_" + nazwaTSP + ".xml");

                stworzPlikDanych.Enabled = false;

                MessageBox.Show("Dodano plik danych!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                WczytajPlikiDanych("< Nowy plik >");
                plikiDanych.Text = "ttp_" + nazwaKP + "_" + nazwaTSP;
                UsunPlikDanychBadanie();
            }
            else
            {
                MessageBox.Show("Błędnie wypełniona formatka pod tworzenie plików danych!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dodajPrzedmiot_Click(object sender, EventArgs e)
        {
            string tmpWartosc = wartosc.Text.Replace('.', ','),
                   tmpWaga = waga.Text.Replace('.', ',');

            if (float.TryParse(tmpWartosc, out float n1) && float.TryParse(tmpWaga, out float n2))
            {
                if (edycjaPrzedmiotu != -1)
                {
                    string[] wiersz = new string[] { (edycjaPrzedmiotu + 1) + "", tmpWartosc, tmpWaga };
                    listaPrzedmiotow.Items.Insert(edycjaPrzedmiotu, new ListViewItem(wiersz));

                    listaPrzedmiotow.Items.RemoveAt(edycjaPrzedmiotu + 1);
                }
                else
                {
                    string[] wiersz = new string[] { (listaPrzedmiotow.Items.Count + 1) + "", tmpWartosc, tmpWaga };
                    listaPrzedmiotow.Items.Add(new ListViewItem(wiersz));

                    waga.Text = "";
                    wartosc.Text = "";
                }

                ObliczSumeParametrowKP();

                stworzPlikDanych.Enabled = true;
            }
            else
            {
                MessageBox.Show("Podaj wartości liczbowe!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dodajMiasto_Click(object sender, EventArgs e)
        {
            bool bledneWspolrzedne = false,
                 bledneDostepnosciPrzedmiotow = false,
                 blednaWartoscDostepnosciPrzedmiotow = false;

            if (int.TryParse(wsp_x.Text, out int n1) && int.TryParse(wsp_y.Text, out int n2))
            {
                if (listaMiast.Items.Count > 0)
                {
                    if (edycjaMiasta == -1)
                    {
                        foreach (ListViewItem m in listaMiast.Items)
                        {
                            if (m.SubItems[1].Text == wsp_x.Text && m.SubItems[2].Text == wsp_y.Text)
                            {
                                bledneWspolrzedne = true;
                                break;
                            }
                        }
                    }

                    if (dostepnePrzedmioty.Text != "")
                    {
                        string[] przedmioty = dostepnePrzedmioty.Text.Split(',');
                        foreach (string p in przedmioty)
                        {
                            if (int.TryParse(p, out int przedmiot))
                            {
                                if (przedmiot < 0 || przedmiot > listaPrzedmiotow.Items.Count)
                                {
                                    bledneDostepnosciPrzedmiotow = true;
                                    break;
                                }
                            } else
                            {
                                blednaWartoscDostepnosciPrzedmiotow = true;
                                break;
                            }
                        }
                    }
                }

                if (!bledneWspolrzedne && !bledneDostepnosciPrzedmiotow && !blednaWartoscDostepnosciPrzedmiotow)
                {
                    if (edycjaMiasta != -1)
                    {
                        string[] wiersz = new string[] { (edycjaMiasta + 1) + "", wsp_x.Text, wsp_y.Text, dostepnePrzedmioty.Text };
                        listaMiast.Items.Insert(edycjaMiasta, new ListViewItem(wiersz));

                        listaMiast.Items.RemoveAt(edycjaMiasta + 1);
                    }
                    else
                    {
                        string[] wiersz = new string[] { (listaMiast.Items.Count + 1) + "", wsp_x.Text, wsp_y.Text, dostepnePrzedmioty.Text };
                        listaMiast.Items.Add(new ListViewItem(wiersz));

                        wsp_x.Text = "";
                        wsp_y.Text = "";
                        dostepnePrzedmioty.Text = "";
                        dostepnePrzedmioty.Enabled = true;
                    }

                    ObliczSumeParametrowTTP();

                    stworzPlikDanych.Enabled = true;
                }
                else
                {
                    if (bledneWspolrzedne) MessageBox.Show("Istniej już miasto o takich współrzędnych!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (bledneDostepnosciPrzedmiotow) MessageBox.Show("Chcesz przydzielić nieistniejący przedmiot do miasta!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (blednaWartoscDostepnosciPrzedmiotow) MessageBox.Show("Podano złą wartość w polu: Dostępne przedmioty!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Podaj wartości całkowite!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void elementZaznaczonyMiasta_Changed(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            edycjaMiasta = (e.IsSelected) ? (int.Parse(e.Item.Text)-1) : -1;

            if (e.IsSelected)
            {
                if (edycjaMiasta == 0) dostepnePrzedmioty.Enabled = false;
                else dostepnePrzedmioty.Enabled = true;

                wsp_x.Text = e.Item.SubItems[1].Text;
                wsp_y.Text = e.Item.SubItems[2].Text;
                dostepnePrzedmioty.Text = e.Item.SubItems[3].Text;
                dodajMiasto.Text = "Edytuj miasto";
            }
            else
            {
                wsp_x.Text = "";
                wsp_y.Text = "";
                dostepnePrzedmioty.Text = "";
                dodajMiasto.Text = "Dodaj miasto";
            }
        }

        private void elementZaznaczonyPrzedmioty_Changed(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            edycjaPrzedmiotu = (e.IsSelected) ? (int.Parse(e.Item.Text)-1) : -1;

            if (e.IsSelected)
            {
                waga.Text = e.Item.SubItems[2].Text;
                wartosc.Text = e.Item.SubItems[1].Text;
                dodajPrzedmiot.Text = "Edytuj przedmiot";
            } else
            {
                waga.Text = "";
                wartosc.Text = "";
                dodajPrzedmiot.Text = "Dodaj przedmiot";
            }
        }

        private void usunPrzedmiot_Click(object sender, EventArgs e)
        {
            if (listaPrzedmiotow.CheckedItems.Count > 0)
            {
                foreach(ListViewItem przedmiot in listaPrzedmiotow.CheckedItems)
                {
                    listaPrzedmiotow.Items.RemoveAt(przedmiot.Index);
                }

                if (listaPrzedmiotow.Items.Count > 0) stworzPlikDanych.Enabled = true;
                ObliczSumeParametrowKP();
            }
        }

        private void usunMiasto_Click(object sender, EventArgs e)
        {
            if (listaMiast.CheckedItems.Count > 0)
            {
                foreach (ListViewItem miasto in listaMiast.CheckedItems)
                {
                    listaMiast.Items.RemoveAt(miasto.Index);
                }

                if (listaMiast.Items.Count > 0) stworzPlikDanych.Enabled = true;
            }

            if(listaMiast.Items.Count == 0) dostepnePrzedmioty.Enabled = false;
            ObliczSumeParametrowTTP();
        }

        private void plikiDanych_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaMiast.Items.Clear();
            listaPrzedmiotow.Items.Clear();

            if (plikiDanych.Text != "< Nowy plik >")
            {
                usunPlik.Enabled = true;

                // pobranie pliku z danymi z dysku
                XmlDocument dokument = new XmlDocument();
                dokument.Load("./Dane/TTP/" + plikiDanych.Text + ".xml");

                // pobranie inforamcji o dostępnościach przedmiotów w poszczególnych miastach
                XmlNodeList rozmieszczeniePrzedmiotow = dokument.DocumentElement.SelectNodes("/korzen/dostepnePrzedmioty/miasto");

                string[] dostepnePrzedmioty = new string[rozmieszczeniePrzedmiotow.Count];
                for (int i = 0; i < rozmieszczeniePrzedmiotow.Count; i++)
                {
                    dostepnePrzedmioty[i] = rozmieszczeniePrzedmiotow[i].InnerText.Trim();
                }

                // pobranie danych składowych problemów optymalizacyjnych z dysku
                XmlNode przypadekTSP = dokument.DocumentElement.SelectSingleNode("/korzen/tsp");
                XmlNode przypadekKP = dokument.DocumentElement.SelectSingleNode("/korzen/kp");

                dokument.Load("./Dane/TSP/" + przypadekTSP.InnerText + ".xml");
                XmlNodeList miasta = dokument.DocumentElement.SelectNodes("/korzen/mapa/miasto");

                for (int i = 0; i < miasta.Count; i++)
                {
                    listaMiast.Items.Add(new ListViewItem(new string[] { (i + 1) + "", miasta[i]["x"].InnerText, miasta[i]["y"].InnerText, dostepnePrzedmioty[i] }));
                }

                dokument.Load("./Dane/KP/" + przypadekKP.InnerText + ".xml");
                XmlNodeList przedmioty = dokument.DocumentElement.SelectNodes("/korzen/przedmioty/przedmiot");

                float sumaWag = 0,
                    sumaWartosci = 0;
                for (int i = 0; i < przedmioty.Count; i++)
                {
                    listaPrzedmiotow.Items.Add(new ListViewItem(new string[] { (i + 1) + "", przedmioty[i]["wartosc"].InnerText, przedmioty[i]["waga"].InnerText }));

                    sumaWag += float.Parse(przedmioty[i]["waga"].InnerText);
                    sumaWartosci += float.Parse(przedmioty[i]["wartosc"].InnerText);
                }

                kp_sumaWag.Text = ""+ sumaWag;
                kp_sumaWartosci.Text = ""+ sumaWartosci;

                ObliczSumeParametrowTTP();

                if (listaMiast.Items.Count == 0) this.dostepnePrzedmioty.Enabled = false;
                else this.dostepnePrzedmioty.Enabled = true;
            } else
            {
                usunPlik.Enabled = false;
            }
        }

        private void miasta_Click(object sender, EventArgs e)
        {
            WyczyscWyborElementow(listaMiast);
        }

        private void przedmioty_Click(object sender, EventArgs e)
        {
            WyczyscWyborElementow(listaPrzedmiotow);
        }

        private void metroPanel1_Click(object sender, EventArgs e)
        {
            WyczyscWyborElementow(listaPrzedmiotow);
            WyczyscWyborElementow(listaMiast);
        }

        private void WyczyscWyborElementow(MetroFramework.Controls.MetroListView lista)
        {
            if (lista.SelectedIndices.Count > 0)
            {
                for (int i = 0; i < lista.SelectedIndices.Count; i++)
                {
                    lista.Items[lista.SelectedIndices[i]].Selected = false;
                }
            }
        }

        private void ObliczSumeParametrowKP()
        {
            float sumaWag = 0,
                  sumaWartosci = 0;

            foreach (ListViewItem p in listaPrzedmiotow.Items)
            {
                sumaWag += float.Parse(p.SubItems[2].Text);
                sumaWartosci += float.Parse(p.SubItems[1].Text);
            }

            kp_sumaWag.Text = "" + sumaWag;
            kp_sumaWartosci.Text = "" + sumaWartosci;
        }

        private void ObliczSumeParametrowTTP()
        {
            float sumaWag = 0,
                  sumaWartosci = 0;

            foreach (ListViewItem m in listaMiast.Items)
            {
                if (m.SubItems[3].Text != "")
                {
                    foreach (string p in m.SubItems[3].Text.Split(','))
                    {
                        int indeks = int.Parse(p.Trim());

                        sumaWag += float.Parse(listaPrzedmiotow.Items[(indeks - 1)].SubItems[2].Text);
                        sumaWartosci += float.Parse(listaPrzedmiotow.Items[(indeks - 1)].SubItems[1].Text);
                    }
                }
            }

            ttp_sumaWag.Text = "" + sumaWag;
            ttp_sumaWartosci.Text = "" + sumaWartosci;
        }

        private void usunPlik_Click(object sender, EventArgs e)
        {
            UsunPlikDanych();
            UsunPlikDanychBadanie();
            MessageBox.Show("Usunięto plik danych!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            WczytajPlikiDanych("< Nowy plik >");
        }

        private void UsunPlikDanych()
        {
            // pobranie pliku z danymi z dysku
            XmlDocument dokument = new XmlDocument();
            dokument.Load("./Dane/TTP/" + plikiDanych.Text + ".xml");

            XmlNode przypadekTSP = dokument.DocumentElement.SelectSingleNode("/korzen/tsp");
            XmlNode przypadekKP = dokument.DocumentElement.SelectSingleNode("/korzen/kp");

            // jeżeli istnieją już dane do problemów optymalizacyjnych o wybranej konfiguracji - wtedy następuje usunięcie starych danych
            // i zastąpienie ich nowymi
            if (File.Exists(@"./Dane/TSP/" + przypadekTSP.InnerText + ".xml"))
            {
                File.Delete(@"./Dane/TSP/" + przypadekTSP.InnerText + ".xml");
            }

            if (File.Exists(@"./Dane/KP/" + przypadekKP.InnerText + ".xml"))
            {
                File.Delete(@"./Dane/KP/" + przypadekKP.InnerText + ".xml");
            }

            if (File.Exists(@"./Dane/TTP/" + plikiDanych.Text + ".xml"))
            {
                File.Delete(@"./Dane/TTP/" + plikiDanych.Text + ".xml");
            }
        }

        private void UsunPlikDanychBadanie()
        {
            if (stronaBadania.wybierzProblem.Text != "")
            {
                stronaBadania.wybierzPlikDanych.Items.Clear();

                if (stronaBadania.wybierzProblem.Text == "Problem Podróżującego Złodzieja")
                {
                    stronaBadania.wybierzPlikDanych.Items.AddRange(badanie.WczytajPlikiDanych("Problem Podróżującego Złodzieja"));
                }
                else if (stronaBadania.wybierzProblem.Text == "Problem Plecakowy")
                {
                    stronaBadania.wybierzPlikDanych.Items.AddRange(badanie.WczytajPlikiDanych("Problem Plecakowy"));
                }
                else
                {
                    stronaBadania.wybierzPlikDanych.Items.AddRange(badanie.WczytajPlikiDanych("Problem Komiwojażera"));
                }
            }
        }

        private void WczytajPlikiDanych(string domyslny)
        {
            // wczytanie plików danych dla TTP
            plikiDanych.Items.Clear();
            plikiDanych.Items.AddRange(badanie.WczytajPlikiDanych("Problem Podróżującego Złodzieja"));

            // domyślnie tworzymy nowy plik danych
            plikiDanych.Items.Add(domyslny);
            plikiDanych.Text = domyslny;
        }
    }
}
