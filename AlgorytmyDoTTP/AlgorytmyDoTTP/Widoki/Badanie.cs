using AlgorytmyDoTTP.Widoki.Narzedzia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AlgorytmyDoTTP.Widoki
{
    public partial class Badanie : Form
    {
        private FormatkaBadania badanie;

        public Badanie(Dictionary<string, string> parametry)
        {
            InitializeComponent();
            badanie = new FormatkaBadania(parametry);
        }
        
        private void Badanie_Load(object sender, EventArgs e)
        {
            wynikiBadania.Text = badanie.UruchomBadanie();
        }

        private void pobierzCSV_Click(object sender, EventArgs e)
        {
            try
            {
                string pulpit = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string sciezka = Path.Combine(pulpit, badanie.ZwrocNazwePliku("csv"));

                File.WriteAllText(sciezka, badanie.ZwrocDaneDoCSV());
            } catch(IOException exc)
            {
                Console.WriteLine(exc);
            }
        }

        private void zapiszBadanie_Click(object sender, EventArgs e)
        {
            badanie.ZapiszBadanie();
        }
    }
}
