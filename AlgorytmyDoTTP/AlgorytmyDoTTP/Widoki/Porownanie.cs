using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AlgorytmyDoTTP.Widoki
{
    public partial class Porownanie : Form
    {
        private Dictionary<string, string[]> paramentry;

        public Porownanie(Dictionary<string, string[]> paramentry)
        {
            InitializeComponent();
            this.paramentry = paramentry;

            Series[] serie = new Series[paramentry.Count];
            DataPoint[][] punkty = new DataPoint[paramentry.Count][];

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

                serie[i] = new Series();
                serie[i].Name = linia.Value[2];
                serie[i].Points.Add(new DataPoint(1, linia.Value[0]));
                serie[i].Points.Add(new DataPoint(2, linia.Value[1]));

                i++;
            }
            
            for(int j = 0; j < paramentry.Count; j++)
            {
                wykresPorownan.Series.Add(serie[j]);
            }
        }
    }
}
