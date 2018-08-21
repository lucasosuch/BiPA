using AlgorytmyDoTTP.Widoki.Narzedzia;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AlgorytmyDoTTP.Widoki
{
    /// <summary>
    /// Klasa widoku porównywania
    /// </summary>
    public partial class Porownanie : Form
    {
        private FormatkaPorownania formatka;
        private Dictionary<string, string[]> paramentry;

        public Porownanie(Dictionary<string, string[]> paramentry)
        {
            InitializeComponent();
            this.paramentry = paramentry;
            formatka = new FormatkaPorownania();
            ZwrocRaport();
        }

        private void ZwrocRaport()
        {
            Series[] seria1 = formatka.ZwrocDaneDlaWykresow(paramentry, 0, "desc"),
                     seria2 = formatka.ZwrocDaneDlaWykresow(paramentry, 1, "asc");

            for (int j = 0; j < paramentry.Count; j++)
            {
                wykresPorownanCzas.Series.Add(seria1[j]);
                wykresPorownanWynik.Series.Add(seria2[j]);
            }

            tekstPorownania.Text = formatka.ZwrocDaneTekstowe(paramentry);
        }
    }
}
