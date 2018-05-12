using AlgorytmyDoTTP.Struktura;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorytmyDoTTP.Widoki
{
    public partial class Badanie : Form
    {
        private Dictionary<string, string> parametry;

        public Badanie(Dictionary<string, string> parametry)
        {
            InitializeComponent();
            this.parametry = parametry;
        }

        private void Badanie_Load(object sender, EventArgs e)
        {
            wynikiBadania.Text = (new Config()).ZbudujAlgorytm(parametry).Start();
        }
    }
}
