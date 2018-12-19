using AlgorytmyDoTTP.Widoki.Narzedzia;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace AlgorytmyDoTTP.Widoki
{
    public partial class DodaniePlikowDanych : Form
    {
        private int edycjaMiasta = -1;
        private int edycjaPrzedmiotu = -1;

        public DodaniePlikowDanych()
        {
            InitializeComponent();

            FormatkaBadania badanie = new FormatkaBadania();
            plikiDanych.Items.Clear();
            plikiDanych.Items.AddRange(badanie.WczytajPlikiDanych("Problem Podróżującego Złodzieja"));
            plikiDanych.Items.Add("< Nowy plik >");
            plikiDanych.Text = "< Nowy plik >";
        }

        private void wygenerujPlikDanych_Click(object sender, EventArgs e)
        {
            GenerowaniePlikow generowaniePlikow = new GenerowaniePlikow();
            generowaniePlikow.Show();
        }

        private void stworzPlikDanych_Click(object sender, EventArgs e)
        {
            if (listaMiast.Items.Count != 0 && listaPrzedmiotow.Items.Count != 0)
            {
                if (plikiDanych.Text != "< Nowy plik >")
                {
                    // pobranie pliku z danymi z dysku
                    XmlDocument dokument = new XmlDocument();
                    dokument.Load("./Dane/TTP/" + plikiDanych.Text + ".xml");

                    XmlNode przypadekTSP = dokument.DocumentElement.SelectSingleNode("/korzen/tsp");
                    XmlNode przypadekKP = dokument.DocumentElement.SelectSingleNode("/korzen/kp");

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

                XDocument xml = new XDocument();
                XElement korzen = new XElement("korzen"),
                         przedmioty = new XElement("przedmioty");

                float sumaWagPrzedmiotow = 0,
                      sumaWartosciPrzedmiotow = 0;
                foreach (ListViewItem p in listaPrzedmiotow.Items)
                {
                    XElement przedmiot = new XElement("przedmiot");

                    przedmiot.Add(new XElement("waga", p.SubItems[2].Text));
                    przedmiot.Add(new XElement("wartosc", p.SubItems[1].Text));
                    przedmioty.Add(przedmiot);

                    sumaWagPrzedmiotow += float.Parse(p.SubItems[2].Text);
                    sumaWartosciPrzedmiotow += float.Parse(p.SubItems[1].Text);
                }

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

                foreach (ListViewItem m in listaMiast.Items)
                {
                    dostepnePrzedmioty.Add(new XElement("miasto", m.SubItems[3].Text));
                }

                korzen.Add(sumaWag);
                korzen.Add(sumaWartosci);
                korzen.Add(dostepnePrzedmioty);
                korzen.Add(new XElement("hash", korzen.GetHashCode()));
                xml.Add(korzen);
                xml.Save("./Dane/TTP/ttp_" + nazwaKP + "_" + nazwaTSP + ".xml");

                stworzPlikDanych.Enabled = false;

                MessageBox.Show("Dodano plik danych!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Błędnie wypełniona formatka pod tworzenie plików danych!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dodajPrzedmiot_Click(object sender, EventArgs e)
        {
            if(edycjaPrzedmiotu != -1)
            {
                string[] wiersz = new string[] { (edycjaPrzedmiotu + 1) + "", wartosc.Text, waga.Text };
                listaPrzedmiotow.Items.Insert(edycjaPrzedmiotu, new ListViewItem(wiersz));

                listaPrzedmiotow.Items.RemoveAt(edycjaPrzedmiotu+1);
            } else
            {
                string[] wiersz = new string[] { (listaPrzedmiotow.Items.Count + 1) + "", wartosc.Text, waga.Text };
                listaPrzedmiotow.Items.Add(new ListViewItem(wiersz));

                waga.Text = "";
                wartosc.Text = "";
            }

            stworzPlikDanych.Enabled = true;
        }

        private void dodajMiasto_Click(object sender, EventArgs e)
        {
            bool bledneWspolrzedne = false,
                 bledneDostepnosciPrzedmiotow = false;

            if (listaMiast.Items.Count > 0)
            {
                foreach (ListViewItem m in listaMiast.Items)
                {
                    if(m.SubItems[1].Text == wsp_x.Text && m.SubItems[2].Text == wsp_y.Text)
                    {
                        bledneWspolrzedne = true;
                        break;
                    }
                }

                if (dostepnePrzedmioty.Text != "")
                {
                    string[] przedmioty = dostepnePrzedmioty.Text.Split(',');
                    foreach (string p in przedmioty)
                    {
                        int przedmiot = int.Parse(p);

                        if (przedmiot < 0 || przedmiot > listaPrzedmiotow.Items.Count)
                        {
                            bledneDostepnosciPrzedmiotow = true;
                            break;
                        }
                    }
                }
            }

            if (!bledneWspolrzedne && !bledneDostepnosciPrzedmiotow)
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

                stworzPlikDanych.Enabled = true;
            } else
            {
                if (bledneWspolrzedne) MessageBox.Show("Istniej już miasto o takich współrzędnych!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (bledneDostepnosciPrzedmiotow) MessageBox.Show("Chcesz przydzielić nieistniejący przedmiot do miasta!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void usunPredmiot_Click(object sender, EventArgs e)
        {
            if (listaPrzedmiotow.CheckedItems.Count > 0)
            {
                foreach(ListViewItem przedmiot in listaPrzedmiotow.CheckedItems)
                {
                    listaPrzedmiotow.Items.RemoveAt(przedmiot.Index);
                }
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
            }

            if(listaMiast.Items.Count == 0) dostepnePrzedmioty.Enabled = false;
        }

        private void plikiDanych_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaMiast.Items.Clear();
            listaPrzedmiotow.Items.Clear();

            if (plikiDanych.Text != "< Nowy plik >")
            {
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
                XmlNodeList miasta = dokument.DocumentElement.SelectNodes("/mapa/miasto");

                for (int i = 0; i < miasta.Count; i++)
                {
                    listaMiast.Items.Add(new ListViewItem(new string[] { (i + 1) + "", miasta[i]["x"].InnerText, miasta[i]["y"].InnerText, dostepnePrzedmioty[i] }));
                }

                dokument.Load("./Dane/KP/" + przypadekKP.InnerText + ".xml");
                XmlNodeList przedmioty = dokument.DocumentElement.SelectNodes("/korzen/przedmioty/przedmiot");

                for (int i = 0; i < przedmioty.Count; i++)
                {
                    listaPrzedmiotow.Items.Add(new ListViewItem(new string[] { (i + 1) + "", przedmioty[i]["wartosc"].InnerText, przedmioty[i]["waga"].InnerText }));
                }

                if (listaMiast.Items.Count == 0) this.dostepnePrzedmioty.Enabled = false;
                else this.dostepnePrzedmioty.Enabled = true;
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

        private void metroPanel1_Click(object sender, EventArgs e)
        {
            WyczyscWyborElementow(listaPrzedmiotow);
            WyczyscWyborElementow(listaMiast);
        }
    }
}
