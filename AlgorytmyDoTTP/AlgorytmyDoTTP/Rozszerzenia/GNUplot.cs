using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace AlgorytmyDoTTP.Rozszerzenia
{
    class GNUPlot
    {
        private readonly string sciezkaGNUPlot = @"C:\Program Files\gnuplot\bin\gnuplot.exe";
        Process procesGnuplot = new Process();

        public GNUPlot()
        {
            procesGnuplot.StartInfo.FileName = sciezkaGNUPlot;
            procesGnuplot.StartInfo.UseShellExecute = false;
            procesGnuplot.StartInfo.RedirectStandardInput = true;
            procesGnuplot.StartInfo.RedirectStandardOutput = true;
            procesGnuplot.Start();
        }

        public void RysujWykresBadania(double[][] wartosci, int szerokosc, int wysokosc, string tytul, string nazwaPliku)
        {
            StreamWriter SW = procesGnuplot.StandardInput;
            StreamReader SR = procesGnuplot.StandardOutput;

            string[] tablicaWartosci = new string[wartosci.Length];
            string[] nazwyPol = new string[wartosci.Length];

            SW.WriteLine("set grid");
            SW.WriteLine("set title '"+ tytul + "'");
            SW.WriteLine("set terminal pngcairo size "+ szerokosc + ", "+ wysokosc);

            for (short i = 0; i < wartosci.Length; i++)
            {
                tablicaWartosci[i] += " ";
                for (short j = 0; j < wartosci[i].Length; j++)
                {
                    tablicaWartosci[i] += wartosci[i][j].ToString().Replace(",", ".") + ",";
                }

                SW.WriteLine("array iteracja"+ (i + 1) + "[" + wartosci[i].Length + "] = [" + tablicaWartosci[i] + "]");
                nazwyPol[i] = "iteracja" + (i + 1) + " w linespoints";
            }

            SW.WriteLine("plot " + string.Join(", ", nazwyPol));
            SW.WriteLine("exit");

            Image png = Image.FromStream(SR.BaseStream);
            png.Save(@".\Wykresy\"+ nazwaPliku + ".png");
        }

        public void RysujWykresPorownania(double[][] wartosci, string[] nazwyBadan, int szerokosc, int wysokosc, string tytul, string nazwaPliku)
        {
            StreamWriter SW = procesGnuplot.StandardInput;
            StreamReader SR = procesGnuplot.StandardOutput;

            string[] tablicaWartosci = new string[wartosci.Length];
            string[] nazwyPol = new string[wartosci.Length];

            SW.WriteLine("set grid");
            SW.WriteLine("set title '" + tytul + "'");
            SW.WriteLine("set terminal pngcairo size " + szerokosc + ", " + wysokosc);

            System.Console.WriteLine(string.Join(", ", nazwyBadan));

            for (short i = 0; i < wartosci.Length; i++)
            {
                tablicaWartosci[i] += " ";
                for (short j = 0; j < wartosci[i].Length; j++)
                {
                    tablicaWartosci[i] += wartosci[i][j].ToString().Replace(",", ".") + ",";
                }

                System.Console.WriteLine("array " + nazwyBadan[i] + "[" + wartosci[i].Length + "] = [" + tablicaWartosci[i] + "]");
                SW.WriteLine("array "+ nazwyBadan[i] + "[" + wartosci[i].Length + "] = [" + tablicaWartosci[i] + "]");
                nazwyPol[i] = nazwyBadan[i] + " w linespoints";
            }

            System.Console.WriteLine(string.Join(", ", nazwyPol));
            SW.WriteLine("plot " + string.Join(", ", nazwyPol));
            SW.WriteLine("exit");

            System.Console.WriteLine("Koniec!!!");
            Image png = Image.FromStream(SR.BaseStream);
            png.Save(@".\Wykresy\" + nazwaPliku + ".png");
        }

        public void ZakonczProcesGNUPlot()
        {
            procesGnuplot.Close();
        }
    }
}
