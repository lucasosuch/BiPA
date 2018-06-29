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
        private Dictionary<string, string[]> paramentry;

        public Porownanie(Dictionary<string, string[]> paramentry)
        {
            InitializeComponent();
            this.paramentry = paramentry;

            Series[] seria1 = new Series[paramentry.Count],
                     seria2 = new Series[paramentry.Count];

            int i = 0;
            string plikDanych = "";
            foreach (KeyValuePair<string, string[]> linia in paramentry)
            {
                if(i == 0)
                {
                    plikDanych = linia.Value[3];
                } else
                {
                    if(plikDanych != linia.Value[3])
                    {
                        throw new Exception();
                    }
                }

                seria1[i] = new Series();
                seria1[i].Name = linia.Value[2];

                seria2[i] = new Series();
                seria2[i].Name = linia.Value[2];

                seria1[i].Points.Add(new DataPoint(1, linia.Value[0]));
                seria2[i].Points.Add(new DataPoint(1, linia.Value[1]));

                i++;
            }
            
            for(int j = 0; j < paramentry.Count; j++)
            {
                wykresPorownanCzas.Series.Add(seria1[j]);
                wykresPorownanWynik.Series.Add(seria2[j]);
            }
        }
    }
}
