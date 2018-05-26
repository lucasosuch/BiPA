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
    public partial class Porownanie : Form
    {
        private Dictionary<string, string[]> paramentry;

        public Porownanie(Dictionary<string, string[]> paramentry)
        {
            InitializeComponent();
            this.paramentry = paramentry;
        }
    }
}
