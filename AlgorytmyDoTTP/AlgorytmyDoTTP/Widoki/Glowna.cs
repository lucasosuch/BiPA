using AlgorytmyDoTTP.Struktura;
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
        public Glowna()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void start_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parametry = new Dictionary<string, string>();
            parametry[pwoMutacji.Name] = pwoMutacji.Text;
            parametry[pwoKrzyzowania.Name] = pwoKrzyzowania.Text;
            parametry[rozmiarPopulacji.Name] = rozmiarPopulacji.Text;
            parametry[iloscPokolen.Name] = iloscPokolen.Text;

            Badanie badanieTemp = new Badanie(parametry);
            badanieTemp.Show();
        }

        private void wyborAlgorytmu_SelectedIndexChanged(object sender, EventArgs e)
        {
            domyslny.Visible = false;

            switch (wyborAlgorytmu.Text)
            {
                case "Ewolucyjny":
                    ewolucyjny.Visible = true;
                    break;

                default:
                    domyslny.Visible = true;
                    break;
            }
        }
    }
}
