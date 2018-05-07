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
        List<Panel> lista = new List<Panel>();

        public Glowna()
        {
            InitializeComponent();
            //this.metroComboBox1.Items.AddRange(new object[] {
            //"test1",
            //"test2"}
            //);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lista.Add(metroPanel1);
            lista.Add(metroPanel2);

            lista[0].BringToFront();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void badanie_Click(object sender, EventArgs e)
        {
            lista[0].BringToFront();
        }

        private void historia_Click(object sender, EventArgs e)
        {
            lista[1].BringToFront();
        }
    }
}
