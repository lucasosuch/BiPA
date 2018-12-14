using System;
using System.Reflection;
using System.Windows.Forms;

namespace AlgorytmyDoTTP.Widoki
{
    public partial class DodaniePlikowDanych : Form
    {
        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(DodaniePlikowDanych);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                Console.WriteLine(propertyName+" "+ myPropInfo);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(DodaniePlikowDanych);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);

            }

        }

        public DodaniePlikowDanych()
        {
            InitializeComponent();
        }

        private void wygenerujPlikDanych_Click(object sender, EventArgs e)
        {
            GenerowaniePlikow generowaniePlikow = new GenerowaniePlikow();
            generowaniePlikow.Show();
        }

        private void stworzPlikDanych_Click(object sender, EventArgs e)
        {
            
        }

        private void dodajPrzedmiot_Click(object sender, EventArgs e)
        {
            Console.WriteLine(waga.Text +" "+ wartosc.Text);

            string[] wiersz = new string[] { (listaPrzedmiotow.Items.Count + 1) +"", waga.Text, wartosc.Text };
            listaPrzedmiotow.Items.Add(new ListViewItem(wiersz));
        }

        private void dodajMiasto_Click(object sender, EventArgs e)
        {
            Console.WriteLine(wsp_x.Text + " " + wsp_y.Text + " " + dostepnePrzedmioty.Text);

            string[] wiersz = new string[] { (listaMiast.Items.Count + 1) + "", wsp_x.Text, wsp_y.Text, dostepnePrzedmioty.Text };
            listaMiast.Items.Add(new ListViewItem(wiersz));
        }
    }
}
