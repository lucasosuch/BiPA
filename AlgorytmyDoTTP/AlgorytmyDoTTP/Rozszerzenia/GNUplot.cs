using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace AlgorytmyDoTTP.Rozszerzenia
{
    class GNUPlot
    {
        private readonly short liczbaIteracji;
        private readonly short czasDzialaniaAlgorytmu;
        private readonly string sciezkaGNUPlot = @"C:\Program Files\gnuplot\bin\gnuplot.exe";
        Process procesGnuplot = new Process();

        public GNUPlot(short liczbaIteracji, short czasDzialaniaAlgorytmu)
        {
            this.liczbaIteracji = liczbaIteracji;
            this.czasDzialaniaAlgorytmu = czasDzialaniaAlgorytmu;

            procesGnuplot.StartInfo.FileName = sciezkaGNUPlot;
            procesGnuplot.StartInfo.UseShellExecute = false;
            procesGnuplot.StartInfo.RedirectStandardInput = true;
            procesGnuplot.StartInfo.RedirectStandardOutput = true;
            procesGnuplot.Start();
        }

        public void RysujWykres(double[][] wartosci, int szerokosc, int wysokosc, string tytul)
        {
            StreamWriter SW = procesGnuplot.StandardInput;
            StreamReader SR = procesGnuplot.StandardOutput;

            string[] tablicaWartosci = new string[liczbaIteracji];
            string[] nazwyPol = new string[liczbaIteracji];

            SW.WriteLine("set grid");
            SW.WriteLine("set title '"+ tytul + "'");
            SW.WriteLine("set terminal pngcairo size "+ szerokosc + ", "+ wysokosc);

            for (short i = 0; i < liczbaIteracji; i++)
            {
                tablicaWartosci[i] += " ";
                for (short j = 0; j < czasDzialaniaAlgorytmu; j++)
                {
                    tablicaWartosci[i] += wartosci[i][j].ToString().Replace(",", ".") + ",";
                }

                SW.WriteLine("array iteracja"+ (i + 1) + "[" + czasDzialaniaAlgorytmu + "] = [" + tablicaWartosci[i] + "]");
                nazwyPol[i] = "iteracja" + (i + 1) + " w linespoints";
            }

            SW.WriteLine("plot " + string.Join(", ", nazwyPol));
            SW.WriteLine("exit");

            Image png = Image.FromStream(SR.BaseStream);
            png.Save(@".\"+ tytul + ".png");
        }

        public void ZakonczProcesGNUPlot()
        {
            procesGnuplot.Close();
        }
    }
}
