using AlgorytmyDoTTP.Struktura;
using AlgorytmyDoTTP.Struktura.Most;
using AlgorytmyDoTTP.Widoki;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorytmyDoTTP
{
    public partial class Glowna : Form
    {
        private List<Algorytm> listaAlgorytmow;

        public Glowna()
        {
            InitializeComponent();
            listaAlgorytmow = (new Lacznik()).ZwrocListeAlgorytmow();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            object[] elementy = new object[listaAlgorytmow.Count];
            for (int i = 0; i < listaAlgorytmow.Count; i++)
            {
                elementy[i] = listaAlgorytmow[i].ZwrocNazwe();
            }

            wyborAlgorytmu.Items.AddRange(elementy);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void start_Click(object sender, EventArgs e)
        {
            Badanie badanieTemp = new Badanie();
            badanieTemp.Show();
        }

        private void wyborAlgorytmu_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listaAlgorytmow.Count; i++)
            {
                if(listaAlgorytmow[i].ZwrocNazwe() == wyborAlgorytmu.GetItemText(wyborAlgorytmu.SelectedItem))
                {
                    foreach(KeyValuePair<string, string> parametr in listaAlgorytmow[i].ZwrocParametryAlgorytmu())
                    {
                        Console.WriteLine(parametr.Key +" "+ parametr.Value);
                    }
                }
            }
        }
    }
}
