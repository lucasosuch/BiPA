using AlgorytmyDoTTP.Widoki.Narzedzia;
using System;
using System.Windows.Forms;
using System.Xml;

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
        }

        private void wygenerujPlikDanych_Click(object sender, EventArgs e)
        {
            GenerowaniePlikow generowaniePlikow = new GenerowaniePlikow();
            generowaniePlikow.Show();
        }

        private void stworzPlikDanych_Click(object sender, EventArgs e)
        {
            if(plikiDanych.Text == "< Nowy plik >")
            {

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
        }

        private void dodajMiasto_Click(object sender, EventArgs e)
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
